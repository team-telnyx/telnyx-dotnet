using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Notifications.NotificationSettings;

namespace Telnyx.net.Services.Notifications.NotificationSettings
{
    public class NotificationSettingService : Service<NotificationSetting>
    {
        public override string BasePath => "/notification_settings";
        public async Task<TelnyxList<NotificationSetting>> ListNotificationSettingsAsync(NotificationSettingListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<NotificationSetting> ListNotificationSettings(NotificationSettingListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<NotificationSetting> RetrieveNotificationSettingAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }
        public NotificationSetting RetrieveNotificationSetting(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
        public NotificationSetting NotificationSettingDelete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }
        public async Task<NotificationSetting> DeleteNotificationSettingAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }
        public async Task<NotificationSetting> CreateNotificationSettingAsync(NotificationSettingOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct);
        }
        public NotificationSetting CreateNotificationSetting(NotificationSettingOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }
    }
}