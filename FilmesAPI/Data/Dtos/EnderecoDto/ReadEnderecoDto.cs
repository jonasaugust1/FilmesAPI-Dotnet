﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.EnderecoDto
{
    public class ReadEnderecoDto
    {
        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string Estado { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
