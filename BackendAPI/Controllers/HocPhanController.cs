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
    [Route("api/[controller]")]
    [ApiController]
    public class HocPhanController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public HocPhanController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/HocPhan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocPhan>>> GetHocPhans()
        {
          if (_context.HocPhans == null)
          {
              return NotFound();
          }
            return await _context.HocPhans.ToListAsync();
        }

        // GET: api/HocPhan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocPhan>> GetHocPhan(string id)
        {
          if (_context.HocPhans == null)
          {
              return NotFound();
          }
            var hocPhan = await _context.HocPhans.FindAsync(id);

            if (hocPhan == null)
            {
                return NotFound();
            }

            return hocPhan;
        }

        // PUT: api/HocPhan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocPhan(string id, HocPhan_VM hocPhan)
        {
            var _hocPhan = _context.HocPhans.FirstOrDefault(p => p.MaHocPhan == id);

            if (id != _hocPhan.MaHocPhan)
            {
                return BadRequest();
            }

            _hocPhan.Ten = hocPhan.Ten;
            _hocPhan.MoTa = hocPhan.MoTa;
            _hocPhan.SoTinChi = hocPhan.SoTinChi;
            _hocPhan.MaKhoa = hocPhan.MaKhoa;

            _context.Entry(_hocPhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocPhanExists(id))
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

        // POST: api/HocPhan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HocPhan>> PostHocPhan(HocPhan_VM hocPhan)
        {
            if (_context.HocPhans == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.HocPhans'  is null.");
            }

            var _hocPhan = new HocPhan
            {
                MaHocPhan = hocPhan.MaHocPhan,
                Ten = hocPhan.Ten,
                MoTa = hocPhan.MoTa,
                SoTinChi = hocPhan.SoTinChi,
                MaKhoa = hocPhan.MaKhoa,
            };

            _context.HocPhans.Add(_hocPhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HocPhanExists(hocPhan.MaHocPhan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHocPhan", new { id = _hocPhan.MaHocPhan }, _hocPhan);
        }

        // DELETE: api/HocPhan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocPhan(string id)
        {
            if (_context.HocPhans == null)
            {
                return NotFound();
            }
            var hocPhan = await _context.HocPhans.FindAsync(id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            _context.HocPhans.Remove(hocPhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocPhanExists(string id)
        {
            return (_context.HocPhans?.Any(e => e.MaHocPhan == id)).GetValueOrDefault();
        }
    }
}
