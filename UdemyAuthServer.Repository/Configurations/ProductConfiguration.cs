using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Repository.Configurations
{
    // Product entity class'ına ait configurasyon işlemlerinin yapıldığı class.
    // Bir class'ın config class'ı olabilmesi için IEntityTypeConfiguration interface'ini implement etmesi gerekir.
    // Configurasyon clsas'ının database tarafına yansıması için Context class'ı içinde ilgili metodnun içinde belirtmemiz gereklidir.

    // ProductConfiguration class
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.UserId).IsRequired();

            builder.ToTable("Products");
        }
    }
}
