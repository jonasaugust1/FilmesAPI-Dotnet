using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class CreateSessaoDto
    {
        [Required(ErrorMessage = "O campo CinemaId é obrigatório")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "O campo FilmeId é obrigatório")]
        public int FilmeId { get; set; }

        public DateTime Estreia { get; set; }

        public DateTime Encerramento { get; set; }
    }
}
