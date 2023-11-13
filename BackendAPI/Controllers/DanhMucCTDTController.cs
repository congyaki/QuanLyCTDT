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
    public class DanhMucCTDTController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public DanhMucCTDTController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/DanhMucCTDTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMucCTDT>>> GetDanhMucCTDTs()
        {
          if (_context.DanhMucCTDTs == null)
          {
              return NotFound();
          }
            return await _context.DanhMucCTDTs.ToListAsync();
        }

        // GET: api/DanhMucCTDTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMucCTDT>> GetDanhMucCTDT(string id)
        {
          if (_context.DanhMucCTDTs == null)
          {
              return NotFound();
          }
            var danhMucCTDT = await _context.DanhMucCTDTs.FindAsync(id);

            if (danhMucCTDT == null)
            {
                return NotFound();
            }

            return danhMucCTDT;
        }

        // PUT: api/DanhMucCTDTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMucCTDT(string id, DanhMucCTDT_VM danhMucCTDT)
        {
            var _danhMucCTDT = _context.DanhMucCTDTs.FirstOrDefault(p => p.MaDanhMucCTDT == id);

            if (id != _danhMucCTDT.MaDanhMucCTDT)
            {
                return BadRequest();
            }

            _danhMucCTDT.MaKhoa = danhMucCTDT.MaKhoa;
            _danhMucCTDT.MaKhoaHoc = danhMucCTDT.MaKhoaHoc;

            _context.Entry(_danhMucCTDT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucCTDTExists(id))
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

        // POST: api/DanhMucCTDTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DanhMucCTDT>> PostDanhMucCTDT(DanhMucCTDT_VM danhMucCTDT)
        {
          if (_context.DanhMucCTDTs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.DanhMucCTDTs'  is null.");
          }

            var _danhMucCTDT = new DanhMucCTDT
            {
                MaDanhMucCTDT = danhMucCTDT.MaKhoa + "_" + danhMucCTDT.MaKhoaHoc,
                MaKhoa = danhMucCTDT.MaKhoa,
                MaKhoaHoc = danhMucCTDT.MaKhoaHoc,
            };

            _context.DanhMucCTDTs.Add(_danhMucCTDT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DanhMucCTDTExists(danhMucCTDT.MaDanhMucCTDT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDanhMucCTDT", new { id = _danhMucCTDT.MaDanhMucCTDT }, _danhMucCTDT);
        }

        // DELETE: api/DanhMucCTDTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhMucCTDT(string id)
        {
            if (_context.DanhMucCTDTs == null)
            {
                return NotFound();
            }
            var danhMucCTDT = await _context.DanhMucCTDTs.FindAsync(id);
            if (danhMucCTDT == null)
            {
                return NotFound();
            }

            _context.DanhMucCTDTs.Remove(danhMucCTDT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DanhMucCTDTExists(string id)
        {
            return (_context.DanhMucCTDTs?.Any(e => e.MaDanhMucCTDT == id)).GetValueOrDefault();
        }
    }
}
