namespace Survey.app.Services
{
    public interface IPollService
    {
        Task<Result<List<Poll>>> GetAllAsync();
        Task<Result<Poll>> GetByIdAsync(int id);
        Task<Result<Poll>> CreateAsync(Poll poll , CancellationToken cancellationToken);
        Task<Result> UpdateAsync(int id, Poll poll , CancellationToken cancellationToken);
        Task<Result> DeleteAsync(int id , CancellationToken cancellationToken);
    }
}
