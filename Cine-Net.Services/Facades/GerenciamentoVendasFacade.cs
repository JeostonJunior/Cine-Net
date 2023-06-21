using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Services.Facades
{
    public class GerenciamentoVendasFacade
    {
        private readonly IUnitOfWork _unitOfWork;

        public GerenciamentoVendasFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private void CadastrarCliente(Cliente cliente) 
        {
            _unitOfWork.ClienteRepository.Add(cliente);

            Console.WriteLine("========================================================");
            Console.WriteLine("Cliente Cadastrado com Sucesso!");
            Console.WriteLine("========================================================\n");
        }

        private void RegistrarIngresso(Ingresso ingresso) 
        {
            ingresso.Sessao.Lugares -= 1;
            _unitOfWork.SessaoRepository.Update(ingresso.Sessao);
            _unitOfWork.IngressoRepository.Add(ingresso);

            Console.WriteLine("========================================================");
            Console.WriteLine("Ingresso Registrado com Sucesso!");
            Console.WriteLine("========================================================\n");
        }

        public void VenderIngresso(Cliente cliente, Sessao sessao, double valor)
        {
            CadastrarCliente(cliente);
            
            var ingresso = new Ingresso
            {
                Cliente = cliente,
                Sessao = sessao,
                Valor = valor,
            };
            
            RegistrarIngresso(ingresso);
        }

        public void CancelarIngresso()
        {
        }

        public void ImprimirTicket()
        {
        }
    }
}