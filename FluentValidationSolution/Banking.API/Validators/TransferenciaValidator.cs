using FluentValidation;
using static Banking.API.DTO.Requests;

namespace Banking.API.Validators
{
    public class TransferenciaValidator : AbstractValidator<TransferenciaRequest>
    {
        public TransferenciaValidator() 
        {
            RuleFor(x => x.ContaOrigem)
               .NotEmpty().WithMessage("O número da conta origem é obrigatório.")
               .Matches(@"^\d{8}$").WithMessage("O nnúmero da conta origenm deve conter extamente 8 dígitos nnuméricos");
            
            RuleFor(x => x.ContaDestino)
               .NotEmpty().WithMessage("O número da conta destino é obrigatório.")
               .Matches(@"^\d{8}$").WithMessage("O nnúmero da conta destino deve conter extamente 8 dígitos nnuméricos");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor do depósito deve ser maior que zero.");

            RuleFor(x => x.Descricao)
               .MaximumLength(200).WithMessage("A descrição deve conter no máximo 200 caracteres.")
               .When(x => !string.IsNullOrEmpty(x.Descricao));
        }
    }
}
