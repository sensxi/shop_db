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

        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _groupRepository.GetGroupsAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _groupRepository.GetGroupByIdAsync(id);
        }

        public async Task<List<Group>> GetGroupsByCourseIdAsync(int courseId)
        {
            return await _groupRepository.GetGroupsByCourseIdAsync(courseId);
        }

        public List<Course> GetCourseCollectionWithDefault()
        {
            return _groupRepository.GetCourseCollectionWithDefault();
        }

        public async Task<bool> GroupHasStudentsAsync(int groupId)
        {
            return await _groupRepository.GroupHasStudentsAsync(groupId);
        }

        public async Task AddGroupAsync(Group group)
        {
            await _groupRepository.AddGroupAsync(group);
        }

        public async Task EditGroupAsync(Group group)
        {
            await _groupRepository.EditGroupAsync(group);
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            await _groupRepository.DeleteGroupAsync(groupId);
        }
    }
}
