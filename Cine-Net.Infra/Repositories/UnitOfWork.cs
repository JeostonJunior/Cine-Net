using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Context;
using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataBase _dataBase;

        public UnitOfWork(DataBase database)
        {
            _dataBase = database;
            CinemaRepository = new Repository<Cinema>(_dataBase);
            SalaRepository = new Repository<Sala>(_dataBase);
            FilmeRepository = new Repository<Filme>(_dataBase);
            SessaoRepository = new Repository<Sessao>(_dataBase);
        }

        public void SetContext(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public IRepository<Cinema> CinemaRepository { get; }
        public IRepository<Sala> SalaRepository { get; }
        public IRepository<Filme> FilmeRepository { get; }

        public IRepository<Sessao> SessaoRepository { get; }

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
