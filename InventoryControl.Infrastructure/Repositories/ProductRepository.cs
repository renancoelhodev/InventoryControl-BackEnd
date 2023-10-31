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
            
            return _context.Product.Include(x => x.Category).Select(p => new ProductResponseDto() {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryName = p.Category.CategoryName

            }).ToList();

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

    }
}