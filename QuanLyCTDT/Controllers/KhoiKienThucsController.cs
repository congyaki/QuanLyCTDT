using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        // GET: KhoiKienThucsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoiKienThucsController/Create
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

        // GET: KhoiKienThucsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhoiKienThucsController/Edit/5
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

        // GET: KhoiKienThucsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhoiKienThucsController/Delete/5
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
