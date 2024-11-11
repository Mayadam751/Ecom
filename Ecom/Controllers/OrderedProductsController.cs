using Ecom.DAL;
using Ecom.DAL.Entities;
using Ecom.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderedProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllOrderedProducts()
        {
            var OrderedProducts = _context.OrderedProducts.ToList();
            return Ok(OrderedProducts);
        }
        [HttpPost]
        public IActionResult CreateOrderedProducts(OrderedProductsDto OPDto)
        {
            var OrderedProduct = new OrderedProduct
            {
                OrderId = OPDto.OrderId,
                ProductId = OPDto.ProductId,
            };
            if (!(OPDto.OrderId == null))
            {

                _context.Add(OrderedProduct);
                _context.SaveChanges();

            }
            return Ok(OrderedProduct);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderedProduct(int id)
        {
            var product = _context.OrderedProducts.FirstOrDefault(p => p.Id == id);
            if (!(product == null))
                return NotFound(value: $"not found");
            _context.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

    }
}
    


