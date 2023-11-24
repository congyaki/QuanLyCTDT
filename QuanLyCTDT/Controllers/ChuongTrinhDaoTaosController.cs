﻿using System;
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
    public class ChuongTrinhDaoTaosController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public ChuongTrinhDaoTaosController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<ChuongTrinhDaoTao> ctdts = new List<ChuongTrinhDaoTao>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/ChuongTrinhDaoTao/GetChuongTrinhDaoTaos").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ctdts = JsonConvert.DeserializeObject<List<ChuongTrinhDaoTao>>(data);
            }
            return View(ctdts);
        }

        // GET: DanhMucCTDT_KKTs/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            ChuongTrinhDaoTao ctdt = new ChuongTrinhDaoTao();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/ChuongTrinhDaoTao/GetChuongTrinhDaoTao").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ctdt = JsonConvert.DeserializeObject<ChuongTrinhDaoTao>(data);
            }
            return View(ctdt);
        }

        // GET: ChuongTrinhDaoTaos/Create
        /*public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa");
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc");
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh");
            return View();
        }

        // POST: ChuongTrinhDaoTaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCTDT,Ten,MaKhoa,MaKhoaHoc,MaNganh,SoNamDaoTao")] ChuongTrinhDaoTao chuongTrinhDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuongTrinhDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", chuongTrinhDaoTao.MaKhoa);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc", chuongTrinhDaoTao.MaKhoaHoc);
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", chuongTrinhDaoTao.MaNganh);
            return View(chuongTrinhDaoTao);
        }

        // GET: ChuongTrinhDaoTaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChuongTrinhDaoTaos == null)
            {
                return NotFound();
            }

            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos.FindAsync(id);
            if (chuongTrinhDaoTao == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", chuongTrinhDaoTao.MaKhoa);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc", chuongTrinhDaoTao.MaKhoaHoc);
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", chuongTrinhDaoTao.MaNganh);
            return View(chuongTrinhDaoTao);
        }

        // POST: ChuongTrinhDaoTaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCTDT,Ten,MaKhoa,MaKhoaHoc,MaNganh,SoNamDaoTao")] ChuongTrinhDaoTao chuongTrinhDaoTao)
        {
            if (id != chuongTrinhDaoTao.MaCTDT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuongTrinhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuongTrinhDaoTaoExists(chuongTrinhDaoTao.MaCTDT))
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", chuongTrinhDaoTao.MaKhoa);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc", chuongTrinhDaoTao.MaKhoaHoc);
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", chuongTrinhDaoTao.MaNganh);
            return View(chuongTrinhDaoTao);
        }

        // GET: ChuongTrinhDaoTaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChuongTrinhDaoTaos == null)
            {
                return NotFound();
            }

            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos
                .Include(c => c.Khoa)
                .Include(c => c.KhoaHoc)
                .Include(c => c.Nganh)
                .FirstOrDefaultAsync(m => m.MaCTDT == id);
            if (chuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(chuongTrinhDaoTao);
        }

        // POST: ChuongTrinhDaoTaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChuongTrinhDaoTaos == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.ChuongTrinhDaoTaos'  is null.");
            }
            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos.FindAsync(id);
            if (chuongTrinhDaoTao != null)
            {
                _context.ChuongTrinhDaoTaos.Remove(chuongTrinhDaoTao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuongTrinhDaoTaoExists(string id)
        {
          return (_context.ChuongTrinhDaoTaos?.Any(e => e.MaCTDT == id)).GetValueOrDefault();
        }*/
    }
}