using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Context;
using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataBase _dataBase;
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly IRepository<Sala> _salaRepository;
        private readonly IRepository<Filme> _filmeRepository;
        private readonly IRepository<Sessao> _sessaoRepository;

        public IRepository<Cinema> CinemaRepository => _cinemaRepository;
        public IRepository<Sala> SalaRepository => _salaRepository;
        public IRepository<Filme> FilmeRepository => _filmeRepository;
        public IRepository<Sessao> SessaoRepository => _sessaoRepository;

        public UnitOfWork(DataBase database,
            IRepository<Cinema> cinemaRepository,
            IRepository<Sala> salaRepository,
            IRepository<Filme> filmeRepository,
            IRepository<Sessao> sessaoRepository)
        {
            _dataBase = database;
            _cinemaRepository = cinemaRepository;
            _salaRepository = salaRepository;
            _filmeRepository = filmeRepository;
            _sessaoRepository = sessaoRepository;
        }

        public void SetContext(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public void SaveChanges()
        {
            _dataBase.SaveChanges();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}