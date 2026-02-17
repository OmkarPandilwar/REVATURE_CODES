using System.Collections.Generic;

public class Segment
{
    public int SegmentId { get; set; }
    public string? SegmentName { get; set; }
    public string? Description { get; set; }

    // 1 Segment -> many Customers
    public List<Customer> Customers { get; set; } = new();
}
