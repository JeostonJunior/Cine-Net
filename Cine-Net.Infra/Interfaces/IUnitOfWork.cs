using Cine_Net.Domain.Entities;

namespace Cine_Net.Infra.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryCache<Cinema> CinemaRepository { get; }
        IRepositoryCache<Sala> SalaRepository { get; }
        IRepositoryCache<Filme> FilmeRepository { get; }
        IRepositoryCache<Sessao> SessaoRepository { get; }

        void SaveChanges();
    }
}