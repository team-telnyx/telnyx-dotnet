namespace Telnyx.net.Services.Calls.CallControl.ClientState
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Calls.CallControl.ClientState;

    public class ClientStateService : Service<TelnyxApiResponse>
    {
        public ClientStateService()
           : base(null)
        {
        }

        public ClientStateService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/calls";

        public override string PostPath => "actions/client_state_update";

        public TelnyxApiResponse Upgrade(string id, ClientStateOption updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpgradeEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        public async Task<TelnyxApiResponse> UpgradeAsync(string id, ClientStateOption updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpgradeEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }
    }
}
