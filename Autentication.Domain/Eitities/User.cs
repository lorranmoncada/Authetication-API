
using Microsoft.AspNetCore.Identity;
using System;

namespace Autentication.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}