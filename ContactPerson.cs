public class ContactPerson
{
    public int ContactPersonId { get; set; }

    // FK -> Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Title { get; set; }
    public bool IsPrimary { get; set; }
}
