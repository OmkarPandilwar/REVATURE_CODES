namespace CustomerManagement.Core.Application.DTOs
{
    public class ContactPersonDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Title { get; set; }
        public bool IsPrimary { get; set; }
    }
}