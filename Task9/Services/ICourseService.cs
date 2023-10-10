using Task9.Models;

namespace Task9.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync();

        Task<Course> GetCourseByIdAsync(int id);

        Task<bool> AddCourseAsync(Course course);

        Task<bool> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);

        Task<List<Group>> GetGroupsByCourseIdAsync(int courseId);

    }
}
