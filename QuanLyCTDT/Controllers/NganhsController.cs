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
    public class NganhsController : Controller
    {

        private readonly TrainingProgramDbContext _context;

        public NganhsController(TrainingProgramDbContext context)
        {
            _context = context;
        }
        // GET: KhoaHocsController
        [HttpGet]
        [Route("Nganhs/Index")]
        public async Task<IActionResult> Index()
        {
            if (_context.Nganhs == null)
            {
                return NotFound();
            }
            var danhSachNganhVM = await _context.Nganhs
                .Select(nganh => new Nganh_VM
                {
                    MaNganh = nganh.MaNganh,
                    Ten = nganh.Ten,
                    MoTa = nganh.MoTa,
                    MaKhoa = nganh.MaKhoa,
                    TenKhoa = nganh.Khoa.Ten
                })
                .ToListAsync();
            return View(danhSachNganhVM);
        }

        // GET: NganhsController/Details/5
        [HttpGet("{id}")]
        [Route("Nganhs/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (_context.Nganhs == null)
            {
                return NotFound();
            }
            var nganh = await _context.Nganhs
                .Where(p => p.MaNganh == id)
                .Select(nganh => new Nganh_VM
                {
                    MaNganh = nganh.MaNganh,
                    Ten = nganh.Ten,
                    MoTa = nganh.MoTa,
                    MaKhoa = nganh.MaKhoa,
                    TenKhoa = nganh.Khoa.Ten
                }).FirstOrDefaultAsync();
            return View(nganh);
        }

        // GET: Nganhs/Create
        [HttpGet]
        [Route("Nganhs/Create")]
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "Ten");
            return View();
        }

        // POST: Nganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Nganhs/Create")]
        public async Task<IActionResult> Create([Bind("MaNganh,Ten,MoTa,MaKhoa")] Nganh_VM nganh)
        {
            if (ModelState.IsValid)
            {
                if (_context.Nganhs == null)
                {
                    return Problem("Entity set 'TrainingProgramDbContext.Nganhs'  is null.");
                }
                var _nganh = new Nganh
                {
                    MaNganh = nganh.MaNganh,
                    Ten = nganh.Ten,
                    MoTa = nganh.MoTa,
                    MaKhoa = nganh.MaKhoa,
                };
                _context.Add(_nganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "Ten", nganh.MaKhoa);
            return View(nganh);
        }

        // GET: Nganhs/Edit/5
        [HttpGet]
        [Route("Nganhs/Edit/{id}")]
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
        [Route("Nganhs/Edit/{id}")]
        public async Task<IActionResult> Edit(string id, [Bind("MaNganh,Ten,MoTa,MaKhoa")] Nganh_VM nganh)
        {
            var _nganh = _context.Nganhs.FirstOrDefault(p => p.MaNganh == id);

            if (id != _nganh.MaNganh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                
                _nganh.Ten = nganh.Ten;
                _nganh.MoTa = nganh.MoTa;
                _nganh.MaKhoa = nganh.MaKhoa;
                try
                {
                    _context.Update(_nganh);
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
        [Route("Nganhs/Delete/{id}")]
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
        [Route("Nganhs/Delete/{id}")]
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
