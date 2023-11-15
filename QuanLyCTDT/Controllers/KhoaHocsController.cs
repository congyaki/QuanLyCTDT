﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_CTDT.Data.Models.Entities;

namespace QuanLyCTDT.Controllers
{
    public class KhoaHocsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7262/api");
        private readonly HttpClient _httpClient;

        public KhoaHocsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: KhoaHocsController
        [HttpGet]
        public IActionResult Index()
        {
            List<KhoaHoc> khoaHocs = new List<KhoaHoc>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/KhoaHoc/GetKhoaHocs").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoaHocs = JsonConvert.DeserializeObject<List<KhoaHoc>>(data);
            }
            return View(khoaHocs);
        }

        // GET: KhoaHocsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details()
        {
            KhoaHoc khoaHoc = new KhoaHoc();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/KhoaHoc/GetKhoaHoc").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                khoaHoc = JsonConvert.DeserializeObject<KhoaHoc>(data);
            }
            return View(khoaHoc);
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
