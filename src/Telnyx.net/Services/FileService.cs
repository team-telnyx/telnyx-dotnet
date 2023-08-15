namespace Telnyx.net.Services
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.Infrastructure;

    public abstract class FileService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        protected FileService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey.</param>
        protected FileService(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Gets or sets ApiKey.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets BasePath.
        /// </summary>
        public abstract string BasePath { get; }

        public virtual string PostPath { get; set; } = string.Empty;

        protected byte[] GetEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null)
        {
            return this.GetRequest<byte[]>(this.CallUrl(id, postPath), options, requestOptions, false);
        }

        protected async Task<byte[]> GetEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken, string postPath = null)
        {
            return await this.GetRequestAsync<byte[]>(this.CallUrl(id, postPath), options, requestOptions, false, cancellationToken);
        }

        protected byte[] GetRequest<T>(string url, BaseOptions options, RequestOptions requestOptions, bool isListMethod)
        {
            return Requestor.GetFile(
                    this.ApplyAllParameters(options, url, isListMethod),
                    this.SetupRequestOptions(requestOptions));
        }

        protected async Task<byte[]> GetRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, bool isListMethod, CancellationToken cancellationToken)
        {
            return await Requestor.GetFileAsync(
                    this.ApplyAllParameters(options, url, isListMethod),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// SetupRequestOptions.
        /// </summary>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>RequestOptions.</returns>
        protected RequestOptions SetupRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            if (!string.IsNullOrEmpty(this.ApiKey))
            {
                requestOptions.ApiKey = this.ApiKey;
            }

            return requestOptions;
        }

        /// <summary>
        /// CallUrl.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string CallUrl(string id, string postFix, string baseUrl = null)
        {
            var postPath = postFix ?? this.PostPath;
            if (string.IsNullOrEmpty(id))
                return this.ClassUrl(baseUrl).UrlCombine(postPath);
            else
                return this.ClassUrl(baseUrl).UrlCombine(WebUtility.UrlEncode(id), postPath);
        }

        /// <summary>
        /// ClassUrl.
        /// </summary>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string ClassUrl(string baseUrl = null)
        {

            baseUrl = baseUrl ?? TelnyxConfiguration.GetApiBase();
            return baseUrl.UrlCombine(this.BasePath);
        }
    }
}
