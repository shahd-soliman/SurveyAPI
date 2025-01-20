namespace Survey.app.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string?  Title { get; set; }
        public string? Summary { get; set; }
        public DateOnly? PublishedAt { get; set; }
        public DateOnly? StartAt { get; set; }
        public DateOnly? EndAt { get; set; }
    }
}
