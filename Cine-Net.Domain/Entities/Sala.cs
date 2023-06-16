using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Sala
    {
        public Sala()
        {
            Equipamentos = new Collection<Equipamentos>();
            Sessao = new Collection<Sessao>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }
     
        public int Capacidade { get; set; }

        public bool Is3D { get; set; }
       
        public int EquipamentosId { get; set; }

        public Collection<Equipamentos> Equipamentos { get; set; }

        [Required]
        public double PrecoIngresso { get; set; }
        
        public int SessaoId { get; set; }

        public Collection<Sessao> Sessao { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; } // Chave estrangeira

        public Cinema Cinema { get; set; } // Propriedade de navegação
    }
}
