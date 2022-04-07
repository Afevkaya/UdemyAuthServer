using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Repository.Configurations
{
    // Oluşturduğumuz UserApp entity classına ait config işlemleri.
    // Bir class'ın config class'ı olabilmesi için IEntityTypeConfiguration interface'ini implement etmesi gerekir.
    // Configurasyon clsas'ının database tarafına yansıması için Context class'ı içinde ilgili metodnun içinde belirtmemiz gereklidir.

    // UserAppConfiguration class
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.Property(x => x.City).HasMaxLength(50);
        }
    }
}
