using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        //public List<Group> Groups { get; set; }
    }
}
