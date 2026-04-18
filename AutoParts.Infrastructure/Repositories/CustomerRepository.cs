using AutoParts.Domain.Entities;
using AutoParts.Domain.Interfaces;
using AutoParts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoParts.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AutoPartsDbContext _context;

        public CustomerRepository(AutoPartsDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}
