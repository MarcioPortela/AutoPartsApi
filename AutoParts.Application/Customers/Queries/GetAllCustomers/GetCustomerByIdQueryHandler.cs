using AutoMapper;
using AutoParts.Domain.Interfaces;
using MediatR;

namespace AutoParts.Application.Customers.Queries.GetAllCustomers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse?>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerResponse?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetCustomerByIdAsync(request.Id, cancellationToken);

            if (customer == null)
            {
                throw new KeyNotFoundException("Cliente não foi encontrado.");
            }

            return _mapper.Map<CustomerResponse>(customer);
        }
    }
}
