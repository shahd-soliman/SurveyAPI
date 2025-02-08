namespace Survey.app.Errors
{
    public static class PollErrors
    {
        public static readonly Error NotFound = new("poll_not_found", "Poll not found");
    }
}
