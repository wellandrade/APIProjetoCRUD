using CRUD.Negocio.Modelos;
using FluentValidation;
using FluentValidation.Validators;

namespace CRUD.Negocio.Validacoes
{
    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome deve ser informado")
                .Length(3, 200).WithMessage("O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("E-mail invalido")
                .MinimumLength(11).WithMessage("O email deve ter no mínimo {MinLength} caracteres e no maximo {MaxLength}");
        }
    }
}
