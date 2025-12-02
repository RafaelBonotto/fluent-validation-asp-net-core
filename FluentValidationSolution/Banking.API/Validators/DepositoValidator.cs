using FluentValidation;
using static Banking.API.DTO.Requests;

namespace Banking.API.Validators
{
    public class DepositoValidator : AbstractValidator<DepositoRequest>
    {
        public DepositoValidator() 
        {
            RuleFor(x => x.NumeroConta)
               .NotEmpty().WithMessage("O Número da conta é obrigatório.")
               .Matches(@"^\d{8}$").WithMessage("O Número da conta deve conter extamente 8 dígitos nnuméricos");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor do depósito deve ser maior que zero.");
        }
    }
}
