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

namespace QuanLyCTDT.Controllers
{
    public class GanHocPhansController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public GanHocPhansController(TrainingProgramDbContext context)
        {
            _context = context;
        }
        // GET: KhoaHocsController
        [HttpGet]
        [Route("GanHocPhans/Index")]

        public IActionResult Index()
        {
            
            return View();
        }

        // GET: DanhMucCTDTsController/Details/5
        [HttpGet("{id}")]
        [Route("GanHocPhans/Details/{id}")]

        public IActionResult Details()
        {
            
            return View();
        }

        // GET: GanHocPhans/Create
        [HttpGet]
        [Route("GanHocPhans/Create/{id}")]
        public IActionResult Create(string id)
        {
            ViewData["CTDT_KKT"] = _context.CTDT_KKTs.FirstOrDefault(e => e.MaCTDT_KKT == id);
            ViewData["HocPhans"] = new SelectList(_context.HocPhans, "MaHocPhan", "Ten");
            return View();
        }

        // POST: GanHocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("GanHocPhans/Create/{id}")]
        public async Task<IActionResult> Create(string maCTDT_KKT, string[] maHP)
        {

            if (maCTDT_KKT != null && maHP != null)
            {
                foreach (var hp in maHP)
                {
                    GanHocPhan ganHP = new GanHocPhan
                    {
                        MaCTDT_KKT = maCTDT_KKT,
                        MaHocPhan = hp
                    };

                    // Lưu KKT vào cơ sở dữ liệu
                    _context.GanHocPhans.Add(ganHP);
                    await _context.SaveChangesAsync();
                }
                var maCTDT = _context.CTDT_KKTs.FirstOrDefault(e => e.MaCTDT_KKT == maCTDT_KKT).MaCTDT;
                return RedirectToAction("Details", "ChuongTrinhDaoTaos", new { id = maCTDT });
            }
            ViewData["HocPhans"] = new SelectList(_context.HocPhans, "MaHocPhan", "Ten");

            return View();
        }

        // GET: GanHocPhans/Edit/5
        [Route("GanHocPhans/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GanHocPhans == null)
            {
                return NotFound();
            }

            var ganHocPhan = await _context.GanHocPhans.FindAsync(id);
            if (ganHocPhan == null)
            {
                return NotFound();
            }
            ViewData["MaCTDT_KKT"] = new SelectList(_context.CTDT_KKTs, "MaCTDT_KKT", "MaCTDT_KKT", ganHocPhan.MaCTDT_KKT);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhans, "MaHocPhan", "MaHocPhan", ganHocPhan.MaHocPhan);
            return View(ganHocPhan);
        }

        // POST: GanHocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("GanHocPhans/Edit/{id}")]

        public async Task<IActionResult> Edit(string id, [Bind("MaCTDT_KKT,MaHocPhan")] GanHocPhan ganHocPhan)
        {
            if (id != ganHocPhan.MaCTDT_KKT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ganHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GanHocPhanExists(ganHocPhan.MaCTDT_KKT))
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
            ViewData["MaCTDT_KKT"] = new SelectList(_context.CTDT_KKTs, "MaCTDT_KKT", "MaCTDT_KKT", ganHocPhan.MaCTDT_KKT);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhans, "MaHocPhan", "MaHocPhan", ganHocPhan.MaHocPhan);
            return View(ganHocPhan);
        }

        // GET: GanHocPhans/Delete/5
        [Route("GanHocPhans/Delete/{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GanHocPhans == null)
            {
                return NotFound();
            }

            var ganHocPhan = await _context.GanHocPhans
                .Include(g => g.CTDT_KKT)
                .Include(g => g.HocPhan)
                .FirstOrDefaultAsync(m => m.MaCTDT_KKT == id);
            if (ganHocPhan == null)
            {
                return NotFound();
            }

            return View(ganHocPhan);
        }

        // POST: GanHocPhans/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("GanHocPhans/Delete/{id}")]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GanHocPhans == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.GanHocPhans'  is null.");
            }
            var ganHocPhan = await _context.GanHocPhans.FindAsync(id);
            if (ganHocPhan != null)
            {
                _context.GanHocPhans.Remove(ganHocPhan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GanHocPhanExists(string id)
        {
            return (_context.GanHocPhans?.Any(e => e.MaCTDT_KKT == id)).GetValueOrDefault();
        }
    }
}
