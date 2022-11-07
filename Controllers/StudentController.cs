using Microsoft.AspNetCore.Mvc;
using Scorpion.Template.AspNet_EfCore.Model;
using Scorpion.Template.AspNet_EfCore.Repository;

namespace Scorpion.Template.AspNet_EfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;
        private readonly ApplicationDbContext dbContext;

        //public StudentController(ILogger<StudentController> logger, ApplicationDbContext dbContext)
        //{
        //    _logger = logger;
        //    this.dbContext = dbContext;
        //}

        //[HttpGet(Name = "GetStudentList")]
        //public IEnumerable<Student> GetStudentList()
        //{
        //    return dbContext.Students.ToList();
            
        //}

        //[HttpPost(Name = "AddStudents")]
        //public IActionResult AddStudents([FromBody] List<Student> studentsList)
        //{
        //    dbContext.AddRange(studentsList);
        //    dbContext.SaveChanges();
        //    return Ok();
        //}
    }
}