using Task9.Models;

namespace Task9.Services.CourseService
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();

        Task<Course> GetAsync(int id);

        Task<bool> AddAsync(Course course);

        Task<bool> UpdateAsync(Course course);

        Task<bool> DeleteAsync(int id);

        Task<bool> CourseHasGroupAsync(int id);
    }
}
