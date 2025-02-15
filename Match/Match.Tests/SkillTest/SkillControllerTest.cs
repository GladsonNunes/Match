using Match.Api.Controllers.Skill;
using Match.Domain.Core;
using Match.Domain.Developer;
using Match.Domain.Skill;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Match.Tests.SkillTest
{
    public class SkillControllerTest
    {
        private readonly Mock<IServCore<Skill>> _serviceMock;
        private readonly SkillController _controller;

        public SkillControllerTest()
        {
            _serviceMock = new Mock<IServCore<Skill>>();
            _controller = new SkillController(_serviceMock.Object);
        }

        [Fact]
        public void ShouldCreateSkillSuccessfully()
        {
            // Arrange
            var skill = new Skill { Id = 1, Name = "Oracle" };
            _serviceMock.Setup(s => s.Add(It.IsAny<Skill>())).Returns(skill);

            // Act
            var result = _controller.Create(skill);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Skill>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Skill>(createdResult.Value);
            Assert.Equal(skill.Id, returnValue.Id);
        }

        [Fact]
        public void ShouldListAllDevelopers()
        {
            // Arrange
            var skill = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Oracle" },
                        new Skill { Id = 2, Name = "C#" }
                    };
            _serviceMock.Setup(s => s.GetAll()).Returns(skill);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Skill>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void ShouldEditDeveloperSuccessfully()
        {
            // Arrange
            var skill = new Skill { Id = 1, Name = "Oracle" };
            _serviceMock.Setup(s => s.Update(It.IsAny<Skill>())).Returns(skill);

            // Act
            var result = _controller.Update(skill.Id, skill);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Skill>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<Skill>(okResult.Value);
            Assert.Equal(skill.Id, returnValue.Id);
        }
    }
}
