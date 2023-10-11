using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _context.Groups.Include(t => t.Course).ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<List<Group>> GetGroupsByCourseIdAsync(int courseId)
        {
            return await _context.Groups.Where(g => g.CourseId == courseId).ToListAsync();
        }

        public List<Course> GetCourseCollectionWithDefault()
        {
            var courseCollection = _context.Courses.ToList();
            Course defaultCourse = new Course() { CourseId = 0, Name = "Choose a Category" };
            courseCollection.Insert(0, defaultCourse);
            return courseCollection;
        }

        public async Task<bool> GroupHasStudentsAsync(int groupId)
        {
            return await _context.Students.AnyAsync(s => s.GroupId == groupId);
        }

        public async Task AddGroupAsync(Group group)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task EditGroupAsync(Group group)
        {
            _context.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
