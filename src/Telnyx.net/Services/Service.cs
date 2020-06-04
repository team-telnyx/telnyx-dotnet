namespace Telnyx
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Telnyx.Infrastructure;
    using Telnyx.net.Entities;

    /// <summary>
    /// Service.
    /// </summary>
    /// <typeparam name="EntityReturned">ITelnyxEntity.</typeparam>
    public abstract class Service<EntityReturned>
        where EntityReturned : ITelnyxEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        protected Service()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey.</param>
        protected Service(string apiKey)
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
        /// <summary>
        /// CreateEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned CreateEntity(string id, string postFix, BaseOptions options, RequestOptions requestOptions)
        {
            return this.PostRequest<EntityReturned>(this.CallUrl(id, postFix), options, requestOptions);
        }

        /// <summary>
        /// CreateEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> CreateEntityAsync(string id, string postFix, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.PostRequestAsync<EntityReturned>(this.CallUrl(id, postFix), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// CreateEntity.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned CreateEntity(BaseOptions options, RequestOptions requestOptions)
        {
            return this.PostRequest<EntityReturned>(this.ClassUrl(), options, requestOptions);
        }

        /// <summary>
        /// CreateEntityAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> CreateEntityAsync(BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.PostRequestAsync<EntityReturned>(this.ClassUrl(), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// DeleteEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned DeleteEntity(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.DeleteRequest<EntityReturned>(this.InstanceUrl(id), options, requestOptions);
        }

        /// <summary>
        /// DeleteEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> DeleteEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.DeleteRequestAsync<EntityReturned>(this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// GetEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned GetEntity(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.GetRequest<EntityReturned>(this.InstanceUrl(id), options, requestOptions, false);
        }

        /// <summary>
        /// GetEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> GetEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.GetRequestAsync<EntityReturned>(this.InstanceUrl(id), options, requestOptions, false, cancellationToken);
        }

        /// <summary>
        /// DeleteEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned DeleteEntity(string id, RequestOptions requestOptions)
        {
            return this.DeleteRequest<EntityReturned>(this.InstanceUrl(id), null, requestOptions);
        }

        /// <summary>
        /// DeleteEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> DeleteEntityAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.DeleteRequestAsync<EntityReturned>(this.InstanceUrl(id), null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// GetEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned GetEntity(string id, RequestOptions requestOptions)
        {
            return this.GetRequest<EntityReturned>(this.InstanceUrl(id), null, requestOptions, false);
        }

        /// <summary>
        /// GetEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> GetEntityAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.GetRequestAsync<EntityReturned>(this.InstanceUrl(id), null, requestOptions, false, cancellationToken);
        }
        /// <summary>
        /// GetEntity
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="postPath">postPath</param>
        /// <returns>{EntityReturned}</returns>
        protected EntityReturned GetEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null)
        {
            return this.GetRequest<EntityReturned>(this.CallUrl(id, postPath), options, requestOptions, false);
        }

        /// <summary>
        /// GetEntityAsync
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <param name="postPath">postPath</param>
        /// <returns>{EntityReturned}</returns>
        protected async Task<EntityReturned> GetEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken, string postPath = null)
        {
            return await this.GetRequestAsync<EntityReturned>(this.CallUrl(id, postPath), options, requestOptions, false, cancellationToken);
        }



        /// <summary>
        /// ListEntitiesAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList {EntityReturned}.</returns>
        protected async Task<TelnyxList<EntityReturned>> ListEntitiesAsync(BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.GetRequestAsync<TelnyxList<EntityReturned>>(this.ClassUrl(), options, requestOptions, true, cancellationToken);
        }
        /// <summary>
        /// ListEntities.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>TelnyxList {EntityReturned}.</returns>
        protected TelnyxList<EntityReturned> ListEntities(BaseOptions options, RequestOptions requestOptions)
        {
            return this.GetRequest<TelnyxList<EntityReturned>>(this.ClassUrl(), options, requestOptions, true);
        }

        /// <summary>
        /// ListEntitiesAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList {EntityReturned}.</returns>
        protected async Task<TelnyxList<EntityReturned>> ListEntitiesAsync(ListOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.ListRequestPagingAsync<EntityReturned>(this.ClassUrl(), options, requestOptions, cancellationToken);
        }
        /// <summary>
        /// ListEntities.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>TelnyxList {EntityReturned}.</returns>
        protected TelnyxList<EntityReturned> ListEntities(ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestPaging<EntityReturned>(this.ClassUrl(), options, requestOptions);
        }
        /// <summary>
        /// ListEntitiesAutoPaging.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>IEnumerable {EntityReturned}.</returns>
        protected IEnumerable<EntityReturned> ListEntitiesAutoPaging(ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestAutoPaging<EntityReturned>(this.ClassUrl(), options, requestOptions);
        }
        /// <summary>
        /// ListEntitiesAutoPaging.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>IEnumerable {EntityReturned}.</returns>
        protected async Task<IEnumerable<EntityReturned>> ListEntitiesAutoPagingAsync(ListOptions options, RequestOptions requestOptions, CancellationToken ct)
        {
            return await this.ListRequestAutoPagingAsync<EntityReturned>(this.ClassUrl(), options, requestOptions, ct);
        }

        /// <summary>
        /// ListEntities
        /// </summary>
        /// <param name="postPath">postPath</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>TelnyxList {EntityReturned}</returns>
        protected TelnyxList<EntityReturned> ListEntities(string postPath, ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestPaging<EntityReturned>(this.CallUrl(null, postPath), options, requestOptions);
        }

        /// <summary>
        /// ListEntitiesAsync
        /// </summary>
        /// <param name="postPath">postPath</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>TelnyxList {EntityReturned}</returns>
        protected async Task<TelnyxList<EntityReturned>> ListEntitiesAsync(string postPath, ListOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.ListRequestPagingAsync<EntityReturned>(this.CallUrl(null, postPath), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// ListEntitiesAutoPaging
        /// </summary>
        /// <param name="postPath">postPath</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>IEnumerable {EntityReturned}</returns>
        protected IEnumerable<EntityReturned> ListEntitiesAutoPaging(string postPath, ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestAutoPaging<EntityReturned>(this.CallUrl(null, postPath), options, requestOptions);
        }
        /// <summary>
        /// ListEntitiesAutoPaging
        /// </summary>
        /// <param name="postPath">postPath</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>IEnumerable {EntityReturned}</returns>
        protected Task<IEnumerable<EntityReturned>> ListEntitiesAutoPagingAsync(string postPath, ListOptions options, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return this.ListRequestAutoPagingAsync<EntityReturned>(this.CallUrl(null, postPath), options, requestOptions, ct);
        }

        /// <summary>
        /// UpdateEntity
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected EntityReturned UpdateEntity(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.PatchRequest<EntityReturned>(this.InstanceUrl(id), options, requestOptions);
        }

        /// <summary>
        /// UpdateEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<EntityReturned> UpdateEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.PatchRequestAsync<EntityReturned>(this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }
        /// <summary>
        /// UpdateEntity
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="postPath">postPath</param>
        /// <returns>{EntityReturned}</returns>
        protected EntityReturned UpdateEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null)
        {
            return this.PatchRequest<EntityReturned>(this.CallUrl(id, postPath), options, requestOptions);
        }

        /// <summary>
        /// UpdateEntityAsync
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <param name="postPath">postPath</param>
        /// <returns>{EntityReturned}</returns>
        protected async Task<EntityReturned> UpdateEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken, string postPath = null)
        {
            return await this.PatchRequestAsync<EntityReturned>(this.CallUrl(id, postPath), options, requestOptions, cancellationToken);
        }
        /// <summary>
        /// DeleteRequest
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected T DeleteRequest<T>(string url, BaseOptions options, RequestOptions requestOptions)
        {
            return Mapper<T>.MapFromJson(
                Requestor.Delete(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)), "data");
        }

        /// <summary>
        /// DeleteRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<T> DeleteRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false), "data");
        }

        /// <summary>
        /// GetRequest.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <returns>{EntityReturned}.</returns>
        protected T GetRequest<T>(string url, BaseOptions options, RequestOptions requestOptions, bool isListMethod)
        {
            var parentToken = (typeof(T) == typeof(TelnyxList<EntityReturned>)) ? null : "data";
            return Mapper<T>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(options, url, isListMethod),
                    this.SetupRequestOptions(requestOptions)), parentToken);
        }

        /// <summary>
        /// GetRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<T> GetRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, bool isListMethod, CancellationToken cancellationToken)
        {
            var parentToken = (typeof(T) == typeof(TelnyxList<EntityReturned>)) ? null : "data";
            return Mapper<T>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(options, url, isListMethod),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false), parentToken);
        }
        /// <summary>
        /// GetRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<T> GetRequestAsync<T>(string url, CancellationToken cancellationToken)
        {
            var parentToken = (typeof(T) == typeof(TelnyxList<EntityReturned>)) ? null : "data";
            return Mapper<T>.MapFromJson(
                await Requestor.GetStringAsync(url, null, cancellationToken)
                    .ConfigureAwait(false), parentToken);
        }
        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>IEnumerable {EntityReturned}.</returns>
        protected IEnumerable<T> ListRequestAutoPaging<T>(string url, ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestAutoPagingAsync<T>(url, options, requestOptions).GetAwaiter().GetResult();
        }
        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>IEnumerable {EntityReturned}.</returns>
        protected async Task<IEnumerable<T>> ListRequestAutoPagingAsync<T>(string url, ListOptions options, RequestOptions requestOptions, CancellationToken ct = default)
        {
            var page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, ct);
            if (options == null)
            {
                options = new ListOptions();
            }
            var listOfEntities = page.Data;
            if (page.HasMore && options.NumberOfPagesToFetch == null)
            {
                while (page.HasMore)
                {
                    options.PageNumber = page.PageInfo?.NextPage ?? options?.PageNumber + 1;

                    page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, ct);
                    if (page != null && page.Data != null && page.Data.Any())
                    {
                        //page.PageInfo.NextPageUrl = page.Url.Replace($"page[number]={options.PageNumber}", $"page[number]={page.PageInfo.NextPage}");
                        listOfEntities.AddRange(page.Data);
                    }
                }
            }
            return listOfEntities ?? new List<T>();
        }
        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>IEnumerable {EntityReturned}.</returns>
        protected TelnyxList<T> ListRequestPaging<T>(string url, ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestPagingAsync<T>(url, options, requestOptions).GetAwaiter().GetResult();
        }
        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>IEnumerable {EntityReturned}.</returns>
        protected async Task<TelnyxList<T>> ListRequestPagingAsync<T>(string url, ListOptions options, RequestOptions requestOptions, CancellationToken ct = default)
        {
            var page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, ct);
            if (options == null)
            {
                options = new ListOptions();
            }
            // page.PageInfo.NextPageUrl = page.Url.Replace($"page[number]={options.PageNumber}", $"page[number]={page.PageInfo.NextPage}");

            if (page.HasMore && options.NumberOfPagesToFetch.HasValue
                && options.NumberOfPagesToFetch > 1
                && options.NumberOfPagesToFetch < page.PageInfo.TotalPages)
            {
                var listOfEntities = page.Data;
                int count = 1;

                do
                {
                    options.PageNumber = page.PageInfo.NextPage;
                    page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, ct);
                    if (page != null && page.Data != null && page.Data.Any())
                    {
                        // page.PageInfo.NextPageUrl = page.Url.Replace($"page[number]={options.PageNumber}", $"page[number]={page.PageInfo.NextPage}");
                        listOfEntities.AddRange(page.Data);
                    }
                    count++;
                }
                while (count < options.NumberOfPagesToFetch && page.HasMore);

                page.Data = listOfEntities; // fill the data
            }

            return page ?? new TelnyxList<T>();
        }

        /// <summary>
        /// PostRequest.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected T PostRequest<T>(string url, BaseOptions options, RequestOptions requestOptions)
        {
            return Mapper<T>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)), "data");
        }

        /// <summary>
        /// PostRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<T> PostRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false), "data");
        }

        /// <summary>
        /// PatchRequest.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{EntityReturned}.</returns>
        protected T PatchRequest<T>(string url, BaseOptions options, RequestOptions requestOptions)
        {
            return Mapper<T>.MapFromJson(
                Requestor.PatchString(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)), "data");
        }

        /// <summary>
        /// PatchRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {EntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{EntityReturned}.</returns>
        protected async Task<T> PatchRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.PatchStringAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false), "data");
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
        /// Helper method to use a url to get resquest
        /// </summary>
        /// <param name="list">Utilizes the NextPage url</param>
        /// <returns></returns>
        public TelnyxList<EntityReturned> GetFromUrl(TelnyxList<EntityReturned> list)
        {
            return this.GetRequestAsync<TelnyxList<EntityReturned>>(list.PageInfo.NextPageUrl, default).GetAwaiter().GetResult();
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
                return $"{this.ClassUrl(baseUrl)}/{postPath}";
            else
                return $"{this.ClassUrl(baseUrl)}/{WebUtility.UrlEncode(id)}/{postPath}";
        }
        /// <summary>
        /// ClassUrl.
        /// </summary>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string ClassUrl(string baseUrl = null)
        {

            baseUrl = baseUrl ?? TelnyxConfiguration.GetApiBase();
            return $"{baseUrl}{this.BasePath}";
        }

        /// <summary>
        /// InstanceUrl.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string InstanceUrl(string id, string baseUrl = null)
        {
            return $"{this.ClassUrl(baseUrl)}/{WebUtility.UrlEncode(id)}";
        }
    }
}
