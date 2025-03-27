using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_.Domains
{
    [Table("PresencaEvento")]
    public class PresencasEventos
    {
        [Key]
        public Guid PresencasEventoID { get; set; }

        [Column(TypeName = "Bit")]
        [Required(ErrorMessage = "O usuario e obrigatoria")]
        public bool Situacao { get; set; }

        public Guid EventoID { get; set; }

        [ForeignKey("EventoID")]
        public Evento? eventos { get; set; }

        public Guid UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario? usuario { get; set; }



    }
}
