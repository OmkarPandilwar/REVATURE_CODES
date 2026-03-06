using Microsoft.EntityFrameworkCore;
using CustomerManagement.Core.Domain.Entities;

namespace CustomerManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Segment> Segments => Set<Segment>();
        public DbSet<ContactPerson> ContactPersons => Set<ContactPerson>();
        public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
        public DbSet<CustomerInteraction> CustomerInteractions => Set<CustomerInteraction>();
        public DbSet<CustomerLifecycle> CustomerLifecycles => Set<CustomerLifecycle>();
        public DbSet<CustomerOwnershipHistory> CustomerOwnershipHistories => Set<CustomerOwnershipHistory>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<CommunicationPreference> CommunicationPreferences => Set<CommunicationPreference>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CommunicationPreference 1–1
            modelBuilder.Entity<CommunicationPreference>()
                .HasOne(cp => cp.Customer)
                .WithOne(c => c.CommunicationPreference)
                .HasForeignKey<CommunicationPreference>(cp => cp.CustomerId);

            modelBuilder.Entity<CommunicationPreference>()
                .HasIndex(cp => cp.CustomerId)
                .IsUnique();
        }
    }
}