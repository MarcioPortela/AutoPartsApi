using AutoMapper;
using AutoParts.Domain.Interfaces;
using MediatR;

namespace AutoParts.Application.Customers.Queries.GetAddressesByCustomerId
{
    public class GetAddressesByCustomerIdQueryHandler : IRequestHandler<GetAddressesByCustomerIdQuery, List<AddressResponse>>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public GetAddressesByCustomerIdQueryHandler(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AddressResponse>> Handle(GetAddressesByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _repository.GetAddressesByCustomerIdAsync(request.CustomerId, cancellationToken);

            return _mapper.Map<List<AddressResponse>>(addresses);
        }
    }
}
