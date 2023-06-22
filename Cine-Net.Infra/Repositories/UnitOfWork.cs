using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache<Cinema> _cinemaRepository;
        private readonly IRepositoryCache<Sala> _salaRepository;
        private readonly IRepositoryCache<Filme> _filmeRepository;
        private readonly IRepositoryCache<Sessao> _sessaoRepository;
        private readonly IRepositoryCache<Ingresso> _ingressoRepository;
        private readonly IRepositoryCache<Cliente> _clienteRepository;

        public IRepositoryCache<Cinema> CinemaRepository => _cinemaRepository;
        public IRepositoryCache<Sala> SalaRepository => _salaRepository;
        public IRepositoryCache<Filme> FilmeRepository => _filmeRepository;
        public IRepositoryCache<Sessao> SessaoRepository => _sessaoRepository;
        public IRepositoryCache<Ingresso> IngressoRepository => _ingressoRepository;
        public IRepositoryCache<Cliente> ClienteRepository => _clienteRepository;

        public UnitOfWork()
        {
            _cinemaRepository = new RepositoryCache<Cinema>();
            _salaRepository = new RepositoryCache<Sala>();
            _filmeRepository = new RepositoryCache<Filme>();
            _sessaoRepository = new RepositoryCache<Sessao>();
            _ingressoRepository = new RepositoryCache<Ingresso>();
            _clienteRepository = new RepositoryCache<Cliente>();
        }
    }
}