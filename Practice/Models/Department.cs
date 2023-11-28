using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public int ShopId { get; set; }
        public Shop? Shop { get; set; }

        public string Name { get; set; }

        //public List<Student> Students { get; set; }
    }
}
