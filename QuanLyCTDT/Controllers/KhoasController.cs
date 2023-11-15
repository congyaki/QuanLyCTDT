using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class KhoasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public KhoasController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<Khoa> khoas = new List<Khoa>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Khoa/GetKhoas").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoas = JsonConvert.DeserializeObject<List<Khoa>>(data);
            }
            return View(khoas);
        }

        // GET: KhoasController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            Khoa khoa = new Khoa();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Khoa/GetKhoa").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoa = JsonConvert.DeserializeObject<Khoa>(data);
            }
            return View(khoa);
        }

        // GET: KhoasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoasController/Create
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

        // GET: KhoasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhoasController/Edit/5
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

        // GET: KhoasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhoasController/Delete/5
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
