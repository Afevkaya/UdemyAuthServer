using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Repository
{
    // Db tabloları ile entity classlarını maplediğimiz class.
    // Bu sefer IdentityDbContext classı inherit ettik.
    // User ile ilgili DbSetler hazır olduğu için geri kalan entityleri DbSet'e ekledik.

    // AppDbContext class.
    public class AppDbContext : IdentityDbContext<UserApp,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        // Config işlemlerinin yapıldığı metod
        // Congig işlemleri başaka bir class içerisinde yapılıyorsa o classı bu metod içerisinde bildirmemiz gerekli.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
