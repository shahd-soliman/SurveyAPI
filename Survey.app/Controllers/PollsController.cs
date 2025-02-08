using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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
            var polls = await _pollService.GetAllAsync();
            return polls.IsSuccess ? Ok(polls.GetValueOrThrow()) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task< IActionResult > GetById(int id)
        {
            var pollresult = await _pollService.GetByIdAsync(id);
            
            return pollresult.IsSuccess ? Ok(pollresult.GetValueOrThrow()) : NotFound();
        }
        [HttpPost("")]
        public async Task< IActionResult> Create(PollRequest newpoll , CancellationToken cancellationToken)
        {
            var poll = newpoll.Adapt<Poll>();

           var pollresult= await _pollService.CreateAsync(poll , cancellationToken);
            return pollresult.IsSuccess ? Ok(pollresult.GetValueOrThrow()) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PollRequest pollRequest, CancellationToken cancellationToken)
        {
            var newpoll = pollRequest.Adapt<Poll>();
            var updatedpoll = await _pollService.UpdateAsync(id, newpoll, cancellationToken);
           return updatedpoll.IsSuccess ? Ok() : NotFound(updatedpoll.Error);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {

            var deleted = await _pollService.DeleteAsync(id, cancellationToken);
            return deleted.IsSuccess ? Ok() : NotFound(deleted.Error);
        }
    }
}
