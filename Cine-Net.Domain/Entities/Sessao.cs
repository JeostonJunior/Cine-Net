using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_Net.Domain.Entities
{
    public class Sessao
    {
        public Sessao()
        {
            Ingresso = new Collection<Ingresso>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Filme")]
        public int FilmeId { get; set; }

        public Filme Filme { get; set; }

        [ForeignKey("Sala")]
        public int SalaId { get; set; }
        
        public Sala Sala { get; set; }
        
        public int IngressoId { get; set; }

        public Collection<Ingresso> Ingresso { get; set; }

        public DateTime Horario { get; set; }
    }
}