using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Data.Models.Request;
using TodoList.Domain.Data.Repositories.Interfaces;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskRepository repository) : ControllerBase
    {
        private readonly ITaskRepository _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAll();
            if (data.Count == 0)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _repository.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskModelRequest request)
        {
            var taskId = await _repository.Add(request);
            return CreatedAtAction(nameof(GetAll), new {Id  = taskId}, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TaskModelRequest request)
        {
            var updated = await _repository.Update(id, request);

            if (updated == null)
            {
                return NotFound();
            }

            if (!updated.Value)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Desactive(Guid id, TaskModelRequest request)
        {
            var desactived = await _repository.Desactive(id, request);
            if (desactived == null)
            {
                return NotFound();
            }
            if (!desactived.Value)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repository.Delete(id);
            if (deleted == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }

}
