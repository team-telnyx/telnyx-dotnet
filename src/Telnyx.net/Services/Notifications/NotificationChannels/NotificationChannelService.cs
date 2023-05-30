using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Notifications.NotificationChannels;

namespace Telnyx.net.Services.Notifications.NotificationChannels
{
    public class NotificationChannelService : Service<NotificationChannel>
    {
        public override string BasePath => "/notification_channels";
        public async Task<TelnyxList<NotificationChannel>> ListNotificationChannelsAsync(NotificationChannelListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<NotificationChannel> ListNotificationChannels(NotificationChannelListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<NotificationChannel> RetrieveNotificationChannelAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }
        public NotificationChannel RetrieveNotificationChannel(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
        public NotificationChannel NotificationChannelDelete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }
        public async Task<NotificationChannel> DeleteNotificationChannelAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }
        public async Task<NotificationChannel> CreateNotificationChannelAsync(NotificationChannelOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct);
        }
        public NotificationChannel CreateNotificationChannel(NotificationChannelOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts);
        }
        public async Task<NotificationChannel> UpdateNotificationChannelAsync(string id, NotificationChannelOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, ct);
        }
        public NotificationChannel UpdateNotificationChannel(string id, NotificationChannelOptions options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts);
        }
    }
}