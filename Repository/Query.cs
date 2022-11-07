using Scorpion.Template.AspNet_EfCore.Model;

namespace Scorpion.Template.AspNet_EfCore.Repository
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [HotChocolate.Data.UseFiltering]
        public IQueryable<Student> GetStudents([ScopedService] ApplicationDbContext context)
        {
            return context.Students;
        }

        //public IQueryable<Student> GetStudentById([Service] ApplicationDbContext context, int studentId)
        //{
        //    return context.Students.Where(a => a.RecordId == studentId);
        //}

    }
}
