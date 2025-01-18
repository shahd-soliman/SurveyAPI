
using Microsoft.AspNetCore.Http.HttpResults;

namespace Survey.app.Services
{
    public class pollService : IPollService
    {
        private static readonly List<Poll> _polls = [
            new Poll{
                Id= 1,
                Title="Poll 1",
                Description="My First Poll"
                    }];
        public Poll Create(Poll poll)
        {
            poll.Id =( _polls.Count) + 1;
            _polls.Add( poll );
            return poll;    
        }

      
        public List<Poll>? GetAll()
        {
            return _polls;
        }

        public Poll GetById(int id)
        {
            var poll = _polls.FirstOrDefault(pol => pol.Id == id);
            return poll;
        }

        public bool Update(int id ,Poll poll)
        {
            var updatedpoll = GetById(id);
            if (updatedpoll is null)
                return false;

                updatedpoll.Title = poll.Title;
                updatedpoll.Description = poll.Description;
            return true;
               
            

        }
        public bool Delete(int id)
        {
            var poll = GetById(id);
            if (poll is null)
                return false;
            _polls.Remove(poll);
            return true;
        }

    }
}
