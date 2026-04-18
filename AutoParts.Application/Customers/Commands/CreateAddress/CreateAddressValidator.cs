using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Application.Customers.Commands.CreateAddress
{
    public class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressValidator() 
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("O Id do cliente é obrigatório.");
            RuleFor(x => x.AddressName)
                .NotEmpty().WithMessage("O nome do endereço é obrigatório."); ;
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("A rua é obrigatória."); ;
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O número é obrigatório."); ;
            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("O bairro é obrigatório.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .MaximumLength(2).WithMessage("O estado deve ter no máximo 2 caracteres.");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .MaximumLength(9).WithMessage("O CEP deve ter no máximo 9 caracteres.");
        }
    }
}
