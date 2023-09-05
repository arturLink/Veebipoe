using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veebipoe.Data;
using Veebipoe.Models;

namespace Veebipoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            var product = _context.Products.ToList();
            return product;
        }

        [HttpPost]
        public List<Product> PostProducts([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        [HttpDelete("{id}")]
        public List<Product> DeleteProducts(int id)
        {
            var person = _context.Products.Find(id);

            if (person == null)
            {
                return _context.Products.ToList();
            }

            _context.Products.Remove(person);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        [HttpDelete("/kustuta2/{id}")]
        public IActionResult DeleteProducts2(int id)
        {
            var person = _context.Products.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Products.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProducts(int id)
        {
            var persons = _context.Products.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Product>> PutProducts(int id, [FromBody] Product updatedPersons)
        {
            var persons = _context.Products.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            persons.Name = updatedPersons.Name;
            persons.Price = updatedPersons.Price;

            _context.Products.Update(persons);
            _context.SaveChanges();

            return Ok(_context.Products);
        }
    }
}
