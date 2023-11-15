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
    public class DanhMucCTDT_KKTController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public DanhMucCTDT_KKTController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/DanhMucCTDT_KKT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMucCTDT_KKT>>> GetDanhMucCTDT_KKTs()
        {
          if (_context.DanhMucCTDT_KKTs == null)
          {
              return NotFound();
          }
            return await _context.DanhMucCTDT_KKTs.ToListAsync();
        }

        // GET: api/DanhMucCTDT_KKT/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMucCTDT_KKT>> GetDanhMucCTDT_KKT(string id)
        {
          if (_context.DanhMucCTDT_KKTs == null)
          {
              return NotFound();
          }
            var danhMucCTDT_KKT = await _context.DanhMucCTDT_KKTs.FindAsync(id);

            if (danhMucCTDT_KKT == null)
            {
                return NotFound();
            }

            return danhMucCTDT_KKT;
        }

        // PUT: api/DanhMucCTDT_KKT/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMucCTDT_KKT(string id, DanhMucCTDT_KKT_VM danhMucCTDT_KKT)
        {
            var _danhMucCTDT_KKT = _context.DanhMucCTDT_KKTs.FirstOrDefault(p => p.MaDanhMucCTDT_KKT == id);

            if (id != _danhMucCTDT_KKT.MaDanhMucCTDT_KKT)
            {
                return BadRequest();
            }
            
            _danhMucCTDT_KKT.MaDanhMucCTDT = danhMucCTDT_KKT.MaDanhMucCTDT;
            _danhMucCTDT_KKT.MaKKT = danhMucCTDT_KKT.MaKKT;


            _context.Entry(_danhMucCTDT_KKT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucCTDT_KKTExists(id))
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

        // POST: api/DanhMucCTDT_KKT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DanhMucCTDT_KKT>> PostDanhMucCTDT_KKT(DanhMucCTDT_KKT_VM danhMucCTDT_KKT)
        {
          if (_context.DanhMucCTDT_KKTs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.DanhMucCTDT_KKTs'  is null.");
          }

            var _danhMucCTDT_KKT = new DanhMucCTDT_KKT
            {
                MaDanhMucCTDT_KKT = danhMucCTDT_KKT.MaDanhMucCTDT + "_" + danhMucCTDT_KKT.MaKKT,
                MaDanhMucCTDT = danhMucCTDT_KKT.MaDanhMucCTDT,
                MaKKT = danhMucCTDT_KKT.MaKKT,
            };

            _context.DanhMucCTDT_KKTs.Add(_danhMucCTDT_KKT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DanhMucCTDT_KKTExists(danhMucCTDT_KKT.MaDanhMucCTDT_KKT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDanhMucCTDT_KKT", new { id = _danhMucCTDT_KKT.MaDanhMucCTDT_KKT }, _danhMucCTDT_KKT);
        }

        // DELETE: api/DanhMucCTDT_KKT/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhMucCTDT_KKT(string id)
        {
            if (_context.DanhMucCTDT_KKTs == null)
            {
                return NotFound();
            }
            var danhMucCTDT_KKT = await _context.DanhMucCTDT_KKTs.FindAsync(id);
            if (danhMucCTDT_KKT == null)
            {
                return NotFound();
            }

            _context.DanhMucCTDT_KKTs.Remove(danhMucCTDT_KKT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DanhMucCTDT_KKTExists(string id)
        {
            return (_context.DanhMucCTDT_KKTs?.Any(e => e.MaDanhMucCTDT_KKT == id)).GetValueOrDefault();
        }
    }
}
