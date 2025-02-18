using Match.Application;
using Match.Domain.Match;
using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;
using Moq;

namespace Match.Tests.MatchTest
{
    public class AplicMatchTest
    {
        private readonly Mock<IServMatch> _servMatchMock;
        private readonly AplicMatch _aplicMatch;

        public AplicMatchTest()
        {
            _servMatchMock = new Mock<IServMatch>();
            _aplicMatch = new AplicMatch(_servMatchMock.Object);
        }

        [Fact]
        public void MatchDeveloperToProjectShouldReturnDadosMatchDeveloperToProjectDTO()
        {
            // Arrange
            int projectId = 1;
            var expectedDto = new DadosMatchDeveloperToProjectDTO();
            _servMatchMock.Setup(s => s.MatchDeveloperToProject(projectId)).Returns(expectedDto);

            // Act
            var result = _aplicMatch.MatchDeveloperToProject(projectId);

            // Assert
            Assert.Equal(expectedDto, result);
        }

        [Fact]
        public void MatchProjectToDeveloperShouldReturnDadosMatchProjectToDeveloperDTO()
        {
            // Arrange
            int developerId = 1;
            var expectedDto = new DadosMatchProjectToDeveloperDTO();
            _servMatchMock.Setup(s => s.MatchProjectToDeveloper(developerId)).Returns(expectedDto);

            // Act
            var result = _aplicMatch.MatchProjectToDeveloper(developerId);

            // Assert
            Assert.Equal(expectedDto, result);
        }

        [Fact]
        public void CreateMatchShouldCallCreateMatchOnServMatch()
        {
            // Arrange
            var dto = new CreateMatchDTO();

            // Act
            _aplicMatch.CreateMatch(dto);

            // Assert
            _servMatchMock.Verify(s => s.CreateMatch(dto), Times.Once);
        }

        [Fact]
        public void GetMatchByIdShouldReturnMatch()
        {
            // Arrange
            int matchId = 1;
            var expectedMatch = new Domain.Match.Match();
            _servMatchMock.Setup(s => s.GetMatchById(matchId)).Returns(expectedMatch);

            // Act
            var result = _aplicMatch.GetMatchById(matchId);

            // Assert
            Assert.Equal(expectedMatch, result);
        }
    }
}
