namespace Match.Domain.Project
{
    public interface IServProject
    {
        Project GetProjectById(int id);
        List<Project> GetProjectAptosBySkill(List<int> dto);
    }
}
