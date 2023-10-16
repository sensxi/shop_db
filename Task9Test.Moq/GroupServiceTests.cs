using Microsoft.EntityFrameworkCore;
using Moq;
using Task9.Models;
using Task9.Data;
using Task9.Services.GroupService;
using Xunit;
using Task9.Repository;
using Task9.Repository.GroupRepository;

namespace Task9Test.Moq
{
    public class GroupServiceTests
    {
        private readonly GroupService _sut;
        private readonly Mock<IGroupRepository> _groupRepoMock = new Mock<IGroupRepository>();

        public GroupServiceTests()
        {
            _sut = new GroupService(_groupRepoMock.Object);
        }
        

        [Fact]
        public async Task GetGroupByIdAsync_ShouldReturnGroup_WhenGroupExist()
        {
            // Arrange
            int groupId = 1; 
            var expectedGroup = new Group { Id = groupId, Name = "My group" }; 

            _groupRepoMock.Setup(repo => repo.GetAsync(groupId)).ReturnsAsync(expectedGroup);

            // Act
            var result = await _sut.GetAsync(groupId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(groupId, result.Id);
            Assert.Equal("My group", result.Name);
        }

        [Fact]
        public async Task GroupHasStudentsAsync_ShouldReturnTrue_WhenGroupHasStudents()
        {
            // Arrange
            int groupId = 1;

            _groupRepoMock.Setup(repo => repo.GroupHasStudentsAsync(groupId)).ReturnsAsync(true);

            // Act
            var result = await _sut.GroupHasStudentsAsync(groupId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GroupHasStudentsAsync_ShouldReturnFalse_WhenGroupHasNoStudents()
        {
            // Arrange
            int groupId = 1;

            _groupRepoMock.Setup(repo => repo.GroupHasStudentsAsync(groupId)).ReturnsAsync(false);

            // Act
            var result = await _sut.GroupHasStudentsAsync(groupId);

            // Assert
            Assert.False(result);
        }

    }


}
