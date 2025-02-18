using Match.Domain.Match;
using Match.Domain.MatchMaker;

namespace Match.Tests.MatchMakerTest
{
    public class MatchMakerConfigTest
    {
        [Fact]
        public void MatchMakerShouldHaveDefaultValues()
        {
            // Arrange
            var matchMaker = new MatchMaker();

            // Assert
            Assert.Equal(0, matchMaker.Id);
            Assert.Equal(0, matchMaker.ProjectId);
            Assert.Equal(0, matchMaker.MatchId);
            Assert.Equal(default(EnumStatusProcessedMatchMakers), matchMaker.StatusProcessedMatchMaker);
            Assert.Equal(0, matchMaker.DeveloperId);
            Assert.Null(matchMaker.Match);
        }

        [Fact]
        public void MatchMakerShouldSetAndGetProperties()
        {
            // Arrange
            var matchMaker = new MatchMaker
            {
                Id = 1,
                ProjectId = 2,
                MatchId = 3,
                StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.MatchAccepted,
                DeveloperId = 4,
                Match = new Domain.Match.Match()
            };

            // Assert
            Assert.Equal(1, matchMaker.Id);
            Assert.Equal(2, matchMaker.ProjectId);
            Assert.Equal(3, matchMaker.MatchId);
            Assert.Equal(EnumStatusProcessedMatchMakers.MatchAccepted, matchMaker.StatusProcessedMatchMaker);
            Assert.Equal(4, matchMaker.DeveloperId);
            Assert.NotNull(matchMaker.Match);
        }
    }
}
