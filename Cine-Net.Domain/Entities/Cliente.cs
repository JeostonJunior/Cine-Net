namespace Cine_Net.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool IsEstudante { get; set; }
    }
}