using Microsoft.EntityFrameworkCore;
using Moq;
using Task9.Models;
using Task9.Data;
using Task9.Services.GroupService;
using Xunit;
using Task9.Repository;

namespace Task9Test.Moq
{
    public class GroupServiceTests
    {
        private readonly GroupService _sut;
        private readonly Mock<ApplicationDbContext> _dbContextMock = new Mock<ApplicationDbContext>();

        public GroupServiceTests()
        {
            //_sut = new GroupService();
        }
        

        [Fact]
        public async Task GetGroupByIdAsync_ShouldReturnGroup_WhenGroupExist()
        {
            //Arrange

            //Act

            //Assert
        }




    }


}
