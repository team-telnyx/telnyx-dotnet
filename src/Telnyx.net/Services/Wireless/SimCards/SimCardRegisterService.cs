namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardRegisterService
    /// </summary>
    internal class SimCardRegisterService : Service<TelnyxCollection<SimCardRecord>>,
        ICreatable<TelnyxCollection<SimCardRecord>, SimCardRegisterOptions>
    {

        public override string BasePath => "/actions/register/sim_cards";

        public TelnyxCollection<SimCardRecord> Create(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        public Task<TelnyxCollection<SimCardRecord>> CreateAsync(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }
    }
}
