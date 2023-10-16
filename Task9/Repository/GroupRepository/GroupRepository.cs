using Microsoft.EntityFrameworkCore;
using Task9.Data;
using Task9.Models;

namespace Task9.Repository.GroupRepository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(t => t.Course).ToListAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<List<Group>> GetAllAsync(int courseId)
        {
            return await _context.Groups.Where(g => g.CourseId == courseId).ToListAsync();
        }

        public List<Course> GetCourseWithDefault()
        {
            var courseCollection = _context.Courses.ToList();
            Course defaultCourse = new Course() { Id = 0, Name = "Choose a Category" };
            courseCollection.Insert(0, defaultCourse);
            return courseCollection;
        }

        public async Task<bool> GroupHasStudentsAsync(int id)
        {
            return await _context.Students.AnyAsync(s => s.GroupId == id);
        }

        public async Task<bool> AddAsync(Group group)
        {
            if (await DubbingCheck(group))
                return false;

            _context.Add(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(Group group)
        {
            if (await DubbingCheck(group))
                return false;

            _context.Update(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DubbingCheck(Group group)
        {
            return await _context.Groups.AnyAsync(c => c.Name == group.Name && c.CourseId == group.CourseId);
        }
    }
}
