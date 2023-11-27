using Task9.Models;

namespace Task9.Services.GroupService
{
    public interface IGroupService
    {
        
        Task<List<Group>> GetAllAsync();

        Task<Group> GetAsync(int id);

        Task<List<Group>> GetAllAsync(int courseId);

        List<Course> GetCourseWithDefault();

        Task<bool> GroupHasStudentsAsync(int groupId);

        Task<bool> AddAsync(Group group);

        Task<bool> UpdateAsync(Group group);

        Task<bool> DeleteAsync(int groupId);
    }
}
