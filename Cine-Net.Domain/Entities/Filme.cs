using System.Collections.ObjectModel;

namespace Cine_Net.Domain.Entities
{
    public class Filme
    {
        public Filme()
        {
            Sessao = new Collection<Sessao>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string AtorPrincipal { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Categoria { get; set; }

        public Collection<Sessao> Sessao { get; set; }

    }
}