using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCTDT.Controllers
{
    public class KhoaController : Controller
    {
        // GET: KhoaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: KhoaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoaController/Create
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

        // GET: KhoaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhoaController/Edit/5
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

        // GET: KhoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhoaController/Delete/5
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
