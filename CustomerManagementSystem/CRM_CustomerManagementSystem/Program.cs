using System;

class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext();

        // Depend on interfaces (DIP)
        ICustomerSeeder seeder = new CustomerSeeder(db);
        ICustomerReportService reporter = new CustomerReportService(db);

        // 1. Seed data only if database is empty
        seeder.SeedIfEmpty();

        // 2. Show dashboard report
        reporter.ShowDashboard();

        Console.WriteLine("\nPress any key to exit...");
        
    }
}