using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_.Domains
{
    [Table("TiposEventos")]
    public class TiposEventos
    {
        [Key]
        public Guid TiposEventosID {  get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O titulo do tipo de evento e obrigatorio")]
        public string? TituloTipoEvento{ get; set; }
       
    }
}
