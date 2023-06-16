namespace Cine_Net.Infra.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T obj);

        T Update(T obj);

        void Remove(int id);

        T GetById(int id);

        IList<T> GetList();
    }
}