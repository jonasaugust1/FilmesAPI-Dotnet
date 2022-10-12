using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperarGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            List<ReadGerenteDto> readDto = _mapper.Map<List<ReadGerenteDto>>(gerentes);

            return readDto;
        }

        public ReadGerenteDto RecuperarGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;
            }

            return null;
        }

        internal Result AtualizaGerente(int id, UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return Result.Fail("Gerente não encontrado");

            _mapper.Map(gerenteDto, gerente);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return Result.Fail("Gerente não encontrado");

            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
