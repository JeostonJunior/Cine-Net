using System.Collections.ObjectModel;

namespace Cine_Net.Domain.Entities
{
    public class Sessao
    {
        public Sessao()
        {
            Ingresso = new Collection<Ingresso>();
        }

        public int Id { get; set; }

        public int Lugares { get; set; }

        public Filme Filme { get; set; }

        public Sala Sala { get; set; }

        public double PrecoIngresso { get; set; }

        public Collection<Ingresso> Ingresso { get; set; }

        public DateTime Horario { get; set; }
    }
}