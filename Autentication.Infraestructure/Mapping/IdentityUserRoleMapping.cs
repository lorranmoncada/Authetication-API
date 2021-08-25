using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autentication.Infraestructure.Mapping
{
    public class IdentityUserRoleMapping : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.ToTable("userroles");
            builder.Property(p => p.RoleId).HasColumnName("roleid");
            builder.Property(p => p.UserId).HasColumnName("userid"); ;
        }
    }
}
