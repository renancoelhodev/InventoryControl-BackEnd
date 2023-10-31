using InventoryControl.Application.Dtos;
using InventoryControl.Application.Services;
using InventoryControl.Application.Services.CategoryService;
using InventoryControl.Contracts.Products;
using InventoryControl.Domain.Models;
using InventoryControl.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorProdutos.API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CategoryController: ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ICategoryService _categoryService;
        
        public CategoryController(DatabaseContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var lista = _categoryService.GetCategories();

            return StatusCode(200, lista);
        }
    }
}