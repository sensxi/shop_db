﻿using Task9.Models;

namespace Task9.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);

        Task<List<Student>> GetStudentsWithGroupsAsync();

        Task<List<Student>> GetStudentsByGroupIdAsync(int groupId);

        List<Group> GetGroupsWithDefault();

        Task AddStudentAsync(Student student);

        Task EditStudentAsync(Student student);

        Task DeleteStudentAsync(int id);
    }
}
