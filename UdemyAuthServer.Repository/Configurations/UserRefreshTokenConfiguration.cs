using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Repository.Configurations
{
    // UserRefreshToken class'ına ait config işlemlerinin yapıldığı class
    // Bir class'ın config class'ı olabilmesi için IEntityTypeConfiguration interface'ini implement etmesi gerekir.
    // Configurasyon clsas'ının database tarafına yansıması için Context class'ı içinde ilgili metodnun içinde belirtmemiz gereklidir.

    // UserRefreshTokenConfiguration class
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
        }
    }
}
