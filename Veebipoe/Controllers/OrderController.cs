using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veebipoe.Data;
using Veebipoe.Models;

namespace Veebipoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Order> GetOrder()
        {
            var product = _context.Orders.ToList();
            return product;
        }

        [HttpPost]
        public List<Order> PostOrders([FromBody] Order product)
        {
            _context.Orders.Add(product);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        [HttpDelete("{id}")]
        public List<Order> DeleteOrders(int id)
        {
            var person = _context.Orders.Find(id);

            if (person == null)
            {
                return _context.Orders.ToList();
            }

            _context.Orders.Remove(person);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        [HttpDelete("/kustuta2/{id}")]
        public IActionResult DeleteOrders2(int id)
        {
            var person = _context.Orders.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrders(int id)
        {
            var persons = _context.Orders.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Order>> PutOrders(int id, [FromBody] Order updatedPersons)
        {
            var persons = _context.Orders.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            persons.Person = updatedPersons.Person;
            persons.created = updatedPersons.created;

            _context.Orders.Update(persons);
            _context.SaveChanges();

            return Ok(_context.Orders);
        }
    }
}
