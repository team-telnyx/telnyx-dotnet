namespace Telnyx.net.Services.Faxes.Applications
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Faxes.Applications;

    public class FaxApplicationService : Service<FaxApplication>
    {
        public FaxApplicationService()
            : base(null)
        {
        }

        public FaxApplicationService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/fax_applications";

        public TelnyxList<FaxApplication> ViewFaxApplications(FaxAppListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<FaxApplication>> ViewFaxApplicationsAsync(FaxAppListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        public FaxApplication CreateFaxApplication(FaxAppOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(sendOptions, requestOptions, parentToken: "data");
        }

        public async Task<FaxApplication> CreateFaxApplicationAsync(FaxAppOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(sendOptions, requestOptions, parentToken: "data", cancellationToken: ct).ConfigureAwait(false);
        }

        public FaxApplication UpdateFaxApplication(string id, FaxAppOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, sendOptions, requestOptions, parentToken: "data");
        }

        public async Task<FaxApplication> UpdateFaxApplicationAsync(string id, FaxAppOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, sendOptions, requestOptions, parentToken: "data", ct).ConfigureAwait(false);
        }

        public FaxApplication GetFaxApplication(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions, parentToken: "data");
        }

        public async Task<FaxApplication> GetFaxApplicationAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, parentToken: "data", ct).ConfigureAwait(false);
        }

        public FaxApplication DeleteFaxApplication(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions, parentToken: "data");
        }

        public async Task<FaxApplication> DeleteFaxApplicationAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, parentToken: "data", ct).ConfigureAwait(false);
        }
    }
}
