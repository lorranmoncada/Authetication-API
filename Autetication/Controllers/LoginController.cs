using Autentication.Domain.Dto;
using Autentication.Domain.Entities;
using Autetication.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Autetication.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IJwtToken _jwtToken;
        public LoginController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenConfigurations tokenConfigurations,
            IJwtToken jwtToken)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenConfigurations = tokenConfigurations;
            _jwtToken = jwtToken;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Logar([FromBody] UserDto usuario)
        {

            // Verifica a existência do usuário nas tabelas do
            // ASP.NET Core Identity
            var userIdentity = _userManager.FindByNameAsync(usuario.UserName).Result;
            if (userIdentity != null)
            {
                // Efetua o login com base no Id do usuário e sua senha
                var resultadoLogin = await _signInManager.CheckPasswordSignInAsync(userIdentity, usuario.Password, false);

                return resultadoLogin.Succeeded ? Ok(await _jwtToken.GenerateToken(userIdentity)) : BadRequest("Não foi possivel realizar o login");
            }

            return BadRequest("Usuário não existente");
        }


    }
}
