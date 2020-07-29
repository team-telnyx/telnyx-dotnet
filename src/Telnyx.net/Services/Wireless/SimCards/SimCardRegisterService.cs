namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardRegisterService
    /// </summary>
    public class SimCardRegisterService : Service<SimCardRecordList>,
        ICreatable<SimCardRecordList, SimCardRegisterOptions>
    {

        public override string BasePath => "/actions/register/sim_cards";

        public SimCardRecordList Create(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        public Task<SimCardRecordList> CreateAsync(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }
    }
}
