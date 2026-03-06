namespace CustomerManagement.Core.Application.DTOs
{
    public class CreateCustomerDto
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }
        public int SegmentId { get; set; }
        public decimal AccountValue { get; set; }
    }
}