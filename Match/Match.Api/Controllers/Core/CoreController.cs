using Match.Domain.Core;
using Match.Domain.Developer;
using Microsoft.AspNetCore.Mvc;

namespace Match.Api.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController<T> : ControllerBase where T : class
    {
        private readonly IServCore<T> _service;

        public CoreController(IServCore<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var items = _service.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = _service.GetById(id);
                if (item == null)
                {
                    return NotFound(new { error = "id not found", id = id });
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<T> Create([FromBody] T item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }
                var createdItem = _service.Add(item);
                return CreatedAtAction(nameof(GetById), createdItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar o item.", details = ex.Message });
            }


        }

        [HttpPut("{id}")]
        public ActionResult<T> Update(int id, [FromBody] T item)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var itemUpdated = _service.Update(item);
                return Ok(itemUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }
    }

}
