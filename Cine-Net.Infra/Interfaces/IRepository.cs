namespace Cine_Net.Infra.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T obj);

        T Update(T obj);

        void Remove(long id);

        T Get(long id);

        IList<T> Get();
    }
}