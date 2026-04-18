using AutoParts.Domain.Interfaces;
using MediatR;

namespace AutoParts.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetCustomerByIdAsync(request.Id, cancellationToken);

            if (customer == null)
            {
                throw new KeyNotFoundException("Cliente não foi encontrado.");
            }

            customer.Update(request.Email, request.Phone);
            await _repository.UpdateCustomerAsync(customer, cancellationToken);

            return Unit.Value;
        }
    }
}
