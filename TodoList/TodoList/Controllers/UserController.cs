using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Models.Requests;
using TodoList.Domain.Repositories.Interfaces;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _repository = userRepository;

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

        public async Task<IActionResult> Add([FromBody] UserModelRequest request)
        {
            var contactId = await _repository.AddAsync(request);

            return CreatedAtAction(nameof(GetAll), new { Id = contactId }, request);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] UserModelRequest request)
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

        [HttpDelete("{id}")]

        public async Task<IActionResult> Desactive(Guid id)
        {
            var desactived = await _repository.Desactive(id);
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
            var deleted = await _repository.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
