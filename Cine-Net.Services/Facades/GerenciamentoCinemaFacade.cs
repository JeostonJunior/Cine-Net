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
            _unitOfWork.SaveChanges();
        }

        public void consultarCinemas()
        {
            IEnumerable<Cinema> cinemasEnumerable = _unitOfWork.CinemaRepository.GetList();
            foreach (Cinema cinema in cinemasEnumerable)
            {
                Console.WriteLine(cinema.Id);
                Console.WriteLine(cinema.Nome);
                Console.WriteLine(cinema.Endereco);
            }
        }

        public void CadastrarSala(int numero, int capacidade, bool is3D, List<String> equipamentos, double precoIngresso, String nomeCinema)

        // Cinema cinema = unityOfWork.Cinema.getByName(nomeCinema)
        {
            var sala = new Sala
            {
                Numero = numero,
                Capacidade = capacidade,
                Is3D = is3D,
                Equipamentos = equipamentos,
                PrecoIngresso = precoIngresso,
                //Cinema = cinema
            };

            _unitOfWork.SalaRepository.Add(sala);
            _unitOfWork.SaveChanges();
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
            _unitOfWork.SaveChanges();
        }

        public void consultarFilmes()
        {
            // Pegar todas as sessões de um dia em um cinema
            // Pegar os filmes diferentes e exibir
        }

        public void CadastrarSessao(Filme filme, Sala sala, DateTime horario)
        {
            var sessao = new Sessao
            {
                Filme = filme,
                Sala = sala,
                Horario = horario
            };

            _unitOfWork.SessaoRepository.Add(sessao);
            _unitOfWork.SaveChanges();
        }


        public void consultarSessoes()
        {
            IEnumerable<Sessao> sessoesEnumerable = _unitOfWork.SessaoRepository.GetList();

            foreach (Sessao sessao in sessoesEnumerable)
            {
                Console.WriteLine(sessao.Horario);
                Console.WriteLine(sessao.Filme.Titulo);
                Console.WriteLine(sessao.Sala.Numero);
            }
        }

        public ICollection<Sala> ObterSalasDoCinema(int cinemaId)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(cinemaId);

            return cinema.Salas;
        }
    }
}