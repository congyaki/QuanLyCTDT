using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCTDT.Controllers
{
    public class KhoaHocsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7259/api");
        private readonly HttpClient _httpClient;

        public KhoaHocsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: KhoaHocsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhoaHocsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoaHocsController/Create
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

        // GET: KhoaHocsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhoaHocsController/Edit/5
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

        // GET: KhoaHocsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhoaHocsController/Delete/5
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
