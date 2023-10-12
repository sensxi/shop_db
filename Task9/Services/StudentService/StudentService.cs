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

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task<List<Student>> GetStudentsWithGroupsAsync()
        {
            return await _studentRepository.GetStudentsWithGroupsAsync();
        }

        public async Task<List<Student>> GetStudentsByGroupIdAsync(int groupId)
        {
            return await _studentRepository.GetStudentsByGroupIdAsync(groupId);
        }

        public List<Group> GetGroupsWithDefault()
        {
            return _studentRepository.GetGroupsWithDefault();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task EditStudentAsync(Student student)
        {
            await _studentRepository.EditStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }



    }
}
