using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class NganhsController : Controller
    {
        // GET: NganhsController
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public NganhsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<Nganh> nganhs = new List<Nganh>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Nganh/GetNganhs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                nganhs = JsonConvert.DeserializeObject<List<Nganh>>(data);
            }
            return View(nganhs);
        }

        // GET: NganhsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            Nganh nganh = new Nganh();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Nganh/GetNganh").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                nganh = JsonConvert.DeserializeObject<Nganh>(data);
            }
            return View(nganh);
        }

        // GET: NganhsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NganhsController/Create
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

        // GET: NganhsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NganhsController/Edit/5
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

        // GET: NganhsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NganhsController/Delete/5
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
