namespace Telnyx.net.Services.CustomStorageService
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.CustomStorageCredentials;

    /// <summary>
    /// CustomStorageCredentialService.
    /// </summary>
    public class CustomStorageCredentialService : Service<CustomStorageCredential>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomStorageCredentialService"/> class.
        /// </summary>
        public CustomStorageCredentialService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomStorageCredentialService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CustomStorageCredentialService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/custom_storage_credentials";

        /// <inheritdoc/>
        public CustomStorageCredential Create(CustomStorageCredentialCreateOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<CustomStorageCredential> CreateAsync(CustomStorageCredentialCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public CustomStorageCredential Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<CustomStorageCredential> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <inheritdoc/>
        public virtual CustomStorageCredential Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public virtual async Task<CustomStorageCredential> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual CustomStorageCredential Update(string id, CustomStorageCredentialCreateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public virtual async Task<CustomStorageCredential> UpdateAsync(string id, CustomStorageCredentialCreateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
