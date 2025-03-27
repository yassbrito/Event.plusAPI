using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Event_.Domains
{
    [Table("Instituicoes")]
    [Index(nameof(CNPJ), IsUnique = true)]   
    public class Instituicoes
    {
        [Key]
        public Guid InstituicoesID { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "O endereco e obrigatorio!")]
        public string? Endereco {get; set;}

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome Fantasia e obrigatorio!")]
        public string? NomeFantasia {get; set;}

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O Cnpj e obrigatorio!")]
        [StringLength(14)]
        public string? CNPJ { get; set;}



    }
}
