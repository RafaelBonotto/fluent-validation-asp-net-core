using Banking.API.Models;

namespace Banking.API.DTO
{
    public class Requests
    {
         public record CriarCOntaRequest(string NomeTitular, string CPF, TipoConta Tipo);

        public record DepositoRequest(string NumeroConta, decimal Valor)
        {
            // Construtor para permitir with expression
            public DepositoRequest() : this("", 0) { }
        }

        public record SaqueReques(string NumeroConta, decimal Valor)
        {
            public SaqueReques() : this("", 0) { }
        }
        
        public record TransferenciaReques(
            string ContaOrigem,
            string ContaDestino,
            decimal Valor,
            string? Descricao = null
        );
    }
}
