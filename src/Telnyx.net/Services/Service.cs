namespace Telnyx
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.Infrastructure;
    using Telnyx.net.Entities;
    using Telnyx.net.Services;

    /// <summary>
    /// Service.
    /// </summary>
    /// <typeparam name="TEntityReturned">ITelnyxEntity.</typeparam>
    public abstract class Service<TEntityReturned>
        where TEntityReturned : ITelnyxEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntityReturned}"/> class.
        /// </summary>
        protected Service()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntityReturned}"/> class.
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
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned CreateEntity(string id, string postFix, BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.PostRequest<TEntityReturned>(this.CallUrl(id, postFix), options, requestOptions, parentToken: parentToken);
        }

        /// <summary>
        /// CreateEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> CreateEntityAsync(string id, string postFix, BaseOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<TEntityReturned>(this.CallUrl(id, postFix), options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// CreateEntity for PlainText response.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected string CreateEntity(string id, string postFix, BaseOptions options, RequestOptions requestOptions, bool isJsonResponse = true)
        {
            return this.PostRequest<string>(this.CallUrl(id, postFix), options, requestOptions, isJsonResponse);
        }

        /// <summary>
        /// CreateEntityAsync for PlainText response.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<string> CreateEntityAsync(string id, string postFix, BaseOptions options, RequestOptions requestOptions, bool isJsonResponse = true, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<string>(this.CallUrl(id, postFix), options, requestOptions, isJsonResponse, parentToken, cancellationToken);
        }

        /// <summary>
        /// CreateEntity.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postBasePath">Post base path.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned CreateEntity(
            BaseOptions options,
            RequestOptions requestOptions,
            string postBasePath = "",
            string parentToken = "")
        {
            return this.PostRequest<TEntityReturned>(this.ClassUrl(postBasePath: postBasePath), options, requestOptions, parentToken: parentToken);
        }

        protected TelnyxList<TEntityReturned> CreateListEntity(
            BaseOptions options,
            RequestOptions requestOptions,
            string postBasePath = "",
            string parentToken = "")
        {
            return this.PostRequest<TelnyxList<TEntityReturned>>(this.ClassUrl(postBasePath: postBasePath), options, requestOptions, parentToken: parentToken);
        }

        /// <summary>
        /// CreateEntityAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TelnyxList<TEntityReturned>> CreateListEntityAsync(
            BaseOptions options,
            RequestOptions requestOptions,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<TelnyxList<TEntityReturned>>(this.ClassUrl(), options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// CreateEntityAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> CreateEntityAsync(
            BaseOptions options,
            RequestOptions requestOptions,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        protected async Task<TEntityReturned> CreateEntityAsync(
            BaseOptions options,
            RequestOptions requestOptions,
            string postBasePath,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<TEntityReturned>(this.ClassUrl(postBasePath: postBasePath), options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// DeleteEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned DeleteEntity(string id, BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.DeleteRequest<TEntityReturned>(this.InstanceUrl(id), options, requestOptions, parentToken);
        }

        /// <summary>
        /// DeleteEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> DeleteEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.DeleteRequestAsync<TEntityReturned>(this.InstanceUrl(id), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// DeleteEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned DeleteEntity(string id, string postFix, BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.DeleteRequest<TEntityReturned>(this.CallUrl(id, postFix), options, requestOptions, parentToken);
        }

        /// <summary>
        /// DeleteEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="postFix">postFix.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> DeleteEntityAsync(string id, string postFix, BaseOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.DeleteRequestAsync<TEntityReturned>(this.CallUrl(id, postFix), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// GetEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned GetEntity(string id, BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.GetRequest<TEntityReturned>(this.InstanceUrl(id), options, requestOptions, false, parentToken);
        }

        /// <summary>
        /// GetEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> GetEntityAsync(
            string id,
            BaseOptions options,
            RequestOptions requestOptions,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<TEntityReturned>(this.InstanceUrl(id), options, requestOptions, false, parentToken, cancellationToken);
        }

        /// <summary>
        /// DeleteEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned DeleteEntity(string id, RequestOptions requestOptions, string parentToken = "")
        {
            return this.DeleteRequest<TEntityReturned>(this.InstanceUrl(id), null, requestOptions, parentToken);
        }

        /// <summary>
        /// DeleteEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> DeleteEntityAsync(string id, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.DeleteRequestAsync<TEntityReturned>(this.InstanceUrl(id), null, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// GetEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned GetEntity(string id, RequestOptions requestOptions, string parentToken = "")
        {
            return this.GetRequest<TEntityReturned>(this.InstanceUrl(id), null, requestOptions, false, parentToken);
        }

        /// <summary>
        /// GetEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned GetEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "")
        {
            return this.GetRequest<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, false, parentToken);
        }

        /// <summary>
        /// GetEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> GetEntityAsync(string id, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<TEntityReturned>(this.InstanceUrl(id), null, requestOptions, false, parentToken, cancellationToken);
        }

        /// <summary>
        /// GetEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> GetEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, false, parentToken, cancellationToken);
        }

        /// <summary>
        /// CreateEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned CreateEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, bool isJsonResponse = false, string parentToken = "")
        {
            return this.PostRequest<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, isJsonResponse, parentToken);
        }

        /// <summary>
        /// CreateListEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>TelnyxList{TEntityReturned}.</returns>
        protected TelnyxList<TEntityReturned> CreateListEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, bool isJsonResponse = false, string parentToken = "")
        {
            return this.PostRequest<TelnyxList<TEntityReturned>>(this.CallUrl(id, postPath), options, requestOptions, isJsonResponse, parentToken);
        }

        /// <summary>
        /// CreateEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> CreateEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, true, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// CreateListEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList{TEntityReturned}.</returns>
        protected async Task<TelnyxList<TEntityReturned>> CreateListEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, bool isJsonResponse = false, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PostRequestAsync<TelnyxList<TEntityReturned>>(this.CallUrl(id, postPath), options, requestOptions, isJsonResponse, parentToken, cancellationToken);
        }

        /// <summary>
        /// ListEntitiesAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected async Task<TelnyxList<TEntityReturned>> ListEntitiesAsync(BaseOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<TelnyxList<TEntityReturned>>(this.ClassUrl(), options, requestOptions, true, parentToken, cancellationToken);
        }

        /// <summary>
        /// ListEntities.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected TelnyxList<TEntityReturned> ListEntities(BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.GetRequest<TelnyxList<TEntityReturned>>(this.ClassUrl(), options, requestOptions, true, parentToken);
        }

        /// <summary>
        /// ListEntitiesAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected async Task<TelnyxList<TEntityReturned>> ListEntitiesAsync(ListOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.ListRequestPagingAsync<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// ListEntities.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected TelnyxList<TEntityReturned> ListEntities(ListOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.ListRequestPaging<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListEntitiesAutoPaging.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected IEnumerable<TEntityReturned> ListEntitiesAutoPaging(ListOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.ListRequestAutoPaging<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListEntitiesAutoPaging.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected async Task<IEnumerable<TEntityReturned>> ListEntitiesAutoPagingAsync(ListOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken = default)
        {
            return await this.ListRequestAutoPagingAsync<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListEntities.
        /// </summary>
        /// <param name="postPath">postPath.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="id">id.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected TelnyxList<TEntityReturned> ListEntities(string postPath, ListOptions options, RequestOptions requestOptions, string parentToken = "", string id = null)
        {
            return this.ListRequestPaging<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListEntitiesAsync.
        /// </summary>
        /// <param name="postPath">postPath.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="id">id.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected async Task<TelnyxList<TEntityReturned>> ListEntitiesAsync(string postPath, ListOptions options, RequestOptions requestOptions, string parentToken = "", string id = null, CancellationToken cancellationToken = default)
        {
            return await this.ListRequestPagingAsync<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// ListEntitiesAutoPaging.
        /// </summary>
        /// <param name="postPath">postPath.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected IEnumerable<TEntityReturned> ListEntitiesAutoPaging(string postPath, ListOptions options, RequestOptions requestOptions, string parentToken)
        {
            return this.ListRequestAutoPaging<TEntityReturned>(this.CallUrl(null, postPath), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListEntitiesAutoPaging.
        /// </summary>
        /// <param name="postPath">postPath.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected Task<IEnumerable<TEntityReturned>> ListEntitiesAutoPagingAsync(string postPath, ListOptions options, RequestOptions requestOptions, string parentToken)
        {
            return this.ListRequestAutoPagingAsync<TEntityReturned>(this.CallUrl(null, postPath), options, requestOptions, parentToken);
        }

        /// <summary>
        /// UpdateEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned UpdateEntity(string id, BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.PatchRequest<TEntityReturned>(this.InstanceUrl(id), options, requestOptions, parentToken);
        }

        /// <summary>
        /// UpdateEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> UpdateEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PatchRequestAsync<TEntityReturned>(this.InstanceUrl(id), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// UpdateEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned UpdateEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "")
        {
            return this.PatchRequest<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, parentToken);
        }

        /// <summary>
        /// UpdateEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> UpdateEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PatchRequestAsync<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// UpgradeEntity.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned UpgradeEntity(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "")
        {
            return this.PutRequest<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, parentToken);
        }

        /// <summary>
        /// UpgradeEntityAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> UpgradeEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PutRequestAsync<TEntityReturned>(this.CallUrl(id, postPath), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// BulkUpdateEntity.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned BulkUpdateEntity(BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "")
        {
            return this.PutRequest<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken);
        }

        /// <summary>
        /// BulkUpdateEntity.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="postPath">postPath.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> BulkUpdateEntityAsync(BaseOptions options, RequestOptions requestOptions, string postPath = null, string parentToken = "", CancellationToken cancellationToken = default)
        {
            return await this.PutRequestAsync<TEntityReturned>(this.ClassUrl(), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// DeleteRequest.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected T DeleteRequest<T>(string url, BaseOptions options, RequestOptions requestOptions, string parentToken)
        {
            return Mapper<T>.MapFromJson(
                Requestor.Delete(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)),
                parentToken);
        }

        /// <summary>
        /// DeleteRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<T> DeleteRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false),
                parentToken);
        }

        /// <summary>
        /// GetRequest.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected T GetRequest<T>(string url, BaseOptions options, RequestOptions requestOptions, bool isListMethod, string parentToken = "")
        {
            return Mapper<T>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(options, url, isListMethod),
                    this.SetupRequestOptions(requestOptions)),
                parentToken);
        }

        /// <summary>
        /// GetRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<T> GetRequestAsync<T>(
            string url,
            BaseOptions options,
            RequestOptions requestOptions,
            bool isListMethod,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(options, url, isListMethod),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false),
                parentToken);
        }

        /// <summary>
        /// GetRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<T> GetRequestAsync<T>(
            string url,
            RequestOptions requestOptions,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.GetStringAsync(url, requestOptions, cancellationToken)
                    .ConfigureAwait(false),
                parentToken);
        }

        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected IEnumerable<T> ListRequestAutoPaging<T>(string url, ListOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            return this.ListRequestAutoPagingAsync<T>(url, options, requestOptions, parentToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected async Task<IEnumerable<T>> ListRequestAutoPagingAsync<T>(string url, ListOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellationToken = default)
        {
            var page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, parentToken, cancellationToken);
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

                    page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, parentToken);
                    if (page != null && page.Data != null && page.Data.Any())
                    {
                        listOfEntities.AddRange(page.Data);
                    }
                }
            }

            return listOfEntities ?? new List<T>();
        }

        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected TelnyxList<T> ListRequestPaging<T>(string url, ListOptions options, RequestOptions requestOptions, string parentToken)
        {
            return this.ListRequestPagingAsync<T>(url, options, requestOptions, parentToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// ListRequestAutoPaging.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellation">cancellationToken.</param>
        /// <returns>IEnumerable {TEntityReturned}.</returns>
        protected async Task<TelnyxList<T>> ListRequestPagingAsync<T>(string url, ListOptions options, RequestOptions requestOptions, string parentToken = "", CancellationToken cancellation = default)
        {
            var page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, parentToken, cancellation);
            if (options == null)
            {
                options = new ListOptions();
            }

            if (page.HasMore && options.NumberOfPagesToFetch.HasValue
                && options.NumberOfPagesToFetch > 1)
            {
                var listOfEntities = page.Data;
                int count = 1;

                do
                {
                    options.PageNumber = page.PageInfo.NextPage;
                    page = await this.GetRequestAsync<TelnyxList<T>>(url, options, requestOptions, true, parentToken);
                    if (page != null && page.Data != null && page.Data.Any())
                    {
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
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected T PostRequest<T>(
            string url,
            BaseOptions options,
            RequestOptions requestOptions,
            bool isJsonResponse = true,
            string parentToken = "")
        {
            if (isJsonResponse)
            {
                return Mapper<T>.MapFromJson(
                    Requestor.PostString(
                        this.ApplyAllParameters(options, url),
                        this.SetupRequestOptions(requestOptions)),
                    parentToken);
            }
            else
            {
                return Mapper<T>.MapFromPlainText(Requestor.PostString(
                        this.ApplyAllParameters(options, url),
                        this.SetupRequestOptions(requestOptions)).ResponseJson);
            }
        }

        /// <summary>
        /// PostRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="isJsonResponse">Maps as json response.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<T> PostRequestAsync<T>(
            string url,
            BaseOptions options,
            RequestOptions requestOptions,
            bool isJsonResponse = true,
            string parentToken = "",
            CancellationToken cancellationToken = default)
        {
            if (isJsonResponse)
            {
                return Mapper<T>.MapFromJson(
                    await Requestor.PostStringAsync(
                        this.ApplyAllParameters(options, url),
                        this.SetupRequestOptions(requestOptions),
                        cancellationToken).ConfigureAwait(false),
                    parentToken);
            }
            else
            {
                var response = await Requestor.PostStringAsync(
                        this.ApplyAllParameters(options, url),
                        this.SetupRequestOptions(requestOptions));
                return Mapper<T>.MapFromPlainText(response.ResponseJson);
            }
        }

        /// <summary>
        /// PatchRequest.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected T PatchRequest<T>(string url, BaseOptions options, RequestOptions requestOptions, string parentToken)
        {
            return Mapper<T>.MapFromJson(
                Requestor.PatchString(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)),
                parentToken);
        }

        /// <summary>
        /// PatchRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<T> PatchRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.PatchStringAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false),
                parentToken);
        }

        /// <summary>
        /// PatchRequest.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected T PutRequest<T>(string url, BaseOptions options, RequestOptions requestOptions, string parentToken)
        {
            return Mapper<T>.MapFromJson(
                Requestor.PutString(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)),
                parentToken);
        }

        /// <summary>
        /// PatchRequestAsync.
        /// </summary>
        /// <typeparam name="T">Request for {TEntityReturned}.</typeparam>
        /// <param name="url">url.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<T> PutRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.PutStringAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false),
                parentToken);
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
        /// Helper method to use a url to get resquest.
        /// </summary>
        /// <param name="list">Utilizes the NextPage url.</param>
        /// <returns>returns <see cref="TelnyxList{TEntityReturned}"/>.</returns>
        public TelnyxList<TEntityReturned> GetFromUrl(TelnyxList<TEntityReturned> list)
        {
            return this.GetRequestAsync<TelnyxList<TEntityReturned>>(list.PageInfo.NextPageUrl, default).GetAwaiter().GetResult();
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
            {
                return this.ClassUrl(baseUrl).UrlCombine(postPath);
            }
            else
            {
                if (string.IsNullOrEmpty(postPath))
                {
                    return this.ClassUrl(baseUrl).UrlCombine(WebUtility.UrlEncode(id));
                }

                return this.ClassUrl(baseUrl).UrlCombine(WebUtility.UrlEncode(id), postPath);
            }
        }

        /// <summary>
        /// ClassUrl.
        /// </summary>
        /// <param name="baseUrl">baseUrl.</param>
        /// <param name="postBasePath">Post base path.</param>
        /// <returns>url.</returns>
        protected virtual string ClassUrl(string baseUrl = null, string postBasePath = "")
        {
            baseUrl = baseUrl ?? TelnyxConfiguration.GetApiBase();
            var basePath = this.BasePath + postBasePath;
            return baseUrl.UrlCombine(basePath);
        }

        /// <summary>
        /// InstanceUrl.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string InstanceUrl(string id, string baseUrl = null)
        {
            return this.ClassUrl(baseUrl).UrlCombine(WebUtility.UrlEncode(id));
        }
    }
}
