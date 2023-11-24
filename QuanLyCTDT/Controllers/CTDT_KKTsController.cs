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
    public class CTDT_KKTsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public CTDT_KKTsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        // GET: CTDT_KKTsController
        [HttpGet]
        public IActionResult Index()
        {
            List<CTDT_KKT> ctdt_kkts = new List<CTDT_KKT>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/CTDT_KKT/GetCTDT_KKTs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ctdt_kkts = JsonConvert.DeserializeObject<List<CTDT_KKT>>(data);
            }
            return View(ctdt_kkts);
        }

        // GET: DanhMucCTDT_KKTs/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            CTDT_KKT ctdt_kkt = new CTDT_KKT();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/CTDT_KKT/GetCTDT_KKT").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ctdt_kkt = JsonConvert.DeserializeObject<CTDT_KKT>(data);
            }
            return View(ctdt_kkt);
        }

        // GET: CTDT_KKTs/Create
        /*public IActionResult Create()
        {
            ViewData["MaCTDT"] = new SelectList(_context.ChuongTrinhDaoTaos, "MaCTDT", "MaCTDT");
            ViewData["MaKKT"] = new SelectList(_context.KhoiKienThucs, "MaKKT", "MaKKT");
            return View();
        }

        // POST: CTDT_KKTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCTDT_KKT,MaCTDT,MaKKT")] CTDT_KKT cTDT_KKT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cTDT_KKT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCTDT"] = new SelectList(_context.ChuongTrinhDaoTaos, "MaCTDT", "MaCTDT", cTDT_KKT.MaCTDT);
            ViewData["MaKKT"] = new SelectList(_context.KhoiKienThucs, "MaKKT", "MaKKT", cTDT_KKT.MaKKT);
            return View(cTDT_KKT);
        }

        // GET: CTDT_KKTs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CTDT_KKTs == null)
            {
                return NotFound();
            }

            var cTDT_KKT = await _context.CTDT_KKTs.FindAsync(id);
            if (cTDT_KKT == null)
            {
                return NotFound();
            }
            ViewData["MaCTDT"] = new SelectList(_context.ChuongTrinhDaoTaos, "MaCTDT", "MaCTDT", cTDT_KKT.MaCTDT);
            ViewData["MaKKT"] = new SelectList(_context.KhoiKienThucs, "MaKKT", "MaKKT", cTDT_KKT.MaKKT);
            return View(cTDT_KKT);
        }

        // POST: CTDT_KKTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCTDT_KKT,MaCTDT,MaKKT")] CTDT_KKT cTDT_KKT)
        {
            if (id != cTDT_KKT.MaCTDT_KKT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cTDT_KKT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CTDT_KKTExists(cTDT_KKT.MaCTDT_KKT))
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
            ViewData["MaCTDT"] = new SelectList(_context.ChuongTrinhDaoTaos, "MaCTDT", "MaCTDT", cTDT_KKT.MaCTDT);
            ViewData["MaKKT"] = new SelectList(_context.KhoiKienThucs, "MaKKT", "MaKKT", cTDT_KKT.MaKKT);
            return View(cTDT_KKT);
        }

        // GET: CTDT_KKTs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CTDT_KKTs == null)
            {
                return NotFound();
            }

            var cTDT_KKT = await _context.CTDT_KKTs
                .Include(c => c.ChuongTrinhDaoTao)
                .Include(c => c.KhoiKienThuc)
                .FirstOrDefaultAsync(m => m.MaCTDT_KKT == id);
            if (cTDT_KKT == null)
            {
                return NotFound();
            }

            return View(cTDT_KKT);
        }

        // POST: CTDT_KKTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CTDT_KKTs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.CTDT_KKTs'  is null.");
            }
            var cTDT_KKT = await _context.CTDT_KKTs.FindAsync(id);
            if (cTDT_KKT != null)
            {
                _context.CTDT_KKTs.Remove(cTDT_KKT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CTDT_KKTExists(string id)
        {
          return (_context.CTDT_KKTs?.Any(e => e.MaCTDT_KKT == id)).GetValueOrDefault();
        }*/
    }
}
