public class CommunicationPreference
{
    public int CommunicationPreferenceId { get; set; }

    // FK -> Customer (must be UNIQUE for true 1-1)
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? PreferredChannel { get; set; } // Email/SMS/Call
    public bool IsActive { get; set; }
}
