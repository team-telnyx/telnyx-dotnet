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

        private string recordPausePath => "/actions/record_pause";

        private string recordResumePath => "/actions/record_resume";

        private string recordStartPath => "/actions/record_start";

        private string recordStopPath => "/actions/record_stop";

        public TelnyxApiResponse Pause(string id, RecordActionOptions options, RequestOptions requestOptions)
        {
            return this.CreateEntity(id, recordPausePath, options, requestOptions);
        }

        public TelnyxApiResponse Resume(string id, RecordActionOptions options, RequestOptions requestOptions)
        {
            return this.CreateEntity(id, recordResumePath, options, requestOptions);
        }

        public TelnyxApiResponse Start(string id, RecordStartOptions options, RequestOptions requestOptions)
        {
            return this.CreateEntity(id, recordStartPath, options, requestOptions);
        }

        public TelnyxApiResponse Stop(string id, RecordActionOptions options, RequestOptions requestOptions)
        {
            return this.CreateEntity(id, recordStopPath, options, requestOptions);
        }
    }
}
