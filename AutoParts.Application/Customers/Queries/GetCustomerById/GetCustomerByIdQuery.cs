using MediatR;

namespace AutoParts.Application.Customers.Queries.GetCustomerById
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