using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Models;


namespace InventoryControl.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase
    {
        
        List<ProductResponseDto> GetAllAsync();
        Task AddAsync(Product product);

        ProductByIdResponseDto GetById(int id);

        Task DeleteAsync(int id);

        Task Update(int id, Product product);
         
    }
}