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
    public class KhoaHocsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public KhoaHocsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<KhoaHoc> khoaHocs = new List<KhoaHoc>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/KhoaHoc/GetKhoaHocs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoaHocs = JsonConvert.DeserializeObject<List<KhoaHoc>>(data);
            }
            return View(khoaHocs);
        }

        // GET: KhoaHocsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            KhoaHoc khoaHoc = new KhoaHoc();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/KhoaHoc/GetKhoaHoc").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoaHoc = JsonConvert.DeserializeObject<KhoaHoc>(data);
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Create
        /*public IActionResult Create()
        {
            return View();
        }

        // POST: KhoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhoaHoc,Ten,MoTa,NgayBatDau,NgayKetThuc")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhoaHocs == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

        // POST: KhoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhoaHoc,Ten,MoTa,NgayBatDau,NgayKetThuc")] KhoaHoc khoaHoc)
        {
            if (id != khoaHoc.MaKhoaHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaHocExists(khoaHoc.MaKhoaHoc))
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
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhoaHocs == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs
                .FirstOrDefaultAsync(m => m.MaKhoaHoc == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            return View(khoaHoc);
        }

        // POST: KhoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhoaHocs == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.KhoaHocs'  is null.");
            }
            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc != null)
            {
                _context.KhoaHocs.Remove(khoaHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaHocExists(string id)
        {
          return (_context.KhoaHocs?.Any(e => e.MaKhoaHoc == id)).GetValueOrDefault();
        }*/
    }
}
