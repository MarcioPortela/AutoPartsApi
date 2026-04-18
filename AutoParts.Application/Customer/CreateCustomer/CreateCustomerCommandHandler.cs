using AutoParts.Domain.Entities;
using AutoParts.Domain.Interfaces;
using MediatR;

namespace AutoParts.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(
                request.FullName,
                request.Email,
                request.Phone,
                request.Cpf,
                request.BirthDate
            );

            await _repository.AddCustomerAsync(customer, cancellationToken);

            return customer.Id;
        }
    }
}