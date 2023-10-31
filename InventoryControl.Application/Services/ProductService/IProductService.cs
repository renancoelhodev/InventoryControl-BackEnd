using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Models;

namespace InventoryControl.Application.Services
{
    public interface IProductService
    {
        Task CreateProduct(ProductRequestDto request);

        List<ProductResponseDto> GetProducts();

        ProductByIdResponseDto GetById(int id);

        Task DeleteProduct(int id);

        Task UpdateProduct(int id, ProductRequestDto request);

    }
}