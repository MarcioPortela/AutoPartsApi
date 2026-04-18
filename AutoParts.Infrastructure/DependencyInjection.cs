using AutoParts.Domain.Interfaces;
using AutoParts.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AutoParts.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}