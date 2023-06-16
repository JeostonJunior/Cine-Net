using Cine_Net.Infra.Context;
using Cine_Net.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cine_Net.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataBase _dataBase;

        public Repository(DataBase database)
        {
            _dataBase = database;
        }

        public T Create(T obj)
        {
            _dataBase.Add(obj);
            _dataBase.SaveChanges();

            return obj;
        }

        public T Update(T obj)
        {
            _dataBase.Entry(obj).State = EntityState.Modified;
            _dataBase.SaveChanges();

            return obj;
        }

        public void Remove(int id)
        {
            var obj = GetById(id);

            if (obj != null)
            {
                _dataBase.Remove(obj);
                _dataBase.SaveChangesAsync();
            }
        }

        public T GetById(int id)
        {
            return _dataBase.Set<T>()
                 .Find(id);
        }

        public IList<T> GetList()
        {
            return _dataBase.Set<T>()
                 .ToList();
        }
    }
}
