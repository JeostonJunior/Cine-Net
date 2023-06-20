using System.Collections.ObjectModel;

namespace Cine_Net.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Ingresso = new Collection<Ingresso>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public bool IsEstudante { get; set; }

        public Collection<Ingresso> Ingresso { get; set; }
    }
}