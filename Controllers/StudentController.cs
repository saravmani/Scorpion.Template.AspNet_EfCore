using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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

        public StudentController(ILogger<StudentController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetStudentList")]
        [EnableQuery]
        public IQueryable<Student> GetStudentList()
        {
            return dbContext.Students.AsQueryable();

        }

        //[HttpPost(Name = "AddStudents")]
        //public IActionResult AddStudents([FromBody] List<Student> studentsList)
        //{
        //    dbContext.AddRange(studentsList);
        //    dbContext.SaveChanges();
        //    return Ok();
        //}
    }
}