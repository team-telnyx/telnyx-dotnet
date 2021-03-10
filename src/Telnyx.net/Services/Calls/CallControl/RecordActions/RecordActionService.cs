using Telnyx.net.Entities;

namespace Telnyx.net.Services.Calls.CallControl.RecordActions
{
    internal class RecordActionService : Service<TelnyxApiResponse>
    {
        public RecordActionService()
            : base(null)
        {

        }

        public RecordActionService(string apiKey)
            : base(apiKey)
        {

        }

        public override string BasePath => "/calls";

        public TelnyxApiResponse Pause(string id, RecordActionOptions options, RequestOptions requestOptions)
        {
            return this.CreateEntity(id, "/actions/record_pause", options, requestOptions);
        }

        public TelnyxApiResponse Resume(string id, RecordActionOptions options, RequestOptions requestOptions)
        {
            return this.CreateEntity(id, "/actions/record_resume", options, requestOptions);
        }
    }
}
