using Cine_Net.Domain.Entities;

namespace Cine_Net.Infra.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Cinema> CinemaRepository { get; }
        IRepository<Sala> SalaRepository { get; }
        IRepository<Filme> FilmeRepository { get; }   
        IRepository<Sessao> SessaoRepository { get; }

        void SaveChanges();
    }
}
