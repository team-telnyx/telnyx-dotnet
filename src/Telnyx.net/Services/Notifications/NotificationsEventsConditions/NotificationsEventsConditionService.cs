using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Notifications.NotificationsEventsConditions;

namespace Telnyx.net.Services.Notifications.NotificationsEventsConditions
{
    public class NotificationsEventsConditionService : Service<NotificationsEventsCondition>
    {
        public override string BasePath => "/notification_event_conditions";

        public async Task<TelnyxList<NotificationsEventsCondition>> ListNotificationsEventsConditionsAsync(NotificationsEventsConditionListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }

        public TelnyxList<NotificationsEventsCondition> ListNotificationsEventsConditions(NotificationsEventsConditionListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
