using CRUD.Negocio.Modelos;
using FluentValidation;

namespace CRUD.Negocio.Validacoes
{
    public class PedidoValidacao : AbstractValidator<Pedido>
    {
        public PedidoValidacao()
        {
            RuleFor(p => p.Descricao)
               .NotEmpty().WithMessage("A descrição do pedido deve ser informado")
               .Length(3, 100).WithMessage("A descrição do pedido precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage("O valor nao pode ser zero");
        }
    }
}
