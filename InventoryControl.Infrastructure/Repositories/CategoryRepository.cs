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
            
            return _context.Category.Select(p => new CategoryResponseDto() {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName
            }).ToList();
        }

    }
}