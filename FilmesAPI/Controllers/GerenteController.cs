using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Services;
using FluentResults;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(gerenteDto);
           
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            List<ReadGerenteDto> readDto = _gerenteService.RecuperarGerentes();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperarGerentesPorId(id);

            if (readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Result result = _gerenteService.AtualizaGerente(id, gerenteDto);

            if (result.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = _gerenteService.DeletaGerente(id);
            
            if(result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
