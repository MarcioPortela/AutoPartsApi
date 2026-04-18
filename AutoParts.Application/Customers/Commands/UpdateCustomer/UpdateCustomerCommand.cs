using MediatR;
using System;

namespace AutoParts.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public UpdateCustomerCommand(Guid id, string email, string phone)
        {
            Id = id;
            Email = email;
            Phone = phone;
        }
    }
}
