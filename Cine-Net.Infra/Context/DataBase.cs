using Cine_Net.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine_Net.Infra.Context
{
    public class DataBase : DbContext
    {
        //puxo a string de conexão por construtor, OBS: tem que ter um construtor vazio iniciando a classe, NÃO remova       
        public DataBase()
        {
        }

        public DataBase(DbContextOptions<DataBase> options) : base(options)
        { }


        public DbSet<Cinema> Cinema { get; set; }

        public DbSet<Sala> Sala { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Equipamentos> Equipamentos { get; set; }

        public DbSet<Sessao> Sessao { get; set; }

        public DbSet<Filme> Filme { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Ingresso> Ingresso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //NÃO mexa, só deus sabe o que eu fiz aqui, não lembro mais
            modelBuilder.Entity<Filme>()
            .HasMany(f => f.Categoria)
            .WithMany(c => c.Filme)
            .UsingEntity<Dictionary<string, object>>(
            "FilmeCategoria",
            j => j.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId"),
            j => j.HasOne<Filme>().WithMany().HasForeignKey("FilmeId"),
            j =>
            {
                j.HasKey("FilmeId", "CategoriaId");
                j.HasIndex("CategoriaId");
            }
        );

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.Id);
        }
    }
}