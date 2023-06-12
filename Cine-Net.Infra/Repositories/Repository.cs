using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Context;
using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly DataBase _dataBase;

        public Repository(DataBase database)
        {
            _dataBase = database;
        }

        public void Create(T obj)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            throw new NotImplementedException();
        }

        public IList<T> Get()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}