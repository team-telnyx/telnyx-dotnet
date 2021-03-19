using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;

namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceSpeak
{
    public class ConferenceSpeakService : Service<TelnyxApiResponse>
    {
        public ConferenceSpeakService()
            : base(null)
        {
        }

        public ConferenceSpeakService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/actions/speak";

        public TelnyxApiResponse Speak(string id, ConferenceSpeakOptions speakOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, speakOptions, requestOptions);
        }

        public async Task<TelnyxApiResponse> SpeakAsync(string id, ConferenceSpeakOptions speakOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, speakOptions, requestOptions, ct);
        }
    }
}
