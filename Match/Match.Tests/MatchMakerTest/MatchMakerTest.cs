using Match.Api.Controllers.MatchMaker;
using Match.Application.MatchMaker;
using Match.Domain.Match;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Match.Tests.MatchMakerTest
{
    public class MatchMakerTest
    {
        private readonly Mock<IAplicMatchMaker> _mockAplicMatchMaker;
        private readonly MatchMakerController _controller;

        public MatchMakerTest()
        {
            _mockAplicMatchMaker = new Mock<IAplicMatchMaker>();
            _controller = new MatchMakerController(_mockAplicMatchMaker.Object);
        }

        [Fact]
        public void UpdateStatusProcessedIdIsZeroReturnsInternalServerError()
        {
            // Arrange
            int id = 0;
            var statusProcessed = EnumStatusProcessedMatchMakers.WaitingForMatch;

            // Act
            var result = _controller.UpdateStatusProcessed(id, statusProcessed) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void UpdateStatusProcessedValidIdReturnsOk()
        {
            // Arrange
            int id = 1;
            var statusProcessed = EnumStatusProcessedMatchMakers.MatchAccepted;

            // Act
            var result = _controller.UpdateStatusProcessed(id, statusProcessed) as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            _mockAplicMatchMaker.Verify(x => x.ProcessedMatchMaker(id, statusProcessed), Times.Once);
        }

        [Fact]
        public void UpdateStatusProcessed_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            int id = 1;
            var statusProcessed = EnumStatusProcessedMatchMakers.MatchRejected;
            _mockAplicMatchMaker.Setup(x => x.ProcessedMatchMaker(It.IsAny<int>(), It.IsAny<EnumStatusProcessedMatchMakers>())).Throws(new Exception("Test exception"));

            // Act
            var result = _controller.UpdateStatusProcessed(id, statusProcessed) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}
