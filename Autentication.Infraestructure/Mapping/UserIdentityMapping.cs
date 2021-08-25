using Autentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autentication.Infraestructure.Mapping
{
    public class UserIdentityMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FirstName).HasColumnName("firstname");
            builder.Property(p => p.LastName).HasColumnName("lastname");
            builder.Property(p => p.AccessFailedCount).HasColumnName("accessfailedcount");
            builder.Property(p => p.ConcurrencyStamp).HasColumnName("concurrencystamp");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.EmailConfirmed).HasColumnName("emailconfirmed");
            builder.Property(p => p.LockoutEnabled).HasColumnName("lockoutenabled");
            builder.Property(p => p.LockoutEnd).HasColumnName("lockoutend");
            builder.Property(p => p.NormalizedEmail).HasColumnName("normalizedemail");
            builder.Property(p => p.NormalizedUserName).HasColumnName("normalizedusername");
            builder.Property(p => p.PasswordHash).HasColumnName("passwordhash");
            builder.Property(p => p.PhoneNumber).HasColumnName("phonenumber");
            builder.Property(p => p.PhoneNumberConfirmed).HasColumnName("phonenumberconfirmed");
            builder.Property(p => p.SecurityStamp).HasColumnName("securitystamp");
            builder.Property(p => p.TwoFactorEnabled).HasColumnName("twofactorenabled");
            builder.Property(p => p.UserName).HasColumnName("username");
        }
    }
}
