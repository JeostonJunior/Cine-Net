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

            bool? doImp = null;

            while (true)
            {
                Console.Write("Deseja Imprimir seu ingresso? [s/n]: ");

                var resp = Console.ReadLine();

                if (resp.ToLower().Equals("s"))
                {
                    Console.Clear();
                    ImprimirTicket(ingresso);
                    break;
                }
                else if (resp.ToLower().Equals("n"))
                {
                    Console.WriteLine("Bom filme!");
                    break;
                }

                if (doImp is null)
                {
                    Console.WriteLine("Opção inválida, digite 's' ou 'n'");
                }
                break;
            }
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

        public void CancelarIngresso(int ingresso_id)
        {
            var ingresso = _unitOfWork.IngressoRepository.GetById(ingresso_id);

            if (ingresso is null) {
                Console.WriteLine("========================================================");
                Console.WriteLine("Ingresso Não Encontrado.");
                Console.WriteLine("========================================================\n");
                return;
            }


            ingresso.Sessao.Lugares += 1;
            _unitOfWork.SessaoRepository.Update(ingresso.Sessao);

            _unitOfWork.IngressoRepository.Delete(ingresso);

            Console.WriteLine("========================================================");
            Console.WriteLine("Ingresso Cancelado com Sucesso!");
            Console.WriteLine("========================================================\n");
        }

        private static void ImprimirTicket(Ingresso ingresso)
        {           
            Console.WriteLine("========================================================");
            Console.WriteLine($"Código: {ingresso.Id}");
            Console.WriteLine($"Valor: R$ {ingresso.Valor.ToString().Replace(".", ",")}");
            Console.WriteLine("=======================Cliente==========================");
            Console.WriteLine($"Nome: {ingresso.Cliente.Nome}");
            Console.WriteLine($"CPF: {ingresso.Cliente.Cpf}");
            Console.WriteLine("=======================Sessão===========================");
            Console.WriteLine($"Sala: {ingresso.Sessao.Sala.Numero}");
            Console.WriteLine($"Horário: {ingresso.Sessao.Horario:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Filme: {ingresso.Sessao.Filme.Titulo}");
            Console.WriteLine($"========================================================\n");            
        }

        public bool ListarIngressos()
        {
            var ingressos = _unitOfWork.IngressoRepository.GetList();

            if (ingressos is null || !ingressos.Any())
            {
                Console.WriteLine("================================");
                Console.WriteLine("Não existem ingressos registrados.");
                Console.WriteLine("================================\n");

                return false;
            }

            foreach (var ingresso in ingressos)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine($"Código: {ingresso.Id}");
                Console.WriteLine($"Valor: R$ {ingresso.Valor.ToString().Replace(".", ",")}");
                Console.WriteLine("=======================Cliente==========================");
                Console.WriteLine($"Nome: {ingresso.Cliente.Nome}");
                Console.WriteLine($"CPF: {ingresso.Cliente.Cpf}");
                Console.WriteLine("=======================Sessão===========================");
                Console.WriteLine($"Sala: {ingresso.Sessao.Sala.Numero}");
                Console.WriteLine($"Horário: {ingresso.Sessao.Horario:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Filme: {ingresso.Sessao.Filme.Titulo}");
                Console.WriteLine($"========================================================\n");
            }
            return true;
        }
    }
}