using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telnyx.net.Entities;
using Telnyx.net.Services;

namespace Telnyx
{
    /// <summary>
    /// Service class for managing comments.
    /// </summary>
    public class CommentsService : Service<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// </summary>
        public CommentsService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class with an API key.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        public CommentsService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/comments"; // Adjust the BasePath to the correct endpoint for comments.

        /// <summary>
        /// Lists comments based on the provided query options.
        /// </summary>
        /// <param name="options">Query options for filtering the comments.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <returns>A list of comments.</returns>
        public virtual TelnyxList<Comment> List(CommentQueryOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Asynchronously lists comments based on the provided query options.
        /// </summary>
        /// <param name="options">Query options for filtering the comments.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns a list of comments.</returns>
        public virtual async Task<TelnyxList<Comment>> ListAsync(CommentQueryOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }

        /// <summary>
        /// Retrieves a single comment entity by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the comment entity.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <returns>A comment entity.</returns>
        public virtual Comment Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Asynchronously retrieves a single comment entity by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the comment entity.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns a comment entity.</returns>
        public virtual async Task<Comment> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
