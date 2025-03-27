using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Event_.Domains
{
        [Table("Usuario")]
        [Index(nameof(Email), IsUnique = true)]
        
    public class Usuario
    {
        [Key]
            public Guid UsuarioID { get; set; }


            [Column(TypeName = "VARCHAR(50)")]
            [Required(ErrorMessage = "O nome e obrigatorio!")]
            public string? NomeUsuario { get; set; }

            [Column(TypeName = "VARCHAR(50)")]
            [Required(ErrorMessage = "O email e obrigatorio!")]

            public string? Email { get; set; }

            [Column(TypeName = "VARCHAR(60)")]
            [Required(ErrorMessage = "A senha e obrigatoria!")]
            [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter no minimo 5 caracteres e no maximo 30")]

            public string? Senha { get; set; }
        
             public Guid TipoUsuarioID { get; set; }
             [ForeignKey("TiposUsuariosID")]
             public TiposUsuarios? TipoUsuario { get; set; }
    }
}
