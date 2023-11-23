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
    public class NganhController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public NganhController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/Nganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nganh>>> GetNganhs()
        {
          if (_context.Nganhs == null)
          {
              return NotFound();
          }
            return await _context.Nganhs.ToListAsync();
        }

        // GET: api/Nganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nganh>> GetNganh(string id)
        {
          if (_context.Nganhs == null)
          {
              return NotFound();
          }
            var nganh = await _context.Nganhs.FindAsync(id);

            if (nganh == null)
            {
                return NotFound();
            }

            return nganh;
        }

        // PUT: api/Nganh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNganh(string id, Nganh_VM nganh)
        {
            var _nganh = _context.Nganhs.FirstOrDefault(p => p.MaNganh == id);

            if (id != _nganh.MaNganh)
            {
                return BadRequest();
            }

            _nganh.Ten = nganh.Ten;
            _nganh.MoTa = nganh.MoTa;
            _nganh.MaKhoa = nganh.MaKhoa;

            _context.Entry(_nganh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NganhExists(id))
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

        // POST: api/Nganh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nganh>> PostNganh(Nganh_VM nganh)
        {
          if (_context.Nganhs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.Nganhs'  is null.");
          }
            var _nganh = new Nganh
            {
                MaNganh = nganh.MaNganh,
                Ten = nganh.Ten,
                MoTa = nganh.MoTa,
                MaKhoa = nganh.MaKhoa,
            };
            _context.Nganhs.Add(_nganh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NganhExists(nganh.MaNganh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNganh", new { id = _nganh.MaNganh }, _nganh);
        }

        // DELETE: api/Nganh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNganh(string id)
        {
            if (_context.Nganhs == null)
            {
                return NotFound();
            }
            var nganh = await _context.Nganhs.FindAsync(id);
            if (nganh == null)
            {
                return NotFound();
            }

            _context.Nganhs.Remove(nganh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NganhExists(string id)
        {
            return (_context.Nganhs?.Any(e => e.MaNganh == id)).GetValueOrDefault();
        }
    }
}
