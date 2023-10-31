using InventoryControl.Application.Dtos;

namespace InventoryControl.Application.Services.CategoryService
{
    public interface ICategoryService
    {
         List<CategoryResponseDto> GetCategories();
    }
}