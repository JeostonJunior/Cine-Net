namespace Cine_Net.Infra.Interfaces
{
    public interface IRepositoryCache<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);

        T GetById(int id);

        IEnumerable<T> GetList();
    }
}