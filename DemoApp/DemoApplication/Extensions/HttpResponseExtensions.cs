namespace DemoApplication.Extensions
{
    public static class HttpResponseExtensions
    {
        public static string? GetCookieValueFromResponse(this HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers.Values)

                foreach (var header in headers)
                    if (header.StartsWith($"{cookieName}="))
                    {
                        var p1 = header.IndexOf('=');
                        var p2 = header.IndexOf(';');
                        return header.Substring(p1 + 1, p2 - p1 - 1);
                    }

            return null;
        }
    }
}
