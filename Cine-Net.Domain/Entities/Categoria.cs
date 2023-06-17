using System.Collections.ObjectModel;

namespace Cine_Net.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Filme = new Collection<Filme>();
        }

        public int Id { get; set; }

        public string Categorias { get; set; }

        public Collection<Filme> Filme { get; set; }
    }
}