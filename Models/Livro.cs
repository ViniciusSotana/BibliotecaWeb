using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Models
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        [Display(Name ="Livro: ")]
        public int livroId { get; set; }

        [Display(Name = "Titulo: ")]
        [Required(ErrorMessage = "Campo Titulo é obrigatório")]
        public string titulo { get; set; }

        [Display(Name = "Autor: ")]
        public int autorId { get; set; }

        [Display(Name = "Autor: ")]
        public Autor autor { get; set; }



        [Display(Name = "Genero: ")]
        public int generoId { get; set; }

        [Display(Name = "Genero: ")]
        public Genero genero { get; set; }



        [Display(Name = "Ano de Publicacao: ")]
        [Required(ErrorMessage = "Campo ano de publicação é obrigatório")]
        public int publicacao { get; set; }

        [Display(Name = "Quantia em Estoque: ")]
        public int quantiaEstoque { get; set; }
    }
}