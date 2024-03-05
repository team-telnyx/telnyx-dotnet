namespace Telnyx.net.Services.Connections.IPs.Global
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Connections.IPs.Global;

    /// <summary>
    /// GlobalIpAssignmentService.
    /// </summary>
    public class GlobalIpAssignmentService : Service<GlobalIpAssignmentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalIpAssignmentService"/> class.
        /// </summary>
        public GlobalIpAssignmentService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalIpAssignmentService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public GlobalIpAssignmentService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/global_ip_assignments";

        /// <inheritdoc/>
        public GlobalIpAssignmentResponse Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<GlobalIpAssignmentResponse> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <inheritdoc/>
        public virtual GlobalIpAssignmentResponse Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public virtual async Task<GlobalIpAssignmentResponse> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual GlobalIpAssignmentResponse Update(string id, UpsertGlobalIpAssignment updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public virtual async Task<GlobalIpAssignmentResponse> UpdateAsync(string id, UpsertGlobalIpAssignment updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<TelnyxList<GlobalIpAssignmentResponse>> ListIPsAsync(ListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<GlobalIpAssignmentResponse> ListIPs(ListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
