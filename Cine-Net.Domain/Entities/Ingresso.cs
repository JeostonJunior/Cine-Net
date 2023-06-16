using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        
        public Cliente Cliente { get; set; }


        [ForeignKey("Sessao")]
        public int SessaoId { get; set; }
      
        public Sessao Sessao { get; set; }

        public double Valor { get; set; }
    }
}