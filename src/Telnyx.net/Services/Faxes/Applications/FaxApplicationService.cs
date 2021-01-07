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
            return await this.ListEntitiesAsync(listOptions, requestOptions, ct).ConfigureAwait(false);
        }

        public FaxApplication CreateFaxApplications(FaxApplicationOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(sendOptions, requestOptions);
        }

        public async Task<FaxApplication> CreateFaxApplicationsAsync(FaxApplicationOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(sendOptions, requestOptions, ct).ConfigureAwait(false);
        }

        public FaxApplication UpdateFaxApplications(string id, FaxApplicationOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, sendOptions, requestOptions);
        }

        public async Task<FaxApplication> UpdateFaxApplicationsAsync(string id, FaxApplicationOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, sendOptions, requestOptions, ct).ConfigureAwait(false);
        }

        public FaxApplication GetFaxApplication(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<FaxApplication> GetFaxApplicationAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, ct).ConfigureAwait(false);
        }

        public FaxApplication DeleteFax(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

        public async Task<FaxApplication> DeleteFaxAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, ct).ConfigureAwait(false);
        }
    }
}
