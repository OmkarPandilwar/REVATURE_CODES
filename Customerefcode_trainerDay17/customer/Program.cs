﻿// using Microsoft.Data.SqlClient;


// string query = "SELECT * FROM Employees WHERE Salary > 50000";
// SqlConnection connection = new SqlConnection("YourConnectionStringHere");
// SqlCommand cmd = new SqlCommand(query, connection);
// SqlDataReader reader = cmd.ExecuteReader();
// List<Employee> employees = new List<Employee>();
// while (reader.Read())
// {
//     employees.Add(new Employee { Name = (string)reader["Name"], Salary = (decimal)reader["Salary"] });
// }


// class Employee
// {
//     public string Name { get; set; }
//     public decimal Salary { get; set; }
// }

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

CrmContext _context = new CrmContext();

var customers = _context.Customers
    .Where(e => e.Age > 20)
    .ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"Id: {customer.Id} Customer: {customer.Name}, Age: {customer.Age}");
}

class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CrmDb;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=True");
        // optionsBuilder.UseMySQL("YourConnectionStringHere");
        // optionsBuilder.UsePostgreql("YourConnectionStringHere");
    }
}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}