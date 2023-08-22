using System.ComponentModel.DataAnnotations;

namespace Task9.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        //public List<Group> Groups { get; set; }
    }
}
