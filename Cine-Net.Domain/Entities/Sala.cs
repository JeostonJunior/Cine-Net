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
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public bool Is3D { get; set; }
        public int EquipamentosId { get; set; }
        public Collection<Equipamentos> Equipamentos { get; set; }
        public double PrecoIngresso { get; set; }
        public List<Sessao> Sessao { get; set; }
    }

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