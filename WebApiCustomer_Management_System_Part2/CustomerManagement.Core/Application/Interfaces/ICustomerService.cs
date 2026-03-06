using CustomerManagement.Core.Application.DTOs;

namespace CustomerManagement.Core.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerSummaryDto>> GetCustomerDashboardAsync();
        Task<CustomerDetailDto?> GetCustomerDetailAsync(int id);
        Task<List<InteractionDto>> GetCustomerInteractionsAsync(int id);
        Task<int> CreateCustomerAsync(CreateCustomerDto dto);
        Task<bool> UpdateCustomerAsync(int id, CreateCustomerDto dto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}