using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Models.Requests;
using TodoList.Domain.Repositories.Interfaces;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskRepository taskRepository) : ControllerBase
    {
        private readonly ITaskRepository _repository = taskRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAllAsync();

            if (data.Count == 0)
            {
                return NoContent();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);

        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] TaskModelRequest request)
        {
            var contactId = await _repository.AddAsync(request);

            return CreatedAtAction(nameof(GetAll), new { Id = contactId }, request);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] TaskModelRequest request)
        {
            var updated = await _repository.UpdateAsync(id, request);

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

        public async Task<IActionResult> Completed(Guid id)
        {
            var desactived = await _repository.CompletedAsync(id);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
