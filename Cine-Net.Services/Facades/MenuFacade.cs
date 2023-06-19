using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace Cine_Net.Services.Facades
{

    public class MenuFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private GerenciamentoCinemaFacade _cineManager;
        public MenuFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cineManager = new GerenciamentoCinemaFacade(_unitOfWork);
        }

        public void menuPrincipal()
        {

            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Cinemas [1]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Salas [2]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Filmes [3]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Sessões [4]");
            Console.WriteLine("Vender um ingresso [5]");
            Console.WriteLine("Cancelar a venda de ingresso [6]");
            Console.WriteLine("Verificar disponibilidade de vagas em uma sessão[7]");
            Console.WriteLine("Selecione uma opção : ");
        }

        public void menuCRUD(string entity)
        {
            Console.WriteLine("Cadastrar " + entity + " [1]");
            Console.WriteLine("Consultar " + entity + " [2]");
            Console.WriteLine("Atualizar " + entity + " [3]");
            Console.WriteLine("Excluir   " + entity + " [4]");
        }

        public void readOptionCinema(int option)
        {

            String nome;
            String endereco;

            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar Cinema");
                Console.WriteLine("Digite o nome do cinema: ");
                nome = Console.ReadLine();
                Console.WriteLine("Digite o endereco do cinema: ");
                endereco = Console.ReadLine();
                _cineManager.CadastrarCinema(nome, endereco);

            }
            else if (option == 2)
            {

            }
            else if (option == 3)
            {

            }
            else if (option == 4)
            {

            }
        }

        public void readOptionFilme(int option)
        {

            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar Filme");
                Console.WriteLine("Digite o título do filme: ");
                string titulo = Console.ReadLine();
                Console.WriteLine("Digite o diretor do filme: ");
                string diretor = Console.ReadLine();
                Console.WriteLine("Digite o ator principal do filme: ");
                string atorPrincipal = Console.ReadLine();
                Console.WriteLine("Digite a duração do filme: ");
                int duracao = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a classificação do filme: ");
                string classificacao = Console.ReadLine();
                Console.WriteLine("Digite a categoria do filme: ");
                string categoria = Console.ReadLine();
                _cineManager.CadastrarFilme(titulo, diretor, atorPrincipal, duracao, classificacao, categoria);
            }
            else if (option == 2)
            {
                Console.WriteLine("Opção 2 selecionada: Consultar filme");
                _cineManager.consultarCinemas();
            }
            else if (option == 3)
            {
                Console.WriteLine("Opção 3 selecionada: Atualizar filme");
                // Lógica para atualizar um filme
            }
            else if (option == 4)
            {
                Console.WriteLine("Opção 4 selecionada: Excluir filme");
                Console.WriteLine("Opção 4 selecionada: Excluir filme");

            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public void readOptionSessao(int option)
        {
            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar sessão");
                // Lógica para cadastrar uma sessão
            }
            else if (option == 2)
            {
                Console.WriteLine("Opção 2 selecionada: Consultar sessão");
                // Lógica para consultar uma sessão
            }
            else if (option == 3)
            {
                Console.WriteLine("Opção 3 selecionada: Atualizar sessão");
                // Lógica para atualizar uma sessão
            }
            else if (option == 4)
            {
                Console.WriteLine("Opção 4 selecionada: Excluir sessão");
                // Lógica para excluir uma sessão
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public void readOptionSala(int option)
        {
            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar sala");
                Console.WriteLine("Digite o número da sala: ");
                int numero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a capacidade da sala: ");
                int capacidade = int.Parse(Console.ReadLine());

                Console.WriteLine("A sala é 3D? (S/N): ");
                bool is3D = Console.ReadLine().ToUpper() == "S";

                Console.WriteLine("Digite o preço do ingresso: ");
                double precoIngresso = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite os equipamentos da sala (separados por vírgula): ");

                string[] equipamentos = Console.ReadLine().Split(',');
                List<string> listaEquipamentos = new List<string>(equipamentos);

                Console.WriteLine("Digite o nome do cinema");
                string nomeCinema = Console.ReadLine();

                _cineManager.CadastrarSala(numero, capacidade, is3D, listaEquipamentos, precoIngresso, nomeCinema);

            }
            else if (option == 2)
            {
                Console.WriteLine("Opção 2 selecionada: Consultar sala");
                // Lógica para consultar uma sala
            }
            else if (option == 3)
            {
                Console.WriteLine("Opção 3 selecionada: Atualizar sala");
                // Lógica para atualizar uma sala
            }
            else if (option == 4)
            {
                Console.WriteLine("Opção 4 selecionada: Excluir sala");
                // Lógica para excluir uma sala
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

    }
}
