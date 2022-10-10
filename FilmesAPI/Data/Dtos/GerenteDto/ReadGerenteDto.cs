using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.GerenteDto
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        public object Cinemas { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
