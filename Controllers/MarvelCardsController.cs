using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Data;
using SampleProject.Model;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelCardsController : ControllerBase
    {
        private readonly SampleProjectContext _context;

        public MarvelCardsController(SampleProjectContext context)
        {
            _context = context;
        }

        // GET: api/MarvelCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarvelCard>>> GetMarvelCard()
        {
            return await _context.MarvelCard.ToListAsync();
        }

        // GET: api/MarvelCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarvelCard>> GetMarvelCard(int id)
        {
            var marvelCard = await _context.MarvelCard.FindAsync(id);

            if (marvelCard == null)
            {
                return NotFound();
            }

            return marvelCard;
        }

        // PUT: api/MarvelCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarvelCard(int id, MarvelCard marvelCard)
        {
            if (id != marvelCard.ID)
            {
                return BadRequest();
            }

            _context.Entry(marvelCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarvelCardExists(id))
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

        // POST: api/MarvelCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarvelCard>> PostMarvelCard(MarvelCard marvelCard)
        {
            _context.MarvelCard.Add(marvelCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarvelCard", new { id = marvelCard.ID }, marvelCard);
        }

        // DELETE: api/MarvelCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarvelCard>> DeleteMarvelCard(int id)
        {
            var marvelCard = await _context.MarvelCard.FindAsync(id);
            if (marvelCard == null)
            {
                return NotFound();
            }

            _context.MarvelCard.Remove(marvelCard);
            await _context.SaveChangesAsync();

            return marvelCard;
        }

        private bool MarvelCardExists(int id)
        {
            return _context.MarvelCard.Any(e => e.ID == id);
        }
    }
}
