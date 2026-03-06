namespace CustomerManagement.Core.Application.DTOs
{
    public class InteractionDto
    {
        public string InteractionType { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime InteractionDate { get; set; }
    }
}