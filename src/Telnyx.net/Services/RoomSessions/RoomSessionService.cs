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
        public override string BasePath => "/room_sessions/{PARENT_ID}/actions/end";

        public TelnyxApiResponse Create(string parentId, UpsertRoomSession options, RequestOptions requestOptions)
        {
            // The end action identifies the session in the path and accepts no request body.
            return this.CreateNestedEntity(parentId, null, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertRoomSession options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, null, requestOptions, parentToken, cancellationToken);
        }
    }
}
