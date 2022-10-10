﻿using AutoMapper;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                 .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (cinema => new { cinema.Id, cinema.Nome, cinema.Endereco, cinema.EnderecoId })));
            CreateMap<UpdateGerenteDto, Gerente>();
               
        }
    }
}
