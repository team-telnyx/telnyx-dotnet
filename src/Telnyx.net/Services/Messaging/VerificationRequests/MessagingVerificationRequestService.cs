using System;
using System.Threading.Tasks;
using System.Threading;
using Telnyx.net.Entities.Messaging.VerificationRequests;
using Telnyx.net.Entities;

namespace Telnyx.net.Services.Messaging.VerificationRequests
{
    public class MessagingVerificationRequestService : Service<MessagingVerificationRequest>
    {
        public override string BasePath => "/messaging_tollfree/verification/requests";

        /// <inheritdoc/>
        public MessagingVerificationRequest Create(UpsertMessagingVerificationRequest createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingVerificationRequest> CreateAsync(UpsertMessagingVerificationRequest createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }


        /// <inheritdoc/>
        public MessagingVerificationRequest Update(string id, UpsertMessagingVerificationRequest updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<MessagingVerificationRequest> UpdateAsync(string id, UpsertMessagingVerificationRequest updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<MessagingVerificationRequest> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingVerificationRequest Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingVerificationRequest> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingVerificationRequest Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }


        /// <inheritdoc/>
        public TelnyxList<MessagingVerificationRequest> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingVerificationRequest>> ListAsync(ListOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }
    }
}
