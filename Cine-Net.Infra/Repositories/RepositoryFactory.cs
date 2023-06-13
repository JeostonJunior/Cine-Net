using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Context;
using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Infra.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DataBase _dataBase;

        public RepositoryFactory(DataBase database)
        {
            _dataBase = database;
        }

        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new Repository<T>(_dataBase);
        }
    }
}
