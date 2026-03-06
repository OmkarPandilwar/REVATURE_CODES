using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LinqEfDemo;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();

        // Ensure DB + tables exist
        db.Database.Migrate();

        // Seed demo data once
        SeedOnce(db);

        Console.WriteLine("\n==============================");
        Console.WriteLine("         INSERT DEMO");
        Console.WriteLine("==============================");
        InsertDemo(db);

        Console.WriteLine("\n==============================");
        Console.WriteLine("          READ DEMO");
        Console.WriteLine("==============================");
        ReadDemo(db);

        Console.WriteLine("\n==============================");
        Console.WriteLine("         UPDATE DEMO");
        Console.WriteLine("==============================");
        UpdateDemo(db);

        Console.WriteLine("\n==============================");
        Console.WriteLine("         DELETE DEMO");
        Console.WriteLine("==============================");
        DeleteDemo(db);

        Console.WriteLine("\n==============================");
        Console.WriteLine("     FINAL READ (AFTER CRUD)");
        Console.WriteLine("==============================");
        ReadDemo(db);
    }

    // -------------------- SEED --------------------
    static void SeedOnce(AppDbContext db)
    {
        if (db.Customers.Any())
        {
            Console.WriteLine("Seed already present. Skipping...");
            return;
        }

        Console.WriteLine("Seeding demo data...");

        using var tx = db.Database.BeginTransaction();

        var c1 = new Customer { Name = "Apex Retail", Email = "apex@demo.com" };
        var c2 = new Customer { Name = "Nova Tech", Email = "nova@demo.com" };

        db.Customers.AddRange(c1, c2);
        db.SaveChanges();

        db.Orders.AddRange(
            new Order { CustomerId = c1.CustomerId, TotalAmount = 250, Status = "Paid" },
            new Order { CustomerId = c1.CustomerId, TotalAmount = 1200, Status = "Paid" },
            new Order { CustomerId = c2.CustomerId, TotalAmount = 800, Status = "Pending" }
        );

        db.SaveChanges();
        tx.Commit();
    }

    // -------------------- INSERT --------------------
    static void InsertDemo(AppDbContext db)
    {
        // Insert a new customer only if not exists
        var email = "bluemart@demo.com";

        var existing = db.Customers.FirstOrDefault(c => c.Email == email);
        if (existing != null)
        {
            Console.WriteLine("Customer already exists, skipping insert.");
            return;
        }

        var newCustomer = new Customer
        {
            Name = "BlueMart",
            Email = email
        };

        db.Customers.Add(newCustomer);
        db.SaveChanges(); // newCustomer.CustomerId generated here

        // Insert orders for this new customer
        db.Orders.AddRange(
            new Order { CustomerId = newCustomer.CustomerId, TotalAmount = 999, Status = "Paid" },
            new Order { CustomerId = newCustomer.CustomerId, TotalAmount = 150, Status = "Pending" }
        );

        db.SaveChanges();

        Console.WriteLine($"Inserted Customer: {newCustomer.CustomerId} {newCustomer.Name}");
    }

    // -------------------- READ (LINQ PRACTICE) --------------------
    static void ReadDemo(AppDbContext db)
    {
        // 1) Customers + order count
        var customerOrderCounts = db.Customers
            .Select(c => new
            {
                c.CustomerId,
                c.Name,
                OrderCount = c.Orders.Count
            })
            .ToList();

        Console.WriteLine("Customers + OrderCount:");
        foreach (var x in customerOrderCounts)
            Console.WriteLine($"{x.CustomerId} {x.Name} -> {x.OrderCount}");

        // 2) Orders > 500 with customer name
        var bigOrders = db.Orders
            .Where(o => o.TotalAmount > 500)
            .Select(o => new
            {
                o.OrderId,
                o.TotalAmount,
                o.Status,
                CustomerName = o.Customer.Name
            })
            .ToList();

        Console.WriteLine("\nOrders > 500:");
        foreach (var x in bigOrders)
            Console.WriteLine($"Order {x.OrderId} Amount={x.TotalAmount} Status={x.Status} Customer={x.CustomerName}");

        // 3) Latest order per customer
        var latestOrders = db.Customers
            .Select(c => new
            {
                c.Name,
                LatestOrder = c.Orders
                    .OrderByDescending(o => o.OrderDate)
                    .Select(o => new { o.OrderId, o.TotalAmount, o.OrderDate })
                    .FirstOrDefault()
            })
            .ToList();

        Console.WriteLine("\nLatest order per customer:");
        foreach (var x in latestOrders)
        {
            if (x.LatestOrder == null) Console.WriteLine($"{x.Name} -> No orders");
            else Console.WriteLine($"{x.Name} -> Order {x.LatestOrder.OrderId} {x.LatestOrder.TotalAmount} on {x.LatestOrder.OrderDate:d}");
        }
    }

    // -------------------- UPDATE --------------------
    static void UpdateDemo(AppDbContext db)
    {
        // Update: change Nova Tech name + update one order status
        var customer = db.Customers.FirstOrDefault(c => c.Email == "nova@demo.com");
        if (customer == null)
        {
            Console.WriteLine("Nova customer not found.");
            return;
        }

        customer.Name = "Nova Tech Pvt Ltd";

        // Update the first Pending order of this customer -> Paid
        var pendingOrder = db.Orders
            .Where(o => o.CustomerId == customer.CustomerId && o.Status == "Pending")
            .OrderBy(o => o.OrderId)
            .FirstOrDefault();

        if (pendingOrder != null)
            pendingOrder.Status = "Paid";

        db.SaveChanges();
        Console.WriteLine("Updated Nova customer + 1 order status (if found).");
    }

    // -------------------- DELETE --------------------
    static void DeleteDemo(AppDbContext db)
    {
        // Delete: remove an order with small amount (< 200) from BlueMart (if exists)
        var blueMart = db.Customers.FirstOrDefault(c => c.Email == "bluemart@demo.com");
        if (blueMart == null)
        {
            Console.WriteLine("BlueMart not found, nothing to delete.");
            return;
        }

        var smallOrder = db.Orders
            .Where(o => o.CustomerId == blueMart.CustomerId && o.TotalAmount < 200)
            .OrderBy(o => o.OrderId)
            .FirstOrDefault();

        if (smallOrder == null)
        {
            Console.WriteLine("No small order found to delete.");
            return;
        }

        db.Orders.Remove(smallOrder);
        db.SaveChanges();

        Console.WriteLine($"Deleted OrderId={smallOrder.OrderId} of BlueMart (Amount < 200).");
    }
}
