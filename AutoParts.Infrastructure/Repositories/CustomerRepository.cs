using AutoParts.Domain.Entities;
using AutoParts.Domain.Interfaces;
using AutoParts.Infrastructure.Context;

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
    }
}
