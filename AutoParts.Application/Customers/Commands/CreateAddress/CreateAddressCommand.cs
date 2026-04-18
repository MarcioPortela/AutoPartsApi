using MediatR;

namespace AutoParts.Application.Customers.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; private set; }
        public string AddressName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public void SetCustomerId(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
