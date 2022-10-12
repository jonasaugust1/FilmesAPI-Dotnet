using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.EnderecoDto
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
