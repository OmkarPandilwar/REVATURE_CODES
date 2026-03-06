namespace CustomerManagement.Core.Application.DTOs
{
    public class CustomerDetailDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }
        public decimal AccountValue { get; set; }
        public string SegmentName { get; set; }
        public string CurrentStatus { get; set; }
    }
}