using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Infra.Repositories
{
    public class Repository<T> : IRepositoryCache<T>
    {
        private readonly IRepositoryCache<T> _repository;

        public Repository(IRepositoryCache<T> repository)
        {
            _repository = repository;
        }

        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public void Delete(T obj)
        {
            _repository.Delete(obj);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetList()
        {
            return _repository.GetList();
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}