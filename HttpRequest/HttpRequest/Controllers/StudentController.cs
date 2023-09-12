using HttpRequest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HttpRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly List<Student> students = new List<Student>
        {
            new Student { Name = "Walter", Class = "7A", Address = "Address 1", Email = "walter@email.com" },
            new Student { Name = "Matthew", Class = "7A", Address = "Address 2", Email = "matthew@email.com" },
            new Student { Name = "Anne", Class = "7A", Address = "Address 3", Email = "anne@email.com" }
        };

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        [HttpGet("{name}")]
        public ActionResult<Student> GetStudent(string name)
        {
            var student = students.FirstOrDefault(p => p.Name == name);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}