using System.Collections.Generic;

namespace CustomerManagement.Core.Domain.Entities
{
    public class Segment
    {
        public int SegmentId { get; set; }
        public string? SegmentName { get; set; }
        public string? Description { get; set; }

        public List<Customer> Customers { get; set; } = new();
    }
}