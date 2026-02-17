using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Segment> Segments => Set<Segment>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<ContactPerson> ContactPersons => Set<ContactPerson>();
    public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
    public DbSet<CustomerInteraction> CustomerInteractions => Set<CustomerInteraction>();
    public DbSet<CommunicationPreference> CommunicationPreferences => Set<CommunicationPreference>();
    public DbSet<CustomerOwnershipHistory> CustomerOwnershipHistories => Set<CustomerOwnershipHistory>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<CustomerLifecycle> CustomerLifecycles => Set<CustomerLifecycle>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            "server=localhost;port=3306;database=CustomerManagementDb;user=root;password=root;",
            new MySqlServerVersion(new Version(8, 0, 36))
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Segment (1) -> Customer (Many)
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Segment)
            .WithMany(s => s.Customers)
            .HasForeignKey(c => c.SegmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Customer (1) -> ContactPerson (Many)
        modelBuilder.Entity<ContactPerson>()
            .HasOne(cp => cp.Customer)
            .WithMany(c => c.ContactPersons)
            .HasForeignKey(cp => cp.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Customer (1) -> CustomerAddress (Many)
        modelBuilder.Entity<CustomerAddress>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Customer (1) -> CustomerInteraction (Many)
        modelBuilder.Entity<CustomerInteraction>()
            .HasOne(i => i.Customer)
            .WithMany(c => c.Interactions)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Customer (1) -> OwnershipHistory (Many)  (keep history safe)
        modelBuilder.Entity<CustomerOwnershipHistory>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.OwnershipHistories)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Customer (1) -> AuditLog (Many) (never auto delete logs)
        modelBuilder.Entity<AuditLog>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.AuditLogs)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Customer (1) -> Lifecycle (Many) (keep lifecycle safe)
        modelBuilder.Entity<CustomerLifecycle>()
            .HasOne(l => l.Customer)
            .WithMany(c => c.Lifecycles)
            .HasForeignKey(l => l.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Customer (1) -> CommunicationPreference (1)
        modelBuilder.Entity<CommunicationPreference>()
            .HasOne(p => p.Customer)
            .WithOne(c => c.CommunicationPreference)
            .HasForeignKey<CommunicationPreference>(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Enforce true 1-1 (CustomerId UNIQUE)
        modelBuilder.Entity<CommunicationPreference>()
            .HasIndex(p => p.CustomerId)
            .IsUnique();

        // // Optional DB default for CreatedDate (MySQL)
        // modelBuilder.Entity<Customer>()
        //     .Property(c => c.CreatedDate)
        //     .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
