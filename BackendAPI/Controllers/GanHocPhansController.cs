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
    public class GanHocPhansController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public GanHocPhansController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/GanHocPhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GanHocPhan>>> GetGanHocPhans()
        {
          if (_context.GanHocPhans == null)
          {
              return NotFound();
          }
            return await _context.GanHocPhans.ToListAsync();
        }

        // GET: api/GanHocPhans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GanHocPhan>> GetGanHocPhan(string id)
        {
          if (_context.GanHocPhans == null)
          {
              return NotFound();
          }
            var ganHocPhan = await _context.GanHocPhans.FindAsync(id);

            if (ganHocPhan == null)
            {
                return NotFound();
            }

            return ganHocPhan;
        }

        // PUT: api/GanHocPhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGanHocPhan(string id, GanHocPhan ganHocPhan)
        {
            if (id != ganHocPhan.MaCTDT_KKT)
            {
                return BadRequest();
            }

            _context.Entry(ganHocPhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GanHocPhanExists(id))
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

        // POST: api/GanHocPhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GanHocPhan>> PostGanHocPhan(GanHocPhan ganHocPhan)
        {
          if (_context.GanHocPhans == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.GanHocPhans'  is null.");
          }
            _context.GanHocPhans.Add(ganHocPhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GanHocPhanExists(ganHocPhan.MaCTDT_KKT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGanHocPhan", new { id = ganHocPhan.MaCTDT_KKT }, ganHocPhan);
        }

        // DELETE: api/GanHocPhans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGanHocPhan(string id)
        {
            if (_context.GanHocPhans == null)
            {
                return NotFound();
            }
            var ganHocPhan = await _context.GanHocPhans.FindAsync(id);
            if (ganHocPhan == null)
            {
                return NotFound();
            }

            _context.GanHocPhans.Remove(ganHocPhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GanHocPhanExists(string id)
        {
            return (_context.GanHocPhans?.Any(e => e.MaCTDT_KKT == id)).GetValueOrDefault();
        }
    }
}
