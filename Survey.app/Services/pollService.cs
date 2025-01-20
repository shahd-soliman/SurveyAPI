
namespace Survey.app.Services
{
    public class pollService(ApplicationDbContext context) : IPollService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Poll> CreateAsync(Poll poll, CancellationToken cancellationToken)
        {
            await _context.Polls.AddAsync(poll, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return poll;
        }


        public async Task<List<Poll>> GetAllAsync()
        {
            return await _context.Polls.AsNoTracking().ToListAsync();
        }

        public async Task<Poll> GetByIdAsync(int id)
        {
            var poll = await _context.Polls.FirstOrDefaultAsync(x => x.Id == id);
            return poll;
        }

        public async Task<bool> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken)
        {
            var updatedpoll = await GetByIdAsync(id);
            if(updatedpoll is null)
                return false;   
            updatedpoll.Title = poll.Title;
            updatedpoll.Summary = poll.Summary;
            updatedpoll.PublishedAt = poll.PublishedAt;
            updatedpoll.StartAt = poll.StartAt;
            updatedpoll.EndAt = poll.EndAt;
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task< bool> DeleteAsync(int id , CancellationToken cancellationToken)
        {
            var poll = await GetByIdAsync(id );
            if (poll is null)
                return false;
           _context.Polls.Remove(poll );
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        
    }
}
