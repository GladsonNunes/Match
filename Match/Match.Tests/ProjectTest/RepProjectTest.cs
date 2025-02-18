using Match.Infrastructure;
using Match.Infrastructure.Project;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.ProjectTest
{
    public class RepProjectTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetAllShouldReturnAllProjects()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProject(context);

            context.Set<Domain.Project.Project>().AddRange(
                new Domain.Project.Project { Id = 1, Name = "Project 1", Description = "Description 1" },
                new Domain.Project.Project { Id = 2, Name = "Project 2", Description = "Description 2" }
            );
            context.SaveChanges();

            // Act
            var projects = repository.GetAll().ToList();

            // Assert
            Assert.Equal(2, projects.Count);
            Assert.Contains(projects, p => p.Id == 1);
            Assert.Contains(projects, p => p.Id == 2);
        }

        [Fact]
        public void GetByIdShouldReturnProjectWhenProjectExists()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProject(context);

            var project = new Domain.Project.Project { Id = 1, Name = "Project 1", Description = "Description 1" };
            context.Set<Domain.Project.Project>().Add(project);
            context.SaveChanges();

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenProjectDoesNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProject(context);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddShouldAddProjectToDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProject(context);
            var project = new Domain.Project.Project { Id = 1, Name = "Project 1", Description = "Description 1" };

            // Act
            repository.Add(project);
            var savedProject = context.Set<Domain.Project.Project>().Find(1);

            // Assert
            Assert.NotNull(savedProject);
            Assert.Equal(1, savedProject.Id);
        }

        [Fact]
        public void Update_ShouldModifyProject()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProject(context);
            var project = new Domain.Project.Project { Id = 1, Name = "Project 1", Description = "Description 1" };
            context.Set<Domain.Project.Project>().Add(project);
            context.SaveChanges();

            // Act
            project.Name = "Updated Project 1";
            repository.Update(project);
            var updatedProject = context.Set<Domain.Project.Project>().Find(1);

            // Assert
            Assert.NotNull(updatedProject);
            Assert.Equal("Updated Project 1", updatedProject.Name);
        }

        [Fact]
        public void Delete_ShouldRemoveProjectFromDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProject(context);
            var project = new Domain.Project.Project { Id = 1, Name = "Project 1", Description = "Description 1" };
            context.Set<Domain.Project.Project>().Add(project);
            context.SaveChanges();

            // Act
            repository.Delete(1);
            var deletedProject = context.Set<Domain.Project.Project>().Find(1);

            // Assert
            Assert.Null(deletedProject);
        }
    }
}
