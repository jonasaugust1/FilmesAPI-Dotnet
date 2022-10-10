using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class ReadCinemaDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
