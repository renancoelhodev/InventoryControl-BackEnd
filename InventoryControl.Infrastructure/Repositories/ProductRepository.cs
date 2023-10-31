using AutoMapper;
using InventoryControl.Application.Dtos;
using InventoryControl.Domain.Models;
using InventoryControl.Domain.Repositories;
using InventoryControl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Application.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Models.Product product)
        {
            
            if(_context.Product.Where(x => x.ProductId.Equals(product.ProductId)).FirstOrDefault() != null)
            {
                throw new Exception();
            }

            _context.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productToBeDeleted = _context.Product.SingleOrDefault(item => item.ProductId == id);

            _context.Product.Remove(productToBeDeleted);

            await _context.SaveChangesAsync();
        }


        public List<ProductResponseDto> GetAllAsync()
        {
            
            var lista = _context.Product.Include(x => x.Category).Select(p => new ProductResponseDto() {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryName = p.Category.CategoryName

            }).ToList();

            return lista;
        }

        public ProductByIdResponseDto GetById(int id)
        {
            
            return _context.Product.Include(x => x.Category).Where(x => x.ProductId.Equals(id)).Select(p => new ProductByIdResponseDto() {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryId = p.Category.CategoryId
            }).FirstOrDefault();

        }

        public async Task Update(int id, Product dto)
        {
            
            var productToBeUpdated = _context.Product.SingleOrDefault(p => p.ProductId == id);
            _context.Entry(productToBeUpdated).CurrentValues.SetValues(dto);

            await _context.SaveChangesAsync();
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