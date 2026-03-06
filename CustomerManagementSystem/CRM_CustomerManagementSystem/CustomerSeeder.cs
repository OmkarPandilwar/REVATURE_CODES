using System;
using System.Linq;

public class CustomerSeeder : ICustomerSeeder
{
    private readonly AppDbContext _db;

    public CustomerSeeder(AppDbContext db)
    {
        _db = db;
    }

    public void SeedIfEmpty()
    {
        // Avoid duplicate inserts every time we run
        if (_db.Customers.Any())
        {
            Console.WriteLine("Demo data already exists.\n");
            return;
        }

        Console.WriteLine("Seeding professional demo data...\n");

        // -------------------- Segments --------------------
        var enterprise = new Segment
        {
            SegmentName = "Enterprise",
            Description = "Large customers with high account value"
        };

        var smb = new Segment
        {
            SegmentName = "SMB",
            Description = "Small and medium businesses"
        };

        _db.Segments.AddRange(enterprise, smb);
        _db.SaveChanges();

        // -------------------- Customers --------------------
        var customer1 = new Customer
        {
            CustomerName = "Apex Retail Solutions Pvt Ltd",
            Email = "support@apexretail.com",
            Phone = "+91-22-4000-1000",
            Type = "B2B",
            Classification = "Platinum",
            SegmentId = enterprise.SegmentId,
            AccountValue = 1250000m,
            CreatedDate = DateTime.Now.AddDays(-40),
            ModifiedDate = DateTime.Now.AddDays(-2),
            IsDeleted = false
        };

        var customer2 = new Customer
        {
            CustomerName = "BlueSky Logistics",
            Email = "contact@blueskylogistics.in",
            Phone = "+91-20-4100-2222",
            Type = "B2B",
            Classification = "Gold",
            SegmentId = smb.SegmentId,
            AccountValue = 350000m,
            CreatedDate = DateTime.Now.AddDays(-15),
            ModifiedDate = DateTime.Now.AddDays(-1),
            IsDeleted = false
        };

        _db.Customers.AddRange(customer1, customer2);
        _db.SaveChanges();

        // -------------------- Contact Persons --------------------
        _db.ContactPersons.AddRange(
            new ContactPerson
            {
                CustomerId = customer1.CustomerId,
                Name = "Neha Sharma",
                Email = "neha.sharma@apexretail.com",
                Phone = "+91-98111-22334",
                Title = "Account Manager",
                IsPrimary = true
            },
            new ContactPerson
            {
                CustomerId = customer1.CustomerId,
                Name = "Rohit Mehta",
                Email = "rohit.mehta@apexretail.com",
                Phone = "+91-98220-33445",
                Title = "Finance Lead",
                IsPrimary = false
            },
            new ContactPerson
            {
                CustomerId = customer2.CustomerId,
                Name = "Priya Nair",
                Email = "priya.nair@blueskylogistics.in",
                Phone = "+91-98765-43210",
                Title = "Operations Head",
                IsPrimary = true
            }
        );

        // -------------------- Addresses --------------------
        _db.CustomerAddresses.AddRange(
            new CustomerAddress
            {
                CustomerId = customer1.CustomerId,
                AddressType = "Billing",
                Street = "3rd Floor, Orion Business Park, Andheri East",
                City = "Mumbai",
                State = "Maharashtra",
                PostalCode = "400069",
                Country = "India"
            },
            new CustomerAddress
            {
                CustomerId = customer1.CustomerId,
                AddressType = "Shipping",
                Street = "Warehouse No. 12, MIDC Industrial Area",
                City = "Navi Mumbai",
                State = "Maharashtra",
                PostalCode = "400705",
                Country = "India"
            },
            new CustomerAddress
            {
                CustomerId = customer2.CustomerId,
                AddressType = "Office",
                Street = "Plot 18, Hinjewadi Phase 1",
                City = "Pune",
                State = "Maharashtra",
                PostalCode = "411057",
                Country = "India"
            }
        );

        // -------------------- Interactions --------------------
        _db.CustomerInteractions.AddRange(
            new CustomerInteraction
            {
                CustomerId = customer1.CustomerId,
                InteractionType = "Meeting",
                Subject = "Quarterly Review",
                Details = "Reviewed Q4 KPIs and planned rollout for new POS integration.",
                InteractionDate = DateTime.Now.AddDays(-7)
            },
            new CustomerInteraction
            {
                CustomerId = customer1.CustomerId,
                InteractionType = "Email",
                Subject = "Invoice Clarification",
                Details = "Shared corrected invoice and payment schedule.",
                InteractionDate = DateTime.Now.AddDays(-3)
            },
            new CustomerInteraction
            {
                CustomerId = customer2.CustomerId,
                InteractionType = "Call",
                Subject = "Onboarding Support",
                Details = "Helped setup initial user accounts and permissions.",
                InteractionDate = DateTime.Now.AddDays(-2)
            }
        );

        // -------------------- Ownership History --------------------
        _db.CustomerOwnershipHistories.AddRange(
            new CustomerOwnershipHistory
            {
                CustomerId = customer1.CustomerId,
                OwnerName = "Karan Desai",
                StartDate = DateTime.Now.AddMonths(-6),
                EndDate = DateTime.Now.AddMonths(-2)
            },
            new CustomerOwnershipHistory
            {
                CustomerId = customer1.CustomerId,
                OwnerName = "Neha Sharma",
                StartDate = DateTime.Now.AddMonths(-2),
                EndDate = null
            },
            new CustomerOwnershipHistory
            {
                CustomerId = customer2.CustomerId,
                OwnerName = "Priya Nair",
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = null
            }
        );

        // -------------------- Lifecycle --------------------
        _db.CustomerLifecycles.AddRange(
            new CustomerLifecycle
            {
                CustomerId = customer1.CustomerId,
                Status = "Active",
                UpdatedDate = DateTime.Now.AddDays(-10)
            },
            new CustomerLifecycle
            {
                CustomerId = customer2.CustomerId,
                Status = "Onboarding",
                UpdatedDate = DateTime.Now.AddDays(-5)
            }
        );

        // -------------------- Communication Preference (1-1) --------------------
        _db.CommunicationPreferences.AddRange(
            new CommunicationPreference
            {
                CustomerId = customer1.CustomerId,
                PreferredChannel = "Email",
                IsActive = true
            },
            new CommunicationPreference
            {
                CustomerId = customer2.CustomerId,
                PreferredChannel = "Call",
                IsActive = true
            }
        );

        // -------------------- Audit Logs --------------------
        _db.AuditLogs.AddRange(
            new AuditLog
            {
                CustomerId = customer1.CustomerId,
                EntityName = "Customer",
                EntityId = customer1.CustomerId,
                ActionType = "Insert",
                OldValue = null,
                NewValue = "Customer created with Enterprise segment and Platinum classification.",
                ModifiedDate = DateTime.Now.AddDays(-40)
            },
            new AuditLog
            {
                CustomerId = customer1.CustomerId,
                EntityName = "CustomerInteraction",
                EntityId = 0,
                ActionType = "Insert",
                OldValue = null,
                NewValue = "Interaction added: Quarterly Review meeting.",
                ModifiedDate = DateTime.Now.AddDays(-7)
            },
            new AuditLog
            {
                CustomerId = customer2.CustomerId,
                EntityName = "Customer",
                EntityId = customer2.CustomerId,
                ActionType = "Insert",
                OldValue = null,
                NewValue = "Customer created with SMB segment and Gold classification.",
                ModifiedDate = DateTime.Now.AddDays(-15)
            }
        );

        _db.SaveChanges();

        Console.WriteLine("Demo data inserted successfully.\n");
    }
}