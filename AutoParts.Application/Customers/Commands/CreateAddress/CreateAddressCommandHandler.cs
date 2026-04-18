using AutoParts.Domain.Entities;
using AutoParts.Domain.Interfaces;
using MediatR;

namespace AutoParts.Application.Customers.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Guid>
    {
        private readonly IAddressRepository _repository;

        public CreateAddressCommandHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(
                request.CustomerId,
                request.AddressName,
                request.Street,
                request.Number,
                request.Complement,
                request.Neighborhood,
                request.City,
                request.State,
                request.ZipCode);

            await _repository.AddAddressAsync(address, cancellationToken);
            return address.Id;
        }
    }
}
