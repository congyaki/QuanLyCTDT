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
    public class HocPhansController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public HocPhansController(TrainingProgramDbContext context)
        {
            _context = context;
        }
        // GET: KhoaHocsController
        [HttpGet]
        [Route("HocPhans/Index")]
        public async Task<IActionResult> Index()
        {
            if (_context.HocPhans == null)
            {
                return NotFound();
            }

            var model = await(from hp in _context.HocPhans
                        join k in _context.Khoas
                        on hp.MaKhoa equals k.MaKhoa
                        select new HocPhan_VM()
                        {
                            MaHocPhan = hp.MaHocPhan,
                            Ten = hp.Ten,
                            SoTinChi = hp.SoTinChi,
                            MoTa = hp.MoTa,
                            TenKhoa = k.Ten,
                        }).ToListAsync();
            return View(model);
        }

        // GET: HocPhansController/Details/5
        [HttpGet("{id}")]
        [Route("HocPhans/Details/{id}")]

        public IActionResult Details(string id)
        {
            if (_context.HocPhans == null)
            {
                return NotFound();
            }
            var model = (from hp in _context.HocPhans
                        join k in _context.Khoas
                        on hp.MaKhoa equals k.MaKhoa
                        where hp.MaHocPhan == id
                        select new HocPhan_VM()
                        {
                            MaHocPhan = hp.MaHocPhan,
                            Ten = hp.Ten,
                            SoTinChi = hp.SoTinChi,
                            MoTa = hp.MoTa,
                            TenKhoa = k.Ten,
                        }).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: HocPhans/Create
        [HttpGet]
        [Route("HocPhans/Create")]

        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "Ten");
            return View();
        }

        // POST: HocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("HocPhans/Create")]

        public async Task<IActionResult> Create([Bind("MaHocPhan,Ten,MoTa,SoTinChi,MaKhoa")] HocPhan_VM hocPhan)
        {
            if (ModelState.IsValid)
            {
                var _hocPhan = new HocPhan
                {
                    MaHocPhan = hocPhan.MaHocPhan,
                    Ten = hocPhan.Ten,
                    MoTa = hocPhan.MoTa,
                    SoTinChi = (int)hocPhan.SoTinChi,
                    MaKhoa = hocPhan.MaKhoa,
                };
                _context.Add(_hocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "Ten", hocPhan.MaKhoa);
            return View(hocPhan);
        }

        // GET: HocPhans/Edit/5
        [HttpGet]
        [Route("HocPhans/Edit/{id}")]
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "Ten", hocPhan.MaKhoa);
            return View(hocPhan);
        }

        // POST: HocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("HocPhans/Edit/{id}")]

        public async Task<IActionResult> Edit(string id, [Bind("MaHocPhan,Ten,MoTa,SoTinChi,MaKhoa")] HocPhan_VM hocPhan)
        {
            if (id != hocPhan.MaHocPhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var _hocPhan = _context.HocPhans.FirstOrDefault(p => p.MaHocPhan == id);

                if (id != _hocPhan.MaHocPhan)
                {
                    return BadRequest();
                }

                _hocPhan.Ten = hocPhan.Ten;
                _hocPhan.MoTa = hocPhan.MoTa;
                _hocPhan.SoTinChi = (int)hocPhan.SoTinChi;
                _hocPhan.MaKhoa = hocPhan.MaKhoa;
                try
                {
                    _context.Update(_hocPhan);
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
        [Route("HocPhans/Delete/{id}")]

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
        [Route("HocPhans/Delete/{id}")]

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
