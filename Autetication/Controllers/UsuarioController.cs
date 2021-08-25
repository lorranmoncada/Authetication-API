using Autentication.Domain.Dto;
using Autentication.Domain.Entities;
using Autetication.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autetication.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        // opçoes para trabalhar em cima do usuário
        private readonly UserManager<User> _userManager;
        //autentica o usuário
        private readonly SignInManager<User> _signInManager;

        public UsuarioController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("criar-conta")]
        public async Task<IActionResult> CriarConta([FromBody] UserDto usuario)
        {
            var createdUser = new IdentityResult();
            var user = new User()
            {
                UserName = usuario.UserName,
                EmailConfirmed = usuario.ConfirmEmail,
                Email = usuario.Email,
                FirstName = usuario.FirstName,
                LastName = usuario.LastName
            };

            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserName))
            {
                var userIdentity = await _userManager.FindByNameAsync(usuario.UserName);

                if (userIdentity == null)
                {
                    createdUser = await CreateUser(user, usuario.Password);
                }
            }

            if (createdUser.Succeeded)
            {
                var resultadoLogin = _signInManager.CheckPasswordSignInAsync(user, usuario.Password, false).Result;
                await _signInManager.SignInAsync(user, false);
            }

            return createdUser.Succeeded ? Ok() : BadRequest("Usuário ja existente");
        }

        private async Task<IdentityResult> CreateUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result;
        }

        [HttpGet]
        [Route("sem-verificar-claims")]
        [Authorize]
        public string SemVerificarClaims()
        {
            return "Sem verificar claims";
        }

        [HttpGet]
        [Route("verificando-roles")]
        [Authorize(Roles = "Admin")]
        public string VerificandoRoles()
        {
            return "Verificando roles";
        }

        [HttpGet]
        [Route("verificando-clayms")]
        [ClaimsAuthorize("Teste", "Acesso-Outro")] // FitlroCustomizado para autenticação
        public string VerificandoClayms()
        {
            return "Verificando clayms";
        }     
    }
}
