using Autentication.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Autetication.Token
{
    public class JwtToken : IJwtToken
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenConfigurations _tokenConfigurations;

        public JwtToken(UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenConfigurations tokenConfigurations)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenConfigurations = tokenConfigurations;
        }

        public async Task<string> GenerateToken(User usuario)
        {
            var identityClaims = new ClaimsIdentity();
            // pega as claims do usuário que estão cadastradas na base
            var claims = await _userManager.GetClaimsAsync(usuario);
            // pega as roles do usuário que estão cadastradas na base
            var roles = await _userManager.GetRolesAsync(usuario);
            var claimsRole = roles.Select(role => new Claim(ClaimTypes.Role, role));

            identityClaims.AddClaims(claims);
            identityClaims.AddClaims(claimsRole);

            var key = Encoding.ASCII.GetBytes(_tokenConfigurations.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Emissor,
                Audience = _tokenConfigurations.ValidoEm,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_tokenConfigurations.Expiracao)
            };

            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return token;
        }
    }
}
