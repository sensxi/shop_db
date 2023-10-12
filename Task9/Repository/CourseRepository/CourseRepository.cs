using Microsoft.EntityFrameworkCore;
using Task9.Data;
using Task9.Models;

namespace Task9.Repository.CourseRepository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Group>> GetGroupsByCourseIdAsync(int courseId)
        {
            return await _context.Groups.Where(g => g.CourseId == courseId).ToListAsync();
        }

    }
}
