using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class DanhMucCTDT_KKTsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public DanhMucCTDT_KKTsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<GanHocPhan> danhMucCTDT_KKT = new List<GanHocPhan>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/DanhMucCTDT_KKT/GetDanhMucCTDT_KKT").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                danhMucCTDT_KKT = JsonConvert.DeserializeObject<List<GanHocPhan>>(data);
            }
            return View(danhMucCTDT_KKT);
        }

        // GET: DanhMucCTDT_KKTs/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            GanHocPhan danhMucCTDT_KKTs = new GanHocPhan();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/DanhMucCTDT_KKT/GetDanhMucCTDT_KKTs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                danhMucCTDT_KKTs = JsonConvert.DeserializeObject<GanHocPhan>(data);
            }
            return View(danhMucCTDT_KKTs);
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
