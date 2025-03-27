using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_.Domains
{
    [Table("TipoUsuario")]
    public class TiposUsuarios
    {
        [Key] 
        public Guid TiposUsuariosID {  get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O titulo do tipo de usuario e obrigatorio")]
        public string? TituloTipoUsuario { get; set; }
    }
}
