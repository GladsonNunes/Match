using Match.Api.Controllers.Core;
using Match.Application.Project;
using Match.Domain.Core;
using Match.Domain.Project;
using Microsoft.AspNetCore.Mvc;

namespace Match.Api.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : CoreController<Project>
    {
        public ProjectController(IServCore<Project> service) : base(service)
        {
        }

        ////É importante ter métodos para buscar os projetos baseados em habilidades
    }
}
