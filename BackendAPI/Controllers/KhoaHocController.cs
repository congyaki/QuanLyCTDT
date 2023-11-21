﻿using System;
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
    public class KhoaHocController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public KhoaHocController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/KhoaHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoaHoc>>> GetKhoaHocs()
        {
          if (_context.KhoaHocs == null)
          {
              return NotFound();
          }
            return await _context.KhoaHocs.ToListAsync();
        }

        // GET: api/KhoaHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhoaHoc>> GetKhoaHoc(string id)
        {
          if (_context.KhoaHocs == null)
          {
              return NotFound();
          }
            var khoaHoc = await _context.KhoaHocs.SingleOrDefaultAsync(p => p.MaKhoaHoc == id);

            if (khoaHoc == null)
            {
                return NotFound();
            }

            return khoaHoc;
        }

        // PUT: api/KhoaHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoaHoc(string id, KhoaHoc_VM khoaHoc)
        {
            var _khoaHoc = _context.KhoaHocs.SingleOrDefault(p => p.MaKhoaHoc == id);
            if (id != _khoaHoc.MaKhoaHoc)
            {
                return BadRequest();
            }
            _khoaHoc.Ten = khoaHoc.Ten;
            _khoaHoc.MoTa = khoaHoc.MoTa;
            _khoaHoc.NgayBatDau = khoaHoc.NgayBatDau;
            _khoaHoc.NgayKetThuc = khoaHoc.NgayKetThuc;

            _context.Entry(_khoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaHocExists(id))
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

        // POST: api/KhoaHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhoaHoc>> PostKhoaHoc(KhoaHoc_VM khoaHoc)
        {
          if (_context.KhoaHocs == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.KhoaHocs'  is null.");
          }
            var _khoaHoc = new KhoaHoc
            {
                MaKhoaHoc = khoaHoc.MaKhoaHoc,
                Ten = khoaHoc.Ten,
                MoTa = khoaHoc.MoTa,
                NgayBatDau = khoaHoc.NgayBatDau,
                NgayKetThuc = khoaHoc.NgayKetThuc,
            };
            _context.KhoaHocs.Add(_khoaHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhoaHocExists(khoaHoc.MaKhoaHoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhoaHoc", new { id = _khoaHoc.MaKhoaHoc }, _khoaHoc);
        }

        // DELETE: api/KhoaHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoaHoc(string id)
        {
            if (_context.KhoaHocs == null)
            {
                return NotFound();
            }
            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            _context.KhoaHocs.Remove(khoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaHocExists(string id)
        {
            return (_context.KhoaHocs?.Any(e => e.MaKhoaHoc == id)).GetValueOrDefault();
        }
    }
}
