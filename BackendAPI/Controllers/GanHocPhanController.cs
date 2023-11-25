using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_CTDT.Data.Models.EF;
using QL_CTDT.Data.Models.Entities;
using QL_CTDT.Data.Models.ViewModels;

namespace QL_CTDT.BackendAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GanHocPhanController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public GanHocPhanController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/GanHocPhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GanHocPhan_VM>>> GetGanHocPhans()
        {
          if (_context.GanHocPhans == null)
          {
              return NotFound();
          }
            List<GanHocPhan_VM> dsGanHocPhan = await (_context.GanHocPhans.Select(p => new GanHocPhan_VM()
            {
                MaCTDT_KKT = p.MaCTDT_KKT,
                TenCTDT_KKT = p.CTDT_KKT.TenCTDT_KKT,
                MaHocPhan = p.MaHocPhan,
                TenHocPhan = p.HocPhan.Ten,
            })).ToListAsync();
            return Ok(dsGanHocPhan);
        }

        // GET: api/GanHocPhans/5
        [HttpGet("{maHP}&&{maCTDT_KKT}")]
        public async Task<ActionResult<GanHocPhan_VM>> GetGanHocPhan(string maHP, string maCTDT_KKT)
        {
          if (_context.GanHocPhans == null)
          {
              return NotFound();
          }
            GanHocPhan_VM ganHocPhan = await (_context.GanHocPhans.Where(p => p.MaCTDT_KKT == maCTDT_KKT && p.MaHocPhan == maHP).Select(p => new GanHocPhan_VM()
            {
                MaCTDT_KKT = p.MaCTDT_KKT,
                TenCTDT_KKT = p.CTDT_KKT.TenCTDT_KKT,
                MaHocPhan = p.MaHocPhan,
                TenHocPhan = p.HocPhan.Ten,
            })).FirstOrDefaultAsync();

            if (ganHocPhan == null)
            {
                return NotFound();
            }

            return ganHocPhan;
        }

        // PUT: api/GanHocPhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maHP}&&{maCTDT_KKT}")]
        public async Task<IActionResult> PutGanHocPhan(string maHP, string maCTDT_KKT, GanHocPhan_VM ganHocPhan_VM)
        {
            var ganHocPhan = await _context.GanHocPhans.FirstOrDefaultAsync(p => p.MaHocPhan == maHP && p.MaCTDT_KKT == maCTDT_KKT);
            if (maCTDT_KKT != ganHocPhan.MaCTDT_KKT || maHP != ganHocPhan.MaHocPhan)
            {
                return BadRequest();
            }

            ganHocPhan.MaCTDT_KKT = ganHocPhan_VM.MaCTDT_KKT;
            ganHocPhan.MaHocPhan = ganHocPhan_VM.MaHocPhan;

            _context.Entry(ganHocPhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GanHocPhanExists(maHP, maCTDT_KKT))
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
        public async Task<ActionResult<GanHocPhan_VM>> PostGanHocPhan(GanHocPhan_VM ganHocPhan_VM)
        {
          if (_context.GanHocPhans == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.GanHocPhans'  is null.");
          }

            GanHocPhan ganHocPhan = new GanHocPhan()
            {
                MaCTDT_KKT = ganHocPhan_VM.MaCTDT_KKT,
                MaHocPhan = ganHocPhan_VM.MaHocPhan,
            };

            _context.GanHocPhans.Add(ganHocPhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GanHocPhanExists(ganHocPhan.MaCTDT_KKT, ganHocPhan.MaHocPhan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGanHocPhan", new { maCTDT_KKT = ganHocPhan.MaCTDT_KKT, maHP = ganHocPhan.MaHocPhan }, ganHocPhan);
        }

        // DELETE: api/GanHocPhans/5
        [HttpDelete("{maHP}&&{maCTDT_KKT}")]
        public async Task<IActionResult> DeleteGanHocPhan(string maHP, string maCTDT_KKT)
        {
            if (_context.GanHocPhans == null)
            {
                return NotFound();
            }
            var ganHocPhan = await _context.GanHocPhans.FindAsync(new {maHP, maCTDT_KKT});
            if (ganHocPhan == null)
            {
                return NotFound();
            }

            _context.GanHocPhans.Remove(ganHocPhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GanHocPhanExists(string maHP, string maCTDT_KKT)
        {
            return (_context.GanHocPhans?.Any(e => e.MaCTDT_KKT == maCTDT_KKT && e.MaHocPhan == maHP)).GetValueOrDefault();
        }
    }
}
