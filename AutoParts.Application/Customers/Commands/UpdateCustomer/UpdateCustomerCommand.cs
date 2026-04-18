using MediatR;
using System;

namespace AutoParts.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; private set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
