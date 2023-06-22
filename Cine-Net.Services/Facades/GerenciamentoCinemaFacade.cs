using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;
using System.Collections.ObjectModel;

namespace Cine_Net.Services.Facades
{
    public class GerenciamentoCinemaFacade
    {
        private readonly IUnitOfWork _unitOfWork;

        public GerenciamentoCinemaFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CadastrarCinema(string nome, string endereco, double precoWeek, double precoWeekend)
        {
            var cinema = new Cinema
            {
                Nome = nome,
                Endereco = endereco,
                PrecoWeek = precoWeek,
                PrecoWeekend = precoWeekend
            };

            _unitOfWork.CinemaRepository.Add(cinema);

            Console.WriteLine("================================");
            Console.WriteLine("Cinema Cadastrado com Sucesso!");
            Console.WriteLine("================================\n");
        }

        public void ConsultarCinemas()
        {
            var cinemasEnumerable = _unitOfWork.CinemaRepository.GetList();

            ListarCinemas(cinemasEnumerable);
        }

        public static bool ListarCinemas(IEnumerable<Cinema> cinemasEnumerable)
        {
            if (cinemasEnumerable is null || !cinemasEnumerable.Any())
            {
                Console.WriteLine("================================");
                Console.WriteLine("Não existem cinemas disponíveis.");
                Console.WriteLine("================================\n");

                return default;
            }

            foreach (var cinema in cinemasEnumerable)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Numero: " + cinema.Id.ToString());
                Console.WriteLine("Nome: " + cinema.Nome);
                Console.WriteLine("Endereço: " + cinema.Endereco);
                Console.WriteLine("Preco em dias de Semana: " + cinema.PrecoWeek);
                Console.WriteLine("Preco em finais de Semana: " + cinema.PrecoWeekend);
                Console.WriteLine("========================================================\n");
            }

            return true;
        }

        public void CadastrarSala(int numero, int capacidade, bool is3D, List<string> equipamentos, int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            if (cinema is null)
            {
                Console.Clear();
                Console.WriteLine($"O ID: {idCinema} não foi encontrado");
                return;
            }

            var sala = new Sala
            {
                Numero = numero,
                Capacidade = capacidade,
                Is3D = is3D,
                Equipamentos = equipamentos,
                Cinema = cinema
            };

            cinema.Salas.Add(sala);

            _unitOfWork.CinemaRepository.Update(cinema);
            _unitOfWork.SalaRepository.Add(sala);

            Console.WriteLine("========================================================");
            Console.WriteLine("Sala cadastrada com sucesso!");
            Console.WriteLine("========================================================\n");
        }

        public void ConsultarSalas(int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            if (cinema is null)
            {
                Console.Clear();
                Console.WriteLine($"O ID: {idCinema} não foi encontrado");
                return;
            }

            var salas = cinema.Salas;

            ListarSalas(salas, cinema);
        }

        public static bool ListarSalas(Collection<Sala> salas, Cinema cinema)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("                 Salas do Cinema" + cinema.Nome);
            Console.WriteLine("========================================================");
            Console.WriteLine("\n");

            if (salas is null || !salas.Any())
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Não existem salas disponíveis.");
                Console.WriteLine("========================================================\n");

