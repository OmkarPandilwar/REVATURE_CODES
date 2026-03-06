using MyApi.Models;

namespace MyApi.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
}