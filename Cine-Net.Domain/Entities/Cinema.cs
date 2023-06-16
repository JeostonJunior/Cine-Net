using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Cinema
    {
        public Cinema()
        {
            Salas = new Collection<Sala>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Endereco { get; set; }

        [ForeignKey("Sala")]
        public int SalaId { get; set; }

        [ForeignKey("SalaId")]
        public Collection<Sala> Salas { get; set; }
    }
}