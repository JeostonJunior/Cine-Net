using System.Collections.ObjectModel;

namespace Cine_Net.Domain.Entities
{
    public class Cinema
    {
        public Cinema()
        {
            Salas = new Collection<Sala>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public double PrecoWeek { get; set; }

        public double PrecoWeekend { get; set; }

        public Collection<Sala> Salas { get; set; }
    }
}