using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_CTDT.Data.Models.EF;
using QL_CTDT.Data.Models.Entities;

namespace QL_CTDT.WebClient.Controllers
{
    public class HocPhansController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public HocPhansController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: HocPhans
        public async Task<IActionResult> Index()
        {
            var trainingProgramDbContext = _context.HocPhans.Include(h => h.Khoa);
            return View(await trainingProgramDbContext.ToListAsync());
        }

        // GET: HocPhans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HocPhans == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans
                .Include(h => h.Khoa)
                .FirstOrDefaultAsync(m => m.MaHocPhan == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // GET: HocPhans/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa");
            return View();
        }

        // POST: HocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHocPhan,Ten,MoTa,SoTinChi,MaKhoa")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", hocPhan.MaKhoa);
            return View(hocPhan);
        }

        // GET: HocPhans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HocPhans == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans.FindAsync(id);
            if (hocPhan == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", hocPhan.MaKhoa);
            return View(hocPhan);
        }

        // POST: HocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHocPhan,Ten,MoTa,SoTinChi,MaKhoa")] HocPhan hocPhan)
        {
            if (id != hocPhan.MaHocPhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocPhanExists(hocPhan.MaHocPhan))
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", hocPhan.MaKhoa);
            return View(hocPhan);
        }

        // GET: HocPhans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HocPhans == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans
                .Include(h => h.Khoa)
                .FirstOrDefaultAsync(m => m.MaHocPhan == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // POST: HocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HocPhans == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.HocPhans'  is null.");
            }
            var hocPhan = await _context.HocPhans.FindAsync(id);
            if (hocPhan != null)
            {
                _context.HocPhans.Remove(hocPhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocPhanExists(string id)
        {
          return (_context.HocPhans?.Any(e => e.MaHocPhan == id)).GetValueOrDefault();
        }
    }
}
