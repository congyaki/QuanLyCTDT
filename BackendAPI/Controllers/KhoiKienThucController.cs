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
    public class KhoiKienThucController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public KhoiKienThucController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/KhoiKienThuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoiKienThuc>>> GetKhoiKienThucs()
        {
          if (_context.KhoiKienThucs == null)
          {
              return NotFound();
          }
            return await _context.KhoiKienThucs.ToListAsync();
        }

        // GET: api/KhoiKienThuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhoiKienThuc>> GetKhoiKienThuc(string id)
        {
          if (_context.KhoiKienThucs == null)
          {
              return NotFound();
          }
            var khoiKienThuc = await _context.KhoiKienThucs.FindAsync(id);

            if (khoiKienThuc == null)
            {
                return NotFound();
            }

            return khoiKienThuc;
        }

        // PUT: api/KhoiKienThuc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoiKienThuc(string id, KhoiKienThuc_VM kKT)
        {
            var _kKT = _context.KhoiKienThucs.FirstOrDefault(p => p.MaKKT == id);
            if (id != _kKT.MaKKT)
            {
                return BadRequest();
            }
            _kKT.Ten = kKT.Ten;
            _kKT.MoTa = kKT.MoTa;

            _context.Entry(_kKT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoiKienThucExists(id))
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

        // POST: api/KhoiKienThuc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhoiKienThuc>> PostKhoiKienThuc(KhoiKienThuc_VM kKT)
        {
          if (_context.KhoiKienThucs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.KhoiKienThucs'  is null.");
          }

            var _kKT = new KhoiKienThuc
            {
                MaKKT = kKT.MaKKT,
                Ten = kKT.Ten,
                MoTa = kKT.MoTa,
            };

            _context.KhoiKienThucs.Add(_kKT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhoiKienThucExists(kKT.MaKKT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhoiKienThuc", new { id = _kKT.MaKKT }, _kKT);
        }

        // DELETE: api/KhoiKienThuc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoiKienThuc(string id)
        {
            if (_context.KhoiKienThucs == null)
            {
                return NotFound();
            }
            var khoiKienThuc = await _context.KhoiKienThucs.FindAsync(id);
            if (khoiKienThuc == null)
            {
                return NotFound();
            }

            _context.KhoiKienThucs.Remove(khoiKienThuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoiKienThucExists(string id)
        {
            return (_context.KhoiKienThucs?.Any(e => e.MaKKT == id)).GetValueOrDefault();
        }
    }
}
