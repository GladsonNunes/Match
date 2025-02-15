using Match.Api.Controllers.Match;
using Match.Application.Match;
using Match.Domain.Developer;
using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;
using Match.Domain.Project;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Match.Tests.MatchTest
{
    public class MatchControllerTest
    {
        private readonly Mock<IAplicMatch> _mockAplicMatch;
        private readonly MatchController _controller;

        public MatchControllerTest()
        {
            _mockAplicMatch = new Mock<IAplicMatch>();
            _controller = new MatchController(null, _mockAplicMatch.Object);
        }

        [Fact]
        public void CreateMatchValidDtoReturnsOk()
        {
            // Arrange
            var dto = new CreateMatchDTO();

            // Act
            var result = _controller.CreateMatch(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockAplicMatch.Verify(x => x.CreateMatch(dto), Times.Once);
        }

        [Fact]
        public void CreateMatchThrowsExceptionReturnsInternalServerError()
        {
            // Arrange
            var dto = new CreateMatchDTO();
            _mockAplicMatch.Setup(x => x.CreateMatch(dto)).Throws(new Exception("Test exception"));

            // Act
            var result = _controller.CreateMatch(dto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            _mockAplicMatch.Verify(x => x.CreateMatch(dto), Times.Once);
        }

        [Fact]
        public void CreateMatchNullDtoReturnsBadRequest()
        {
            // Arrange
            CreateMatchDTO dto = null;

            // Act
            var result = _controller.CreateMatch(dto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result); // Verifica se o resultado é um BadRequestObjectResult
            Assert.Equal("DTO não pode ser nulo.", badRequestResult.Value); // Verifica a mensagem de erro
            _mockAplicMatch.Verify(x => x.CreateMatch(dto), Times.Never); // Garante que o método não foi chamado
        }

        [Fact]
        public void GetMatchValidIdReturnsOkWithMatch()
        {
            // Arrange
            int matchId = 1;
            var expectedMatch = new Domain.Match.Match();
            _mockAplicMatch.Setup(x => x.GetMatchById(matchId)).Returns(expectedMatch);

            // Act
            var result = _controller.GetMatch(matchId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedMatch, okResult.Value);
            _mockAplicMatch.Verify(x => x.GetMatchById(matchId), Times.Once);
        }

        [Fact]
        public void GetMatchInvalidIdReturnsBadRequest()
        {
            // Arrange
            int matchId = 0;

            // Act
            var result = _controller.GetMatch(matchId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            _mockAplicMatch.Verify(x => x.GetMatchById(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void GetMatchThrowsExceptionReturnsInternalServerError()
        {
            // Arrange
            int matchId = 1;
            _mockAplicMatch.Setup(x => x.GetMatchById(matchId)).Throws(new Exception("Test exception"));

            // Act
            var result = _controller.GetMatch(matchId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            _mockAplicMatch.Verify(x => x.GetMatchById(matchId), Times.Once);
        }

        [Fact]
        public void MatchDevelopersToProjectValidProjectIdReturnsOkWithTwoMatchedDevelopers()
        {
            // Arrange
            int projectId = 1;
            var matchedDevelopers = new DadosMatchDeveloperToProjectDTO
            {
                DevelopersAptos = new List<DadosDeveloperMatchResultDTO>
                    {
                        new DadosDeveloperMatchResultDTO { Score = 90, Developer = new Developer { Id = 1, Name = "Dev1" } },
                        new DadosDeveloperMatchResultDTO { Score = 85, Developer = new Developer { Id = 2, Name = "Dev2" } }
                    },
                DevelopersAptosSegunda = new List<DadosDeveloperMatchResultDTO>()
            };
            _mockAplicMatch.Setup(x => x.MatchDeveloperToProject(projectId)).Returns(matchedDevelopers);

            
            // Act
            var result = _controller.MatchDevelopersToProject(projectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDevelopers = Assert.IsType<DadosMatchDeveloperToProjectDTO>(okResult.Value);
            Assert.Equal(2, returnedDevelopers.DevelopersAptos.Count);
            Assert.Equal("Dev1", returnedDevelopers.DevelopersAptos[0].Developer.Name);
            Assert.Equal("Dev2", returnedDevelopers.DevelopersAptos[1].Developer.Name);
            _mockAplicMatch.Verify(x => x.MatchDeveloperToProject(projectId), Times.Once);
        }

        [Fact]
        public void MatchDevelopersToProjectNoMatchedDevelopersReturnsNoContent()
        {
            // Arrange
            int projectId = 1;
            var matchedDevelopers = new DadosMatchDeveloperToProjectDTO
            {
                DevelopersAptos = new List<DadosDeveloperMatchResultDTO>(),
                DevelopersAptosSegunda = new List<DadosDeveloperMatchResultDTO>(),
            };
            _mockAplicMatch.Setup(x => x.MatchDeveloperToProject(projectId)).Returns(matchedDevelopers);

            // Act
            var result = _controller.MatchDevelopersToProject(projectId);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockAplicMatch.Verify(x => x.MatchDeveloperToProject(projectId), Times.Once);
        }

        [Fact]
        public void MatchDevelopersToProjectThrowsExceptionReturnsInternalServerError()
        {
            // Arrange
            int projectId = 1;
            _mockAplicMatch.Setup(x => x.MatchDeveloperToProject(projectId)).Throws(new Exception("Test exception"));

            // Act
            var result = _controller.MatchDevelopersToProject(projectId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            _mockAplicMatch.Verify(x => x.MatchDeveloperToProject(projectId), Times.Once);
        }

        [Fact]
        public void MatchProjectToDevelopersValidDeveloperIdReturnsOkWithOneMatchedProject()
        {
            // Arrange
            int developerId = 1;
            var matchedProjects = new DadosMatchProjectToDeveloperDTO
            {
                ProjectsAptos = new List<DadosProjectMatchResultDTO>
                {
                    new DadosProjectMatchResultDTO { Score = 95, Project = new Project { Id = 1, Name = "Project1" } }
                }
            };

            _mockAplicMatch.Setup(x => x.MatchProjectToDeveloper(developerId)).Returns(matchedProjects);

            // Act
            var result = _controller.MatchProjectToDevelopers(developerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProjects = Assert.IsType<DadosMatchProjectToDeveloperDTO>(okResult.Value);
            Assert.Single(returnedProjects.ProjectsAptos);
            Assert.Equal("Project1", returnedProjects.ProjectsAptos[0].Project.Name);
            _mockAplicMatch.Verify(x => x.MatchProjectToDeveloper(developerId), Times.Once);
        }

        [Fact]
        public void MatchProjectToDevelopersNoMatchedProjectsReturnsNoContent()
        {
            // Arrange
            int developerId = 1;
            var matchedProjects = new DadosMatchProjectToDeveloperDTO();
            
            _mockAplicMatch.Setup(x => x.MatchProjectToDeveloper(developerId)).Returns(matchedProjects);

            // Act
            var result = _controller.MatchProjectToDevelopers(developerId);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockAplicMatch.Verify(x => x.MatchProjectToDeveloper(developerId), Times.Once);
        }

        [Fact]
        public void MatchProjectToDevelopersThrowsExceptionReturnsInternalServerError()
        {
            // Arrange
            int developerId = 1;
            _mockAplicMatch.Setup(x => x.MatchProjectToDeveloper(developerId)).Throws(new Exception("Test exception"));

            // Act
            var result = _controller.MatchProjectToDevelopers(developerId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            _mockAplicMatch.Verify(x => x.MatchProjectToDeveloper(developerId), Times.Once);
        }
    }
}
