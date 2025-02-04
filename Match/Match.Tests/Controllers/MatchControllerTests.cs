using Match.Api.Controllers.Match;
using Match.Application.Match;
using Match.Domain.Core;
using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Match.Tests.Controllers
{
    public class MatchControllerTests
    {
        private readonly Mock<IAplicMatch> _mockAplicMatch;
        private readonly Mock<IServCore<Match.Domain.Match.Match>> _mockServCore;
        private readonly MatchController _controller;

        public MatchControllerTests()
        {
            _mockAplicMatch = new Mock<IAplicMatch>();
            _mockServCore = new Mock<IServCore<Match.Domain.Match.Match>>();
            _controller = new MatchController(_mockServCore.Object, _mockAplicMatch.Object);
        }

        [Fact]
        public void CreateMatch_ShouldReturnOk_WhenMatchIsCreatedSuccessfully()
        {
            // Arrange
            var dto = new CreateMatchDTO();
            _mockAplicMatch.Setup(s => s.CreateMatch(dto)).Returns(1);

            // Act
            var result = _controller.CreateMatch(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockAplicMatch.Verify(s => s.CreateMatch(dto), Times.Once);
        }

        [Fact]
        public void CreateMatch_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var dto = new CreateMatchDTO();
            _mockAplicMatch.Setup(s => s.CreateMatch(dto)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.CreateMatch(dto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao criar Match", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void MatchDevelopersToProject_ShouldReturnOk_WhenDataIsReturned()
        {
            // Arrange
            var projectId = 1;
            var expectedData = new DadosMatchDeveloperToProjectDTO();
            _mockAplicMatch.Setup(s => s.MatchDeveloperToProject(projectId)).Returns(expectedData);

            // Act
            var result = _controller.MatchDevelopersToProject(projectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedData, okResult.Value);
        }

        [Fact]
        public void MatchDevelopersToProject_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var projectId = 1;
            _mockAplicMatch.Setup(s => s.MatchDeveloperToProject(projectId)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.MatchDevelopersToProject(projectId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao realizar o match.", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void MatchProjectToDevelopers_ShouldReturnOk_WhenDataIsReturned()
        {
            // Arrange
            var developerId = 1;
            var expectedData = new DadosMatchProjectToDeveloperDTO();
            _mockAplicMatch.Setup(s => s.MatchProjectToDeveloper(developerId)).Returns(expectedData);

            // Act
            var result = _controller.MatchProjectToDevelopers(developerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedData, okResult.Value);
        }

        [Fact]
        public void MatchProjectToDevelopers_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var developerId = 1;
            _mockAplicMatch.Setup(s => s.MatchProjectToDeveloper(developerId)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.MatchProjectToDevelopers(developerId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao realizar o match.", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void GetAll_ShouldReturnOk_WhenDataIsReturned()
        {
            // Arrange
            var matches = new List<Match.Domain.Match.Match> { new Match.Domain.Match.Match() };
            _mockServCore.Setup(s => s.GetAll()).Returns(matches);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(matches, okResult.Value);
        }

        [Fact]
        public void GetAll_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockServCore.Setup(s => s.GetAll()).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.GetAll();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao obter os dados.", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void GetById_ShouldReturnOk_WhenDataIsReturned()
        {
            // Arrange
            var match = new Match.Domain.Match.Match { Id = 1 };
            _mockServCore.Setup(s => s.GetById(1)).Returns(match);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(match, okResult.Value);
        }

        [Fact]
        public void GetById_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockServCore.Setup(s => s.GetById(1)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.GetById(1);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao obter os dados.", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void Create_ShouldReturnOk_WhenDataIsCreated()
        {
            // Arrange
            var match = new Match.Domain.Match.Match();
            _mockServCore.Setup(s => s.Add(match)).Verifiable();

            // Act
            var result = _controller.Create(match);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
            _mockServCore.Verify(s => s.Add(match), Times.Once);
        }

        [Fact]
        public void Create_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var match = new Match.Domain.Match.Match();
            _mockServCore.Setup(s => s.Add(match)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.Create(match);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao criar o item.", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void Update_ShouldReturnOk_WhenDataIsUpdated()
        {
            // Arrange
            var match = new Match.Domain.Match.Match { Id = 1 };
            _mockServCore.Setup(s => s.Update(match)).Verifiable();

            // Act
            var result = _controller.Update(1, match);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockServCore.Verify(s => s.Update(match), Times.Once);
        }

        [Fact]
        public void Update_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var match = new Match.Domain.Match.Match { Id = 1 };
            _mockServCore.Setup(s => s.Update(match)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.Update(1, match);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao atualizar o item.", ((dynamic)statusCodeResult.Value).message);
        }

        [Fact]
        public void Delete_ShouldReturnOk_WhenDataIsDeleted()
        {
            // Arrange
            _mockServCore.Setup(s => s.Delete(1)).Verifiable();

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockServCore.Verify(s => s.Delete(1), Times.Once);
        }

        [Fact]
        public void Delete_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockServCore.Setup(s => s.Delete(1)).Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.Delete(1);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro ao deletar o item.", ((dynamic)statusCodeResult.Value).message);
        }
    }
}
