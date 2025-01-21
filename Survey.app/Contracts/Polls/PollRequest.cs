namespace Survey.app.Contracts.Polls
{
    public record PollRequest(

     string Title,
     string Summary,
     DateOnly PublishedAt,
     DateOnly StartAt,
     DateOnly EndAt
        );
}
