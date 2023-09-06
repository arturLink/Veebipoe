using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veebipoe.Data;
using Veebipoe.Models;

namespace Veebipoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Category> GetCategory()
        {
            var product = _context.Categories.ToList();
            return product;
        }

        [HttpPost]
        public List<Category> PostCategory([FromBody] Category product)
        {
            _context.Categories.Add(product);
            _context.SaveChanges();
            return _context.Categories.ToList();
        }

        [HttpDelete("{id}")]
        public List<Category> DeleteCategories(int id)
        {
            var person = _context.Categories.Find(id);

            if (person == null)
            {
                return _context.Categories.ToList();
            }

            _context.Categories.Remove(person);
            _context.SaveChanges();
            return _context.Categories.ToList();
        }

        //[HttpDelete("/kustuta2/{id}")]
        //public IActionResult DeleteCategory2(int id)
        //{
        //    var person = _context.Categories.Find(id);

        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(person);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var persons = _context.Categories.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Category>> PutCategories(int id, [FromBody] Category updatedPersons)
        {
            var persons = _context.Categories.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            persons.Name = updatedPersons.Name;

            _context.Categories.Update(persons);
            _context.SaveChanges();

            return Ok(_context.Categories);
        }
    }
}
