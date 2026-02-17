
using System;

public class CustomerInteraction
{
    public int CustomerInteractionId { get; set; }

    // FK -> Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? InteractionType { get; set; }  // Call/Email/Meeting
    public string? Subject { get; set; }
    public string? Details { get; set; }
    public DateTime InteractionDate { get; set; }
}
