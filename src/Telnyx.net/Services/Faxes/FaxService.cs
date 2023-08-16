namespace Telnyx.net.Services.Faxes
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Faxes;

    public class FaxService : Service<Fax>
    {
        public FaxService()
            : base(null)
        {
        }

        public FaxService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/faxes";

        public TelnyxList<Fax> ViewFaxes(FaxListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<Fax>> ViewFaxesAsync(FaxListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        public Fax SendFax(FaxSendOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(sendOptions, requestOptions);
        }

        public async Task<Fax> SendFaxAsync(FaxSendOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(sendOptions, requestOptions, cancellationToken: ct).ConfigureAwait(false);
        }

        public Fax GetFax(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<Fax> GetFaxAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        public Fax DeleteFax(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

        public async Task<Fax> DeleteFaxAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }
    }
}
