using System;

namespace CustomerManagement.Core.Domain.Entities
{
    public class CustomerOwnershipHistory
    {
        public int CustomerOwnershipHistoryId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string? OwnerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}