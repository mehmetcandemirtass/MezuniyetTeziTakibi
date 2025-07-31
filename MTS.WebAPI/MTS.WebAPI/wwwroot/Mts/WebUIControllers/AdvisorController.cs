using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using MTS.Application.DTOs.Students;

namespace MTS.WebUI.Controllers
{
    public class AdvisorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdvisorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MyStudents()
        {
            int advisorId = 3; // Örnek: login sonrası alınan danışman ID
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"https://localhost:7251/api/advisors/{advisorId}/students");

            if (!response.IsSuccessStatusCode)
                return View(new List<StudentDto>()); // hata durumu

            var json = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<List<StudentDto>>(json);

            return View(students);
        }
    }
}
