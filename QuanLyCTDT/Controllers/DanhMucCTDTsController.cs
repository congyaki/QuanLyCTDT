using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class DanhMucCTDTsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public DanhMucCTDTsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<DanhMucCTDT> danhMucCTDTs = new List<DanhMucCTDT>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/DanhMucCTDT/GetDanhMucCTDTs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                danhMucCTDTs = JsonConvert.DeserializeObject<List<DanhMucCTDT>>(data);
            }
            return View(danhMucCTDTs);
        }

        // GET: DanhMucCTDTsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            DanhMucCTDT danhMucCTDT = new DanhMucCTDT();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/DanhMucCTDT/GetDanhMucCTDT").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                danhMucCTDT = JsonConvert.DeserializeObject<DanhMucCTDT>(data);
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
