using System.Collections.ObjectModel;

namespace Cine_Net.Domain.Entities
{
    public class Sala
    {
        public Sala()
        {
            Equipamentos = new List<String>();
            Sessao = new Collection<Sessao>();
        }

        public int Id { get; set; }

        public int Numero { get; set; }

        public int Capacidade { get; set; }

        public bool Is3D { get; set; }

        public List<String> Equipamentos { get; set; }

        public Collection<Sessao> Sessao { get; set; }

        public Cinema Cinema { get; set; }
    }
}