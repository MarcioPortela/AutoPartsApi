using AutoParts.Domain.Entities;

namespace AutoParts.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken);
    }
}
