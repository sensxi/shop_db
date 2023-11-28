using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public string Name { get; set; }
        
        public int Cost { get; set; }
        
        public int Amount { get; set; }
    }
}
