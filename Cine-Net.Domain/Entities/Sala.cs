using System.Collections.ObjectModel;

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
}