namespace Banking.API.Models
{
    public class Conta
    {
        public string NumeroConta { get; set; } = string.Empty;
        public string NomeTitular { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public decimal Saldo { get; set; } 
        public DateTime DataAbertura { get; set; } 
        public TipoConta TipoConta { get; set; }
        public bool Ativa { get; set; } = true;
    }

    public enum TipoConta 
    {
        Corrente = 1,
        Poupanca = 2,
        Empresarial = 3
    }    
}
