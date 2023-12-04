using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.EF;
using QL_CTDT.Data.Models.Entities;
using QL_CTDT.Data.Models.ViewModels;

namespace QuanLyCTDT.Controllers
{
    public class KhoaHocsController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public KhoaHocsController(TrainingProgramDbContext context)
        {
            _context = context;
        }
        // GET: KhoaHocsController
        [HttpGet]
        [Route("KhoaHocs/Index")]
        public async Task<IActionResult> Index()
        {
            if (_context.KhoaHocs == null)
            {
                return NotFound();
            }
            var khoaHoc = await _context.KhoaHocs.ToListAsync();
            return View(khoaHoc);
        }

        // GET: KhoaHocsController/Details/5
        [HttpGet("{id}")]
        [Route("KhoaHocs/Details/{id}")]

        public async Task<IActionResult> Details(string id)
        {
            if (_context.KhoaHocs == null)
            {
                return NotFound();
            }
            var khoaHoc = await _context.KhoaHocs.FirstOrDefaultAsync(p => p.MaKhoaHoc == id);

            if (khoaHoc == null)
            {
                return NotFound();
            }

            return View(khoaHoc);
        }

        // GET: KhoaHocs/Create
        [Route("KhoaHocs/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("KhoaHocs/Create")]

        public async Task<IActionResult> Create([Bind("MaKhoaHoc,Ten,MoTa,NgayBatDau,NgayKetThuc")] KhoaHoc_VM khoaHoc)
        {
            if (ModelState.IsValid)
            {
                var _khoaHoc = new KhoaHoc
                {
                    MaKhoaHoc = khoaHoc.MaKhoaHoc,
                    Ten = khoaHoc.Ten,
                    MoTa = khoaHoc.MoTa,
                    NgayBatDau = khoaHoc.NgayBatDau,
                    NgayKetThuc = khoaHoc.NgayKetThuc,
                };

                _context.Add(_khoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Edit/5
        [HttpGet]
        [Route("KhoaHocs/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhoaHocs == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

        // POST: KhoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("KhoaHocs/Edit/{id}")]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhoaHoc,Ten,MoTa,NgayBatDau,NgayKetThuc")] KhoaHoc_VM khoaHoc)
        {
            if (id != khoaHoc.MaKhoaHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var _khoaHoc = _context.KhoaHocs.FirstOrDefault(p => p.MaKhoaHoc == id);
                if (id != _khoaHoc.MaKhoaHoc)
                {
                    return BadRequest();
                }
                _khoaHoc.Ten = khoaHoc.Ten;
                _khoaHoc.MoTa = khoaHoc.MoTa;
                _khoaHoc.NgayBatDau = khoaHoc.NgayBatDau;
                _khoaHoc.NgayKetThuc = khoaHoc.NgayKetThuc;
                try
                {
                    _context.Update(_khoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaHocExists(khoaHoc.MaKhoaHoc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Delete/5
        [Route("KhoaHocs/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhoaHocs == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs
                .FirstOrDefaultAsync(m => m.MaKhoaHoc == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            return View(khoaHoc);
        }

        // POST: KhoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("KhoaHocs/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhoaHocs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.KhoaHocs'  is null.");
            }
            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc != null)
            {
                _context.KhoaHocs.Remove(khoaHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaHocExists(string id)
        {
            return (_context.KhoaHocs?.Any(e => e.MaKhoaHoc == id)).GetValueOrDefault();
        }
    }
}
