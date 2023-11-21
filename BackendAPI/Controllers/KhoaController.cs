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
    public class KhoaController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public KhoaController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/Khoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoa>>> GetKhoas()
        {
          if (_context.Khoas == null)
          {
              return NotFound();
          }
            return await _context.Khoas.ToListAsync();
        }

        // GET: api/Khoa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khoa>> GetKhoa(string id)
        {
          if (_context.Khoas == null)
          {
              return NotFound();
          }
            var hocPhans = await (from hp in _context.HocPhans
                          where hp.MaKhoa == id
                          select hp).ToListAsync();

            var khoa = await (from k in _context.Khoas
                       where k.MaKhoa == id
                       select new Khoa()
                       {
                            MaKhoa = k.MaKhoa,
                            Ten = k.Ten,
                            MoTa = k.MoTa,
                            HocPhans = hocPhans
                       }).ToListAsync();

            if (khoa == null)
            {
                return NotFound();
            }

            return Ok(khoa);
        }

        // PUT: api/Khoa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoa(string id, Khoa_VM khoa)
        {
            var _khoa = _context.Khoas.FirstOrDefault(p => p.MaKhoa == id);

            if (id != _khoa.MaKhoa)
            {
                return BadRequest();
            }

            _khoa.Ten = khoa.Ten;
            _khoa.MoTa = khoa.MoTa;

            _context.Entry(_khoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaExists(id))
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

        // POST: api/Khoa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khoa>> PostKhoa(Khoa_VM khoa)
        {
          if (_context.Khoas == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.Khoas'  is null.");
          }
            var _khoa = new Khoa
            {
                MaKhoa = khoa.MaKhoa,
                Ten = khoa.Ten,
                MoTa = khoa.MoTa,
            };
            _context.Khoas.Add(_khoa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhoaExists(khoa.MaKhoa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhoa", new { id = _khoa.MaKhoa }, _khoa);
        }

        // DELETE: api/Khoa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoa(string id)
        {
            if (_context.Khoas == null)
            {
                return NotFound();
            }
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }

            _context.Khoas.Remove(khoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaExists(string id)
        {
            return (_context.Khoas?.Any(e => e.MaKhoa == id)).GetValueOrDefault();
        }
    }
}
