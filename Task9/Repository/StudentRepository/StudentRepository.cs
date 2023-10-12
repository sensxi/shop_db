using Microsoft.EntityFrameworkCore;
using Task9.Data;
using Task9.Models;

namespace Task9.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetStudentsWithGroupsAsync()
        {
            return await _context.Students.Include(s => s.Group).ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByGroupIdAsync(int groupId)
        {
            return await _context.Students.Where(g => g.GroupId == groupId).ToListAsync();
        }

        public List<Group> GetGroupsWithDefault()
        {
            var GroupCollection = _context.Groups.ToList();
            Group DefaultGroup = new Group() { GroupId = 0, Name = "Choose a Category" };
            GroupCollection.Insert(0, DefaultGroup);
            return GroupCollection;
        }

        public async Task AddStudentAsync(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task EditStudentAsync(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
