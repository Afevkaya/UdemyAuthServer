using UdemyAuthServer.Core.UnitOfWorks;

namespace UdemyAuthServer.Repository.UnitOfWorks
{
    // IUnitOfWork interface'ini implement eden class
    // Bu class Unit Of Work desig pattern'ı uygulamamzı sağlıyor.

    // UnitOfWork class
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
