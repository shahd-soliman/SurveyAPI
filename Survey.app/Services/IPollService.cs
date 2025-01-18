namespace Survey.app.Services
{
    public interface IPollService
    {
        List<Poll>? GetAll();
        Poll GetById(int id);
        Poll Create(Poll poll);
        bool Update(int id, Poll poll);
        bool Delete(int id);
    }
}
