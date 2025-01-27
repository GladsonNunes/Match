
namespace Match.Domain.Project
{
    
    public class ServProject : IServProject
    {
        private readonly IRepProject _repProject;

        public ServProject(IRepProject repProject)
        {
            _repProject = repProject;
        }


        public Project GetProjectById(int id)
        {
            return _repProject.GetById(id);
        }
    }

    
}
