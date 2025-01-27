
using Match.Domain.Developer;
using Match.Domain.DeveloperSkill;
using Match.Domain.ProjectSkill;

namespace Match.Domain.Project
{
    
    public class ServProject : IServProject
    {
        private readonly IRepProject _repProject;
        private readonly IRepProjectSkill _repProjectSkill;

        public ServProject(IRepProject repProject,IRepProjectSkill repProjectSkill)
        {
            _repProject = repProject;
            _repProjectSkill = repProjectSkill;
        }


        public Project GetProjectById(int id)
        {
            return _repProject.GetById(id);
        }

        public List<Project> GetProjectAptosBySkill(List<int> dto)
        {
            var listIdsProjects = _repProjectSkill.GetProjectAptosBySkill(dto);
            return _repProject.GetByIds(listIdsProjects).ToList();
        }
    }

    
}
