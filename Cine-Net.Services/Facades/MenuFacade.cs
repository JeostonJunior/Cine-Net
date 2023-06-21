using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

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

        public void menuInit()
        {
            this._cineManager.initCinema();
        }

        public void menuPrincipal()
        {
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Cinemas [1]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Salas [2]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Filmes [3]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Sessões [4]");
            Console.WriteLine("Vender um ingresso [5]");
            Console.WriteLine("Cancelar a venda de ingresso [6]");
            Console.WriteLine("Consultar filmes em exibição em um determinado dia[7]");
            Console.WriteLine("Verificar disponibilidade de vagas em uma sessão[8]:");
            Console.WriteLine("Selecione uma opção : ");

        }

        public void menuCRUD(string entity)
        {
            Console.Clear();
            Console.Write("Cadastrar " + entity + "[1]  ");
            Console.Write("Consultar " + entity + "[2]  ");
            Console.Write("Atualizar " + entity + "[3]  ");
            Console.Write("Excluir   " + entity + "[4]  ");

        }

        public void readOptionCinema(int option)
        {

            String nome;
            String endereco;

            Console.Clear();

            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar Cinema");
                Console.WriteLine("Digite o nome do cinema: ");
                nome = Console.ReadLine();
                Console.WriteLine("Digite o endereco do cinema: ");
                endereco = Console.ReadLine();

                Console.Clear();

                _cineManager.CadastrarCinema(nome, endereco);

            }
            else if (option == 2)
            {
                _cineManager.ConsultarCinemas();
            }
            else if (option == 3)
            {
                // To-do : Lógica para atualizar cinema

            }
            else if (option == 4)
            {
                // To-do : Lógica para excluir cinema
            }
            else
            {
                Console.WriteLine("Opção inválida : Tente Novamente");
            }
        }

        public void readOptionFilme(int option)
        {
            Console.Clear();

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
                _cineManager.ConsultarFilmes();

            }
            else if (option == 3)
            {
                Console.WriteLine("Opção 3 selecionada: Atualizar filme");
                // To-do : Lógica para atualizar um filme
            }
            else if (option == 4)
            {
                Console.WriteLine("Opção 4 selecionada: Excluir filme");
                // To-do : Lógica para excluir um filme
            }
            else
            {
                Console.WriteLine("Opção inválida : Tente Novamente");
            }
        }

        public void readOptionSessao(int option)
        {

            Console.Clear();

            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar sessão");
                _cineManager.ConsultarCinemas();

                Console.WriteLine("Digite o numero do cinema que deseja a sessão");
                int idCinema = int.Parse(Console.ReadLine());

                _cineManager.ConsultarSalas(idCinema);

                Console.WriteLine("Digite o código da sala em que você quer cadastrar a sessão");
                int idSala = int.Parse(Console.ReadLine());


                _cineManager.ConsultarFilmes();
                Console.WriteLine("Digite o código do filme que você quer exibir na sessão");
                int idFilme = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a data e hora da sessão (no formato dd/mm/yyyy HH:mm:ss):");
                string input = Console.ReadLine();

                DateTime dateTime;
                if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    // To:do - Fazer a verificação de datas
                    Console.WriteLine("A data e hora inseridas são válidas.");
                    Console.WriteLine("Data e Hora: " + dateTime.ToString());
                }

                _cineManager.CadastrarSessao(idFilme, idSala, dateTime);

            }
            else if (option == 2)
            {
                Console.WriteLine("Opção 2 selecionada: Consultar sessão");
                _cineManager.ConsultarCinemas();

                Console.WriteLine("Digite o numero do cinema que deseja ver as sessões");
                int idCinema = int.Parse(Console.ReadLine());

                _cineManager.ConsultarSessoes(idCinema);
            }
            else if (option == 3)
            {
                Console.WriteLine("Opção 3 selecionada: Atualizar sessão");
                // To-do : Lógica para atualizar uma sessão
            }
            else if (option == 4)
            {
                Console.WriteLine("Opção 4 selecionada: Excluir sessão");
                // To-do : Lógica para excluir uma sessão
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public void readOptionSala(int option)
        {

            Console.Clear();

            if (option == 1)
            {
                Console.WriteLine("Opção 1 selecionada: Cadastrar sala");

                _cineManager.ConsultarCinemas();
                Console.WriteLine("Digite o numero do cinema que deseja cadastrar a sala");
                int idCinema = int.Parse(Console.ReadLine());

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

                _cineManager.CadastrarSala(numero, capacidade, is3D, listaEquipamentos, precoIngresso, idCinema);

            }
            else if (option == 2)
            {
                Console.WriteLine("Opção 2 selecionada: Consultar sala");
                _cineManager.ConsultarCinemas();
                Console.WriteLine("Digite o numero do cinema que deseja consultar as salas");
                int idCinema = int.Parse(Console.ReadLine());
                _cineManager.ConsultarSalas(idCinema);
            }
            else if (option == 3)
            {
                Console.WriteLine("Opção 3 selecionada: Atualizar sala");
                // To-do :Lógica para atualizar uma sala
            }
            else if (option == 4)
            {
                Console.WriteLine("Opção 4 selecionada: Excluir sala");
                // To-do : Lógica para excluir uma sala
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

    }
}
