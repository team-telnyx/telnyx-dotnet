namespace Telnyx.net.Services.DialogFlowConnections
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Connections.DialogFlowConnections;

    /// <summary>
    /// DialogFlowConnectionService.
    /// </summary>
    public class DialogFlowConnectionService : Service<DialogFlowConnection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogFlowConnectionService"/> class.
        /// </summary>
        public DialogFlowConnectionService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogFlowConnectionService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public DialogFlowConnectionService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/dialogflow_connections";

        /// <inheritdoc/>
        public DialogFlowConnection Create(DialogFlowConnectionCreateOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<DialogFlowConnection> CreateAsync(DialogFlowConnectionCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public DialogFlowConnection Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<DialogFlowConnection> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <inheritdoc/>
        public virtual DialogFlowConnection Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public virtual async Task<DialogFlowConnection> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual DialogFlowConnection Update(string id, DialogFlowConnectionCreateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public virtual async Task<DialogFlowConnection> UpdateAsync(string id, DialogFlowConnectionCreateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
