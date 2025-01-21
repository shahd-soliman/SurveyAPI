using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.app.Contracts.Polls;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Survey.app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        //this method called primary instructor
        private readonly IPollService _pollService = pollService;

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var polls =await _pollService.GetAllAsync();
            return Ok(polls);
        }
        [HttpGet("{id}")]
        public async Task< IActionResult > GetById(int id)
        {
            var poll = await _pollService.GetByIdAsync(id);

            if (poll is null)
            {
                return NotFound();
            }

            var pollResponse = poll.Adapt<PollResponse>();

            return Ok(pollResponse);
        }
        [HttpPost("")]
        public async Task< IActionResult> Create(PollRequest newpoll , CancellationToken cancellationToken)
        {
            var poll = newpoll.Adapt<Poll>();

            await _pollService.CreateAsync(poll , cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task< IActionResult> Update(int id, PollRequest pollRequest , CancellationToken cancellationToken)
        {
            var newpoll = pollRequest.Adapt<Poll>();
            var updatedpoll = await _pollService.UpdateAsync(id, newpoll , cancellationToken);
            if (!updatedpoll)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task< IActionResult> Delete(int id , CancellationToken cancellationToken)
        {

           var deleted=await _pollService.DeleteAsync(id , cancellationToken);
            return deleted ? Ok() : NotFound();
        }
    }
}
