namespace Survey.app.Contracts.Responses
{
    public class PollResponse
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateOnly StartAt { get; set; }

        public DateOnly EndAt { get; set; }

    }
}
