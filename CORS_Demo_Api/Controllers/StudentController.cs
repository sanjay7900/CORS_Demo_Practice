using CORS_Demo_Api.Model;
using CORS_Demo_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CORS_Demo_Api.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        private Students _students;

        public StudentController(Students students)
        {
            _students = students;

        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var studentsList = JsonConvert.SerializeObject(_students.GetStudents());
            return Ok(studentsList);
        }
        [HttpPost]
        public async Task<IActionResult> PostStudents(StudentsViewModel students)
        {
            try
            {
                _students.PostStudents(students);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }  

    }
}
