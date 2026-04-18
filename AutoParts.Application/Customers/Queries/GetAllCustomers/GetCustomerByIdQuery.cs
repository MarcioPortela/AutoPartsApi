using MediatR;

namespace AutoParts.Application.Customers.Queries.GetAllCustomers
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse?>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}