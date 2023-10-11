using Microsoft.EntityFrameworkCore;
using Moq;
using Task9.Models;
using Task9.Services.GroupService;
using Xunit;

namespace Task9Test.Moq
{
    public class GroupServiceTests
    {
        private readonly GroupService _groupService;
        private readonly Mock<ApplicationDbContext> _dbContextMock = new Mock<ApplicationDbContext>();

        public GroupServiceTests()
        {
            _groupService =  new GroupService(_dbContextMock.Object);
        }

        [Fact]
        public async Task Tes_ss()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task GetGroupByIdAsync_Should_Return_Group()
        {
            // Arrange
            int groupId = 1;
            var expectedGroup = new Group { GroupId = groupId, Name = "Test Group" };


            _dbContextMock.Setup(x => x.Groups.FindAsync(groupId))
                        .ReturnsAsync(expectedGroup);

            // Act
            var result = await _groupService.GetGroupByIdAsync(groupId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(groupId, result.GroupId);
            Assert.Equal(expectedGroup.Name, result.Name);
        }


    }


}
