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
    public class NganhController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public NganhController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: Nganh
        public async Task<IActionResult> Index()
        {
            var trainingProgramDbContext = _context.Nganhs.Include(n => n.Khoa);
            return View(await trainingProgramDbContext.ToListAsync());
        }

        // GET: Nganh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nganhs == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs
                .Include(n => n.Khoa)
                .FirstOrDefaultAsync(m => m.NganhID == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // GET: Nganh/Create
        public IActionResult Create()
        {
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa");
            return View();
        }

        // POST: Nganh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NganhID,TenNganh,MoTa,KhoaID")] Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa", nganh.KhoaID);
            return View(nganh);
        }

        // GET: Nganh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nganhs == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs.FindAsync(id);
            if (nganh == null)
            {
                return NotFound();
            }
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa", nganh.KhoaID);
            return View(nganh);
        }

        // POST: Nganh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NganhID,TenNganh,MoTa,KhoaID")] Nganh nganh)
        {
            if (id != nganh.NganhID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhExists(nganh.NganhID))
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
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa", nganh.KhoaID);
            return View(nganh);
        }

        // GET: Nganh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nganhs == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs
                .Include(n => n.Khoa)
                .FirstOrDefaultAsync(m => m.NganhID == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // POST: Nganh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nganhs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.Nganhs'  is null.");
            }
            var nganh = await _context.Nganhs.FindAsync(id);
            if (nganh != null)
            {
                _context.Nganhs.Remove(nganh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NganhExists(int id)
        {
          return (_context.Nganhs?.Any(e => e.NganhID == id)).GetValueOrDefault();
        }
    }
}
