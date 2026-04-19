using MediatR;

namespace AutoParts.Application.Customers.Queries.GetAddressesByCustomerId
{
    public class GetAddressesByCustomerIdQuery : IRequest<List<AddressResponse>>
    {
        public Guid CustomerId { get; set; }

        public GetAddressesByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
