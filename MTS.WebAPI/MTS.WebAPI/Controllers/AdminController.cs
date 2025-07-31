using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        public IActionResult admindashboard()
        {
            return View();
        }

        [HttpGet("/api/students")]
        public IActionResult GetStudents()
        {
            // Örnek veriler (gerçek veritabanı çekimiyle değiştirilebilir)
            var students = new List<object>
        {
            new { name = "Ali Yılmaz", projectTitle = "Yapay Zeka ile Görüntü İşleme" },
            new { name = "Ayşe Demir", projectTitle = "Mobil Uygulama ile Takip Sistemi" }
        };
            return Json(students);
        }

        [HttpGet("/api/advisors")]
        public IActionResult GetAdvisors()
        {
            var advisors = new List<object>
        {
            new { name = "Dr. Ahmet Koç", department = "Bilgisayar Mühendisliği" },
            new { name = "Dr. Zeynep Kara", department = "Yazılım Mühendisliği" }
        };
            return Json(advisors);
        }
    }

}
