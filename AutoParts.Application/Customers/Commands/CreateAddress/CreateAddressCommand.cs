using MediatR;

namespace AutoParts.Application.Customers.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; } = Guid.Empty;
        public string AddressName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public CreateAddressCommand(Guid customerId, string addressName, string street, string number, string complement, string neighborhood, string city, string state, string zipCode)
        {
            CustomerId = customerId;
            AddressName = addressName;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
