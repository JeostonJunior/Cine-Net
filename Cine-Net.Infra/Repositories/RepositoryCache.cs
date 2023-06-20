using Cine_Net.Infra.Interfaces;
using System.Reflection;

namespace Cine_Net.Infra.Repositories
{
    public class RepositoryCache<T> : IRepositoryCache<T>
    {
        private readonly IDictionary<int, T> _cache;

        public RepositoryCache()
        {
            _cache = new Dictionary<int, T>();
        }

        public void Add(T obj)
        {
            int id = GetEntityId(obj);

            while (_cache.ContainsKey(id))
            {
                id++; // Increment the id by 1 until it is unique
            }

            PropertyInfo idProperty = typeof(T).GetProperty("Id");
            idProperty.SetValue(obj, id);

            _cache[id] = obj;
        }

        public void Update(T obj)
        {
            int id = GetEntityId(obj);
            if (_cache.ContainsKey(id))
            {
                _cache[id] = obj;
            }
        }

        public void Delete(T obj)
        {
            int id = GetEntityId(obj);
            if (_cache.ContainsKey(id))
            {
                _cache.Remove(id);
            }
        }

        public T GetById(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            return default(T);
        }

        public IEnumerable<T> GetList()
        {
            return _cache.Values;
        }

        private int GetEntityId(T obj)
        {
            PropertyInfo idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null && idProperty.PropertyType == typeof(int))
            {
                return (int)idProperty.GetValue(obj);
            }
            else
            {
                // Handle the case where the object doesn't have an integer Id property
                throw new InvalidOperationException("The object does not have a valid integer Id property.");
            }
        }
    }
}