using AutoMapper;
using AutoParts.Application.Customers.Queries.GetAddressesByCustomerId;
using AutoParts.Application.Customers.Queries.GetCustomerById;
using AutoParts.Domain.Entities;

namespace AutoParts.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Address, AddressResponse>();
        }
    }
}
