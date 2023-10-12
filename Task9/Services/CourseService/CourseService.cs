using Microsoft.AspNetCore.Mvc;
using Task9.Models;
using Microsoft.EntityFrameworkCore;
using Task9.Data;
using Task9.Repository.CourseRepository;

namespace Task9.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetCoursesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseByIdAsync(id);
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddCourseAsync(course);

        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            return await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            return await _courseRepository.DeleteCourseAsync(id);
        }

        public async Task<List<Group>> GetGroupsByCourseIdAsync(int courseId)
        {
            return await _courseRepository.GetGroupsByCourseIdAsync(courseId);
        }


    }
}
