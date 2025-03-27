using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid ComentarioEventoID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A descricao e obrigatoria")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "o exibir e obrigatorio")]
        public bool Exibe {  get; set; }  
        
        [Required(ErrorMessage ="O usuario e obrigatorio")]

        public Guid UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario? usuario {  get; set; }

        public Guid EventoID { get; set; }

        [ForeignKey("EventoID")]
        public Evento? evento { get; set; }
    }
}
