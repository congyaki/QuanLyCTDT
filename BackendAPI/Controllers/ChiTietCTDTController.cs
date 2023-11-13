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
    public class ChiTietCTDTController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public ChiTietCTDTController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietCTDT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietCTDT>>> GetChiTietCTDTs()
        {
          if (_context.ChiTietCTDTs == null)
          {
              return NotFound();
          }
            return await _context.ChiTietCTDTs.ToListAsync();
        }

        // GET: api/ChiTietCTDT/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietCTDT>> GetChiTietCTDT(string id)
        {
          if (_context.ChiTietCTDTs == null)
          {
              return NotFound();
          }
            var chiTietCTDT = await _context.ChiTietCTDTs.FindAsync(id);

            if (chiTietCTDT == null)
            {
                return NotFound();
            }

            return chiTietCTDT;
        }

        // PUT: api/ChiTietCTDT/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietCTDT(string id, ChiTietCTDT_VM chiTietCTDT)
        {

            var _chiTietCTDT = _context.ChiTietCTDTs.FirstOrDefault(p => p.MaChiTietCTDT == id);

            if (id != _chiTietCTDT.MaChiTietCTDT)
            {
                return BadRequest();
            }

            _chiTietCTDT.MaDanhMucCTDT_KKT = chiTietCTDT.MaDanhMucCTDT_KKT;
            _chiTietCTDT.MaHocPhan = chiTietCTDT.MaHocPhan;

            _context.Entry(chiTietCTDT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietCTDTExists(id))
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

        // POST: api/ChiTietCTDT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietCTDT>> PostChiTietCTDT(ChiTietCTDT_VM chiTietCTDT)
        {
          if (_context.ChiTietCTDTs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.ChiTietCTDTs'  is null.");
          }

            var _chiTietCTDT = new ChiTietCTDT
            {
                MaChiTietCTDT = chiTietCTDT.MaChiTietCTDT,
                MaDanhMucCTDT_KKT = chiTietCTDT.MaDanhMucCTDT_KKT,
                MaHocPhan = chiTietCTDT.MaHocPhan,
            };

            _context.ChiTietCTDTs.Add(_chiTietCTDT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietCTDTExists(chiTietCTDT.MaChiTietCTDT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietCTDT", new { id = _chiTietCTDT.MaChiTietCTDT }, _chiTietCTDT);
        }

        // DELETE: api/ChiTietCTDT/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietCTDT(string id)
        {
            if (_context.ChiTietCTDTs == null)
            {
                return NotFound();
            }
            var chiTietCTDT = await _context.ChiTietCTDTs.FindAsync(id);
            if (chiTietCTDT == null)
            {
                return NotFound();
            }

            _context.ChiTietCTDTs.Remove(chiTietCTDT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietCTDTExists(string id)
        {
            return (_context.ChiTietCTDTs?.Any(e => e.MaChiTietCTDT == id)).GetValueOrDefault();
        }
    }
}
