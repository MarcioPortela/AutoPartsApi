using AutoParts.Domain.Entities;

namespace AutoParts.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Task AddAddressAsync(Address address, CancellationToken cancellationToken);
        Task<IQueryable<Address>> GetAddressesByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
    }
}
