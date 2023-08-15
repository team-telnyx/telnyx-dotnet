namespace Telnyx.net.Services.Notifications.NotificationSettings
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Notifications.NotificationSettings;

    public class NotificationSettingService : Service<NotificationSetting>
    {
        public override string BasePath => "/notification_settings";

        public async Task<TelnyxList<NotificationSetting>> ListNotificationSettingsAsync(NotificationSettingListOptions options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<NotificationSetting> ListNotificationSettings(NotificationSettingListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<NotificationSetting> RetrieveNotificationSettingAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public NotificationSetting RetrieveNotificationSetting(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public NotificationSetting NotificationSettingDelete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<NotificationSetting> DeleteNotificationSettingAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<NotificationSetting> CreateNotificationSettingAsync(NotificationSettingOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public NotificationSetting CreateNotificationSetting(NotificationSettingOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}