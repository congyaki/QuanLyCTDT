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
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public GanHocPhansController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<GanHocPhan> ganHocPhans = new List<GanHocPhan>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/GanHocPhan/GetGanHocPhans").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ganHocPhans = JsonConvert.DeserializeObject<List<GanHocPhan>>(data);
            }
            return View(ganHocPhans);
        }

        // GET: DanhMucCTDTsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            GanHocPhan danhMucCTDT = new GanHocPhan();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/GanHocPhan/GetGanHocPhans").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                danhMucCTDT = JsonConvert.DeserializeObject<GanHocPhan>(data);
            }
            return View(danhMucCTDT);
        }

        // GET: GanHocPhans/Create
        /*public IActionResult Create()
        {
            ViewData["MaCTDT_KKT"] = new SelectList(_context.CTDT_KKTs, "MaCTDT_KKT", "MaCTDT_KKT");
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhans, "MaHocPhan", "MaHocPhan");
            return View();
        }

        // POST: GanHocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCTDT_KKT,MaHocPhan")] GanHocPhan ganHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ganHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCTDT_KKT"] = new SelectList(_context.CTDT_KKTs, "MaCTDT_KKT", "MaCTDT_KKT", ganHocPhan.MaCTDT_KKT);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhans, "MaHocPhan", "MaHocPhan", ganHocPhan.MaHocPhan);
            return View(ganHocPhan);
        }

        // GET: GanHocPhans/Edit/5
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
        }*/
    }
}
