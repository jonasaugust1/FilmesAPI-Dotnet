using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(sessaoDto);
            
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            List<ReadSessaoDto> readDto = _sessaoService.RecuperarSessoes();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperarSessoesPorId(id);
            
            if(readDto == null) return NotFound();

            return Ok(readDto); 
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result result = _sessaoService.AtualizaSessao(id, sessaoDto);

            if (result == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = _sessaoService.DeletaGerente(id);
            
            if(result == null) return NotFound();

            return NoContent();
        }
    }
}
