namespace Survey.app.Services
{
    public interface IPollService
    {
        Task<List<Poll>> GetAllAsync();
        Task<Poll?> GetByIdAsync(int id);
        Task<Poll> CreateAsync(Poll poll , CancellationToken cancellationToken);
       Task< bool> UpdateAsync(int id, Poll poll , CancellationToken cancellationToken);
       Task< bool> DeleteAsync(int id , CancellationToken cancellationToken);
    }
}
