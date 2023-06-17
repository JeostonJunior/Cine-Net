namespace Cine_Net.Domain.Entities
{
    public class Equipamentos
    {
        public int Id { get; set; }
        public string Itens { get; set; }
        public Sala Salas { get; set; }
    }
}