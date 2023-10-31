using AutoMapper;
using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Models;
using InventoryControl.Domain.Repositories;
using InventoryControl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Application.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        private readonly DatabaseContext _context;
        public CategoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public List<CategoryResponseDto> GetAllAsync()
        {
            
            var lista = _context.Category.Select(p => new CategoryResponseDto() {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName

            }).ToList();

            return lista;
        }

        // private readonly IRepositoryBase<Domain.Entities.Product> _repositoryBase;

        // public ProductRepository(IRepositoryBase<Domain.Entities.Product> repositoryBase)
        // {
        //     _repositoryBase = repositoryBase;
        // }

        // public IEnumerable<ProductResponseDto> CreateProduct(ProductRequestDto requestDto)
        // {
        //     Product produto = new Product(request.ProductId, request.ProductName);

        //     _context.Add(produto);

        //     await _context.SaveChangesAsync();
        // }

        // public async Task CreateProduct(ProductRequestDto requestDto)
        // {
        //     Product produto = new Product(){ProductId = 12, ProductName = "teste"};


        //     _context.Add(produto);

        //     await _context.SaveChangesAsync();

        // }

        // public async Task<List<ProductResponseDto>> GetProducts()
        // {

        //     var configuration = new MapperConfiguration(cfg =>
        //     {
        //         cfg.CreateMap<Product, ProductResponseDto>();
        //     });

        //     var mapper = configuration.CreateMapper();


        //     var listProducts = _context.Products.ToList();

        //     return mapper.Map<List<ProductResponseDto>>(listProducts);



        // }




        // Task<List<ProductResponseDto>> IProductRepository.GetAllAsync()
        // {
        //     await _context.Products.ToListAsync();
        // }
    }
}