namespace Telnyx.net.Services.Notifications.NotificationsEventsConditions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Notifications.NotificationsEventsConditions;

    public class NotificationsEventsConditionService : Service<NotificationsEventsCondition>
    {
        public override string BasePath => "/notification_event_conditions";

        public async Task<TelnyxList<NotificationsEventsCondition>> ListNotificationsEventsConditionsAsync(NotificationsEventsConditionListOptions options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<NotificationsEventsCondition> ListNotificationsEventsConditions(NotificationsEventsConditionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
