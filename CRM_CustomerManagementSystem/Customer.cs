using System;
using System.Collections.Generic;

public class Customer
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Type { get; set; }
    public string? Classification { get; set; }

    // FK -> Segment (many customers belong to 1 segment)
    public int SegmentId { get; set; }
    public Segment Segment { get; set; } = null!;

    public decimal AccountValue { get; set; }
  public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    // Customer -> many
    public List<ContactPerson> ContactPersons { get; set; } = new();
    public List<CustomerAddress> Addresses { get; set; } = new();
    public List<CustomerInteraction> Interactions { get; set; } = new();
    public List<CustomerOwnershipHistory> OwnershipHistories { get; set; } = new();
    public List<AuditLog> AuditLogs { get; set; } = new();
    public List<CustomerLifecycle> Lifecycles { get; set; } = new();

    // Customer -> 1 (optional)
    public CommunicationPreference? CommunicationPreference { get; set; }
}
