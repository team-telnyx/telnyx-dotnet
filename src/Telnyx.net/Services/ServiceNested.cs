namespace Telnyx
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// ServiceNested.
    /// </summary>
    /// <typeparam name="TEntityReturned">ITelnyxEntity.</typeparam>
    public abstract class ServiceNested<TEntityReturned> : Service<TEntityReturned>
        where TEntityReturned : ITelnyxEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceNested{TEntityReturned}"/> class.
        /// </summary>
        protected ServiceNested()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceNested{TEntityReturned}"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey.</param>
        protected ServiceNested(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// CreateNestedEntity.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned CreateNestedEntity(string parentId, BaseOptions options, RequestOptions requestOptions)
        {
            return this.PostRequest<TEntityReturned>(this.ClassUrl(parentId), options, requestOptions);
        }

        /// <summary>
        /// CreateNestedEntityAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> CreateNestedEntityAsync(string parentId, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.PostRequestAsync<TEntityReturned>(this.ClassUrl(parentId), options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// DeleteNestedEntity.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned DeleteNestedEntity(string parentId, string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.DeleteRequest<TEntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, string.Empty);
        }

        /// <summary>
        /// DeleteNestedEntityAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> DeleteNestedEntityAsync(string parentId, string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.DeleteRequestAsync<TEntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, string.Empty, cancellationToken);
        }

        /// <summary>
        /// GetNestedEntity.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned GetNestedEntity(string parentId, string id, BaseOptions options, RequestOptions requestOptions, string parentToken = "")
        {
            var url = this.InstanceUrl(parentId, id).TrimEnd('/');
            return this.GetRequest<TEntityReturned>(url, options, requestOptions, false, parentToken);
        }

        /// <summary>
        /// GetNestedEntityAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> GetNestedEntityAsync(string parentId, string id, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.GetRequestAsync<TEntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, false, parentToken, cancellationToken);
        }

        /// <summary>
        /// ListNestedEntities.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected TelnyxList<TEntityReturned> ListNestedEntities(string parentId, ListOptions options, RequestOptions requestOptions, string parentToken)
        {
            return this.ListRequestPaging<TEntityReturned>(this.ClassUrl(parentId), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListNestedEntitiesAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList {TEntityReturned}.</returns>
        protected async Task<TelnyxList<TEntityReturned>> ListNestedEntitiesAsync(string parentId, ListOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.ListRequestPagingAsync<TEntityReturned>(this.ClassUrl(parentId), options, requestOptions, parentToken);
        }

        /// <summary>
        /// ListNestedEntitiesAutoPaging.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>Ienumerable {TEntityReturned}.</returns>
        protected IEnumerable<TEntityReturned> ListNestedEntitiesAutoPaging(string parentId, ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestAutoPaging<TEntityReturned>(this.ClassUrl(parentId), options, requestOptions);
        }

        /// <summary>
        /// ListNestedEntitiesAutoPaging.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Ienumerable {TEntityReturned}.</returns>
        protected async Task<IEnumerable<TEntityReturned>> ListNestedEntitiesAutoPagingAsync(string parentId, ListOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.ListRequestAutoPagingAsync<TEntityReturned>(this.ClassUrl(parentId), options, requestOptions, parentToken, cancellationToken);
        }

        /// <summary>
        /// UpdateNestedEntity.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected TEntityReturned UpdateNestedEntity(string parentId, string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.PostRequest<TEntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions);
        }

        /// <summary>
        /// UpdateNestedEntityAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="parentToken">Parsing token.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>{TEntityReturned}.</returns>
        protected async Task<TEntityReturned> UpdateNestedEntityAsync(string parentId, string id, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.PostRequestAsync<TEntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// ClassUrl.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string ClassUrl(string parentId, string baseUrl = null)
        {
            baseUrl = baseUrl ?? TelnyxConfiguration.GetApiBase();
            return $"{baseUrl}{this.BasePath.Replace("{PARENT_ID}", parentId)}";
        }

        /// <summary>
        /// InstanceUrl.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="baseUrl">baseUrl.</param>
        /// <returns>url.</returns>
        protected virtual string InstanceUrl(string parentId, string id, string baseUrl = null)
        {
            return $"{this.ClassUrl(parentId, baseUrl)}/{WebUtility.UrlEncode(id)}";
        }
    }
}
