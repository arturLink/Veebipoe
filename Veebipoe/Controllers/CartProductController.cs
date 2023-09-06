using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veebipoe.Data;
using Veebipoe.Models;

namespace Veebipoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CartProduct> GetCartProducts()
        {
            var product = _context.CartProducts.ToList();
            return product;
        }

        [HttpPost]
        public List<CartProduct> PostProducts([FromBody] CartProduct product)
        {
            _context.CartProducts.Add(product);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        [HttpDelete("{id}")]
        public List<CartProduct> DeleteCartProducts(int id)
        {
            var person = _context.CartProducts.Find(id);

            if (person == null)
            {
                return _context.CartProducts.ToList();
            }

            _context.CartProducts.Remove(person);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        //[HttpDelete("/kustuta2/{id}")]
        //public IActionResult DeleteCartProducts2(int id)
        //{
        //    var person = _context.CartProducts.Find(id);

        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CartProducts.Remove(person);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetCartProducts(int id)
        {
            var persons = _context.CartProducts.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<CartProduct>> PutProducts(int id, [FromBody] CartProduct updatedPersons)
        {
            var persons = _context.CartProducts.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            persons.ProductId = updatedPersons.ProductId;
            persons.Quantity = updatedPersons.Quantity;

            _context.CartProducts.Update(persons);
            _context.SaveChanges();

            return Ok(_context.CartProducts);
        }
    }
}
