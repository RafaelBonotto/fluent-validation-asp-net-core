using Banking.API.DTO;
using Banking.API.Models;
using System.Collections.Concurrent;

namespace Banking.API.Services
{
    public class ContaService : IContaService
    {
        // Estrutura de dados simulando base de dados
        private static readonly ConcurrentDictionary<string, Conta> _contas = new();
        private static readonly ConcurrentDictionary<string, List<decimal>> _transferenciasDiarias = new();
        private static int _contadorConta = 1000; 

        public Task<bool> ContaExisteAsync(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> CriarContaAsync(Requests.CriarContaRequest request)
        {
            var numeroConta = Interlocked.Increment(ref _contadorConta).ToString();

            var conta = new Conta
            {
                NumeroConta = numeroConta,
                NomeTitular = request.NomeTitular,
                CPF = request.CPF,
                Saldo = 0,
                DataAbertura = DateTime.Now,
                TipoConta = request.Tipo,
                Ativa = true
            };

            _contas.TryAdd(numeroConta, conta);
            return Task.FromResult(conta);
        }

        public Task<Conta> DepositarAsync(Requests.DepositoRequest request)
        {
            if(_contas.TryGetValue(request.NumeroConta, out var conta))
            {
                conta.Saldo += request.Valor;
                return Task.FromResult(conta);
            }

            throw new InvalidOperationException("Conta não encontrada");
        }

        public Task<Conta?> GetContaAsync(string numeroConta)
        {
            _contas.TryGetValue(numeroConta, out var conta);
            return Task.FromResult(conta);
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
            if (_contas.TryGetValue(request.NumeroConta, out var conta))
            {
                if (conta.Saldo >= request.Valor)
                {
                    conta.Saldo -= request.Valor;
                    return Task.FromResult(conta);
                }

                throw new InvalidOperationException("Saldo insuficiente");
            }

            throw new InvalidOperationException("Conta não encontrada");
        }

        public Task TransferirAsync(Requests.TransferenciaRequest request)
        {
            if (!_contas.ContainsKey(request.ContaOrigem))
                throw new InvalidOperationException("Conta de origem não encontrada");
            
            if (!_contas.ContainsKey(request.ContaDestino))
                throw new InvalidOperationException("Conta de destino não encontrada");

            var contaOrigem = _contas[request.ContaOrigem];
            var contaDestino = _contas[request.ContaDestino];

            if (contaOrigem.Saldo < request.Valor)
                throw new InvalidOperationException("Saldo insuficiente");

            contaOrigem.Saldo -= request.Valor;
            contaDestino.Saldo += request.Valor;

            //Registra Transferência diária
            var hoje = DateTime.Today.ToString("yyyy-MM-dd");
            var chave = $"{request.ContaOrigem}_{hoje}";

            _transferenciasDiarias.AddOrUpdate(
                chave,
                [request.Valor],
                (key, list) => { list.Add(request.Valor); return list; });

            return Task.CompletedTask;
        }
    }
}
