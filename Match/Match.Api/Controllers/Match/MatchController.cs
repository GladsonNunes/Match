using Match.Api.Controllers.Core;
using Match.Application.Match;
using Match.Domain.Core;
using Match.Domain.Match;
using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;
using Match.Domain.Project;
using Microsoft.AspNetCore.Mvc;

namespace Match.Api.Controllers.Match
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IAplicMatch _aplicMatch;

        public MatchController(IServCore<Domain.Match.Match> service, IAplicMatch aplicMatch)
        {
            _aplicMatch = aplicMatch;
        }

        [HttpPost("CreateMatch")]
        public IActionResult CreateMatch(CreateMatchDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("DTO não pode ser nulo.");
            }

            try
            {
                _aplicMatch.CreateMatch(dto);
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { message = "Erro ao criar Match.", details = ex.Message });
            }
            
        }

        [HttpGet("GetMatch/{Id}")]
        public IActionResult GetMatch(int MatchId)
        {
            if (MatchId == 0)
            {
                return BadRequest("Match code cannot be 0.");
            }

            try
            {
                var match = _aplicMatch.GetMatchById(MatchId);
                return Ok(match);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao realizar o match.", details = ex.Message });
            }
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
                    return NoContent();
                }

                return Ok(new DadosMatchDeveloperToProjectDTO
                {
                    DevelopersAptos = matchedDevelopers.DevelopersAptos,
                    DevelopersAptosSegunda = matchedDevelopers.DevelopersAptosSegunda,
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
                    return NoContent();
                }

                return Ok(new DadosMatchProjectToDeveloperDTO
                {
                    ProjectsAptos = matchedProjects.ProjectsAptos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao realizar o match.", details = ex.Message });
            }
        }

    }
}
