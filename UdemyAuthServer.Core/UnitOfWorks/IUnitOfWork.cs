namespace UdemyAuthServer.Core.UnitOfWorks
{
    // Unit Of Work design pattern'ı kullanan interface

    // IUnitOfWork interface
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
