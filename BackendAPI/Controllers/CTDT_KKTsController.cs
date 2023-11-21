using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_CTDT.Data.Models.EF;
using QL_CTDT.Data.Models.Entities;

namespace QL_CTDT.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTDT_KKTsController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public CTDT_KKTsController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/CTDT_KKTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTDT_KKT>>> GetCTDT_KKTs()
        {
          if (_context.CTDT_KKTs == null)
          {
              return NotFound();
          }
            return await _context.CTDT_KKTs.ToListAsync();
        }

        // GET: api/CTDT_KKTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CTDT_KKT>> GetCTDT_KKT(string id)
        {
          if (_context.CTDT_KKTs == null)
          {
              return NotFound();
          }
            var cTDT_KKT = await _context.CTDT_KKTs.FindAsync(id);

            if (cTDT_KKT == null)
            {
                return NotFound();
            }

            return cTDT_KKT;
        }

        // PUT: api/CTDT_KKTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCTDT_KKT(string id, CTDT_KKT cTDT_KKT)
        {
            if (id != cTDT_KKT.MaCTDT_KKT)
            {
                return BadRequest();
            }

            _context.Entry(cTDT_KKT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTDT_KKTExists(id))
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

        // POST: api/CTDT_KKTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CTDT_KKT>> PostCTDT_KKT(CTDT_KKT cTDT_KKT)
        {
          if (_context.CTDT_KKTs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.CTDT_KKTs'  is null.");
          }
            _context.CTDT_KKTs.Add(cTDT_KKT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CTDT_KKTExists(cTDT_KKT.MaCTDT_KKT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCTDT_KKT", new { id = cTDT_KKT.MaCTDT_KKT }, cTDT_KKT);
        }

        // DELETE: api/CTDT_KKTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTDT_KKT(string id)
        {
            if (_context.CTDT_KKTs == null)
            {
                return NotFound();
            }
            var cTDT_KKT = await _context.CTDT_KKTs.FindAsync(id);
            if (cTDT_KKT == null)
            {
                return NotFound();
            }

            _context.CTDT_KKTs.Remove(cTDT_KKT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CTDT_KKTExists(string id)
        {
            return (_context.CTDT_KKTs?.Any(e => e.MaCTDT_KKT == id)).GetValueOrDefault();
        }
    }
}
