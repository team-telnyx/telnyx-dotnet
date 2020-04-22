namespace Telnyx
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ServiceNested
    /// </summary>
    /// <typeparam name="EntityReturned">ITelnyxEntity</typeparam>
    public abstract class ServiceNested<EntityReturned> : Service<EntityReturned>
        where EntityReturned : ITelnyxEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceNested{EntityReturned}"/> class.
        /// </summary>
        protected ServiceNested()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceNested{EntityReturned}"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey</param>
        protected ServiceNested(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// CreateNestedEntity
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>{EntityReturned}</returns>
        protected EntityReturned CreateNestedEntity(string parentId, BaseOptions options, RequestOptions requestOptions)
        {
            return this.PostRequest<EntityReturned>(this.ClassUrl(parentId), options, requestOptions);
        }

        /// <summary>
        /// CreateNestedEntityAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>{EntityReturned}</returns>
        protected async Task<EntityReturned> CreateNestedEntityAsync(string parentId, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.PostRequestAsync<EntityReturned>(this.ClassUrl(parentId), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// DeleteNestedEntity
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>{EntityReturned}</returns>
        protected EntityReturned DeleteNestedEntity(string parentId, string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.DeleteRequest<EntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions);
        }

        /// <summary>
        /// DeleteNestedEntityAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>{EntityReturned}</returns>
        protected async Task<EntityReturned> DeleteNestedEntityAsync(string parentId, string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.DeleteRequestAsync<EntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// GetNestedEntity
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>{EntityReturned}</returns>
        protected EntityReturned GetNestedEntity(string parentId, string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.GetRequest<EntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, false);
        }

        /// <summary>
        /// GetNestedEntityAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>{EntityReturned}</returns>
        protected async Task<EntityReturned> GetNestedEntityAsync(string parentId, string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.GetRequestAsync<EntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, false, cancellationToken);
        }

        /// <summary>
        /// ListNestedEntities
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>TelnyxList {EntityReturned}</returns>
        protected TelnyxList<EntityReturned> ListNestedEntities(string parentId, ListOptions options, RequestOptions requestOptions)
        {
            return this.GetRequest<TelnyxList<EntityReturned>>(this.ClassUrl(parentId), options, requestOptions, true);
        }

        /// <summary>
        /// ListNestedEntitiesAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>TelnyxList {EntityReturned}</returns>
        protected async Task<TelnyxList<EntityReturned>> ListNestedEntitiesAsync(string parentId, ListOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.GetRequestAsync<TelnyxList<EntityReturned>>(this.ClassUrl(parentId), options, requestOptions, true, cancellationToken);
        }

        /// <summary>
        /// ListNestedEntitiesAutoPaging
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>Ienumerable {EntityReturned}</returns>
        protected IEnumerable<EntityReturned> ListNestedEntitiesAutoPaging(string parentId, ListOptions options, RequestOptions requestOptions)
        {
            return this.ListRequestAutoPaging<EntityReturned>(this.ClassUrl(parentId), options, requestOptions);
        }

        /// <summary>
        /// UpdateNestedEntity
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>{EntityReturned}</returns>
        protected EntityReturned UpdateNestedEntity(string parentId, string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.PostRequest<EntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions);
        }

        /// <summary>
        /// UpdateNestedEntityAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="options">options</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>{EntityReturned}</returns>
        protected async Task<EntityReturned> UpdateNestedEntityAsync(string parentId, string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.PostRequestAsync<EntityReturned>(this.InstanceUrl(parentId, id), options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// ClassUrl
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="baseUrl">baseUrl</param>
        /// <returns>url</returns>
        protected virtual string ClassUrl(string parentId, string baseUrl = null)
        {
            baseUrl = baseUrl ?? TelnyxConfiguration.GetApiBase();
            return $"{baseUrl}{this.BasePath.Replace("{PARENT_ID}", parentId)}";
        }

        /// <summary>
        /// InstanceUrl
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="baseUrl">baseUrl</param>
        /// <returns>url</returns>
        protected virtual string InstanceUrl(string parentId, string id, string baseUrl = null)
        {
            return $"{this.ClassUrl(parentId, baseUrl)}/{WebUtility.UrlEncode(id)}";
        }
    }
}
