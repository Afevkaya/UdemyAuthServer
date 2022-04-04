using SharedLibrary.Dtos;
using System.Linq.Expressions;

namespace UdemyAuthServer.Core.Services
{
    // SERVİCE LER GERİYE DTO CLASS DÖNERLER. ÇÜNKÜ DATAYI TÜKETECEK OLAN KATMAN UI KATMANIDIR.
    // TEntity class TDto classa çevrilecek.
    public interface IService<TEntity,TDto> where TEntity : class where TDto : class
    {
        Task<CustomResponseDto<TDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<CustomResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression);
        Task<CustomResponseDto<TDto>> AddAsync();
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(TEntity entity);
        
    }
}
