using Task9.Models;

namespace Task9.Repository.CourseRepository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();

        Task<Course> GetAsync(int id);

        Task<bool> CourseHasGroupAsync(int id);

        Task<bool> AddAsync(Course course);

        Task<bool> UpdateAsync(Course course);

        Task<bool> DeleteAsync(int id);

        Task<List<Group>> GetAllAsync(int id);

        Task<bool> DubbingCheck(Course course);
    }
}
