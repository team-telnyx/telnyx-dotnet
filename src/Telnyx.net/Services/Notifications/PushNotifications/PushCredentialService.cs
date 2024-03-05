namespace Telnyx.net.Services.Notifications.PushNotifications
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Notifications.PushNotifications;

    public class PushNotificationCredentialsService : Service<PushNotificationCredentials>
    {
        public override string BasePath => "/mobile_push_credentials";

        public async Task<TelnyxList<PushNotificationCredentials>> ListPushNotificationCredentialsAsync(PushNotificationCredentialOptions options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<PushNotificationCredentials> ListPushNotificationCredentials(PushNotificationCredentialOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<PushNotificationCredentials> RetrievePushNotificationCredentialAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public PushNotificationCredentials RetrievePushNotificationCredential(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public PushNotificationCredentials PushNotificationCredentialDelete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<PushNotificationCredentials> DeletePushNotificationCredentialAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<PushNotificationCredentials> CreateAndriodPushNotificationCredentialAsync(UpsertPushNotificationCredentialsAndroid options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public PushNotificationCredentials CreateAndriodPushNotificationCredential(UpsertPushNotificationCredentialsAndroid options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<PushNotificationCredentials> CreateIOSPushNotificationCredentialAsync(UpsertPushNotificationCredentialsIOS options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public PushNotificationCredentials CreateIOSPushNotificationCredential(UpsertPushNotificationCredentialsIOS options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
