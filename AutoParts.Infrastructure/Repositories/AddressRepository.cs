using AutoParts.Domain.Entities;
using AutoParts.Domain.Interfaces;
using AutoParts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoParts.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AutoPartsDbContext _context;

        public AddressRepository(AutoPartsDbContext context)
        {
            _context = context;
        }

        public async Task AddAddressAsync(Address address, CancellationToken cancellationToken)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IQueryable<Address>> GetAddressesByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await _context.Addresses
                .Where(a => a.CustomerId == customerId)
                .ToListAsync(cancellationToken)
                .ContinueWith(t => t.Result.AsQueryable(), cancellationToken);
        }
    }
}
