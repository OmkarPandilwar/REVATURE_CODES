public interface ICustomerSeeder
{
    /// <summary>
    /// Seed demo data only if there are no customers.
    /// </summary>
    void SeedIfEmpty();
}