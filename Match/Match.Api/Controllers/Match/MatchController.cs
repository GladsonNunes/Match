using Match.Application.Match;
using Match.Domain.Project;
using Microsoft.AspNetCore.Mvc;

namespace Match.Api.Controllers.Match
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IAplicMatch _aplicMatch;
        public MatchController(IAplicMatch aplicMatch)
        {
            _aplicMatch = aplicMatch;
        }

        [HttpGet("MatchDevelopersToProject/{id}")]
        public IActionResult MatchDevelopersToProject(int Projectid)
        {
            if (Projectid == null)
            {
                return BadRequest("Codigo do Projeto não pode ser nulo.");
            }

            try
            {
                var matchedDevelopers = _aplicMatch.MatchDeveloperToProject(Projectid);
                
                if (matchedDevelopers == null || !matchedDevelopers.DevelopersAptos.Any())
                {
                    return NotFound("Nenhum desenvolvedor corresponde aos requisitos do projeto.");
                }

                return Ok(new
                {
                    MatchedDevelopersAptos = matchedDevelopers.DevelopersAptos,
                    MatchedDevelopersAptosSecond = matchedDevelopers.DevelopersAptosSegunda,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao realizar o match.", details = ex.Message });
            }
        }

        [HttpGet("MatchProjectToDevelopers/{id}")]
        public IActionResult MatchProjectToDevelopers(int Developerid)
        {
            if (Developerid == null)
            {
                return BadRequest("Codigo do Developer não pode ser nulo.");
            }

            try
            {
                var matchedProjects = _aplicMatch.MatchProjectToDeveloper(Developerid);

                if (matchedProjects == null || !matchedProjects.ProjectsAptos.Any())
                {
                    return NotFound("Nenhum desenvolvedor corresponde aos requisitos do projeto.");
                }

                return Ok(new
                {
                    MatchedProjectAptos = matchedProjects.ProjectsAptos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao realizar o match.", details = ex.Message });
            }
        }


    }
}
