using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaWeb.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        [Display(Name = "Genero")]
        public int generoId { get; set; }

        [Display(Name = "Assunto: ")]
        public String assunto { get; set; }
    }
}
