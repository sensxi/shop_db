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

        public async Task<List<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            return await _courseRepository.GetAsync(id);
        }

        public async Task<bool> AddAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            return await _courseRepository.UpdateAsync(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseRepository.DeleteAsync(id);
        }

        public async Task<bool> CourseHasGroupAsync(int id)
        {
            return await _courseRepository.CourseHasGroupAsync(id);
        }
    }
}
