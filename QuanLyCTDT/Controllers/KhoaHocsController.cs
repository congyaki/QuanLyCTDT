using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCTDT.Models;

namespace QuanLyCTDT.Controllers
{
    public class KhoaHocsController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public KhoaHocsController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: KhoaHocs
        public async Task<IActionResult> Index()
        {
            var trainingProgramDbContext = _context.KhoaHocs.Include(k => k.Nganh);
            return View(await trainingProgramDbContext.ToListAsync());
        }

        // GET: KhoaHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KhoaHocs == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs
                .Include(k => k.Nganh)
                .FirstOrDefaultAsync(m => m.KhoaHocID == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            return View(khoaHoc);
        }

        // GET: KhoaHocs/Create
        public IActionResult Create()
        {
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh");
            return View();
        }

        // POST: KhoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhoaHocID,TenKhoaHoc,MoTa,NgayBatDau,NgayKetThuc,NganhID")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh", khoaHoc.NganhID);
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh", khoaHoc.NganhID);
            return View(khoaHoc);
        }

        // POST: KhoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KhoaHocID,TenKhoaHoc,MoTa,NgayBatDau,NgayKetThuc,NganhID")] KhoaHoc khoaHoc)
        {
            if (id != khoaHoc.KhoaHocID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaHocExists(khoaHoc.KhoaHocID))
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
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh", khoaHoc.NganhID);
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KhoaHocs == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs
                .Include(k => k.Nganh)
                .FirstOrDefaultAsync(m => m.KhoaHocID == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            return View(khoaHoc);
        }

        // POST: KhoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool KhoaHocExists(int id)
        {
          return (_context.KhoaHocs?.Any(e => e.KhoaHocID == id)).GetValueOrDefault();
        }
    }
}
