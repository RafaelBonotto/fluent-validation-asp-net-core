using Banking.API.DTO;
using Banking.API.Models;

namespace Banking.API.Services
{
    public class ContaService : IContaService
    {
        public Task<bool> ContaExisteAsync(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> CriarContaAsync(Requests.CriarContaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> DepositarAsync(Requests.DepositoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> GetContaAsync(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetSaldCPFJaCadastradoAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetSaldoAsync(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTransferenciaDiariaAsync(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> SacarAsync(Requests.SaqueRequest request)
        {
            throw new NotImplementedException();
        }

        public Task TransferirAsync(Requests.TransferenciaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
