using System.Collections.Generic;

namespace LinqEfDemo;

public class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    // 1 Customer -> Many Orders
    public List<Order> Orders { get; set; } = new();
}
