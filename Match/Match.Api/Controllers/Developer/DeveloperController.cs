using Match.Api.Controllers.Core;
using Match.Application.Developer;
using Match.Domain.Core;
using Match.Domain.Developer;
using Microsoft.AspNetCore.Mvc;

namespace Match.Api.Controllers.Developers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : CoreController<Developer>
    {
        public DeveloperController(IServCore<Developer> service) : base(service)
        {
        }

        //É importante ter métodos para buscar os desenvolvedores baseados em habilidades
    }
}
