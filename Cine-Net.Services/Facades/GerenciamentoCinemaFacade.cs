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
            Console.WriteLine("================================");
            Console.WriteLine("\n");
        }

        public void ConsultarCinemas()
        {
            IEnumerable<Cinema> cinemasEnumerable = _unitOfWork.CinemaRepository.GetList();
            ListarCinemas(cinemasEnumerable);
        }

        public bool ListarCinemas(IEnumerable<Cinema> cinemasEnumerable)
        {
            if (cinemasEnumerable == null || !cinemasEnumerable.Any())
            {
                Console.WriteLine("================================");
                Console.WriteLine("Não existem cinemas disponíveis.");
                Console.WriteLine("================================");
                Console.WriteLine("\n");
                return false;
            }

            foreach (Cinema cinema in cinemasEnumerable)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Numero: " + cinema.Id.ToString());
                Console.WriteLine("Nome: " + cinema.Nome);
                Console.WriteLine("Endereço: " + cinema.Endereco);
                Console.WriteLine("========================================================");
                Console.WriteLine("\n");
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

            cinema.Salas.Add(sala);
            _unitOfWork.CinemaRepository.Update(cinema); // talvez n funcione, ou seja, tem que chamar o update do repository
            _unitOfWork.SalaRepository.Add(sala);

            Console.WriteLine("========================================================");
            Console.WriteLine("Sala cadastrada com sucesso!");
            Console.WriteLine("========================================================");
            Console.WriteLine("\n");

        }

        public void ConsultarSalas(int idCinema)
        {
            Cinema cinema = _unitOfWork.CinemaRepository.GetById(idCinema);

            // To-do: Vericar se  o id escolhido existe

            Collection<Sala> salas = cinema.Salas;
            ListarSalas(salas, cinema);
        }

        public bool ListarSalas(Collection<Sala> salas, Cinema cinema)
        {

            Console.WriteLine("========================================================");
            Console.WriteLine("                 Salas do Cinema" + cinema.Nome);
            Console.WriteLine("========================================================");
            Console.WriteLine("\n");

            if (salas == null || !salas.Any())
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Não existem salas disponíveis.");
                Console.WriteLine("========================================================");
                Console.WriteLine("\n");
                return false;
            }

            foreach (Sala sala in salas)
            {
                Console.WriteLine("\n");
                Console.WriteLine("========================================================");
                Console.WriteLine($"Código: {sala.Id} | Sala: {sala.Numero}  | Preço: {sala.PrecoIngresso} | Capacidade: {sala.Capacidade}");
                Console.WriteLine("========================================================");
                Console.WriteLine("\n");
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
            Console.WriteLine("========================================================");
            Console.WriteLine("\n");
        }

        public void ConsultarFilmes()
        {
            IEnumerable<Filme> filmesEnumerable = _unitOfWork.FilmeRepository.GetList();
            ListarFilmes(filmesEnumerable);
        }

        public bool ListarFilmes(IEnumerable<Filme> filmesEnumerable)
        {
            if (filmesEnumerable == null || !filmesEnumerable.Any())
            {
                Console.WriteLine("================================");
                Console.WriteLine("Não existem filmes disponíveis.");
                Console.WriteLine("================================");
                Console.WriteLine("\n");
                return false;
            }

            foreach (Filme filme in filmesEnumerable)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("Código: " + filme.Id.ToString());
                Console.WriteLine("Titulo: " + filme.Titulo);
                Console.WriteLine("Diretor: " + filme.Diretor);
                Console.WriteLine("AtorPrincipal: " + filme.AtorPrincipal);
                Console.WriteLine("Duracao: " + filme.Duracao);
                Console.WriteLine("Classificacao: " + filme.Classificacao);
                Console.WriteLine("Categoria: " + filme.Categoria);
                Console.WriteLine("========================================================");
                Console.WriteLine("\n");
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

            sala.Sessao.Add(sessao);
            _unitOfWork.SalaRepository.Update(sala);
            _unitOfWork.SessaoRepository.Add(sessao);
            _unitOfWork.SaveChanges();
        }


        // Pega todas as seções de um cinema
        public void ConsultarSessoes(int idCinema)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(idCinema);
            IEnumerable<Sessao> sessoesEnumerable = _unitOfWork.SessaoRepository.GetList();
            Collection<Sala> salas = cinema.Salas;
            listarSessoes(salas, cinema);
        }

        public bool listarSessoes(Collection<Sala> salas, Cinema cinema)
        {
            foreach (Sala sala in salas)
            {
                Collection<Sessao> sessoes = sala.Sessao;

                if (sessoes == null || !sessoes.Any())
                {
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Não existem sessoes disponíveis.");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("\n");
                    return false;
                }

                foreach (Sessao sessao in sessoes)
                {
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Código: " + sessao.Id);
                    Console.WriteLine("Numero da sala: " + sessao.Sala.Numero);
                    Console.WriteLine("Titulo: " + sessao.Filme.Titulo);
                    Console.WriteLine("Horario: " + sessao.Horario);
                    Console.WriteLine("Lugares: " + sessao.Lugares);
                    if (sessao.Sala.Is3D) Console.WriteLine("Sessao 3D");
                    Console.WriteLine("Preco Inteira: " + sessao.Sala.PrecoIngresso);
                    Console.WriteLine("========================================================");
                    Console.WriteLine("\n");
                }

            }

            return true;
        }

        public void initCinema()
        {
            // Add Cinemas
            this.CadastrarCinema("CineSSA", "Rua Salvador"); // Id 0
            this.CadastrarCinema("CineBA", "Rua Bahia"); // Id 1
            this.CadastrarCinema("CineSP", "Rua São Paulo"); // Id 2

            // Add Salas no Cinema SSA
            this.CadastrarSala(1, 30, false, new List<string> { "Cadeira Especial" }, 30, 0); // Id 0
            this.CadastrarSala(2, 30, false, new List<string> { "Cadeira Especial" }, 30, 0); // Id 1

            // Add Salas no Cinema BA
            this.CadastrarSala(1, 30, true, new List<string> { "Oculos 3D", "Cadeira Especial" }, 30, 1);// Id 2
            this.CadastrarSala(2, 30, false, new List<string> { "Cadeira Especial" }, 30, 1);  // Id 3

            // Add Salas no Cinema SP
            this.CadastrarSala(1, 30, true, new List<string> { "Oculos", "Cadeira Especial" }, 30, 2); // Id 4
            this.CadastrarSala(2, 30, true, new List<string> { "Oculos", "Cadeira Especial" }, 30, 2); // Id 5


            // Add Filmes
            this.CadastrarFilme("Matrix", "Lana Wachowski", "Keanu Reeves", 136, "+14", "Ficção Científica"); // Id 0
            this.CadastrarFilme("Senhor dos Anéis: A Sociedade do Anel", "Peter Jackson", "Elijah Wood", 178, "+12", "Fantasia"); // Id 1
            this.CadastrarFilme("Interestelar", "Christopher Nolan", "Matthew McConaughey", 169, "+12", "Ficção Científica"); // Id 2
            this.CadastrarFilme("Clube da Luta", "David Fincher", "Brad Pitt", 139, "+18", "Drama"); // Id 3
            this.CadastrarFilme("O Poderoso Chefão", "Francis Ford Coppola", "Marlon Brando", 175, "+16", "Crime"); // Id 4
            this.CadastrarFilme("O Senhor dos Anéis: O Retorno do Rei", "Peter Jackson", "Viggo Mortensen", 201, "+12", "Fantasia"); // Id 5
            this.CadastrarFilme("Cidade de Deus", "Fernando Meirelles", "Alexandre Rodrigues", 130, "+16", "Crime"); // Id 6
            this.CadastrarFilme("Batman: O Cavaleiro das Trevas", "Christopher Nolan", "Christian Bale", 152, "+14", "Ação"); // Id 7
            this.CadastrarFilme("A Origem", "Christopher Nolan", "Leonardo DiCaprio", 148, "+14", "Ficção Científica"); // Id 8

            // Add Sessões
            this.CadastrarSessao(3, 1, new DateTime(2023, 6, 24, 10, 0, 0));
            this.CadastrarSessao(2, 2, new DateTime(2023, 6, 25, 14, 30, 0));
            this.CadastrarSessao(3, 1, new DateTime(2023, 6, 26, 19, 15, 0));
            this.CadastrarSessao(4, 4, new DateTime(2023, 6, 27, 11, 45, 0));
            this.CadastrarSessao(5, 5, new DateTime(2023, 6, 28, 16, 20, 0));
            this.CadastrarSessao(0, 1, new DateTime(2023, 7, 3, 13, 15, 0));
            this.CadastrarSessao(1, 2, new DateTime(2023, 7, 4, 17, 0, 0));
            this.CadastrarSessao(2, 3, new DateTime(2023, 7, 5, 21, 30, 0));
            this.CadastrarSessao(2, 4, new DateTime(2023, 7, 6, 10, 45, 0));
            this.CadastrarSessao(4, 0, new DateTime(2023, 7, 7, 14, 20, 0));
            this.CadastrarSessao(5, 3, new DateTime(2023, 7, 8, 18, 45, 0));
            this.CadastrarSessao(7, 4, new DateTime(2023, 7, 10, 16, 15, 0));
            this.CadastrarSessao(6, 1, new DateTime(2023, 7, 12, 13, 45, 0));
            this.CadastrarSessao(2, 2, new DateTime(2023, 7, 13, 17, 30, 0));
        }




        /*

        public ICollection<Sala> ObterSalasDoCinema(int cinemaId)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(cinemaId);

            return cinema.Salas; 
        */
    }
}