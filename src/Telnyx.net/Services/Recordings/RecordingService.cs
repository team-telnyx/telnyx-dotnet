using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Recordings;

namespace Telnyx.net.Services.Recordings
{
    public class RecordingService : Service<Recording>
    {
        public override string BasePath => "/recordings/:id";

        public async Task<Recording> GetRecordingAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public Recording GetRecording(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, parentToken: "data");
        }

        public Recording DeleteRecording(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<Recording> DeleteRecordingAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
