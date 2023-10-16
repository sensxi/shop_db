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

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Group).ToListAsync();
        }

        public async Task<List<Student>> GetAllAsync(int groupId)
        {
            return await _context.Students.Where(g => g.Id == groupId).ToListAsync();
        }

        public List<Group> GetGroupsWithDefault()
        {
            var GroupCollection = _context.Groups.ToList();
            Group DefaultGroup = new Group() { Id = 0, Name = "Choose a Category" };
            GroupCollection.Insert(0, DefaultGroup);
            return GroupCollection;
        }

        public async Task<bool> AddAsync(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
