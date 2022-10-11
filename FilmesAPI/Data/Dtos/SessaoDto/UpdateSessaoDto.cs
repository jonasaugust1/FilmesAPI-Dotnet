using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class UpdateSessaoDto
    {
        [Required(ErrorMessage = "O campo CinemaId é obrigatório")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "O campo FilmeId é obrigatório")]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "O campo Estreia é obrigatório")]
        public DateTime Estreia { get; set; }

        [Required(ErrorMessage = "O campo Encerramento é obrigatório")]
        public DateTime Encerramento { get; set; }
    }
}
