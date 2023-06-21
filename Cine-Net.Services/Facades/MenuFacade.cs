using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;
using System.Globalization;

namespace Cine_Net.Services.Facades
{
    public class MenuFacade
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly GerenciamentoCinemaFacade _cineManager;
        private readonly GerenciamentoVendasFacade _vendasManager;

        public MenuFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cineManager = new GerenciamentoCinemaFacade(_unitOfWork);
            _vendasManager = new GerenciamentoVendasFacade(_unitOfWork);
        }

        public void MenuInit()
        {
            _cineManager.InitCinema();
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Cinemas -> [1]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Salas -> [2]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Filmes -> [3]");
            Console.WriteLine("Cadastrar, Consultar, Atualizar ou Excluir Sessões -> [4]");
            Console.WriteLine("Vender um ingresso -> [5]");
            Console.WriteLine("Cancelar a venda de ingresso -> [6]");
            Console.WriteLine("Consultar filmes em exibição em um determinado dia -> [7]");
            Console.WriteLine("Verificar disponibilidade de vagas em uma sessão -> [8]");
            Console.WriteLine("=========================================================\n");

            Console.Write("Selecione uma opção: ");
        }

        public static void MenuCRUD(string entity)
        {
            Console.Clear();

            Console.WriteLine("Cadastrar " + entity + " -> [1]");
            Console.WriteLine("Consultar " + entity + " -> [2]");
            Console.WriteLine("Atualizar " + entity + " -> [3]");
            Console.WriteLine("Excluir " + entity + " -> [4]\n");
        }

        public void ReadOptionCinema(int option)
        {
            string nome;
            string endereco;

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar Cinema");
                    Console.Write("Digite o nome do cinema: ");
                    nome = Console.ReadLine();

                    Console.Write("Digite o endereco do cinema: ");
                    endereco = Console.ReadLine();

                    Console.Clear();

                    _cineManager.CadastrarCinema(nome, endereco);
                    break;

                case 2:
                    _cineManager.ConsultarCinemas();
                    break;

                case 3:
                    // Lógica para atualizar cinema
                    break;

                case 4:
                    // Lógica para excluir cinema
                    break;

                default:
                    Console.WriteLine("Opção inválida: Tente Novamente\n");
                    break;
            }
        }

        public void ReadOptionFilme(int option)
        {
            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar Filme");

                    Console.WriteLine("Digite o título do filme: ");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("Digite o diretor do filme: ");
                    string diretor = Console.ReadLine();

                    Console.WriteLine("Digite o ator principal do filme: ");
                    string atorPrincipal = Console.ReadLine();

                    Console.WriteLine("Digite a duração do filme: ");
                    int duracao = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a classificação do filme: ");
                    string classificacao = Console.ReadLine();

                    Console.WriteLine("Digite a categoria do filme: ");
                    string categoria = Console.ReadLine();

                    _cineManager.CadastrarFilme(titulo, diretor, atorPrincipal, duracao, classificacao, categoria);
                    break;

                case 2:
                    Console.WriteLine("Opção 2 selecionada: Consultar filme");
                    // Lógica para consultar um filme
                    _cineManager.ConsultarFilmes();
                    break;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar filme");
                    // Lógica para atualizar um filme
                    break;

                case 4:
                    Console.WriteLine("Opção 4 selecionada: Excluir filme");
                    // Lógica para excluir um filme
                    break;

                default:
                    Console.WriteLine("Opção inválida: Tente novamente");
                    break;
            }
        }

        public void ReadOptionSessao(int option)
        {
            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar sessão");
                    _cineManager.ConsultarCinemas();

                    Console.WriteLine("Digite o número do cinema que deseja a sessão");
                    int idCinema;

                    while(true) {
                        if(int.TryParse(Console.ReadLine(), out idCinema)) {
                            break;
                        } else {
                            Console.WriteLine("Opção inválida, informe novamente!");
                        }
                    }

                    _cineManager.ConsultarSalas(idCinema);

                    Console.WriteLine("Digite o código da sala em que você quer cadastrar a sessão");
                    int idSala = int.Parse(Console.ReadLine());

                    _cineManager.ConsultarFilmes();
                    Console.WriteLine("Digite o código do filme que você quer exibir na sessão");
                    int idFilme = int.Parse(Console.ReadLine());

                    bool dataHoraValida = false;

                    while (!dataHoraValida)
                    {
                        Console.WriteLine("Digite a data e hora da sessão (no formato dd/MM/yyyy HH:mm:ss):");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                        {
                            Console.WriteLine("A data e hora inseridas são válidas.");
                            Console.WriteLine($"Data e Hora: {dateTime}");

                            _cineManager.CadastrarSessao(idFilme, idSala, dateTime);

                            dataHoraValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Data e hora inseridas são inválidas. Tente novamente.");
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Opção 2 selecionada: Consultar sessão");
                    _cineManager.ConsultarCinemas();

                    Console.WriteLine("Digite o número do cinema que deseja ver as sessões");
                    int idCinemaConsultar;

                    while(true) {
                        if(int.TryParse(Console.ReadLine(), out idCinemaConsultar)) {
                            break;
                        } else {
                            Console.WriteLine("Opção inválida, informe novamente!");
                        }
                    }

                    _cineManager.ConsultarSessoes(idCinemaConsultar);
                    break;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar sessão");
                    // Lógica para atualizar uma sessão
                    break;

                case 4:
                    Console.WriteLine("Opção 4 selecionada: Excluir sessão");
                    // Lógica para excluir uma sessão
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        public void ReadOptionSala(int option)
        {
            Console.Clear();

            switch (option)
            {
                case 1:
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

                    var listaEquipamentos = new List<string>(equipamentos);

                    _cineManager.CadastrarSala(numero, capacidade, is3D, listaEquipamentos, precoIngresso, idCinema);
                    break;

                case 2:
                    Console.WriteLine("Opção 2 selecionada: Consultar sala");
                    _cineManager.ConsultarCinemas();

                    Console.WriteLine("Digite o numero do cinema que deseja consultar as salas");
                    int idCinemaConsulta = int.Parse(Console.ReadLine());

                    _cineManager.ConsultarSalas(idCinemaConsulta);
                    break;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar sala");
                    // Lógica para atualizar uma sala
                    break;

                case 4:
                    Console.WriteLine("Opção 4 selecionada: Excluir sala");
                    // Lógica para excluir uma sala
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        private double ReadDouble() {
            double value;

            while(true) {
                if(double.TryParse(Console.ReadLine().Replace(",", "."), out value)) {
                    break;
                } else {
                    Console.WriteLine("Valor inválido, informe novamente!");
                }
            }

            return value;
        }
        public void ReadVendaIngressoInfos() {
            Console.WriteLine("Informe o nome do cliente: ");
            var nome = Console.ReadLine();
            
            Console.WriteLine("Informe o CPF do cliente: ");
            var cpf = Console.ReadLine();
            
            Console.WriteLine("Informe o valor do ingresso: ");
            var valor = ReadDouble();

            bool? isEstudante = null;
            while(true) {
                Console.WriteLine("O cliente é estudante? [s/n]: ");
                var resp = Console.ReadLine();

                if(resp.ToLower().Equals("s")) {
                    isEstudante = true;
                    valor /= 2;
                    Console.WriteLine($"O valor do ingresso foi alterado: R${valor.ToString().Replace(".", ",")}");
                }
                else if (resp.ToLower().Equals("n")) {
                    isEstudante = false;
                }

                if(isEstudante is null) {
                    Console.WriteLine("Opção inválida, digite 's' ou 'n'");
                } else {
                    break;
                }
            }

            var cliente = new Cliente
            {
                Nome = nome,
                Cpf = cpf,
                IsEstudante = (bool)isEstudante,
            };

            ReadOptionSessao(2);
            Sessao sessao;

            while(true) {
                Console.WriteLine("Digite o número da sessão desejada: ");
                int idSessao;

                while(true) {
                    if(int.TryParse(Console.ReadLine(), out idSessao)) {
                        break;
                    } else {
                        Console.WriteLine("Opção inválida, informe novamente!");
                    }
                }

                sessao = _unitOfWork.SessaoRepository.GetById(idSessao);

                if(sessao.Lugares == 0) {
                    Console.WriteLine("A sessão selecionada está cheia, por favor escolha outra!");
                    sessao = null;
                } else {
                    break;
                }
            }

            _vendasManager.VenderIngresso(cliente, sessao, valor);
        }

        public void ReadCancelIngressoInfos() {
            _vendasManager.ListarIngressos();

            Console.WriteLine("Digite o número do ingresso que deseja cancelar: ");

            int ingresso_id;
            while(true) {
                if(int.TryParse(Console.ReadLine(), out ingresso_id)) {
                    break;
                } else {
                    Console.WriteLine("Opção inválida, informe novamente!");
                }
            }

            _vendasManager.CancelarIngresso(ingresso_id);
        }
    }
}