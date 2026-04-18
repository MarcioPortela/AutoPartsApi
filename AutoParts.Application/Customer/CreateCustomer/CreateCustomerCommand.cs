using MediatR;

namespace AutoParts.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
    }
}