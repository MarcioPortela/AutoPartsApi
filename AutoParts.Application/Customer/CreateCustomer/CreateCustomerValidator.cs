using FluentValidation;

namespace AutoParts.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(v => v.FullName)
                .NotEmpty().WithMessage("O nome completo é obrigatório.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O formato do e-mail é inválido.");

            RuleFor(v => v.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos numéricos.");

            RuleFor(v => v.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório.");

            RuleFor(v => v.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.");
        }
    }
}