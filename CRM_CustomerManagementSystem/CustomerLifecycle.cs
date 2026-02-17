using System;

public class CustomerLifecycle
{
    public int CustomerLifecycleId { get; set; }

    // FK -> Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? Status { get; set; }     // Lead, Active, Suspended, Closed
    public DateTime UpdatedDate { get; set; }
}
