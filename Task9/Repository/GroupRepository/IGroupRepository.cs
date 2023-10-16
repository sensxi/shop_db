using Task9.Models;

namespace Task9.Repository.GroupRepository
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllAsync();

        Task<Group> GetAsync(int id);

        Task<List<Group>> GetAllAsync(int courseId);

        List<Course> GetCourseWithDefault();

        Task<bool> GroupHasStudentsAsync(int id);

        Task<bool> AddAsync(Group group);

        Task<bool> EditAsync(Group group);

        Task<bool> DeleteAsync(int id);

        Task<bool> DubbingCheck(Group group);
    }
}
