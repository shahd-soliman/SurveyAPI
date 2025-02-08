
namespace Survey.app.Services
{
    public class pollService(ApplicationDbContext context) : IPollService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Result<Poll>> CreateAsync(Poll poll, CancellationToken cancellationToken)
        {
            await _context.Polls.AddAsync(poll, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(poll);
        }


        public async Task<Result<List<Poll>>> GetAllAsync()
        {
            var polls = await _context.Polls.AsNoTracking().ToListAsync();
            return (polls.Any()) ? Result.Success(polls) : Result.Failure<List<Poll>>(PollErrors.NotFound);
        }

        public async Task<Result<Poll>> GetByIdAsync(int id)
        {
            var poll = await _context.Polls.FirstOrDefaultAsync(x => x.Id == id);
            return poll is not null ? Result<Poll>.Success(poll) : Result.Failure<Poll>(PollErrors.NotFound);
        }

        public async Task<Result> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken)
        {
            var resultpoll = await GetByIdAsync(id);
            if (resultpoll.IsFailure)
                return Result.Failure(PollErrors.NotFound);
            var updatedpoll = resultpoll.GetValueOrThrow();

            updatedpoll.Title = poll.Title;
            updatedpoll.Summary = poll.Summary;
            updatedpoll.PublishedAt = poll.PublishedAt;
            updatedpoll.StartAt = poll.StartAt;
            updatedpoll.EndAt = poll.EndAt;
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();

        }
        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var resultpoll = await GetByIdAsync(id);
            if (resultpoll.IsFailure)
                return Result.Failure(PollErrors.NotFound);
            var poll = resultpoll.GetValueOrThrow();
            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }


    }
}
