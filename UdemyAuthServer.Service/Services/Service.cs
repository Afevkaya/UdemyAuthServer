using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System.Linq.Expressions;
using UdemyAuthServer.Core.Repositories;
using UdemyAuthServer.Core.Services;
using UdemyAuthServer.Core.UnitOfWorks;
using UdemyAuthServer.Service.Mapping;

namespace UdemyAuthServer.Service.Services
{
    // Core katmanında yazılan Generic IService interface'ini implement eden class.
    // IService interface içinde bulunan metodların gövdelerini yazdığımız class

    // Generic Service class
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        
        public Service(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;  
        }

        // Asenkron ekleme metodu
        public async Task<CustomResponseDto<TDto>> AddAsync(TDto dto)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return CustomResponseDto<TDto>.Success(201, newDto);
        }

        // Asenkron bütün dataları çekme metodu
        public async Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var entites = await _repository.GetAllAsync();
            if (entites == null)
            {
                return CustomResponseDto<IEnumerable<TDto>>.Fail(404, "Not Found", true);
            }

            var dtos = ObjectMapper.Mapper.Map<List<TDto>>(entites);
            return CustomResponseDto<IEnumerable<TDto>>.Success(200, dtos);
        }

        // Asenkron Id'ye göre data çekme metodu
        public async Task<CustomResponseDto<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            // Business rule
            if (entity == null)
            {
                return CustomResponseDto<TDto>.Fail(404, "Not found", true);
            }
            var dto = ObjectMapper.Mapper.Map<TDto>(entity);
            return CustomResponseDto<TDto>.Success(200, dto);
        }

        // Asenkron silme metodu
        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);
            
            // Business rule
            if(isExistEntity == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Id Not Found", true);
            }
            _repository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        // Asenkron güncelleme metodu
        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(TDto dto, int id)
        {  
            var isExistEntity = await _repository.GetByIdAsync(id);
            
            // Business rule
            if (isExistEntity == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Id Not Found", true);
            }
            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            _repository.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        // Asenkron sorgulama metodu
        public async Task<CustomResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var list = _repository.Where(expression);
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync());
            return CustomResponseDto<IEnumerable<TDto>>.Success(200, dtos);
        }
    }
}
