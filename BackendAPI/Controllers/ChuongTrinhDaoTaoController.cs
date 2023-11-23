using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_CTDT.Data.Models.EF;
using QL_CTDT.Data.Models.Entities;
using QL_CTDT.Data.Models.ViewModels;

namespace QL_CTDT.BackendAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly TrainingProgramDbContext _context;

        public ChuongTrinhDaoTaoController(TrainingProgramDbContext context)
        {
            _context = context;
        }

        // GET: api/ChuongTrinhDaoTaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuongTrinhDaoTao>>> GetChuongTrinhDaoTaos()
        {
          if (_context.ChuongTrinhDaoTaos == null)
          {
              return NotFound();
          }
            var model = await(from ctdt in _context.ChuongTrinhDaoTaos
                        join k in _context.Khoas on ctdt.MaKhoa equals k.MaKhoa
                        join kh in _context.KhoaHocs on ctdt.MaKhoaHoc equals kh.MaKhoaHoc
                        join n in _context.Nganhs on ctdt.MaNganh equals n.MaNganh
                        select new DanhMucCTDT_VM()
                        {
                            TenCTDT = ctdt.Ten,
                            TenKhoa = k.Ten,
                            TenKhoaHoc = kh.Ten,
                            TenNganh = n.Ten,
                        }).ToListAsync();
            return Ok(model);
        }

        // GET: api/ChuongTrinhDaoTaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuongTrinhDaoTao>> GetChuongTrinhDaoTao(string id)
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

            return Ok(chiTietCTDT);
        }

        // PUT: api/ChuongTrinhDaoTaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuongTrinhDaoTao(string id, ChuongTrinhDaoTao chuongTrinhDaoTao)
        {
            if (id != chuongTrinhDaoTao.MaCTDT)
            {
                return BadRequest();
            }

            _context.Entry(chuongTrinhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuongTrinhDaoTaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ChuongTrinhDaoTaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChuongTrinhDaoTao>> PostChuongTrinhDaoTao(ChuongTrinhDaoTao chuongTrinhDaoTao)
        {
          if (_context.ChuongTrinhDaoTaos == null)
          {
              return Problem("Entity set 'TrainingProgramDbContext.ChuongTrinhDaoTaos'  is null.");
          }
            _context.ChuongTrinhDaoTaos.Add(chuongTrinhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChuongTrinhDaoTaoExists(chuongTrinhDaoTao.MaCTDT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChuongTrinhDaoTao", new { id = chuongTrinhDaoTao.MaCTDT }, chuongTrinhDaoTao);
        }

        // DELETE: api/ChuongTrinhDaoTaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuongTrinhDaoTao(string id)
        {
            if (_context.ChuongTrinhDaoTaos == null)
            {
                return NotFound();
            }
            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos.FindAsync(id);
            if (chuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            _context.ChuongTrinhDaoTaos.Remove(chuongTrinhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChuongTrinhDaoTaoExists(string id)
        {
            return (_context.ChuongTrinhDaoTaos?.Any(e => e.MaCTDT == id)).GetValueOrDefault();
        }
    }
}
