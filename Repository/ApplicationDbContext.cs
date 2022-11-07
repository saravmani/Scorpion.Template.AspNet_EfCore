using Microsoft.EntityFrameworkCore;
using Scorpion.Template.AspNet_EfCore.Model;

namespace Scorpion.Template.AspNet_EfCore.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=ApplicaitonDb.db");
    }
}
