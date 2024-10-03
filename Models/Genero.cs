using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaWeb.Models
{
    [Table("Generos")]
    public class Genero
    {
        public enum Assunto { Terror, Romance, Suspense, Drama, Ficcao, Didaticos }


        [Key]
        [Display(Name = "Genero")]
        public int generoId { get; set; }

        [Display(Name = "Assunto: ")]
        public Assunto assunto { get; set; }
    }
}
