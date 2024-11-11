using Ecom.DAL;
using Ecom.DAL.Entities;
using Ecom.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var Customers = _context.Users.ToList();
            return Ok(Customers);
        }
        [HttpPost]
        public IActionResult CreateUser(CustomerDto Cdto)
        {
            var Customer = new User
            {
                Name = Cdto.Name,
                Age = Cdto.Age,
                Password = Cdto.Password
               
            };
            _context.Add(Customer);
            _context.SaveChanges();
            return Ok(Customer);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, CustomerDto Cdto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(value: $"not found");
            user.Name = Cdto.Name;
           user.Age = Cdto.Age;

          
            return Ok(user);
        }
    }
}
