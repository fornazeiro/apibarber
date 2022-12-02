using Barber.Api.Services;
using BarberApi.Entidades;
using BarberApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Barber.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Logar")]
        public async Task<ActionResult<dynamic>> Logar([FromBody] Login model)
        {                
            BarberApi.Negocios.Login nLogin = new BarberApi.Negocios.Login();

            var usuario = nLogin.Logon(model);

            if (usuario == null || usuario.Id == 0)
            {
                var ret = new Retorno<Usuario>
                {
                    Mensagem = "Usuário ou senha inválidos",
                    Sucesso = true,
                    ObjetoRetorno = new Usuario()
                };

                return ret;
            }

            var token = TokenService.GenerateToken(usuario);

            usuario.Senha = "";

            var retorno = new Retorno<Usuario>
            {
                Token = new BarberApi.Entidades.Token.TokenSecurity
                {
                    Criacao = DateTime.UtcNow,
                    Expira = DateTime.UtcNow.AddHours(24),
                    Token = token,
                    Autenticado = true
                },
                ObjetoRetorno = usuario
            };

            return retorno;
        }
    }
}
