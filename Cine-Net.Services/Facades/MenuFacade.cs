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
            double precoWeek;
            double precoWeekend;
            int idCinema;

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar Cinema");
                    Console.Write("Digite o nome do cinema: ");
                    nome = Console.ReadLine();

                    Console.Write("Digite o endereco do cinema: ");
                    endereco = Console.ReadLine();

                    precoWeek = ReadDouble("Digite um preco padrão para todas as sessões 2D nos dias de semana: ");

                    precoWeekend = ReadDouble("Digite um preco padrão para todas as sessões 2D nos finais de semana: ");
                    Console.Clear();

                    _cineManager.CadastrarCinema(nome, endereco, precoWeek, precoWeekend);
                    break;

                case 2:
                    Console.WriteLine("Opção 2 selecionada: Consultar Cinema");
                    Console.Clear();
                    _cineManager.ConsultarCinemas();
                    break;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar Cinema");
                    _cineManager.ConsultarCinemas();

                    idCinema = ReadInt("Digite o número do cinema que deseja atualizar: ");

                    Console.Write("Digite o novo nome do cinema: ");
                    nome = Console.ReadLine();

                    Console.Write("Digite o novo endereco do cinema: ");
                    endereco = Console.ReadLine();

                    precoWeek = ReadDouble("Digite um novo preco padrão para todas as sessões 2D nos dias de semana: ");

                    precoWeekend = ReadDouble("Digite um novo preco padrão para todas as sessões 2D nos finais de semana: ");
                    Console.Clear();

                    _cineManager.AtualizarCinema(idCinema, nome, endereco, precoWeek, precoWeekend);
                    break;

                case 4:
                    _cineManager.ConsultarCinemas();
                    idCinema = ReadInt("Digite o código do cinema que deseja excluir: ");
                    Console.Clear();
                    _cineManager.ExcluirCinema(idCinema);

                    break;

                default:
                    Console.WriteLine("Opção inválida: Tente Novamente\n");
                    break;
            }
        }

        public void ReadOptionFilme(int option)
        {
            string titulo;
            string diretor;
            string atorPrincipal;
            int duracao;
            string classificacao;
            string categoria;
            int idFilme;

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar Filme");

                    Console.WriteLine("Digite o título do filme: ");
                    titulo = Console.ReadLine();

                    Console.WriteLine("Digite o diretor do filme: ");
                    diretor = Console.ReadLine();

                    Console.WriteLine("Digite o ator principal do filme: ");
                    atorPrincipal = Console.ReadLine();

                    duracao = ReadInt("Digite a duração do filme: ");

                    Console.WriteLine("Digite a classificação do filme: ");
                    classificacao = Console.ReadLine();

                    Console.WriteLine("Digite a categoria do filme: ");
                    categoria = Console.ReadLine();
                    Console.Clear();

                    _cineManager.CadastrarFilme(titulo, diretor, atorPrincipal, duracao, classificacao, categoria);
                    break;

                case 2:
                    Console.WriteLine("Opção 2 selecionada: Consultar filme");
                    Console.Clear();
                    _cineManager.ConsultarFilmes();
                    break;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar filme");
                    _cineManager.ConsultarFilmes();
                    idFilme = ReadInt("Digite o código do filme que atualizar: ");

                    Console.WriteLine("Digite o novo título do filme: ");
                    titulo = Console.ReadLine();

                    Console.WriteLine("Digite o novo diretor do filme: ");
                    diretor = Console.ReadLine();

                    Console.WriteLine("Digite o novo ator principal do filme: ");
                    atorPrincipal = Console.ReadLine();

                    duracao = ReadInt("Digite a nova duração do filme: ");

                    Console.WriteLine("Digite a nova classificação do filme: ");
                    classificacao = Console.ReadLine();

                    Console.WriteLine("Digite a nova categoria do filme: ");
                    categoria = Console.ReadLine();
                    Console.Clear();

                    _cineManager.AtualizarFilme(idFilme, titulo, diretor, atorPrincipal, duracao, classificacao, categoria);

                    break;

                case 4:
                    Console.WriteLine("Opção 4 selecionada: Excluir filme");
                    _cineManager.ConsultarFilmes();
                    idFilme = ReadInt("Digite o código do filme que deseja excluir: ");
                    Console.Clear();
                    _cineManager.ExcluirFilme(idFilme);
                    break;

                default:
                    Console.WriteLine("Opção inválida: Tente novamente");
                    break;
            }
        }

        public bool ReadOptionSessao(int option)
        {
            int idCinema;
            int idSala;
            int idFilme;
            int idSessao;
            bool dataHoraValida;
            string input;

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar sessão");
                    _cineManager.ConsultarCinemas();

                    idCinema = ReadInt("Digite o número do cinema que deseja a sessão: ");

                    if (!_cineManager.ConsultarSalas(idCinema))
                    {
                        break;
                    }

                    idSala = ReadInt("Digite o código da sala em que você quer cadastrar a sessão: ");

                    _cineManager.ConsultarFilmes();

                    idFilme = ReadInt("Digite o código do filme que você quer exibir na sessão: ");

                    dataHoraValida = false;

                    while (!dataHoraValida)
                    {
                        Console.WriteLine("Digite a data e hora da sessão (no formato dd/MM/yyyy HH:mm:ss):");
                        input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                        {
                            Console.WriteLine($"Data e Hora: {dateTime}");

                            DateTime dataAtual = DateTime.Now;
                            if (dateTime > dataAtual)
                            {
                                dataHoraValida = true;
                                Console.WriteLine("A data e hora inseridas são válidas.");
                                Console.Clear();
                                _cineManager.CadastrarSessao(idFilme, idSala, dateTime, idCinema);
                            }
                            else
                            {
                                Console.WriteLine("Data e hora inseridas são inválidas. Tente novamente.");
                            }
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

                    idCinema = ReadInt("Digite o número do cinema que deseja ver as sessões: ");

                    if (!_cineManager.ConsultarSessoes(idCinema))
                    {
                        break;
                    }

                    //_cineManager.ConsultarSessoes(idCinema);
                    return true;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar sessão");

                    _cineManager.ConsultarCinemas();
                    idCinema = ReadInt("Digite o número do cinema que deseja a atualizar sessão: ");

                    if (!_cineManager.ConsultarSessoes(idCinema))
                    {
                        break;
                    }
                    // AQUI!
                    idSessao = ReadInt("Digite o código da sessão que você deseja atualizar: ");

                    if (!_cineManager.ConsultarSalas(idCinema))
                    {
                        break;
                    }

                    idSala = ReadInt("Digite o código da sala em que a sessão ficará a partir de agora: ");

                    _cineManager.ConsultarFilmes();
                    idFilme = ReadInt("Digite o código do filme que você quer exibir na sessão a partir de agora: ");

                    dataHoraValida = false;

                    while (!dataHoraValida)
                    {
                        Console.WriteLine("Digite a nova data e hora da sessão (no formato dd/MM/yyyy HH:mm:ss):");
                        input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                        {
                            Console.WriteLine($"Data e Hora: {dateTime}");

                            DateTime dataAtual = DateTime.Now;
                            if (dateTime > dataAtual)
                            {
                                dataHoraValida = true;
                                Console.WriteLine("A data e hora inseridas são válidas.");
                                Console.Clear();
                                _cineManager.AtualizarSessao(idSessao, idFilme, idSala, dateTime, idCinema);
                            }
                            else
                            {
                                Console.WriteLine("Data e hora inseridas são inválidas. Tente novamente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Data e hora inseridas são inválidas. Tente novamente.");
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Opção 4 selecionada: Excluir sessão");
                    _cineManager.ConsultarCinemas();
                    idCinema = ReadInt("Digite o número do cinema que deseja a excluir uma sessão: ");

                    if (!_cineManager.ConsultarSessoes(idCinema))
                    {
                        break;
                    }
                    idSessao = ReadInt("Digite o código da sessão que você deseja excluir: ");


                    Console.Clear();
                    _cineManager.ExcluirSessao(idSessao, idCinema);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            return false;
        }

        public void ReadOptionSala(int option)
        {
            int idCinema;
            int idSala;
            int numero;
            int capacidade;
            bool is3D;
            string[] equipamentos;
            List<string> listaEquipamentos;

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Opção 1 selecionada: Cadastrar sala");

                    _cineManager.ConsultarCinemas();

                    idCinema = ReadInt("Digite o numero do cinema que deseja cadastrar a sala: ");

                    numero = ReadInt("Digite o número da sala: ");

                    capacidade = ReadInt("Digite a capacidade da sala: ");

                    Console.WriteLine("A sala é 3D? (S/N): ");
                    is3D = Console.ReadLine().ToUpper() == "S";

                    Console.WriteLine("Digite os equipamentos da sala (separados por vírgula): ");

                    equipamentos = Console.ReadLine().Split(',');

                    listaEquipamentos = new List<string>(equipamentos);

                    Console.Clear();
                    _cineManager.CadastrarSala(numero, capacidade, is3D, listaEquipamentos, idCinema);
                    break;

                case 2:
                    Console.WriteLine("Opção 2 selecionada: Consultar sala");
                    _cineManager.ConsultarCinemas();

                    int idCinemaConsulta = ReadInt("Digite o numero do cinema que deseja consultar as salas: ");

                    _cineManager.ConsultarSalas(idCinemaConsulta);
                    break;

                case 3:
                    Console.WriteLine("Opção 3 selecionada: Atualizar sala");
                    _cineManager.ConsultarCinemas();


                    idCinema = ReadInt("Digite o numero do cinema em que deseja atualizar uma sala: ");

                    if (!_cineManager.ConsultarSalas(idCinema))
                    {
                        break;
                    }

                    idSala = ReadInt("Digite o código da sala que deseja atualizar: ");

                    numero = ReadInt("Digite o novo número da sala: ");

                    capacidade = ReadInt("Digite a nova capacidade da sala: ");

                    Console.WriteLine("A sala é 3D? (S/N): ");
                    is3D = Console.ReadLine().ToUpper() == "S";

                    Console.WriteLine("Digite os novos equipamentos da sala (separados por vírgula): ");

                    equipamentos = Console.ReadLine().Split(',');

                    listaEquipamentos = new List<string>(equipamentos);

                    Console.Clear();
                    _cineManager.AtualizarSala(idSala, numero, capacidade, is3D, listaEquipamentos, idCinema);

                    break;

                case 4:
                    Console.WriteLine("Opção 4 selecionada: Excluir sala");
                    _cineManager.ConsultarCinemas();


                    idCinema = ReadInt("Digite o numero do cinema em que deseja excluir uma sala: ");

                    if (!_cineManager.ConsultarSalas(idCinema))
                    {
                        break;
                    }

                    idSala = ReadInt("Digite o código da sala que deseja excluir: ");

                    Console.Clear();
                    _cineManager.ExcluirSala(idSala, idCinema);

                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        public bool ReadVendaIngressoInfos()
        {
            Console.Write("Informe o nome do cliente: ");
            var nome = Console.ReadLine();

            Console.Write("Informe o CPF do cliente: ");
            var cpf = Console.ReadLine();

            //Console.Write("Informe o valor do ingresso: ");

            bool? isEstudante = null;
            while (true)
            {
                Console.Write("O cliente é estudante? [s/n]: ");
                var resp = Console.ReadLine();

                if (resp.ToLower().Equals("s"))
                {
                    isEstudante = true;
                }
                else if (resp.ToLower().Equals("n"))
                {
                    isEstudante = false;
                }

                if (isEstudante is null)
                {
                    Console.WriteLine("Opção inválida, digite 's' ou 'n'");
                }
                else
                {
                    break;
                }
            }

            Console.Clear();

            var cliente = new Cliente
            {
                Nome = nome,
                Cpf = cpf,
                IsEstudante = (bool)isEstudante,
            };


            _cineManager.ConsultarCinemas();

            int idCinema = ReadInt("Digite o número do cinema que deseja ver as sessões: ");

            if (!_cineManager.ConsultarSessoes(idCinema))
            {
                return false;
            }

            _cineManager.ConsultarSessoes(idCinema);


            int idSessao = ReadInt("Digite o número de sessão desejada: ");

            Console.Clear();

            var sessao = _cineManager.VerificaSessao(idCinema, idSessao);

            if (sessao is null)
            {
                Console.WriteLine("Sessão Não encontrada");
                return false;
            }

            if (sessao.Lugares.Equals(0))
            {
                Console.WriteLine("A sessão selecionada está cheia, por favor escolha outra!");
                return false;
=========
                if (sessao.Lugares.Equals(0))
                {
                    Console.WriteLine("A sessão selecionada está cheia, por favor escolha outra!");
                }

            if (sessao.Filme == null)
            {
                Console.WriteLine("A sessão selecionada está indisponível. Por favor escolha outra!");
                return false;
            }


            if (sessao.Lugares.Equals(0))
            {
                Console.WriteLine("A sessão selecionada está cheia, por favor escolha outra!");
                return false;
            }

            var valor = sessao.PrecoIngresso;

            if (cliente.IsEstudante)
            {
                valor /= 2;
            }

            Console.Clear();

            _vendasManager.VenderIngresso(cliente, sessao, valor);
            return true;
        }

        public bool ReadCancelIngressoInfos()
        {
            if (!_vendasManager.ListarIngressos())
            {
                return false;
            }

            int ingresso_id = ReadInt("Digite o número do ingresso que deseja cancelar");

            Console.Clear();
            _vendasManager.CancelarIngresso(ingresso_id);
            return true;
        }

        public void ConsultaFilmeDia()
        {
            DateTime dataFilme;

            while (true)
            {
                Console.Write("Informe o dia do filme (no formato dd/MM/yyyy): ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                {
                    dataFilme = data;
                    Console.WriteLine($"Data: {dataFilme:dd/MM/yyyy}");
                    break;
                }
                else
                {
                    Console.WriteLine("Data inserida é inválida. Tente novamente.");
                }
            }

            _cineManager.ConsultarFilmeDia(dataFilme);
        }

        public void VerificarSessaoDisponivel()
        {
            DateTime dataSessao;

            while (true)
            {
                Console.Write("Informe o dia das sessões(no formato dd/MM/yyyy): ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                {
                    dataSessao = data;
                    Console.WriteLine($"Data: {dataSessao:dd/MM/yyyy}");
                    break;
                }
                else
                {
                    Console.WriteLine("Data inserida é inválida. Tente novamente.");
                }
            }

            _cineManager.VerificarSessaoDisponivel(dataSessao);
        }

        public static int ReadInt(string msgForm)
        {
            while (true)
            {
                Console.Write(msgForm);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }

                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }

        public static double ReadDouble(string msgForm)
        {
            while (true)
            {
                Console.Write(msgForm);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }
    }
}