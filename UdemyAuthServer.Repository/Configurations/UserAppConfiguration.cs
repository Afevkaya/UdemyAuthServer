using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Repository.Configurations
{
    // Oluşturduğumuz UserApp entity classına ait config işlemleri.

    // UserAppConfiguration class
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.Property(x => x.City).HasMaxLength(50);
        }
    }
}
