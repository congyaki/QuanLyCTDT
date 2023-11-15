using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class HocPhansController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public HocPhansController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<HocPhan> hocPhans = new List<HocPhan>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/HocPhan/GetHocPhans").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                hocPhans = JsonConvert.DeserializeObject<List<HocPhan>>(data);
            }
            return View(hocPhans);
        }

        // GET: HocPhansController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            HocPhan hocPhan = new HocPhan();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/HocPhan/GetHocPhan").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                hocPhan = JsonConvert.DeserializeObject<HocPhan>(data);
            }
            return View(hocPhan);
        }

        // GET: HocPhansController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocPhansController/Create
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

        // GET: HocPhansController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HocPhansController/Edit/5
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

        // GET: HocPhansController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HocPhansController/Delete/5
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
