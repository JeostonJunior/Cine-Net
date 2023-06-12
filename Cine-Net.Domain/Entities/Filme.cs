using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Filme
    {
        public Filme()
        {
            Categoria = new Collection<Categoria>();
        }
                
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string AtorPrincipal { get; set; }
        public double Duracao { get; set; }
        public string Classificacao { get; set; }
        public int CategoriaId { get; set; }        
        public Collection<Categoria> Categoria { get; set; }
    }

    public class Categoria
    {
        [Key]
        [Column(Order = 2)]
        public int Id { get; set; }

        public string Categorias { get; set; }

        [Key]
        [Column(Order = 1)]
        public int FilmeId { get; set; }

        public Collection<Filme> Filme { get; set; }
    }
}