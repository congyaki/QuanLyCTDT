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
    public class KhoiKienThucsController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public KhoiKienThucsController(TrainingProgramDbContext context)
        {
            _context = context;
        }
        // GET: KhoaHocsController
        [HttpGet]
        [Route("KhoiKienThucs/Index")]
        public async Task<IActionResult> Index()
        {
            if (_context.KhoiKienThucs == null)
            {
                return NotFound();
            }
            var kkt = await _context.KhoiKienThucs.ToListAsync();
            return View(kkt);
        }

        // GET: KhoiKienThucsController/Details/5
        [HttpGet("{id}")]
        [Route("KhoiKienThucs/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (_context.KhoiKienThucs == null)
            {
                return NotFound();
            }
            var khoiKienThuc = await _context.KhoiKienThucs.FirstOrDefaultAsync(e => e.MaKKT == id);

            if (khoiKienThuc == null)
            {
                return NotFound();
            }
            return View(khoiKienThuc);
        }

        // GET: KhoiKienThucs/Create
        [HttpGet]
        [Route("KhoiKienThucs/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoiKienThucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("KhoiKienThucs/Create")]
        public async Task<IActionResult> Create([Bind("MaKKT,Ten,MoTa")] KhoiKienThuc_VM kKT)
        {
            if (ModelState.IsValid)
            {
                if (_context.KhoiKienThucs == null)
                {
                    return Problem("Entity set 'TrainingProgramDbContext.KhoiKienThucs'  is null.");
                }

                var _kKT = new KhoiKienThuc
                {
                    MaKKT = kKT.MaKKT,
                    Ten = kKT.Ten,
                    MoTa = kKT.MoTa,
                };
                _context.Add(_kKT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kKT);
        }

        // GET: KhoiKienThucs/Edit/5
        [HttpGet]
        [Route("KhoiKienThucs/Edit/{id}")]
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

        // POST: KhoiKienThucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("KhoiKienThucs/Edit/{id}")]
        public async Task<IActionResult> Edit(string id, [Bind("MaKKT,Ten,MoTa")] KhoiKienThuc_VM kKT)
        {

            if (ModelState.IsValid)
            {
                var _kKT = _context.KhoiKienThucs.FirstOrDefault(p => p.MaKKT == id);
                if (id != _kKT.MaKKT)
                {
                    return NotFound();
                }
                _kKT.Ten = kKT.Ten;
                _kKT.MoTa = kKT.MoTa;
                try
                {
                    _context.Update(_kKT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoiKienThucExists(kKT.MaKKT))
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
            return View(kKT);
        }

        // GET: KhoiKienThucs/Delete/5
        [Route("KhoiKienThucs/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhoiKienThucs == null)
            {
                return NotFound();
            }

            var khoiKienThuc = await _context.KhoiKienThucs
                .FirstOrDefaultAsync(m => m.MaKKT == id);
            if (khoiKienThuc == null)
            {
                return NotFound();
            }

            return View(khoiKienThuc);
        }

        // POST: KhoiKienThucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("KhoiKienThucs/Delete/{id}")]
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
            return (_context.KhoiKienThucs?.Any(e => e.MaKKT == id)).GetValueOrDefault();
        }
    }
}
