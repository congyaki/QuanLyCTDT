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
    public class DanhMucCTDTController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public DanhMucCTDTController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: DanhMucCTDT
        public async Task<IActionResult> Index()
        {
            var trainingProgramDbContext = _context.DanhMucCTDTs.Include(d => d.KhoaHoc).Include(d => d.Nganh);
            return View(await trainingProgramDbContext.ToListAsync());
        }

        // GET: DanhMucCTDT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhMucCTDTs == null)
            {
                return NotFound();
            }

            var danhMucCTDT = await _context.DanhMucCTDTs
                .Include(d => d.KhoaHoc)
                .Include(d => d.Nganh)
                .FirstOrDefaultAsync(m => m.NganhID == id);
            if (danhMucCTDT == null)
            {
                return NotFound();
            }

            return View(danhMucCTDT);
        }

        // GET: DanhMucCTDT/Create
        public IActionResult Create()
        {
            ViewData["KhoaHocID"] = new SelectList(_context.KhoaHocs, "KhoaHocID", "TenKhoaHoc");
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh");
            return View();
        }

        // POST: DanhMucCTDT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NganhID,KhoaHocID")] DanhMucCTDT danhMucCTDT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucCTDT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaHocID"] = new SelectList(_context.KhoaHocs, "KhoaHocID", "TenKhoaHoc", danhMucCTDT.KhoaHocID);
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh", danhMucCTDT.NganhID);
            return View(danhMucCTDT);
        }

        // GET: DanhMucCTDT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhMucCTDTs == null)
            {
                return NotFound();
            }

            var danhMucCTDT = await _context.DanhMucCTDTs.FindAsync(id);
            if (danhMucCTDT == null)
            {
                return NotFound();
            }
            ViewData["KhoaHocID"] = new SelectList(_context.KhoaHocs, "KhoaHocID", "TenKhoaHoc", danhMucCTDT.KhoaHocID);
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh", danhMucCTDT.NganhID);
            return View(danhMucCTDT);
        }

        // POST: DanhMucCTDT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NganhID,KhoaHocID")] DanhMucCTDT danhMucCTDT)
        {
            if (id != danhMucCTDT.NganhID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucCTDT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucCTDTExists(danhMucCTDT.NganhID))
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
            ViewData["KhoaHocID"] = new SelectList(_context.KhoaHocs, "KhoaHocID", "TenKhoaHoc", danhMucCTDT.KhoaHocID);
            ViewData["NganhID"] = new SelectList(_context.Nganhs, "NganhID", "TenNganh", danhMucCTDT.NganhID);
            return View(danhMucCTDT);
        }

        // GET: DanhMucCTDT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhMucCTDTs == null)
            {
                return NotFound();
            }

            var danhMucCTDT = await _context.DanhMucCTDTs
                .Include(d => d.KhoaHoc)
                .Include(d => d.Nganh)
                .FirstOrDefaultAsync(m => m.NganhID == id);
            if (danhMucCTDT == null)
            {
                return NotFound();
            }

            return View(danhMucCTDT);
        }

        // POST: DanhMucCTDT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DanhMucCTDTs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.DanhMucCTDTs'  is null.");
            }
            var danhMucCTDT = await _context.DanhMucCTDTs.FindAsync(id);
            if (danhMucCTDT != null)
            {
                _context.DanhMucCTDTs.Remove(danhMucCTDT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucCTDTExists(int id)
        {
          return (_context.DanhMucCTDTs?.Any(e => e.NganhID == id)).GetValueOrDefault();
        }
    }
}
