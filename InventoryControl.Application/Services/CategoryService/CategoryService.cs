using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Repositories;

namespace InventoryControl.Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;       
        }
        public List<CategoryResponseDto> GetCategories()
        {
            var retorno = _categoryRepository.GetAllAsync();
            return retorno;
        }
    }
}