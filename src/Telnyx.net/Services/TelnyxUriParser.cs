using System.Linq;

namespace Telnyx.net.Services
{
    public static class TelnyxUriParser
    {
        public static string UrlCombine(this string baseUrl, params string[] segments) => string.Join("/", new[] { baseUrl.TrimEnd('/') }.Concat(segments.Select(s => s.Trim('/'))));
    }
}
