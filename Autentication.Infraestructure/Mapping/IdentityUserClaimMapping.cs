using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autentication.Infraestructure.Mapping
{
    public class IdentityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.ToTable("userclaims");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClaimType).HasColumnName("claimtype");
            builder.Property(p => p.ClaimValue).HasColumnName("claimvalue");
            builder.Property(p => p.UserId).HasColumnName("userid");
        }
    }
}
