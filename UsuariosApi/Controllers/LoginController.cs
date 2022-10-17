﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
           Result result = _loginService.LogaUsuario(request);

            if(result.IsFailed) return Unauthorized(result.Errors);
           
            return Ok(result.Successes[0]);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result result = _loginService.SolicitaResetSenhaUsuario(request);

            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes.First());
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result result = _loginService.ResetaSenhaUsuario(request);

            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes.First());
        }
    }
}
