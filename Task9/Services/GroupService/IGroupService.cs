using Task9.Models;

namespace Task9.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroupsAsync();

        Task<Group> GetGroupByIdAsync(int id);

        Task<List<Group>> GetGroupsByCourseIdAsync(int courseId);

        List<Course> GetCourseCollectionWithDefault();

        Task<bool> GroupHasStudentsAsync(int groupId);

        Task AddGroupAsync(Group group);

        Task EditGroupAsync(Group group);

        Task DeleteGroupAsync(int groupId);
    }
}
