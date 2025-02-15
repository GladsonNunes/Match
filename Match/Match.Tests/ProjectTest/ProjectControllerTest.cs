using Match.Api.Controllers.Projects;
using Match.Domain.Core;
using Match.Domain.Project;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Match.Tests.ProjectTest
{
    public class ProjectControllerTest
    {
        private readonly Mock<IServCore<Project>> _serviceMock;
        private readonly ProjectController _controller;

        public ProjectControllerTest()
        {
            _serviceMock = new Mock<IServCore<Project>>();
            _controller = new ProjectController(_serviceMock.Object);
        }

        [Fact]
        public void ShouldCreateProjectSuccessfully()
        {
            // Arrange
            var project = new Project { Id = 1, Name = "Project A" };
            _serviceMock.Setup(s => s.Add(It.IsAny<Project>())).Returns(project);

            // Act
            var result = _controller.Create(project);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Project>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Project>(createdResult.Value);
            Assert.Equal(project.Id, returnValue.Id);
        }

        [Fact]
        public void ShouldListAllProjects()
        {
            // Arrange
            var projects = new List<Project>
                        {
                            new Project { Id = 1, Name = "Project A" },
                            new Project { Id = 2, Name = "Project B" }
                        };
            _serviceMock.Setup(s => s.GetAll()).Returns(projects);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void ShouldEditProjectSuccessfully()
        {
            // Arrange
            var project = new Project { Id = 1, Name = "Project A" };
            _serviceMock.Setup(s => s.Update(It.IsAny<Project>())).Returns(project);

            // Act
            var result = _controller.Update(project.Id, project);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Project>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<Project>(okResult.Value);
            Assert.Equal(project.Id, returnValue.Id);
        }
    }
}
