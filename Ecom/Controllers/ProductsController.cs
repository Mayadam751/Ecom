using Ecom.DAL;
using Ecom.DAL.Entities;
using Ecom.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var Product = new Product
            {
                ProductName = dto.Name,
                Code = dto.Code,
                Price = dto.Price
            };
            _context.Add(Product);
            _context.SaveChanges();
            return Ok(Product);
        }
        [HttpPut("{id}")]
        public IActionResult Updateproduct(int id, CreateProductDto dto)
        {
            var product =_context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound(value: $"not found");
            product.ProductName = dto.Name;
            product.Code = dto.Code;
            product.Price = dto.Price;
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id );
            if (product == null)
                return NotFound(value: $"not found");
            _context.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

    }
}