                return default;
            }

            foreach (var sala in salas)
            {
                string is3D = sala.Is3D ? "Sala 3D" : "Sala 2D";

                Console.WriteLine("\n========================================================");
                Console.WriteLine($"Código: {sala.Id} | Sala: {sala.Numero}  | Tipo: {is3D} | Capacidade: {sala.Capacidade}");
                Console.WriteLine("========================================================\n");
            }

            return true;
        }

        public void CadastrarFilme(string titulo, string diretor, string atorPrincipal, int duracao, string classificacao, string categoria)
        {
            var filme = new Filme
            {
                Titulo = titulo,
                Diretor = diretor,
                AtorPrincipal = atorPrincipal,
                Duracao = duracao,
                Classificacao = classificacao,
                Categoria = categoria
            };

            _unitOfWork.FilmeRepository.Add(filme);

            Console.WriteLine("========================================================");
            Console.WriteLine("Filme Cadastrado com Sucesso!");
            Console.WriteLine("========================================================\n");
        }

        public void ConsultarFilmes()
        {
            var filmesEnumerable = _unitOfWork.FilmeRepository.GetList();

            ListarFilmes(filmesEnumerable);
        }

        public static bool ListarFilmes(IEnumerable<Filme> filmesEnumerable)
        {
            if (filmesEnumerable is null || !filmesEnumerable.Any())
            {
                Console.WriteLine("================================");
                Console.WriteLine("Não existem filmes disponíveis.");
                Console.WriteLine("================================\n");

                return default;
            }

            foreach (var filme in filmesEnumerable)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Código: " + filme.Id.ToString());
                Console.WriteLine("Titulo: " + filme.Titulo);
                Console.WriteLine("Diretor: " + filme.Diretor);
                Console.WriteLine("AtorPrincipal: " + filme.AtorPrincipal);
                Console.WriteLine("Duracao: " + filme.Duracao);
                Console.WriteLine("Classificacao: " + filme.Classificacao);
                Console.WriteLine("Categoria: " + filme.Categoria);
                Console.WriteLine("========================================================\n");
            }

            return true;
        }

        public void CadastrarSessao(int idFilme, int idSala, DateTime horario)
        {
            var filme = _unitOfWork.FilmeRepository.GetById(idFilme);

            if (filme is null)
            {
                Console.Clear();
                Console.WriteLine($"O ID: {idFilme} não foi encontrado");
                return;
            }

            var sala = _unitOfWork.SalaRepository.GetById(idSala);

            if (sala is null)
            {
                Console.Clear();
                Console.WriteLine($"O ID: {idSala} não foi encontrado");
                return;
            }

            var sessao = new Sessao
            {
                Filme = filme,
                Lugares = sala.Capacidade,
                Sala = sala,
                Horario = horario,
                PrecoIngresso = CalcPrecoIngresso(sala, horario)
            };

            sala.Sessao.Add(sessao);

            _unitOfWork.SalaRepository.Update(sala);
            _unitOfWork.SessaoRepository.Add(sessao);
        }

        public void ConsultarSessoes(int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            if (cinema is null)
            {
                Console.Clear();
                Console.WriteLine($"O ID: {idCinema} não foi encontrado");
                return;
            }

            var salas = cinema.Salas;
            ListarSessoes(salas, cinema);
        }

        public static bool ListarSessoes(Collection<Sala> salas, Cinema cinema)
        {
            foreach (var sala in salas)
            {
                var sessoes = sala.Sessao;

                if (sessoes is null || !sessoes.Any())
                {
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Não existem sessoes disponíveis.");
                    Console.WriteLine("========================================================\n");

                    return default;
                }

                foreach (var sessao in sessoes)
                {
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Código: " + sessao.Id);
                    Console.WriteLine("Numero da sala: " + sessao.Sala.Numero);
                    Console.WriteLine("Titulo: " + sessao.Filme.Titulo);
                    Console.WriteLine("Horario: " + sessao.Horario);
                    Console.WriteLine("Lugares: " + sessao.Lugares);

                    if (sessao.Sala.Is3D)
                    {
                        Console.WriteLine("Sessao 3D");
                    }

                    Console.WriteLine("Preco Inteira: " + sessao.PrecoIngresso);
                    Console.WriteLine("========================================================\n");
                }
            }

            return true;
        }

        public static bool IsWeekend(DateTime data)
        {
            if (data.DayOfWeek.Equals(DayOfWeek.Saturday) || data.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                return true;
            }

            return default;
        }

        public static double CalcPrecoIngresso(Sala sala, DateTime data)
        {
            double precoWeek = sala.Cinema.PrecoWeek;
            double precoWeekend = sala.Cinema.PrecoWeekend;

            if (IsWeekend(data) && sala.Is3D)
            {
                return precoWeekend * 1.20;
            }
            else if (IsWeekend(data) && (!sala.Is3D))
            {
                return precoWeekend;
            }
            else if (!IsWeekend(data) && sala.Is3D)
            {
                return precoWeek * 1.20;
            }

            return precoWeek;
        }

        public void InitCinema()
        {
            // Add Cinemas
            CadastrarCinema("CineSSA", "Rua Salvador", 30, 35); // Id 0
            CadastrarCinema("CineBA", "Rua Bahia", 40, 50); // Id 1
            CadastrarCinema("CineSP", "Rua São Paulo", 50, 75); // Id 2

            // Add Salas no Cinema SSA
            CadastrarSala(1, 30, false, new List<string> { "Cadeira Especial" }, 0); // Id 0
            CadastrarSala(2, 30, false, new List<string> { "Cadeira Especial" }, 0); // Id 1

            // Add Salas no Cinema BA
            CadastrarSala(1, 30, true, new List<string> { "Oculos 3D", "Cadeira Especial" }, 1);// Id 2
            CadastrarSala(2, 30, false, new List<string> { "Cadeira Especial" }, 1);  // Id 3

            // Add Salas no Cinema SP
            CadastrarSala(1, 30, true, new List<string> { "Oculos", "Cadeira Especial" }, 2); // Id 4
            CadastrarSala(2, 30, true, new List<string> { "Oculos", "Cadeira Especial" }, 2); // Id 5

            // Add Filmes
            CadastrarFilme("Matrix", "Lana Wachowski", "Keanu Reeves", 136, "+14", "Ficção Científica"); // Id 0
            CadastrarFilme("Senhor dos Anéis: A Sociedade do Anel", "Peter Jackson", "Elijah Wood", 178, "+12", "Fantasia"); // Id 1
            CadastrarFilme("Interestelar", "Christopher Nolan", "Matthew McConaughey", 169, "+12", "Ficção Científica"); // Id 2
            CadastrarFilme("Clube da Luta", "David Fincher", "Brad Pitt", 139, "+18", "Drama"); // Id 3
            CadastrarFilme("O Poderoso Chefão", "Francis Ford Coppola", "Marlon Brando", 175, "+16", "Crime"); // Id 4
            CadastrarFilme("O Senhor dos Anéis: O Retorno do Rei", "Peter Jackson", "Viggo Mortensen", 201, "+12", "Fantasia"); // Id 5
            CadastrarFilme("Cidade de Deus", "Fernando Meirelles", "Alexandre Rodrigues", 130, "+16", "Crime"); // Id 6
            CadastrarFilme("Batman: O Cavaleiro das Trevas", "Christopher Nolan", "Christian Bale", 152, "+14", "Ação"); // Id 7
            CadastrarFilme("A Origem", "Christopher Nolan", "Leonardo DiCaprio", 148, "+14", "Ficção Científica"); // Id 8

            // Add Sessões
            CadastrarSessao(3, 1, new DateTime(2023, 6, 24, 10, 0, 0));
            CadastrarSessao(2, 2, new DateTime(2023, 6, 25, 14, 30, 0));
            CadastrarSessao(3, 1, new DateTime(2023, 6, 26, 19, 15, 0));
            CadastrarSessao(4, 4, new DateTime(2023, 6, 27, 11, 45, 0));
            CadastrarSessao(5, 5, new DateTime(2023, 6, 28, 16, 20, 0));
            CadastrarSessao(0, 1, new DateTime(2023, 7, 3, 13, 15, 0));
            CadastrarSessao(1, 2, new DateTime(2023, 7, 4, 17, 0, 0));
            CadastrarSessao(2, 3, new DateTime(2023, 7, 5, 21, 30, 0));
            CadastrarSessao(2, 4, new DateTime(2023, 7, 6, 10, 45, 0));
            CadastrarSessao(4, 0, new DateTime(2023, 7, 7, 14, 20, 0));
            CadastrarSessao(5, 3, new DateTime(2023, 7, 8, 18, 45, 0));
            CadastrarSessao(7, 4, new DateTime(2023, 7, 10, 16, 15, 0));
            CadastrarSessao(6, 1, new DateTime(2023, 7, 12, 13, 45, 0));
            CadastrarSessao(2, 2, new DateTime(2023, 7, 13, 17, 30, 0));
        }

        public void ConsultarFilmeDia(DateTime data)
        {

            var sessoes = _unitOfWork.SessaoRepository.GetList();
            var sessoesFiltradas = sessoes.Where((sessao) => IsSameDay(sessao.Horario, data));

            if (!sessoesFiltradas.Any())
            {
                Console.WriteLine("Não foram encontrados filmes para este dia");
            }

            foreach (var sessao in sessoesFiltradas)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Código: " + sessao.Filme.Id.ToString());
                Console.WriteLine("Titulo: " + sessao.Filme.Titulo);
                Console.WriteLine("Diretor: " + sessao.Filme.Diretor);
                Console.WriteLine("AtorPrincipal: " + sessao.Filme.AtorPrincipal);
                Console.WriteLine("Duracao: " + sessao.Filme.Duracao);
                Console.WriteLine("Classificacao: " + sessao.Filme.Classificacao);
                Console.WriteLine("Categoria: " + sessao.Filme.Categoria);
                Console.WriteLine("========================================================\n");
            }
        }

        private static bool IsSameDay(DateTime data1, DateTime data2)
        {
            return data1.Date.Equals(data2.Date);
        }

        public void VerificarSessaoDisponivel(DateTime data)
        {

            var sessoes = _unitOfWork.SessaoRepository.GetList();
            var sessoesFiltradas = sessoes.Where((sessao) => IsSameDay(sessao.Horario, data) && sessao.Lugares > 0);

            if (!sessoesFiltradas.Any())
            {
                Console.WriteLine("Não foram encontradas sessões disponíveis para este dia");
            }

            foreach (var sessao in sessoesFiltradas)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Código: " + sessao.Id);
                Console.WriteLine("Numero da sala: " + sessao.Sala.Numero);
                Console.WriteLine("Titulo: " + sessao.Filme.Titulo);
                Console.WriteLine("Horario: " + sessao.Horario);
                Console.WriteLine("Lugares: " + sessao.Lugares);

                if (sessao.Sala.Is3D)
                {
                    Console.WriteLine("Sessao 3D");
                }

                Console.WriteLine("Preco Inteira: " + sessao.PrecoIngresso);
                Console.WriteLine("========================================================\n");
            }
        }
    }
}