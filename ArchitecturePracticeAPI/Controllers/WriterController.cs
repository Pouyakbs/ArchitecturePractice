using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePracticeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePracticeAPI.Controllers
{
    public class WriterController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:44305/api/Writer";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<WriterDTO>>>(res);

            return View(json);
        }
        public async Task<IActionResult> LoadData()
        {
            var url = "https://localhost:44305/api/Writer";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<WriterDTO>>>(res);

            return Json(json.Data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WriterDTO writer)
        {
            var json = JsonConvert.SerializeObject(writer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44305/api/Writer";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Get(int id)
        {
            var url = $"https://localhost:44305/api/Writer/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<WriterDTO>>(res);

            return Json(json);
        }
        public async Task<IActionResult> EditWriter(int id)
        {
            var url = $"https://localhost:44305/api/Writer/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<WriterDTO>>(res);

            return Json(json);
        }
        [HttpPost]
        public async Task<IActionResult> EditWriter(WriterDTO writer)
        {
            var json = JsonConvert.SerializeObject(writer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://localhost:44305/api/Writer/Edit/{writer}";

            HttpClient client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> DeleteWriter(int id)
        {

            var url = $"https://localhost:44305/api/Writer/Delete/{id}";

            HttpClient client = new HttpClient();

            var res = await client.DeleteAsync(url);

            return RedirectToAction("index", res);
        }
    }
}
