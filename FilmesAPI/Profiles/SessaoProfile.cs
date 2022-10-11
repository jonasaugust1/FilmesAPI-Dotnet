using AutoMapper;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.Estreia, opts => opts
                .MapFrom(dto =>
                dto.Encerramento.AddMinutes(dto.Filme.Duracao * (-1))));
            CreateMap<UpdateSessaoDto, Sessao>();

        }
    }
}
