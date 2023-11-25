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
    public class CTDT_KKTController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public CTDT_KKTController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/CTDT_KKTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTDT_KKT_VM>>> GetCTDT_KKTs()
        {
            if (_context.CTDT_KKTs == null)
            {
                return NotFound();
            }
            List<CTDT_KKT_VM> danhSachCTDT_KKT = await _context.CTDT_KKTs
                  .Select(e => new CTDT_KKT_VM()
                  {
                      MaCTDT_KKT = e.MaCTDT_KKT,
                      TenCTDT_KKT = e.TenCTDT_KKT,
                      TenCTDT = e.ChuongTrinhDaoTao.Ten,
                      TenKKT = e.KhoiKienThuc.Ten,
                  }).ToListAsync();
            return Ok(danhSachCTDT_KKT);
        }

        // GET: api/CTDT_KKTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CTDT_KKT>> GetCTDT_KKT(string id)
        {
          if (_context.CTDT_KKTs == null)
          {
              return NotFound();
          }
            CTDT_KKT_VM ck = await _context.CTDT_KKTs
                .Where(p => p.MaCTDT_KKT == id)
                  .Select(e => new CTDT_KKT_VM
                  {
                      MaCTDT_KKT = e.MaCTDT_KKT,
                      TenCTDT_KKT = e.TenCTDT_KKT,
                      TenCTDT = e.ChuongTrinhDaoTao.Ten,
                      TenKKT = e.KhoiKienThuc.Ten,
                  }).FirstOrDefaultAsync();

            if (ck == null)
            {
                return NotFound();
            }

            return Ok(ck);
        }

        // PUT: api/CTDT_KKTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCTDT_KKT(string id, CTDT_KKT_VM ck_VM)
        {
            var ck = _context.CTDT_KKTs.FirstOrDefault(p => p.MaCTDT_KKT == id);

            if (id != ck.MaCTDT_KKT)
            {
                return BadRequest();
            }

            ck.MaCTDT = ck_VM.MaCTDT;
            ck.MaKKT = ck_VM.MaKKT;
            string tenCTDT = _context.ChuongTrinhDaoTaos.Where(p => p.MaCTDT == ck_VM.MaCTDT).Select(p => p.Ten).FirstOrDefault();
            string tenKKT = _context.KhoiKienThucs.Where(p => p.MaKKT == ck_VM.MaKKT).Select(p => p.Ten).FirstOrDefault();
            ck.TenCTDT_KKT = tenCTDT + " - " + tenKKT;

            _context.Entry(ck).State = EntityState.Modified;

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
        public async Task<ActionResult<CTDT_KKT>> PostCTDT_KKT(CTDT_KKT_VM ck_VM)
        {
            if (_context.CTDT_KKTs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.CTDT_KKTs'  is null.");
            }
            string tenCTDT = _context.ChuongTrinhDaoTaos.Where(p => p.MaCTDT == ck_VM.MaCTDT).Select(p => p.Ten).FirstOrDefault();
            string tenKKT = _context.KhoiKienThucs.Where(p => p.MaKKT == ck_VM.MaKKT).Select(p => p.Ten).FirstOrDefault();
            var ck = new CTDT_KKT
            {
                MaCTDT_KKT = ck_VM.MaCTDT + " - " + ck_VM.MaKKT,
                MaCTDT = ck_VM.MaCTDT,
                MaKKT = ck_VM.MaKKT,
                TenCTDT_KKT = tenCTDT + " - " + tenKKT
            };

            _context.CTDT_KKTs.Add(ck);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CTDT_KKTExists(ck.MaCTDT_KKT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCTDT_KKT", new { id = ck.MaCTDT_KKT }, ck);
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
