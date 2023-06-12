namespace Cine_Net.Domain.Entities
{
    public class Sessao
    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
    }
}