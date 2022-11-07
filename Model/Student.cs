using System.ComponentModel.DataAnnotations;

namespace Scorpion.Template.AspNet_EfCore.Model
{
    public class Student
    {
        [Key]
        public int RecordId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
