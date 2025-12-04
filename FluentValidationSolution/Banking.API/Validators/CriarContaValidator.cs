using Banking.API.Services;
using Banking.API.Utils;
using FluentValidation;
using static Banking.API.DTO.Requests;

namespace Banking.API.Validators
{
    public class CriarContaValidator : AbstractValidator<CriarContaRequest>
    {
        private readonly IContaService _contaService;

        public CriarContaValidator(IContaService contaService) 
        {
            _contaService = contaService;

            RuleFor(x => x.NomeTitular)
                .NotEmpty().WithMessage("O Nome do titular é obrigatório.")
                .Length(2, 100).WithMessage("O nome do titular deve ter entre 2 a 100 caracteres")
                .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Nome deve conter apenas letras e espaço");

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Must(ValidadorCPF.Validar).WithMessage("CPF inválido")
                .MustAsync(async (cpf, cancellation) => !await _contaService.CPFJaCadastradoAsync(cpf))
                .WithMessage("CPF já possui conta cadstrada");
                //.Matches(@"^\d{11}$").WithMessage("O CPF deve conter extamente 11 dígitos numéricos");

            RuleFor(x => x.Tipo)
                .IsInEnum().WithMessage("O tipo de conta é inválido")
                .NotEqual(Models.TipoConta.Empresarial).WithMessage("Conta empresarial requer validação adicional");
        } 
    }
}
