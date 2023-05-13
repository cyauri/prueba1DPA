using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba1.Models;

namespace prueba1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tablita1Controller : ControllerBase
    {
        private readonly CeliaContext _context;

        public Tablita1Controller(CeliaContext context)
        {
            _context = context;
        }

        // GET: api/Tablita1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tablita1>>> GetTablita1()
        {
          if (_context.Tablita1 == null)
          {
              return NotFound();
          }
            return await _context.Tablita1.ToListAsync();
        }

        // GET: api/Tablita1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tablita1>> GetTablita1(int id)
        {
          if (_context.Tablita1 == null)
          {
              return NotFound();
          }
            var tablita1 = await _context.Tablita1.FindAsync(id);

            if (tablita1 == null)
            {
                return NotFound();
            }

            return tablita1;
        }

        // PUT: api/Tablita1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTablita1(int id, Tablita1 tablita1)
        {
            if (id != tablita1.Id)
            {
                return BadRequest();
            }

            _context.Entry(tablita1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tablita1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tablita1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tablita1>> PostTablita1(Tablita1 tablita1)
        {
          if (_context.Tablita1 == null)
          {
              return Problem("Entity set 'CeliaContext.Tablita1'  is null.");
          }
            _context.Tablita1.Add(tablita1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTablita1", new { id = tablita1.Id }, tablita1);
        }

        // DELETE: api/Tablita1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTablita1(int id)
        {
            if (_context.Tablita1 == null)
            {
                return NotFound();
            }
            var tablita1 = await _context.Tablita1.FindAsync(id);
            if (tablita1 == null)
            {
                return NotFound();
            }

            _context.Tablita1.Remove(tablita1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tablita1Exists(int id)
        {
            return (_context.Tablita1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
