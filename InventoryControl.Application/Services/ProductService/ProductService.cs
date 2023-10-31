using AutoMapper;
using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Models;
using InventoryControl.Domain.Repositories;

namespace InventoryControl.Application.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
        
            _productRepository = productRepository;
            
        }
        public async Task CreateProduct(ProductRequestDto request){
            
            try {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductRequestDto, Product>();
                });
                var mapper = configuration.CreateMapper();  
                var mapped = mapper.Map<Product>(request);

                
                await _productRepository.AddAsync(mapped);
            }catch(Exception ex){
                throw ex;
            }
            
        }

        public List<ProductResponseDto> GetProducts()
        {
            return _productRepository.GetAllAsync();
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);

        }

        public async Task UpdateProduct(int id, ProductRequestDto request)
        {

            var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductRequestDto, Product>();
                });
            
            var mapper = configuration.CreateMapper();  
            
            var mapped = mapper.Map<Product>(request);

            await _productRepository.Update(id, mapped);
        }

        public ProductByIdResponseDto GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        
    }
}