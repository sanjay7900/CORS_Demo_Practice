using ImplementCors_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ImplementCors_Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly string BASE_URL = "https://localhost:7059/Student/";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            HttpResponseMessage response = client.GetAsync(BASE_URL+ "GetAllStudents").Result;
            var stringData= response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<StudentsViewModel>>(stringData);

            return View(data);
        }
        public IActionResult CORS()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Post()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Post(StudentsViewModel students)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var data = JsonConvert.SerializeObject(students);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(BASE_URL + "PostStudents", contentData).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(CORS));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();    
            }

        }
    }
}
