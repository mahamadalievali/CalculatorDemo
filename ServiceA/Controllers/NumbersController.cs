using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceA.Data;
using ServiceA.Models;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NumbersController(AppDbContext context)
        {
            _context = context;
        }

        // POST /api/numbers?value=5
        [HttpPost]
        public async Task<IActionResult> AddNumber([FromQuery] int value)
        {
            var number = new Number { Value = value };
            _context.Numbers.Add(number);
            await _context.SaveChangesAsync();
            return Ok(number.Id);
        }

        // GET /api/numbers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNumber(int id)
        {
            var number = await _context.Numbers.FindAsync(id);
            if (number == null)
                return NotFound();
            return Ok(number.Value);
        }

        // GET /api/numbers
        [HttpGet]
        public async Task<IActionResult> GetAllNumbers()
        {
            var numbers = await _context.Numbers.ToListAsync();
            return Ok(numbers);
        }
    }
}