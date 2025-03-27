using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid EventoID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento e  obrigatorio!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao e obrigatoria!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "a data do evento e obrigatorio!")]
        public DateTime DataEvento {get; set;}

        public Guid TiposEventosID { get; set; }

        [ForeignKey("TiposEventosID")]
        public TiposEventos? TipoEvento { get; set; }

        public Guid InstituicoesID { get; set; }

        [ForeignKey("InstituicoesID")]

        public Instituicoes? instituicao { get; set; }

        public PresencasEventos? PresencasEventos { get; set; }
    }
}
