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
    public class NganhsController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public NganhsController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: Nganhs
        public async Task<IActionResult> Index()
        {
            var trainingProgramDbContext = _context.Nganhs.Include(n => n.Khoa);
            return View(await trainingProgramDbContext.ToListAsync());
        }

        // GET: Nganhs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nganhs == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs
                .Include(n => n.Khoa)
                .FirstOrDefaultAsync(m => m.MaNganh == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // GET: Nganhs/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa");
            return View();
        }

        // POST: Nganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNganh,Ten,MoTa,MaKhoa")] Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", nganh.MaKhoa);
            return View(nganh);
        }

        // GET: Nganhs/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", nganh.MaKhoa);
            return View(nganh);
        }

        // POST: Nganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNganh,Ten,MoTa,MaKhoa")] Nganh nganh)
        {
            if (id != nganh.MaNganh)
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
                    if (!NganhExists(nganh.MaNganh))
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", nganh.MaKhoa);
            return View(nganh);
        }

        // GET: Nganhs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nganhs == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs
                .Include(n => n.Khoa)
                .FirstOrDefaultAsync(m => m.MaNganh == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // POST: Nganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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

        private bool NganhExists(string id)
        {
          return (_context.Nganhs?.Any(e => e.MaNganh == id)).GetValueOrDefault();
        }
    }
}
