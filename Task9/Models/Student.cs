using System.ComponentModel.DataAnnotations;

namespace Task9.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group? Group { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
