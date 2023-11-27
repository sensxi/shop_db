using Microsoft.EntityFrameworkCore;
using Task9.Models;
using Task9.Data;
namespace Task9.Services
{
    public class DataSeedService : IDataSeedService
    {
        private readonly ApplicationDbContext _context;

        public DataSeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> SeedDatabaseAsync()
        {
            if (_context.Courses.Any())
            {
                return "Database already seeded.";
            }


            List<Course> courses = new List<Course>
            {
                new Course { Name = "math", Description = "first course" },
                new Course { Name = "english", Description = "second course" },
                new Course { Name = "programming", Description = "course about programming in c#" },
                new Course { Name = "philosophy", Description = "........." },
                // Add more entities as needed
            };

            // Add the entities to the DbContext and save changes to the database
            _context.Courses.AddRange(courses);
            _context.SaveChanges();

            List<Group> groups = new List<Group>
            {
                new Group { Name = "Group A", CourseId = courses[0].Id },
                new Group { Name = "Group B", CourseId = courses[1].Id },
                new Group { Name = "Group C", CourseId = courses[2].Id },
                new Group { Name = "Group A(1)", CourseId = courses[0].Id },
                new Group { Name = "Group A(2)", CourseId = courses[0].Id },
                new Group { Name = "Group C(1)", CourseId = courses[2].Id }, 
                // Add more groups as needed
            };

            _context.Groups.AddRange(groups);
            _context.SaveChanges();

            List<Student> students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Doe", GroupId = groups[0].Id },
                new Student { FirstName = "Jane", LastName = "Smith", GroupId = groups[0].Id },
                new Student { FirstName = "Michael", LastName = "Johnson", GroupId = groups[1].Id },
                new Student { FirstName = "John", LastName = "Smith", GroupId = groups[0].Id },
                new Student { FirstName = "Jane", LastName = "Johnson", GroupId = groups[1].Id },
                new Student { FirstName = "Michael", LastName = "Shumaher", GroupId = groups[1].Id },
                new Student { FirstName = "Test", LastName = "Test", GroupId = groups[2].Id },

            };

            _context.Students.AddRange(students);
            _context.SaveChanges();
            return "Database seeded successfully.";
        }

    }
}
