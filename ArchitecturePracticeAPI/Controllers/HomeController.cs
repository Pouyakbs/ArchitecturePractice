﻿using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePracticeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePracticeAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:44305/api/Book";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<BookDTO>>>(res);

            return View(json);
        }
        public async Task<IActionResult> LoadData()
        {
            var url = "https://localhost:44305/api/Book";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<BookDTO>>>(res);

            return Json(json.Data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO book)
        {
            var json = JsonConvert.SerializeObject(book);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44305/api/book";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Get(int id)
        {
            var url = $"https://localhost:44305/api/book/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<BookDTO>>(res);

            return View(json);
        }
        public async Task<IActionResult> EditBook(int id)
        {
            var url = $"https://localhost:44305/api/book/Get/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<BookDTO>>(res);

            return Json(json.Data);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(BookDTO book , int id)
        {
            var json = JsonConvert.SerializeObject(book);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://localhost:44305/api/book/Edit/{book}";

            HttpClient client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return Json(result);
        }
        public async Task<IActionResult> DeleteBook(int id)
        {
            var url = $"https://localhost:44305/api/book/Delete/{id}";

            HttpClient client = new HttpClient();

            var res = await client.DeleteAsync(url);

            return RedirectToAction("index", res);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
