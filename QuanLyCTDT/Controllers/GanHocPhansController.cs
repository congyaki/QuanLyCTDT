using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class GanHocPhansController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public GanHocPhansController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<GanHocPhan> ganHocPhans = new List<GanHocPhan>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/GanHocPhan/GetGanHocPhans").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ganHocPhans = JsonConvert.DeserializeObject<List<GanHocPhan>>(data);
            }
            return View(ganHocPhans);
        }

        // GET: DanhMucCTDTsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            GanHocPhan danhMucCTDT = new GanHocPhan();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/GanHocPhan/GetGanHocPhans").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                danhMucCTDT = JsonConvert.DeserializeObject<GanHocPhan>(data);
            }
            return View(danhMucCTDT);
        }

        // GET: DanhMucCTDTsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucCTDTsController/Create
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

        // GET: DanhMucCTDTsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DanhMucCTDTsController/Edit/5
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

        // GET: DanhMucCTDTsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhMucCTDTsController/Delete/5
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
