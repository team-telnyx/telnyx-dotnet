namespace Telnyx.net.Services.NumberPortouts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberPortouts;

    public class NumberPortoutService : Service<PortoutDetails>
    {
        public NumberPortoutService()
           : base(null)
        {
        }

        public NumberPortoutService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/portouts";

        public async Task<TelnyxList<PortoutDetails>> ListPortoutRequestsAsync(ListPortoutRequestOptions listOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, reqOpts, string.Empty, ct);
        }

        public TelnyxList<PortoutDetails> ListPortoutRequests(ListPortoutRequestOptions listOptions, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOptions, reqOpts);
        }

        public async Task<PortoutDetails> RetrieveNumberPortoutsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public PortoutDetails RetrieveNumberPortouts(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, parentToken: "data");
        }
    }
}
