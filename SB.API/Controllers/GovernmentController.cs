using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SB.Application.Interfaces;
using SB.Domain.Entities;

namespace SB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GovernmentController : ControllerBase
    {
        private readonly IGovernmentRepository _repository;

        public GovernmentController(IGovernmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _repository.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(GovernmentEntity entity)
        {
            await _repository.AddAsync(entity);
            return Ok(new { Message = "Entity added successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(GovernmentEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return Ok(new { Message = "Entity updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(new { Message = "Entity deleted successfully" });
        }
    }
}
