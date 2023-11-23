using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;
using System.Net.Http;

namespace QuanLyCTDT.Controllers
{
    public class CTDT_KKTsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public CTDT_KKTsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        // GET: CTDT_KKTsController
        [HttpGet]
        public IActionResult Index()
        {
            List<CTDT_KKT> ctdt_kkts = new List<CTDT_KKT>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/CTDT_KKT/GetCTDT_KKTs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ctdt_kkts = JsonConvert.DeserializeObject<List<CTDT_KKT>>(data);
            }
            return View(ctdt_kkts);
        }

        // GET: DanhMucCTDT_KKTs/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            CTDT_KKT ctdt_kkt = new CTDT_KKT();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/CTDT_KKT/GetCTDT_KKT").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ctdt_kkt = JsonConvert.DeserializeObject<CTDT_KKT>(data);
            }
            return View(ctdt_kkt);
        }

        // GET: CTDT_KKTsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTDT_KKTsController/Create
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

        // GET: CTDT_KKTsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CTDT_KKTsController/Edit/5
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

        // GET: CTDT_KKTsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CTDT_KKTsController/Delete/5
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
