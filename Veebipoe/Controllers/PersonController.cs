using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veebipoe.Data;
using Veebipoe.Models;

namespace Veebipoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Person> GetPersons()
        {
            var persons = _context.Persons.ToList();
            return persons;
        }

        [HttpPost]
        public List<Person> PostPersons([FromBody] Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return _context.Persons.ToList();
        }

        [HttpDelete("{id}")]
        public List<Person> DeletePersons(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
            {
                return _context.Persons.ToList();
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return _context.Persons.ToList();
        }

        [HttpDelete("/kustuta2/{id}")]
        public IActionResult DeletePersons2(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersons(int id)
        {
            var persons = _context.Persons.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> PutPersons(int id, [FromBody] Person updatedPersons)
        {
            var persons = _context.Persons.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            persons.FirstName = updatedPersons.FirstName;
            persons.LastName = updatedPersons.LastName;

            _context.Persons.Update(persons);
            _context.SaveChanges();

            return Ok(_context.Persons);
        }
    }
}
