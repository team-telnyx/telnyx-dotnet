// <copyright file="Requestor.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Requestor.
    /// </summary>
    internal static class Requestor
    {
        static Requestor()
        {
            HttpClient =
                TelnyxConfiguration.HttpMessageHandler != null
                    ? new HttpClient(TelnyxConfiguration.HttpMessageHandler)
                    : new HttpClient();

            if (TelnyxConfiguration.HttpTimeSpan.HasValue)
            {
                HttpClient.Timeout = TelnyxConfiguration.HttpTimeSpan.Value;
            }
        }

        /// <summary>
        /// Gets HttpClient.
        /// </summary>
        internal static HttpClient HttpClient { get; private set; }

        /// <summary>
        /// GetString.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse GetString(string url, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, HttpMethod.Get, requestOptions);

            return ExecuteRequest(wr);
        }

        public static byte[] GetFile(string url, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, HttpMethod.Get, requestOptions);

            return ExecuteFileRequest(wr);
        }

        public static async Task<byte[]> GetFileAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, HttpMethod.Get, requestOptions);

            return await ExecuteFileRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// PostString.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse PostString(string url, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, HttpMethod.Post, requestOptions);

            return ExecuteRequest(wr);
        }

        /// <summary>
        /// PatchString.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse PatchString(string url, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, new HttpMethod("PATCH"), requestOptions);

            return ExecuteRequest(wr);
        }

        /// <summary>
        /// PutString.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse PutString(string url, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, HttpMethod.Put, requestOptions);

            return ExecuteRequest(wr);
        }

        /// <summary>
        /// PutStringAsync.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> PutStringAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, HttpMethod.Put, requestOptions);

            return await ExecuteRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse Delete(string url, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, HttpMethod.Delete, requestOptions);

            return ExecuteRequest(wr);
        }

        /// <summary>
        /// PostFile.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="stream">stream.</param>
        /// <param name="purpose">purpose.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse PostFile(string url, Stream stream, string purpose, RequestOptions requestOptions)
        {
            var wr = GetRequestMessage(url, HttpMethod.Post, requestOptions);

            ApplyMultiPartFileToRequest(wr, stream, purpose);

            return ExecuteRequest(wr);
        }

        /// <summary>
        /// ExecuteRequest.
        /// </summary>
        /// <param name="requestMessage">requestMessage.</param>
        /// <returns>telnyxResponse.</returns>
        public static TelnyxResponse ExecuteRequest(HttpRequestMessage requestMessage)
        {
            var response = HttpClient.SendAsync(requestMessage).ConfigureAwait(false).GetAwaiter().GetResult();
            var responseText = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            var result = BuildResponseData(response, responseText);

            if (response.IsSuccessStatusCode)
            {
                result.Url = requestMessage.RequestUri.ToString();
                return result;
            }

            throw BuildTelnyxException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, responseText);
        }

        public static byte[] ExecuteFileRequest(HttpRequestMessage requestMessage)
        {
            var response = HttpClient.SendAsync(requestMessage).ConfigureAwait(false).GetAwaiter().GetResult();
            return response.Content.ReadAsByteArrayAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static async Task<byte[]> ExecuteFileRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// GetStringAsync.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> GetStringAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, HttpMethod.Get, requestOptions);

            return await ExecuteRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// PostStringAsync.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> PostStringAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, HttpMethod.Post, requestOptions);

            return await ExecuteRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// PatchStringAsync.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> PatchStringAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, new HttpMethod("PATCH"), requestOptions);

            return await ExecuteRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> DeleteAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, HttpMethod.Delete, requestOptions);

            return await ExecuteRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// PostFileAsync.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="stream">stream.</param>
        /// <param name="purpose">purpose.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> PostFileAsync(string url, Stream stream, string purpose, RequestOptions requestOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetRequestMessage(url, HttpMethod.Post, requestOptions);

            ApplyMultiPartFileToRequest(wr, stream, purpose);

            return await ExecuteRequestAsync(wr, cancellationToken);
        }

        /// <summary>
        /// ExecuteRequestAsync.
        /// </summary>
        /// <param name="requestMessage">requestMessage.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>telnyxResponse.</returns>
        public static async Task<TelnyxResponse> ExecuteRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = BuildResponseData(response, responseText);

            if (response.IsSuccessStatusCode)
            {
                result.Url = requestMessage.RequestUri.ToString();
                return result;
            }

            throw BuildTelnyxException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, responseText);
        }

        /// <summary>
        /// GetRequestMessage.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="method">method.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>http request message.</returns>
        public static HttpRequestMessage GetRequestMessage(string url, HttpMethod method, RequestOptions requestOptions)
        {
            requestOptions.ApiKey = requestOptions.ApiKey ?? TelnyxConfiguration.GetApiKey();

            var request = BuildRequest(method, url);

            request.Headers.Add(
                "Authorization",
                GetAuthorizationHeaderValue(requestOptions.ApiKey));

            if (requestOptions.IdempotencyKey != null)
            {
                request.Headers.Add("Idempotency-Key", requestOptions.IdempotencyKey);
            }

            if (requestOptions.TelnyxVersion != null)
            {
                request.Headers.Add("Telnyx-Version", requestOptions.TelnyxVersion);
            }
            else
            {
                request.Headers.Add("Telnyx-Version", TelnyxConfiguration.TelnyxApiVersion);
            }

            var client = new Client(request);
            client.ApplyUserAgent();
            client.ApplyClientData();

            return request;
        }

        private static HttpRequestMessage BuildRequest(HttpMethod method, string url)
        {
            if (method != HttpMethod.Post && method != new HttpMethod("PATCH") && method != HttpMethod.Put)
            {
                return new HttpRequestMessage(method, new Uri(url));
            }

            var content = string.Empty;
            var newUrl = url;

            if (url.Contains("?"))
            {
                newUrl = url.Substring(0, url.IndexOf("?", StringComparison.CurrentCultureIgnoreCase));
                content = url.Substring(url.IndexOf("?", StringComparison.CurrentCultureIgnoreCase) + 1);
            }

            var request = new HttpRequestMessage(method, new Uri(newUrl))
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            return request;
        }

        private static string GetAuthorizationHeaderValue(string apiKey)
        {
            return $"Bearer {apiKey}";
        }

        private static void ApplyMultiPartFileToRequest(HttpRequestMessage requestMessage, Stream stream, string purpose)
        {
            requestMessage.Headers.ExpectContinue = true;

            string fileName = "blob";

            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = $"\"{fileName}\""
            };

            fileContent.Headers.ContentType = new MediaTypeHeaderValue(MimeTypes.GetMimeType(fileName));

            var multiPartContent =
                new MultipartFormDataContent($"----------Upload:{DateTime.UtcNow.Ticks:x}")
                {
                    { new StringContent(purpose), "\"purpose\"" },
                    fileContent
                };

            requestMessage.Content = multiPartContent;
        }

        private static TelnyxException BuildTelnyxException(TelnyxResponse response, HttpStatusCode statusCode, string requestUri, string responseContent)
        {
            try
            {
                var telnyxErrors = Mapper<IEnumerable<TelnyxError>>.MapFromJsonErrors(responseContent, "errors", response);
                //todo: double check with API on these fields. seems errors always return as array
                var message = telnyxErrors.Any() ? (string.Join(" | ", telnyxErrors.Select(x =>
                    $"{x.ErrorTitle ?? string.Empty} {x.ErrorDetail ?? string.Empty} {x.ErrorDescription ?? string.Empty} {x.Message ?? string.Empty}"))).Trim()
                    : string.Empty;

                return new TelnyxException(statusCode, telnyxErrors, message);
            }
            catch
            {
                // TEL29 fix: Errors are not being passed to user
                return new TelnyxException(statusCode, new TelnyxError { Message = responseContent, RequestUri = requestUri }, responseContent);
            }
        }

        private static TelnyxResponse BuildResponseData(HttpResponseMessage response, string responseText)
        {
            var result = new TelnyxResponse
            {
                RequestId = response.Headers.Contains("Request-Id") ?
                    response.Headers.GetValues("Request-Id").First() :
                    "n/a",
                RequestDate = response.Headers.Contains("Date") ?
                    Convert.ToDateTime(response.Headers.GetValues("Date").First(), CultureInfo.InvariantCulture) :
                    default(DateTime),
                ResponseJson = responseText,
            };

            return result;
        }
    }
}
