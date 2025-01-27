using Match.Domain.Project;
using Match.Infrastructure.Core;
namespace Match.Infrastructure.Project
{
    public class RepProject : RepCore<Domain.Project.Project>, IRepProject
    {
        public RepProject(AppDbContext context) : base(context)
        {
        }
    }
}
