using Cine_Net.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cine_Net.Infra.Context
{
    public class DataBase : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataBase()
        {
        }

        //puxo a string de conexão por construtor, OBS: tem que ter um construtor vazio iniciando a classe, NÃO remova
        public DataBase(DbContextOptions<DataBase> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Cinema> Cinema { get; set; }

        public DbSet<Sala> Sala { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Equipamentos> Equipamentos { get; set; }

        public DbSet<Sessao> Sessao { get; set; }

        public DbSet<Filme> Filme { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Ingresso> Ingresso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("Cine-Net");

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-E63H78O;Initial Catalog=Cine-Net;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                 .HasMany(c => c.Filme)
                 .WithMany(f => f.Categoria)
                 .UsingEntity<Dictionary<string, object>>(
                     "FilmeCategoria",
                     j => j.HasOne<Filme>().WithMany().HasForeignKey("FilmeId"),
                     j => j.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId"),
                     j =>
                     {
                         j.HasKey("CategoriaId", "FilmeId");
                         j.HasIndex("FilmeId");
                     }
                 );

            modelBuilder.Entity<Equipamentos>()
                .HasKey(e => e.Id); // Define a chave primária

            modelBuilder.Entity<Equipamentos>()
                .HasOne(e => e.Salas) // Define a propriedade de navegação para Sala
                .WithMany(s => s.Equipamentos) // Define a propriedade de navegação inversa em Sala
                .HasForeignKey(e => e.SalaId);

            modelBuilder.Entity<Sala>()
                .HasOne(s => s.Cinema) // Configura o relacionamento com Cinema
                .WithMany(c => c.Salas) // Uma sala tem um cinema, um cinema pode ter várias salas
                .HasForeignKey(s => s.CinemaId) // Chave estrangeira em Sala
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Sessao)
                .WithOne(s => s.Sala)
                .HasForeignKey(s => s.SalaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sessao>()
                .HasOne(s => s.Filme) // Configura o relacionamento com Filme
                .WithMany(f => f.Sessao) // Um filme pode ter várias sessões
                .HasForeignKey(s => s.FilmeId) // Chave estrangeira em Sessao
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

            modelBuilder.Entity<Sessao>()
                .HasOne(s => s.Sala) // Configura o relacionamento com Sala
                .WithMany(s => s.Sessao) // Uma sessão pertence a uma sala
                .HasForeignKey(s => s.SalaId) // Chave estrangeira em Sessao
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

            modelBuilder.Entity<Ingresso>()
                .HasOne(i => i.Cliente) // Configura o relacionamento com Cliente
                .WithMany(c => c.Ingresso) // Um cliente pode ter vários ingressos
                .HasForeignKey(i => i.ClienteId) // Chave estrangeira em Ingresso
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

            modelBuilder.Entity<Ingresso>()
                .HasOne(i => i.Sessao) // Configura o relacionamento com Sessao
                .WithMany(s => s.Ingresso) // Uma sessão pode ter vários ingressos
                .HasForeignKey(i => i.SessaoId) // Chave estrangeira em Ingresso
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Ingresso) // Configura o relacionamento com Ingresso
                .WithOne(i => i.Cliente) // Um ingresso pertence a um cliente
                .HasForeignKey(i => i.ClienteId) // Chave estrangeira em Ingresso
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}