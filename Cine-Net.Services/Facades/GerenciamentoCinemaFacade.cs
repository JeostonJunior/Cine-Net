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

        public void CadastrarCinema(string nome, string endereco)
        {
            var cinema = new Cinema
            {
                Nome = nome,
                Endereco = endereco
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
                Console.WriteLine("========================================================\n");
            }

            return true;
        }

        public void CadastrarSala(int numero, int capacidade, bool is3D, List<String> equipamentos, double precoIngresso, int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            // To-do: Vericar se  o id escolhido existe

            var sala = new Sala
            {
                Numero = numero,
                Capacidade = capacidade,
                Is3D = is3D,
                Equipamentos = equipamentos,
                PrecoIngresso = precoIngresso,
                Cinema = cinema
            };

            cinema.Salas.Add(sala); // talvez n funcione, ou seja, tem que chamar o update do repository
            _unitOfWork.SalaRepository.Add(sala);

            Console.WriteLine("========================================================");
            Console.WriteLine("Sala cadastrada com sucesso!");
            Console.WriteLine("========================================================\n");
        }

        public void ConsultarSalas(int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            // To-do: Vericar se  o id escolhido existe

            var salas = cinema.Salas;
            ListarSalas(salas);
        }

        public static bool ListarSalas(Collection<Sala> salas)
        {
            if (salas is null || !salas.Any())
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Não existem salas disponíveis.");
                Console.WriteLine("========================================================\n");

                return default;
            }

            foreach (var sala in salas)
            {
                Console.WriteLine("\n========================================================");
                Console.WriteLine($"Código: {sala.Id} | Sala: {sala.Numero}  | Preço: {sala.PrecoIngresso} | Capacidade: {sala.Capacidade}");
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

            var sala = _unitOfWork.SalaRepository.GetById(idSala);

            var sessao = new Sessao
            {
                Filme = filme,
                Lugares = sala.Capacidade,
                Sala = sala,
                Horario = horario
            };

            sala.Sessao.Add(sessao);  // talvez n funcione, ou seja, tem que chamar o update do repository
            _unitOfWork.SessaoRepository.Add(sessao);
            _unitOfWork.SaveChanges();
        }

        // Pega todas as seções de um cinema
        public bool ConsultarSessoes(int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            var salas = cinema.Salas;

            // to-do:lembrar de fazer o update em salas e cinema

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

                    Console.WriteLine("Preco Inteira: " + sessao.Sala.PrecoIngresso);
                    Console.WriteLine("========================================================\n");
                }
            }

            return true;
        }

        public ICollection<Sala> ObterSalasDoCinema(int cinemaId)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(cinemaId);

            return cinema.Salas;
        }
    }
}