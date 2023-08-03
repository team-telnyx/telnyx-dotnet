namespace Telnyx.net.Services.Notifications.NotificationProfiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Notifications.NotificationProfiles;

    public class NotificationProfileService : Service<NotificationProfile>
    {
        public override string BasePath => "/notification_profiles";

        public async Task<TelnyxList<NotificationProfile>> ListNotificationProfilesAsync(RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(null, reqOpts, string.Empty, ct);
        }

        public TelnyxList<NotificationProfile> ListNotificationProfiles(RequestOptions reqOpts = null)
        {
            return this.ListEntities(null, reqOpts);
        }

        public async Task<NotificationProfile> RetrieveNotificationProfileAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, string.Empty, ct);
        }

        public NotificationProfile RetrieveNotificationProfile(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, string.Empty);
        }

        public NotificationProfile DeleteNotificationProfile(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        public async Task<NotificationProfile> DeleteNotificationProfileAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        public async Task<NotificationProfile> CreateNotificationProfileAsync(NotificationProfileOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, cancellationToken: ct);
        }

        public NotificationProfile CreateNotificationProfile(NotificationProfileOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }

        public async Task<NotificationProfile> UpdateNotificationProfileAsync(string id, NotificationProfileOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, string.Empty, ct);
        }

        public NotificationProfile UpdateNotificationProfile(string id, NotificationProfileOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, string.Empty);
        }
    }
}
