using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Models;


namespace InventoryControl.Domain.Repositories
{
    public interface ICategoryRepository : IRepositoryBase
    {
        
        List<CategoryResponseDto> GetAllAsync();
        
         
    }
}