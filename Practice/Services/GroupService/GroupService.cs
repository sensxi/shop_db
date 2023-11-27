using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;
using Task9.Data;
using Task9.Repository.GroupRepository;

namespace Task9.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _groupRepository.GetAsync(id);
        }

        public async Task<List<Group>> GetAllAsync(int courseId)
        {
            return await _groupRepository.GetAllAsync(courseId);
        }

        public List<Course> GetCourseWithDefault()
        {
            return _groupRepository.GetCourseWithDefault();
        }

        public async Task<bool> GroupHasStudentsAsync(int id)
        {
            return await _groupRepository.GroupHasStudentsAsync(id);
        }

        public async Task<bool> AddAsync(Group group)
        {
            return await _groupRepository.AddAsync(group);
        }

        public async Task<bool> UpdateAsync(Group group)
        {
            return await _groupRepository.EditAsync(group);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasStudent = await _groupRepository.GroupHasStudentsAsync(id);
            if (hasStudent)
            {
                return false;
            }
            return await _groupRepository.DeleteAsync(id);
        }
    }
}
