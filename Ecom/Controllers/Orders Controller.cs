using Ecom.DAL;
using Ecom.DAL.Entities;
using Ecom.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders_Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public Orders_Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderDto Odto)
        {
           // var SelectedCustomer = _context.Users.FirstOrDefault(u => u.Id == Odto.uID);
            var SelectedProducts = new List<OrderedProduct>();
            foreach (var productId in Odto.productIds)
            {
                var SelectedProduct = _context.Products.FirstOrDefault(p => p.Id == productId);
                var SelectedOrderedProduct = new OrderedProduct { Product = SelectedProduct };
                SelectedProducts.Add(SelectedOrderedProduct);
            }
            var Order = new order
            {
                QTY = Odto.QTY,
                TotalPrice = Odto.TotalPrice,
                uID = Odto.uID,
                OrderedProducts = SelectedProducts
            };
            _context.Orders.Add(Order);
            _context.SaveChanges();
            return Ok(Order);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, OrderDto dto)
        {
            var Order = _context.Orders.FirstOrDefault(O => O.Id == id);
            if (Order == null)
                return NotFound(value: $"not found");
            
            Order.QTY = dto.QTY;
            Order.TotalPrice = dto.TotalPrice;
            _context.SaveChanges();
            return Ok(Order);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var Order = _context.Orders.FirstOrDefault(O => O.Id == id);
            if (Order == null)
                return NotFound(value: $"not found");
            _context.Remove(Order);
            _context.SaveChanges();
            return Ok();
        }
    }
}
