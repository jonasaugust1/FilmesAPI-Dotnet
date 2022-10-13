using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Gerente Gerente { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
