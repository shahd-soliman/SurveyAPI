using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Survey.app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        //this method called primary instructor
        private readonly IPollService _pollService = pollService;

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();
            return Ok(polls);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var poll = _pollService.GetById(id).Adapt< PollResponse>();

            return poll is null ? NotFound() : Ok(poll);
        }
        [HttpPost("")]
        public IActionResult Create(PollRequest newpoll)
        {
            var poll = newpoll.Adapt<Poll>();

            _pollService.Create(poll);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Poll newpoll)
        {

            var updatedpoll = _pollService.Update(id, newpoll);
            if (!updatedpoll)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

           var deleted= _pollService.Delete(id);
            return deleted ? Ok() : NotFound();
        }
    }
}
