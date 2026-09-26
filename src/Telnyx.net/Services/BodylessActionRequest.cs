namespace Telnyx
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.Infrastructure;

    // The fax cancel and SIM public-IP actions have no requestBody in the API schema.
    // Keep this transport scoped to those actions; ordinary POSTs still serialize options.
    internal static class BodylessActionRequest
    {
        internal static T Send<T>(string url, RequestOptions options, string parentToken = "")
        {
            using (var request = Create(url, options))
            {
                return Mapper<T>.MapFromJson(Requestor.ExecuteRequest(request), parentToken);
            }
        }

        internal static async Task<T> SendAsync<T>(string url, RequestOptions options, string parentToken, CancellationToken cancellationToken)
        {
            using (var request = Create(url, options))
            {
                return Mapper<T>.MapFromJson(await Requestor.ExecuteRequestAsync(request, cancellationToken).ConfigureAwait(false), parentToken);
            }
        }

        private static HttpRequestMessage Create(string url, RequestOptions options)
        {
            var request = Requestor.GetRequestMessage(url, HttpMethod.Post, options);
            request.Content?.Dispose();
            request.Content = null;
            return request;
        }
    }
}
