using System;

namespace CustomerManagement.Core.Domain.Entities
{
    public class CustomerLifecycle
    {
        public int CustomerLifecycleId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string? Status { get; set; }    // Lead, Active, At-Risk, etc.
        public DateTime UpdatedDate { get; set; }
    }
}