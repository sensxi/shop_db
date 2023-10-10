using Microsoft.AspNetCore.Mvc;
using Task9.Models;
using Microsoft.EntityFrameworkCore;


namespace Task9.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
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
