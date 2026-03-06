using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class CustomerReportService : ICustomerReportService
{
    private readonly AppDbContext _db;

    public CustomerReportService(AppDbContext db)
    {
        _db = db;
    }

    public void ShowDashboard()
    {
        var customers = _db.Customers
            .Include(c => c.Segment)     // EAGER LOADING: loads related data in single query
            .Include(c => c.ContactPersons)
            .Include(c => c.Addresses)
            .Include(c => c.Interactions)
            .Include(c => c.OwnershipHistories)
            .Include(c => c.Lifecycles)
            .Include(c => c.AuditLogs)
            .Include(c => c.CommunicationPreference)
            .OrderBy(c => c.CustomerName)
            .ToList();

        Console.WriteLine("========== CUSTOMER MANAGEMENT SYSTEM  ==========\n");

        foreach (var c in customers)
        {
            Console.WriteLine($"Customer: {c.CustomerName}");
            Console.WriteLine($"Segment: {c.Segment.SegmentName} | Class: {c.Classification} | Type: {c.Type}");
            Console.WriteLine($"Email: {c.Email} | Phone: {c.Phone}");
            Console.WriteLine($"Account Value: {c.AccountValue:N0}");
            Console.WriteLine($"Preference: {c.CommunicationPreference?.PreferredChannel} (Active: {c.CommunicationPreference?.IsActive})");

            Console.WriteLine($"Contacts: {c.ContactPersons.Count} | Addresses: {c.Addresses.Count} | Interactions: {c.Interactions.Count}");
            Console.WriteLine($"Ownership Records: {c.OwnershipHistories.Count} | Lifecycle Records: {c.Lifecycles.Count} | Audit Logs: {c.AuditLogs.Count}");

            var primary = c.ContactPersons.FirstOrDefault(x => x.IsPrimary);
            if (primary != null)
                Console.WriteLine($"Primary Contact: {primary.Name} ({primary.Title}) - {primary.Email}");

            var latestLifecycle = c.Lifecycles
                .OrderByDescending(x => x.UpdatedDate)
                .FirstOrDefault();
            if (latestLifecycle != null)
                Console.WriteLine($"Current Status: {latestLifecycle.Status} (Updated: {latestLifecycle.UpdatedDate:yyyy-MM-dd})");

            var lastInteraction = c.Interactions
                .OrderByDescending(x => x.InteractionDate)
                .FirstOrDefault();
            if (lastInteraction != null)
                Console.WriteLine($"Last Interaction: {lastInteraction.InteractionType} - {lastInteraction.Subject} ({lastInteraction.InteractionDate:yyyy-MM-dd})");

            Console.WriteLine(new string('-', 60));
        }
    }
}