using Match.Application.MatchMaker;
using Match.Domain.Match;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Match.Api.Controllers.MatchMaker
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchMakerController : ControllerBase
    {
        private readonly IAplicMatchMaker _aplicMatchMaker;
        public MatchMakerController(IAplicMatchMaker aplicMatchMaker)
        {
            _aplicMatchMaker = aplicMatchMaker;
        }

        [HttpPut("UpdateStatusProcessed/{id}")]
        public IActionResult UpdateStatusProcessed(int id, EnumStatusProcessedMatchMakers statusProcessed)
        {
            try
            {
                if (id == 0)
                {
                    return StatusCode(500, new { message = "Ocorreu um erro inesperado. Código do MatchMaker não pode ser 0" }); ;
                }
                _aplicMatchMaker.ProcessedMatchMaker(id, statusProcessed);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }
    }
}
