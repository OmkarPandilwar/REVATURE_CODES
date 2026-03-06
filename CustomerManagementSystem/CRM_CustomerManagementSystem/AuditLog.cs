using System;

public class AuditLog
{
    public int AuditLogId { get; set; }

    // FK -> Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? EntityName { get; set; }  // e.g. "Customer"
    public int EntityId { get; set; }        // e.g. CustomerId
    public string? ActionType { get; set; }  // Insert/Update/Delete
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime ModifiedDate { get; set; }
}
