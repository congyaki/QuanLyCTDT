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
using QL_CTDT.Data.Models.ViewModels;

namespace QuanLyCTDT.Controllers
{
    public class KhoasController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public KhoasController(TrainingProgramDbContext context)
        {
            _context = context;
        }
        // GET: KhoaHocsController
        [HttpGet]
        [Route("Khoas/Index")]
        public async Task<IActionResult> Index()
        {
            if (_context.Khoas == null)
            {
                return NotFound();
            }
            var khoa = await _context.Khoas.ToListAsync();
            return View(khoa);
        }

        // GET: KhoasController/Details/5
        [HttpGet("{id}")]
        [Route("Khoas/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (_context.Khoas == null)
            {
                return NotFound();
            }
            var hocPhans = await (from hp in _context.HocPhans
                                  where hp.MaKhoa == id
                                  select hp).ToListAsync();

            var khoa = await (from k in _context.Khoas
                              where k.MaKhoa == id
                              select new Khoa()
                              {
                                  MaKhoa = k.MaKhoa,
                                  Ten = k.Ten,
                                  MoTa = k.MoTa,
                                  HocPhans = hocPhans
                              }).FirstOrDefaultAsync();
            return View(khoa);
        }

        // GET: Khoas/Create
        [Route("Khoas/Create")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Khoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Khoas/Create")]

        public async Task<IActionResult> Create([Bind("MaKhoa,Ten,MoTa")] Khoa_VM khoa)
        {
            if (ModelState.IsValid)
            {
                var _khoa = new Khoa
                {
                    MaKhoa = khoa.MaKhoa,
                    Ten = khoa.Ten,
                    MoTa = khoa.MoTa,
                };
                _context.Add(_khoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoa);
        }

        // GET: Khoas/Edit/5
        [HttpGet]
        [Route("Khoas/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Khoas == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        // POST: Khoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Khoas/Edit/{id}")]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhoa,Ten,MoTa")] Khoa_VM khoa)
        {
            if (id != khoa.MaKhoa)
            {
                return NotFound();
            }
            var _khoa = _context.Khoas.FirstOrDefault(p => p.MaKhoa == id);

            if (ModelState.IsValid)
            {
                if (id != _khoa.MaKhoa)
                {
                    return BadRequest();
                }

                _khoa.Ten = khoa.Ten;
                _khoa.MoTa = khoa.MoTa;
                try
                {
                    _context.Update(_khoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaExists(khoa.MaKhoa))
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
            return View(khoa);
        }

        // GET: Khoas/Delete/5
        [Route("Khoas/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Khoas == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.MaKhoa == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // POST: Khoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Khoas/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Khoas == null)
            {
                return Problem("Entity set 'TrainingProgramDbContext.Khoas'  is null.");
            }
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa != null)
            {
                _context.Khoas.Remove(khoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaExists(string id)
        {
            return (_context.Khoas?.Any(e => e.MaKhoa == id)).GetValueOrDefault();
        }
    }
}
