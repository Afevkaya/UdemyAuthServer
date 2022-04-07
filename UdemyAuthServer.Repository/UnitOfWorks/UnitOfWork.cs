using UdemyAuthServer.Core.UnitOfWorks;

namespace UdemyAuthServer.Repository.UnitOfWorks
{
    // IUnitOfWork interface'ini implement eden class
    // UnitOfWork class'ı Unit Of Work design pattern'ı projede uygulamamızı sağlar.
    // Unit Of Work design pattern'ı uygulanması gereken katman service layer'dır.

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
