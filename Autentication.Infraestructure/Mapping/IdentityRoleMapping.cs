using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autentication.Infraestructure.Mapping
{
    public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.ToTable("roles");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ConcurrencyStamp).HasColumnName("concurrencystamp");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.NormalizedName).HasColumnName("normalizedname");
        }
    }
}
