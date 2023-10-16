using System.ComponentModel.DataAnnotations;

namespace Task9.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public string Name { get; set; }

        //public List<Student> Students { get; set; }
    }
}
