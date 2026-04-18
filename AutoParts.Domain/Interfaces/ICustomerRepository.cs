using AutoParts.Domain.Entities;

namespace AutoParts.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken);
        Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken);
    }
}
