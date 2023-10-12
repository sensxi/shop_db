using Task9.Models;

namespace Task9.Repository.CourseRepository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesAsync();

        Task<Course> GetCourseByIdAsync(int id);

        Task<bool> AddCourseAsync(Course course);

        Task<bool> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);

        Task<List<Group>> GetGroupsByCourseIdAsync(int courseId);
    }
}
