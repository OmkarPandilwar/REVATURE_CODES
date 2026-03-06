using CustomerManagement.Core.Application.DTOs;
using CustomerManagement.Core.Application.Interfaces;
using CustomerManagement.Core.Domain.Entities;
using CustomerManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;

        public CustomerRepository(AppDbContext db)
        {
            _db = db;
        }

        // GET DASHBOARD
        public async Task<List<CustomerSummaryDto>> GetCustomerSummariesAsync()
        {
            return await _db.Customers
                .Include(c => c.Segment)
                .Select(c => new CustomerSummaryDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    SegmentName = c.Segment.SegmentName,
                    Type = c.Type,
                    Classification = c.Classification,
                    Email = c.Email,
                    Phone = c.Phone
                })
                .ToListAsync();
        }

        // GET CUSTOMER DETAILS
        public async Task<CustomerDetailDto?> GetCustomerDetailAsync(int id)
        {
            return await _db.Customers
                .Include(c => c.Segment)
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerDetailDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Email = c.Email,
                    Phone = c.Phone,
                    SegmentName = c.Segment.SegmentName,
                    Type = c.Type,
                    Classification = c.Classification
                })
                .FirstOrDefaultAsync();
        }

        // GET INTERACTIONS
        public async Task<List<InteractionDto>> GetCustomerInteractionsAsync(int id)
        {
            return await _db.CustomerInteractions
                .Where(i => i.CustomerId == id)
                .Select(i => new InteractionDto
                {
                    InteractionType = i.InteractionType,
                    Subject = i.Subject,
                    Details = i.Details,
                    InteractionDate = i.InteractionDate
                })
                .ToListAsync();
        }

        // CREATE CUSTOMER
        public async Task<int> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                CustomerName = dto.CustomerName,
                Email = dto.Email,
                Phone = dto.Phone,
                Type = dto.Type,
                Classification = dto.Classification,
                SegmentId = dto.SegmentId,
                CreatedDate = DateTime.Now
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer.CustomerId;
        }

        // UPDATE
        public async Task<bool> UpdateCustomerAsync(int id, CreateCustomerDto dto)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null) return false;

            customer.CustomerName = dto.CustomerName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Type = dto.Type;
            customer.Classification = dto.Classification;
            customer.SegmentId = dto.SegmentId;
            customer.ModifiedDate = DateTime.Now;

            await _db.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null) return false;

            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}