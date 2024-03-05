using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.RoomSessions;

namespace Telnyx.net.Services.RoomSessions
{
    public class RoomSessionService : ServiceNested<TelnyxApiResponse>
    {
        public override string BasePath => "/room_sessions/:room_session_id/actions/end";

        public TelnyxApiResponse Create(string parentId, UpsertRoomSession options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertRoomSession options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
