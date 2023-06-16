using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;
using System.Collections.ObjectModel;

namespace Cine_Net.Services.Facades
{
    public class GerenciamentoCinemaFacade
    {
        private readonly IUnitOfWork _uof;

        public GerenciamentoCinemaFacade(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public void CadastrarCinema(string nome, string endereco)
        {
            var cinema = new Cinema
            {
                Nome = nome,
                Endereco = endereco
            };

            _uof.CinemaRepository.Create(cinema);
        }

        public void CadastrarSala(int numero, int capacidade, bool is3D, Collection<Equipamentos> equipamentos, double precoIngresso, int cinemaId)
        {
            var sala = new Sala
            {
                Numero = numero,
                Capacidade = capacidade,
                Is3D = is3D,
                Equipamentos = equipamentos,
                PrecoIngresso = precoIngresso,
                CinemaId = cinemaId
            };

            _uof.SalaRepository.Create(sala);
            _uof.SaveChanges();
        }


        public void CadastrarFilme(string titulo, string diretor, string atorPrincipal, double duracao, string classificacao, Collection<Categoria> categoria)
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

            _uof.FilmeRepository.Create(filme);
        }

        public void CadastrarSessao(Filme filme, Sala sala, DateTime horario)
        {
            var sessao = new Sessao
            {
                Filme = filme,
                Sala = sala,
                Horario = horario
            };

            _uof.SessaoRepository.Create(sessao);
        }

        public ICollection<Sala> ObterSalasDoCinema(int cinemaId)
        {
            var cinema = _uof.CinemaRepository.GetById(cinemaId);

            return cinema.Salas;
        }
    }
}
