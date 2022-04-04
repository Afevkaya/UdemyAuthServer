using SharedLibrary.DTOs;
using System.Linq.Expressions;

namespace UdemyAuthServer.Core.Services
{
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
