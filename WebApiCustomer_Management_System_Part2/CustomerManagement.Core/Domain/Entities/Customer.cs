using System;
using System.Collections.Generic;

namespace CustomerManagement.Core.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public string? CompanySize { get; set; }
        public string? Classification { get; set; }   // Prospect/Active/VIP
        public string? Type { get; set; }             // Business / Individual

        public int SegmentId { get; set; }
        public Segment Segment { get; set; } = null!;

        public decimal AccountValue { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<ContactPerson> ContactPersons { get; set; } = new();
        public List<CustomerAddress> Addresses { get; set; } = new();
        public List<CustomerInteraction> Interactions { get; set; } = new();
        public List<CustomerLifecycle> Lifecycles { get; set; } = new();
        public List<CustomerOwnershipHistory> OwnershipHistories { get; set; } = new();
        public List<AuditLog> AuditLogs { get; set; } = new();

        public CommunicationPreference? CommunicationPreference { get; set; }
    }
}