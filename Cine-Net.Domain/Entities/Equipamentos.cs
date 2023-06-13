using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Equipamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Itens { get; set; }

        public int SalaId { get; set; }

        public Sala Salas { get; set; }
    }
}
