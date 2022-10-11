using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Filme Filme { get; set; }

        [Required(ErrorMessage = "O campo FilmeId é obrigatório")]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "O campo CinemaId é obrigatório")]
        public int CinemaId { get; set; }

        public DateTime Estreia { get; set; }

        public DateTime Encerramento { get; set; } 
    }
}
