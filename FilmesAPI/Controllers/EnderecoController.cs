using AutoMapper;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Services;
using FluentResults;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
           _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.AcionaEndereco(enderecoDto);
            
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            List<ReadEnderecoDto> readDto = _enderecoService.RecuperarEnderecos();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.RecuperarEnderecoPorId(id);

            if (readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoService.AtualizaEndereco(id, enderecoDto);

            if (result.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result result = _enderecoService.DeletaEndereco(id);
            
            if(result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
