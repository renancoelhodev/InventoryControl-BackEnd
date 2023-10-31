using InventoryControl.Application.Dtos;
using InventoryControl.Application.Services;
using InventoryControl.Contracts.Products;
using InventoryControl.Domain.Models;
using InventoryControl.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorProdutos.API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ProductsController: ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IProductService _productService;
        
        public ProductsController(DatabaseContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        
        [HttpGet]
        public async Task<ActionResult> GetProdutosAsync()
        {
            var lista = _productService.GetProducts();

            return StatusCode(200, lista);
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            
            var lista = _productService.GetById(id);

            return StatusCode(200, lista);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProducts(ProductRequest request)
        {
            try {
                var requestDto = new ProductRequestDto(request.ProductId, request.ProductName, request.CategoryId);
                await _productService.CreateProduct(requestDto);
            
                return StatusCode(201);
            }
            catch(Exception) {
                return StatusCode(400);
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProducts(int id)
        {
            
            _productService.DeleteProduct(id);
            

            return StatusCode(204);
        }

    
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductRequest request)
        {
            var requestDto = new ProductRequestDto(request.ProductId, request.ProductName, request.CategoryId);
            await _productService.UpdateProduct(id, requestDto);
            
            return StatusCode(200);
        }
    }
}