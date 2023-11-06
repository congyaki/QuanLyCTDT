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
    public class HocPhanController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public HocPhanController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: HocPhan
        public async Task<IActionResult> Index()
        {
            var trainingProgramDbContext = _context.HocPhans.Include(h => h.Khoa).Include(h => h.KhoiKienThuc);
            return View(await trainingProgramDbContext.ToListAsync());
        }

        // GET: HocPhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HocPhans == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans
                .Include(h => h.Khoa)
                .Include(h => h.KhoiKienThuc)
                .FirstOrDefaultAsync(m => m.Ma_HocPhan == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // GET: HocPhan/Create
        public IActionResult Create()
        {
            ViewData["Ma_Khoa"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa");
            ViewData["Ma_KhoiKienThuc"] = new SelectList(_context.KhoiKienThucs, "Id_KhoiKT", "Id_KhoiKT");
            return View();
        }

        // POST: HocPhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ma_HocPhan,Ten_HocPhan,MoTa_HocPhan,SoTinChi_HocPhan,Ma_Khoa,Ma_KhoiKienThuc")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ma_Khoa"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa", hocPhan.Ma_Khoa);
            ViewData["Ma_KhoiKienThuc"] = new SelectList(_context.KhoiKienThucs, "Id_KhoiKT", "Id_KhoiKT", hocPhan.Ma_KhoiKienThuc);
            return View(hocPhan);
        }

        // GET: HocPhan/Edit/5
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
            ViewData["Ma_Khoa"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa", hocPhan.Ma_Khoa);
            ViewData["Ma_KhoiKienThuc"] = new SelectList(_context.KhoiKienThucs, "Id_KhoiKT", "Id_KhoiKT", hocPhan.Ma_KhoiKienThuc);
            return View(hocPhan);
        }

        // POST: HocPhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ma_HocPhan,Ten_HocPhan,MoTa_HocPhan,SoTinChi_HocPhan,Ma_Khoa,Ma_KhoiKienThuc")] HocPhan hocPhan)
        {
            if (id != hocPhan.Ma_HocPhan)
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
                    if (!HocPhanExists(hocPhan.Ma_HocPhan))
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
            ViewData["Ma_Khoa"] = new SelectList(_context.Khoas, "KhoaID", "TenKhoa", hocPhan.Ma_Khoa);
            ViewData["Ma_KhoiKienThuc"] = new SelectList(_context.KhoiKienThucs, "Id_KhoiKT", "Id_KhoiKT", hocPhan.Ma_KhoiKienThuc);
            return View(hocPhan);
        }

        // GET: HocPhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HocPhans == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans
                .Include(h => h.Khoa)
                .Include(h => h.KhoiKienThuc)
                .FirstOrDefaultAsync(m => m.Ma_HocPhan == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // POST: HocPhan/Delete/5
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
          return (_context.HocPhans?.Any(e => e.Ma_HocPhan == id)).GetValueOrDefault();
        }
    }
}
