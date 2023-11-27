using Microsoft.EntityFrameworkCore;
using Task9.Models;
using Task9.Data;
using Task9.Repository.StudentRepository;

namespace Task9.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _studentRepository.GetAsync(id);
        }

        public async Task<List<Student>> GetAllAsync(int groupId)
        {
            return await _studentRepository.GetAllAsync(groupId);
        }

        public List<Group> GetGroupsWithDefault()
        {
            return _studentRepository.GetGroupsWithDefault();
        }

        public async Task<bool> AddAsync(Student student)
        {
           return await _studentRepository.AddAsync(student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }



    }
}
