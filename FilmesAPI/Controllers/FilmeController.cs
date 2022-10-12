using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.FilmeDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);

            if(readDto == null)
            {
                return NotFound();
            }

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorID(id);
            
            if(readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result= _filmeService.AtualizaFilme(id, filmeDto);
            
            if(result.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result result = _filmeService.DeletaFilme(id);

            if (result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
