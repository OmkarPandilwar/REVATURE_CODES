using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyApp.Api.Services
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // avoid nulls
        public string Email { get; set; } = string.Empty; // avoid nulls
    }

    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO?> GetCustomerByIdAsync(int id);
        Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto);
        Task<bool> UpdateCustomerAsync(int id, CustomerDTO dto);
        Task<bool> DeleteCustomerAsync(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;

        // simple in-memory store
        private static readonly List<CustomerDTO> _customers = new()
        {
            new CustomerDTO { Id = 1, Name = "Acme Corp",     Email = "contact@acme.com" },
            new CustomerDTO { Id = 2, Name = "TechStart Inc", Email = "info@techstart.com" }
        };

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            _logger.LogInformation("Fetching all customers");
            return Task.FromResult(_customers.ToList());
        }

        public Task<CustomerDTO?> GetCustomerByIdAsync(int id)
        {
            _logger.LogInformation("Fetching customer {CustomerId}", id);
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }

        public Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto)
        {
            _logger.LogInformation("Creating customer {CustomerName}", dto.Name);

            // simple id generation
            if (dto.Id == 0)
            {
                var nextId = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
                dto.Id = nextId;
            }

            _customers.Add(dto);
            return Task.FromResult(dto);
        }

        public Task<bool> UpdateCustomerAsync(int id, CustomerDTO dto)
        {
            _logger.LogInformation("Updating customer {CustomerId}", id);

            var existing = _customers.FirstOrDefault(c => c.Id == id);
            if (existing == null)
                return Task.FromResult(false);

            existing.Name  = dto.Name;
            existing.Email = dto.Email;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            _logger.LogInformation("Deleting customer {CustomerId}", id);

            var existing = _customers.FirstOrDefault(c => c.Id == id);
            if (existing == null)
                return Task.FromResult(false);

            _customers.Remove(existing);
            return Task.FromResult(true);
        }
    }
}