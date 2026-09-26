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
            ValidateSessionId(parentId);
            return this.CreateNestedEntity(parentId, null, requestOptions);
        }

        public async Task<TelnyxApiResponse> CreateAsync(string parentId, UpsertRoomSession options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            ValidateSessionId(parentId);
            return await this.CreateNestedEntityAsync(parentId, null, requestOptions, parentToken, cancellationToken);
        }

        private static void ValidateSessionId(string parentId)
        {
            Guid sessionId;
            // The documented path parameter is a UUID, never a URL fragment.
            if (parentId == null || parentId.Length != 36 || !Guid.TryParseExact(parentId, "D", out sessionId))
            {
                throw new ArgumentException("A hyphenated room-session UUID is required.", nameof(parentId));
            }
        }
    }
}
