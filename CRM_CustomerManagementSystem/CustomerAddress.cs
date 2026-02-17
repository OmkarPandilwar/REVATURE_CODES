public class CustomerAddress
{
    public int CustomerAddressId { get; set; }

    // FK -> Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? AddressType { get; set; }  // Billing/Shipping/Office
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}
