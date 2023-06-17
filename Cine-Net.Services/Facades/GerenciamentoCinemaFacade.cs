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

        public void CadastrarSala(int numero, int capacidade, bool is3D, Collection<Equipamentos> equipamentos, double precoIngresso, Cinema cinema)
        {
            var sala = new Sala
            {
                Numero = numero,
                Capacidade = capacidade,
                Is3D = is3D,
                Equipamentos = equipamentos,
                PrecoIngresso = precoIngresso,
                Cinema = cinema
            };

            _unitOfWork.SalaRepository.Add(sala);
            _unitOfWork.SaveChanges();
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

            _unitOfWork.FilmeRepository.Add(filme);
            _unitOfWork.SaveChanges();
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

        public ICollection<Sala> ObterSalasDoCinema(int cinemaId)
        {
            var cinema = _unitOfWork.CinemaRepository.GetById(cinemaId);

            return cinema.Salas;
        }
    }
}