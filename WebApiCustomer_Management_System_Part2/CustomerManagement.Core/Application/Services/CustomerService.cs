using CustomerManagement.Core.Application.DTOs;
using CustomerManagement.Core.Application.Interfaces;

namespace CustomerManagement.Core.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public Task<List<CustomerSummaryDto>> GetCustomerDashboardAsync() =>
            _repo.GetCustomerSummariesAsync();

        public Task<CustomerDetailDto?> GetCustomerDetailAsync(int id) =>
            _repo.GetCustomerDetailAsync(id);

        public Task<List<InteractionDto>> GetCustomerInteractionsAsync(int id) =>
            _repo.GetCustomerInteractionsAsync(id);

        public Task<int> CreateCustomerAsync(CreateCustomerDto dto) =>
            _repo.CreateCustomerAsync(dto);

        public Task<bool> UpdateCustomerAsync(int id, CreateCustomerDto dto) =>
            _repo.UpdateCustomerAsync(id, dto);

        public Task<bool> DeleteCustomerAsync(int id) =>
            _repo.DeleteCustomerAsync(id);
    }
}