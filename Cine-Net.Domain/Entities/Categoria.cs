using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Filme = new Collection<Filme>();
        }

        [Key]        
        public int Id { get; set; }

        public string Categorias { get; set; }

        [ForeignKey("Filme")]
        public int FilmeId { get; set; }
        
        public Collection<Filme> Filme { get; set; }
    }
}