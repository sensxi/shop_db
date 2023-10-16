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

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Group>> GetAllAsync(int id)
        {
            return await _context.Groups.Where(g => g.Id == id).ToListAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<bool> AddAsync(Course course)
        {
            _context.Add(course);

            if (await DubbingCheck(course))
                return false;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateAsync(Course course)
        {
            _context.Update(course);

            if (await DubbingCheck(course))
                return false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
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

        public async Task<bool> DubbingCheck(Course course)
        {
            return await _context.Courses.AnyAsync(c => c.Name == course.Name && c.Description == course.Description);
        }


    }
}
