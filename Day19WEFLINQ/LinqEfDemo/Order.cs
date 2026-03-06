using System;

namespace LinqEfDemo;

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = "Pending";

    public int CustomerId { get; set; }   // Foreign Key

    public Customer Customer { get; set; } = null!;
}
