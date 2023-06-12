namespace Cine_Net.Domain.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Sala> Salas { get; set; }
    }
}