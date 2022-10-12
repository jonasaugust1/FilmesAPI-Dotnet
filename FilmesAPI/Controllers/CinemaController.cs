using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.CinemaDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);
           
            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string? nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperarCinemas(nomeDoFilme);
           
            if(readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperarCinemaPorId(id);
           
            if(readDto==null) return NotFound();

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.AtualizaCinema(id, cinemaDto);

            if (result.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result result = _cinemaService.DeletaCinema(id);
           
            if(result == null) return NotFound();

            return NoContent();
        }
    }
}
