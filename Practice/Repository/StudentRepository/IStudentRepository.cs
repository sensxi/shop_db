using Task9.Models;

namespace Task9.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> GetAsync(int id);

        Task<List<Student>> GetAllAsync();

        Task<List<Student>> GetAllAsync(int groupId);

        List<Group> GetGroupsWithDefault();

        Task<bool> AddAsync(Student student);

        Task<bool> UpdateAsync(Student student);

        Task<bool> DeleteAsync(int id);
    }
}
