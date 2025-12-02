using FluentValidation;
using static Banking.API.DTO.Requests;

namespace Banking.API.Validators
{
    public class CriarContaValidator : AbstractValidator<CriarContaRequest>
    {
        public CriarContaValidator() 
        {
            RuleFor(x => x.NomeTitular)
                .NotEmpty().WithMessage("O Nome do titular é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do titular deve ter no máximo 100 caracteres");

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter extamente 11 dígitos nnuméricos");

            RuleFor(x => x.Tipo)
                .IsInEnum().WithMessage("O tipo de conta é inválido");
        } 
    }
}
