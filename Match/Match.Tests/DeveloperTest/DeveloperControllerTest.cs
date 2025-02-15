using Match.Api.Controllers.Developers;
using Match.Domain.Core;
using Match.Domain.Developer;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Match.Tests.DeveloperTest
{
    public class DeveloperControllerTest
    {
        private readonly Mock<IServCore<Developer>> _serviceMock;
        private readonly DeveloperController _controller;

        public DeveloperControllerTest()
        {
            _serviceMock = new Mock<IServCore<Developer>>();
            _controller = new DeveloperController(_serviceMock.Object);
        }

        [Fact]
        public void ShouldCreateDeveloperSuccessfully()
        {
            // Arrange
            var developer = new Developer { Id = 1, Name = "John Doe" };
            _serviceMock.Setup(s => s.Add(It.IsAny<Developer>())).Returns(developer);

            // Act
            var result = _controller.Create(developer);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Developer>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Developer>(createdResult.Value);
            Assert.Equal(developer.Id, returnValue.Id);
        }

        [Fact]
        public void ShouldListAllDevelopers()
        {
            // Arrange
            var developers = new List<Developer>
                    {
                        new Developer { Id = 1, Name = "John Doe" },
                        new Developer { Id = 2, Name = "Jane Doe" }
                    };
            _serviceMock.Setup(s => s.GetAll()).Returns(developers);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Developer>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void ShouldEditDeveloperSuccessfully()
        {
            // Arrange
            var developer = new Developer { Id = 1, Name = "John Doe" };
            _serviceMock.Setup(s => s.Update(It.IsAny<Developer>())).Returns(developer);

            // Act
            var result = _controller.Update(developer.Id, developer);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Developer>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<Developer>(okResult.Value);
            Assert.Equal(developer.Id, returnValue.Id);
        }
    }
}
