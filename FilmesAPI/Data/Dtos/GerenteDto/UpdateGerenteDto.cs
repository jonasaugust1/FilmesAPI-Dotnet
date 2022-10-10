using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.GerenteDto
{
    public class UpdateGerenteDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
    }
}
