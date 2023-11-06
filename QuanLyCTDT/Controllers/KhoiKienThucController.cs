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
    public class KhoiKienThucController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public KhoiKienThucController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: KhoiKienThuc
        public async Task<IActionResult> Index()
        {
              return _context.KhoiKienThucs != null ? 
                          View(await _context.KhoiKienThucs.ToListAsync()) :
                          Problem("Entity set 'TrainingProgramDbContext.KhoiKienThucs'  is null.");
        }

        // GET: KhoiKienThuc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhoiKienThucs == null)
            {
                return NotFound();
            }

            var khoiKienThuc = await _context.KhoiKienThucs
                .FirstOrDefaultAsync(m => m.Id_KhoiKT == id);
            if (khoiKienThuc == null)
            {
                return NotFound();
            }

            return View(khoiKienThuc);
        }

        // GET: KhoiKienThuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoiKienThuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_KhoiKT,Ten_KhoiKT,MoTa_KhoiKT")] KhoiKienThuc khoiKienThuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoiKienThuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoiKienThuc);
        }

        // GET: KhoiKienThuc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhoiKienThucs == null)
            {
                return NotFound();
            }

            var khoiKienThuc = await _context.KhoiKienThucs.FindAsync(id);
            if (khoiKienThuc == null)
            {
                return NotFound();
            }
            return View(khoiKienThuc);
        }

        // POST: KhoiKienThuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id_KhoiKT,Ten_KhoiKT,MoTa_KhoiKT")] KhoiKienThuc khoiKienThuc)
        {
            if (id != khoiKienThuc.Id_KhoiKT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoiKienThuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoiKienThucExists(khoiKienThuc.Id_KhoiKT))
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
            return View(khoiKienThuc);
        }

        // GET: KhoiKienThuc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhoiKienThucs == null)
            {
                return NotFound();
            }

            var khoiKienThuc = await _context.KhoiKienThucs
                .FirstOrDefaultAsync(m => m.Id_KhoiKT == id);
            if (khoiKienThuc == null)
            {
                return NotFound();
            }

            return View(khoiKienThuc);
        }

        // POST: KhoiKienThuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhoiKienThucs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.KhoiKienThucs'  is null.");
            }
            var khoiKienThuc = await _context.KhoiKienThucs.FindAsync(id);
            if (khoiKienThuc != null)
            {
                _context.KhoiKienThucs.Remove(khoiKienThuc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoiKienThucExists(string id)
        {
          return (_context.KhoiKienThucs?.Any(e => e.Id_KhoiKT == id)).GetValueOrDefault();
        }
    }
}
