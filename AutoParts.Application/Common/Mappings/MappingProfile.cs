using AutoMapper;
using AutoParts.Application.Customers.Queries.GetAllCustomers;
using AutoParts.Domain.Entities;

namespace AutoParts.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
