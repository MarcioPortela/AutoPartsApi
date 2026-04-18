namespace AutoParts.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; } = Guid.Empty;
        public string AddressName { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Complement { get; private set; } = string.Empty;
        public string Neighborhood { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string ZipCode { get; private set; } = string.Empty;

        public Address(Guid customerId, string addressName,string street, string number, string complement, string neighborhood, string city, string state, string zipCode)
        {
            Id = Guid.NewGuid();
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
