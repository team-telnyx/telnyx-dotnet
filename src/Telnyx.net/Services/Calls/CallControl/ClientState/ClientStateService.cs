using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Calls.CallControl.ClientState;
using Telnyx.net.Entities;
namespace Telnyx.net.Services.Calls.CallControl.ClientState
{
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

        public TelnyxApiResponse UpdateEntity(string id, ClientStateOption updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions);
        }

        public async Task<TelnyxApiResponse> UpdateEntityAsync(string id, ClientStateOption updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, cancellationToken);
        }
    }
}
