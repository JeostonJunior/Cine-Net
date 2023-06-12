using Cine_Net.Domain.Entities;

namespace Cine_Net.Infra.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        void Create(T obj);

        void Update(T obj);

        void Remove(long id);

        T Get(long id);

        IList<T> Get();
    }
}