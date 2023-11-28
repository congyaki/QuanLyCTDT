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
    public class ChuongTrinhDaoTaosController : Controller
    {
        private readonly TrainingProgramDbContext _context;

        public ChuongTrinhDaoTaosController(TrainingProgramDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            if (_context.ChuongTrinhDaoTaos == null)
            {
                return NotFound();
            }
            var model = await(from ctdt in _context.ChuongTrinhDaoTaos
                              join k in _context.Khoas on ctdt.MaKhoa equals k.MaKhoa
                              join kh in _context.KhoaHocs on ctdt.MaKhoaHoc equals kh.MaKhoaHoc
                              join n in _context.Nganhs on ctdt.MaNganh equals n.MaNganh
                              select new CTDT_VM()
                              {
                                  MaCTDT = ctdt.MaCTDT,
                                  TenCTDT = ctdt.Ten,
                                  MaKhoa = ctdt.MaKhoa,
                                  TenKhoa = k.Ten,
                                  MaKhoaHoc = ctdt.MaKhoaHoc,
                                  TenKhoaHoc = kh.Ten,
                                  MaNganh = ctdt.MaNganh,
                                  TenNganh = n.Ten,
                                  SoNamDaoTao = ctdt.SoNamDaoTao,
                              }).ToListAsync();
            return View(model);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (_context.ChuongTrinhDaoTaos == null)
            {
                return NotFound();
            }
            var chiTietCTDT = _context.KhoaHocs
            .SelectMany(kh => kh.ChuongTrinhDaoTaos.Where(ctdt => ctdt.MaCTDT == id).Select(ctdt => new ChiTietCTDT_VM
            {
                TenKhoaHoc = kh.Ten,
                TenNganh = ctdt.Nganh.Ten,
                TenCTDT = ctdt.Ten,
                CTDT_KKT_VM = ctdt.CTDT_KKTs
                    .Select(ctdt_kkt => new CTDT_KKT_VM
                    {
                        TenKKT = ctdt_kkt.KhoiKienThuc.Ten,
                        TongSoHocPhan = ctdt_kkt.GanHocPhans.Count,
                        HocPhans = ctdt_kkt.GanHocPhans
                            .Select(ganHP => new HocPhan_VM
                            {
                                MaHocPhan = ganHP.HocPhan.MaHocPhan,
                                Ten = ganHP.HocPhan.Ten,
                                MoTa = ganHP.HocPhan.MoTa,
                                SoTinChi = ganHP.HocPhan.SoTinChi,
                                MaKhoa = ganHP.HocPhan.MaKhoa
                            })
                            .ToList()
                    })
                    .ToList()
            }))
            .FirstOrDefault();

            if (chiTietCTDT == null)
            {
                return NotFound();
            }
            return View(chiTietCTDT);
        }

        // GET: ChuongTrinhDaoTaos/Create
        public IActionResult Create()
        {
            /*ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa");
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc");
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh");*/
            return View();
        }

        // POST: ChuongTrinhDaoTaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCTDT,Ten,MaKhoa,MaKhoaHoc,MaNganh,SoNamDaoTao")] CTDT_VM ctdt_VM)
        {
            ctdt_VM.TenNganh = _context.Nganhs.FirstOrDefault(e => e.MaNganh == ctdt_VM.MaNganh)?.Ten;
            ctdt_VM.TenKhoaHoc = _context.KhoaHocs.FirstOrDefault(e => e.MaKhoaHoc == ctdt_VM.MaKhoaHoc)?.Ten;

            var ctdt = new ChuongTrinhDaoTao()
            {
                Ten = ctdt_VM.TenNganh + " - " + ctdt_VM.TenKhoaHoc,
                MaKhoa = ctdt_VM.MaKhoa,
                MaKhoaHoc = ctdt_VM.MaKhoaHoc,
                MaNganh = ctdt_VM.MaNganh,
                MaCTDT = ctdt_VM.MaNganh + " - " + ctdt_VM.MaKhoaHoc,
                SoNamDaoTao = (float)ctdt_VM.SoNamDaoTao
            };

            if (!ModelState.IsValid)
            {
                _context.Add(ctdt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", ctdt.MaKhoa);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc", ctdt.MaKhoaHoc);
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", ctdt.MaNganh);
            return View(ctdt);
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
        public async Task<IActionResult> Edit(string id, [Bind("MaCTDT,Ten,MaKhoa,MaKhoaHoc,MaNganh,SoNamDaoTao")] CTDT_VM ctdt_VM)
        {
            var ctdt = await _context.ChuongTrinhDaoTaos.FindAsync(id);

            if (id != ctdt.MaCTDT)
            {
                return NotFound();
            }

            ctdt.Ten = ctdt_VM.TenNganh + " - " + ctdt_VM.TenKhoaHoc;
            ctdt.MaKhoa = ctdt_VM.MaKhoa;
            ctdt.MaKhoaHoc = ctdt_VM.MaKhoaHoc;
            ctdt.MaNganh = ctdt_VM.MaNganh;
            ctdt.SoNamDaoTao = (float)ctdt_VM.SoNamDaoTao;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctdt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuongTrinhDaoTaoExists(ctdt.MaCTDT))
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "MaKhoa", ctdt.MaKhoa);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "MaKhoaHoc", ctdt.MaKhoaHoc);
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", ctdt.MaNganh);
            return View(ctdt);
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
        }
    }
}
