﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string? Diretor { get; set; }

        [StringLength(50, ErrorMessage = "O gênero deve ter no máximo 50 caracteres")]
        public string? Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter entre 1 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
