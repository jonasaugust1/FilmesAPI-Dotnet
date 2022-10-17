using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;
        
        public CadastroService(IMapper mapper, 
            UserManager<CustomIdentityUser> userManager, 
            EmailService emailService
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            CustomIdentityUser identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);
            
            IdentityResult identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            
            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário");
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            CustomIdentityUser identityUser = _mapper.Map<CustomIdentityUser>(usuario);
            IdentityResult resultadoIdentiy = _userManager
                .CreateAsync(identityUser, createDto.Password).Result;

            _userManager.AddToRoleAsync(identityUser, "user");

            if (resultadoIdentiy.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;

                string encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new[] { identityUser.Email },
                    "Link de Ativação", identityUser.Id, encodedCode);

                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

    }
}
