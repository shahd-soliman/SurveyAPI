using Microsoft.AspNetCore.Mvc;

namespace Survey.app.Abstraction
{
    public static class ResultExtention
    {
        public static ObjectResult ToProblem(this Result result, int statusCode, string title)
        {
            var problemDetails = new ProblemDetails
            {
                Type = GetStatusCodeLink(statusCode), 
                Title = title,
                Status = statusCode,
                Extensions =
                {
                    ["errors"] = result.Error
                }
            };

            return new ObjectResult(problemDetails)
            {
                StatusCode = statusCode
            };
        }

        private static string GetStatusCodeLink(int statusCode)
        {
            return $"https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/{statusCode}";
        }
    }
}
