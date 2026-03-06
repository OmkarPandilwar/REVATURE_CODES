namespace CustomerManagement.Core.Domain.Entities
{
    public class CommunicationPreference
    {
        public int CommunicationPreferenceId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string? PreferredChannel { get; set; } // Email / SMS / Call
        public bool IsActive { get; set; }
    }
}