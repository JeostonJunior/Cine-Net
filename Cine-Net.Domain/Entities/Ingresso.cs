namespace Cine_Net.Domain.Entities
{
    public class Ingresso
    {
        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        public Sessao Sessao { get; set; }

        public double Valor { get; set; }
    }
}