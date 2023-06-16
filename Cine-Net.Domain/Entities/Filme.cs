using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Filme
    {
        public Filme()
        {
            Categoria = new Collection<Categoria>();
            Sessao = new Collection<Sessao>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string AtorPrincipal { get; set; }
        public double Duracao { get; set; }
        public string Classificacao { get; set; }

        public int SessaoId { get; set; }
        
        public Collection<Sessao> Sessao { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public Collection<Categoria> Categoria { get; set; }
    }
}