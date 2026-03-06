using System;

namespace CustomerManagement.Core.Domain.Entities
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string? EntityName { get; set; }
        public int EntityId { get; set; }
        public string? ActionType { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}