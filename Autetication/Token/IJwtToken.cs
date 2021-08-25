using Autentication.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autetication.Token
{
    public interface IJwtToken
    {
        public Task<string> GenerateToken(User usuario);
    }
}
