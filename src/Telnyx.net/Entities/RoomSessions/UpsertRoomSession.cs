using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.RoomSessions
{
    public class UpsertRoomSession : BaseOptions
    {
        [JsonProperty("room_session_id")]
        public Guid RoomSessionId { get; set; }
    }
}
