using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.EF;
using QL_CTDT.Data.Models.Entities;
using QL_CTDT.Data.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [Route("ChuongTrinhDaoTaos/Index")]
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
        [Route("ChuongTrinhDaoTaos/Details/{id}")]
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
                        MaCTDT_KKT = ctdt_kkt.MaCTDT_KKT,
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
        [HttpGet]
        [Route("ChuongTrinhDaoTaos/Create")]
        public IActionResult Create()
        {
            
            ViewBag.Nganhs = new SelectList(_context.Nganhs, "MaNganh", "Ten");
            ViewBag.KhoaHocs = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "Ten");
            ViewBag.Khoas = new SelectList(_context.Khoas, "MaKhoa", "Ten");
            ViewBag.KKTs = new SelectList(_context.KhoiKienThucs, "MaKKT", "Ten");

            return View();
        }

        // POST: ChuongTrinhDaoTaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ChuongTrinhDaoTaos/Create")]

        public async Task<IActionResult> Create(Create_CTDT_VM ctdt_VM, string[] MaKKT)
        {
            if (TryValidateModel(ctdt_VM))
            {
                var tenNganh = _context.Nganhs.FirstOrDefault(e => e.MaNganh == ctdt_VM.MaNganh)?.Ten;
                var tenKhoaHoc = _context.KhoaHocs.FirstOrDefault(e => e.MaKhoaHoc == ctdt_VM.MaKhoaHoc)?.Ten;

                var chuongTrinhDaoTao = new ChuongTrinhDaoTao()
                {
                    Ten = tenNganh + " - " + tenKhoaHoc,
                    MaKhoa = ctdt_VM.MaKhoa,
                    MaKhoaHoc = ctdt_VM.MaKhoaHoc,
                    MaNganh = ctdt_VM.MaNganh,
                    MaCTDT = ctdt_VM.MaNganh + " - " + ctdt_VM.MaKhoaHoc,
                    SoNamDaoTao = (float)ctdt_VM.SoNamDaoTao
                };
            
                    _context.ChuongTrinhDaoTaos.Add(chuongTrinhDaoTao);
                        await _context.SaveChangesAsync();
                // Xử lý các giá trị MaKKT đã chọn
                if (MaKKT != null)
                {
                    foreach (var maKKT in MaKKT)
                    {
                        var tenKKT = _context.KhoiKienThucs.FirstOrDefault(e => e.MaKKT == maKKT)?.Ten;

                        // Tạo một đối tượng KKT từ maKKT và chuongTrinhDaoTao.Id
                        CTDT_KKT ctdt_kkt = new CTDT_KKT
                        {
                            MaKKT = maKKT,
                            MaCTDT = chuongTrinhDaoTao.MaCTDT,
                            MaCTDT_KKT = chuongTrinhDaoTao.MaCTDT + " - " + maKKT,
                            TenCTDT_KKT = chuongTrinhDaoTao.Ten + " - " + tenKKT,
                        };

                        // Lưu KKT vào cơ sở dữ liệu
                        _context.CTDT_KKTs.Add(ctdt_kkt);
                        await _context.SaveChangesAsync();
                    }
                }
                // Chuyển hướng đến action thêm CTDT_KKT_VM và truyền id của CTDT
                return RedirectToAction("Details", new { id = chuongTrinhDaoTao.MaCTDT });
            }

            ViewBag.Nganhs = new SelectList(_context.Nganhs, "MaNganh", "Ten");
            ViewBag.KhoaHocs = new SelectList(_context.KhoaHocs, "MaKhoaHoc", "Ten");
            ViewBag.Khoas = new SelectList(_context.Khoas, "MaKhoa", "Ten");
            ViewBag.KKTs = new SelectList(_context.KhoiKienThucs, "MaKKT", "Ten");
            ViewBag.HocPhans = new SelectList(_context.HocPhans, "MaHocPhan", "Ten");
            return View(ctdt_VM);
        }

        // GET: ChuongTrinhDaoTaos/Edit/5
        [HttpGet]
        [Route("ChuongTrinhDaoTaos/Edit/{id}")]
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
        [Route("ChuongTrinhDaoTaos/Edit/{id}")]
        public async Task<IActionResult> Edit(string id, [Bind("MaCTDT,Ten,MaKhoa,MaKhoaHoc,MaNganh,SoNamDaoTao")] CTDT_VM ctdt_VM)
        {
            var ctdt = await _context.ChuongTrinhDaoTaos.FindAsync(id);
            var tenNganh = _context.Nganhs.FirstOrDefault(e => e.MaNganh == ctdt_VM.MaNganh)?.Ten;
            var tenKhoaHoc = _context.KhoaHocs.FirstOrDefault(e => e.MaKhoaHoc == ctdt_VM.MaKhoaHoc)?.Ten;
            if (id != ctdt.MaCTDT)
            {
                return NotFound();
            }

            ctdt.Ten = tenNganh + " - " + tenKhoaHoc;
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
        [Route("ChuongTrinhDaoTaos/Delete/{id}")]

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
        [Route("ChuongTrinhDaoTaos/Delete/{id}")]

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
