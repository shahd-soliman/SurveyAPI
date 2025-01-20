namespace Survey.app.Contracts.Requests
{
    public record PollRequest(

     string Title,
     string Summary,
     DateOnly PublishedAt,
     DateOnly StartAt,
     DateOnly EndAt
        );
}
