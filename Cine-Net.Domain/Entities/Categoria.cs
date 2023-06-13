using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
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
