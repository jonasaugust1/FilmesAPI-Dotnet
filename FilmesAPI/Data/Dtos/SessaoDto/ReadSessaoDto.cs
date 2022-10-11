using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }

        public Cinema Cinema { get; set; }

        public Filme Filme { get; set; }

        public DateTime Estreia { get; set; }

        public DateTime Encerramento { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
