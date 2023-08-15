namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardRegisterService.
    /// </summary>
    internal class SimCardRegisterService : Service<SimCardRecord>,
        ICreatable<TelnyxList<SimCardRecord>, SimCardRegisterOptions>
    {

        public override string BasePath => "/actions/register/sim_cards";

        public TelnyxList<SimCardRecord> Create(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateListEntity(createOptions, requestOptions, null, string.Empty);
        }

        public async Task<TelnyxList<SimCardRecord>> CreateAsync(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateListEntityAsync(createOptions, requestOptions, cancellationToken: cancellationToken);
        }
    }
}
