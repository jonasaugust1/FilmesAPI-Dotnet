using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            Result result = _cadastroService.CadastraUsuario(usuarioDto);

            if (result.IsFailed) return StatusCode(500);

            return Ok(result.Successes.First());
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result result = _cadastroService.AtivaContaUsuario(request);

            if (result.IsFailed) return StatusCode(500);

            return Ok(result.Successes);
        }
    }
}
