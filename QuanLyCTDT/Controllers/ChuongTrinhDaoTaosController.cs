using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        // GET: DanhMucCTDT_KKTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucCTDT_KKTs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMucCTDT_KKTs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DanhMucCTDT_KKTs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMucCTDT_KKTs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhMucCTDT_KKTs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
