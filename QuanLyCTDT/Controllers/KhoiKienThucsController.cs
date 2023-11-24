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
    public class KhoiKienThucsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public KhoiKienThucsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<KhoiKienThuc> khoiKienThucs = new List<KhoiKienThuc>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/KhoiKienThuc/GetKhoiKienThucs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoiKienThucs = JsonConvert.DeserializeObject<List<KhoiKienThuc>>(data);
            }
            return View(khoiKienThucs);
        }

        // GET: KhoiKienThucsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            KhoiKienThuc khoiKienThuc = new KhoiKienThuc();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/KhoiKienThuc/GetKhoiKienThuc").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoiKienThuc = JsonConvert.DeserializeObject<KhoiKienThuc>(data);
            }
            return View(khoiKienThuc);
        }

        // GET: KhoiKienThucs/Create
        /*public IActionResult Create()
        {
            return View();
        }

        // POST: KhoiKienThucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKKT,Ten,MoTa")] KhoiKienThuc khoiKienThuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoiKienThuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoiKienThuc);
        }

        // GET: KhoiKienThucs/Edit/5
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
        public async Task<IActionResult> Edit(string id, [Bind("MaKKT,Ten,MoTa")] KhoiKienThuc khoiKienThuc)
        {
            if (id != khoiKienThuc.MaKKT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoiKienThuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoiKienThucExists(khoiKienThuc.MaKKT))
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
            return View(khoiKienThuc);
        }

        // GET: KhoiKienThucs/Delete/5
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
        }*/
    }
}
