using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Task9.Controllers;
using Task9.Data;
using Task9.Models;
using Xunit;


namespace MoqTest
{
    public class YourControllerTests
    {
        private readonly GroupController _controller;
        private readonly ApplicationDbContext _context;
        private readonly Mock<ApplicationDbContext> _contextMock = new Mock<ApplicationDbContext>();

        public YourControllerTests(ApplicationDbContext context)
        {
            _context = context;
            _controller = new GroupController(_context);
        }
        /*
        [Fact]
        public void GroupHasStudents_ReturnsTrue_WhenStudentsExist()
        {
            // Arrange

            var groupId = 1;
            var students = new List<Student>
        {
            new Student { GroupId = groupId },
        }.AsQueryable();

            _contextMock.Setup(c => c.Students).Returns(students);
            var controller = new GroupController(_contextMock.Object);

            // Act
            var result = controller.GroupHasStudents(groupId);

            // Assert
            Assert.True(result);
        }
        */
    }

}