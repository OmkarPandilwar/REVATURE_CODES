namespace CustomerManagement.Core.Application.DTOs
{
    public class CustomerSummaryDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SegmentName { get; set; }
        public string Classification { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal AccountValue { get; set; }
        public decimal LifetimeValue { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactEmail { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime? CurrentStatusUpdatedDate { get; set; }
        public string LastInteractionType { get; set; }
        public string LastInteractionSubject { get; set; }
        public DateTime? LastInteractionDate { get; set; }
    }
}