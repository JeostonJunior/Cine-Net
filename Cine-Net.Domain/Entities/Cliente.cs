using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Ingresso = new Collection<Ingresso>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        public bool IsEstudante { get; set; }

        public int IngressoId { get; set; }
        public Collection<Ingresso> Ingresso { get; set; }
    }
}
