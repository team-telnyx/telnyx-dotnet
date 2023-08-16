namespace Telnyx.net.Services.Calls.CallControlApplications
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Calls.CallControlApplications;

    public class CallControlApplicationService : Service<CallControlApplication>,
        IListable<CallControlApplication, ListCallControlApplicationOptions>,
        IRetrievable<CallControlApplication>,
        IDeletable<CallControlApplication>,
        ICreatable<CallControlApplication, CreateCallControlApplicationOptions>,
        IUpdatable<CallControlApplication, CreateCallControlApplicationOptions>
    {
        public override string BasePath => "/call_control_applications";

        public CallControlApplication Create(CreateCallControlApplicationOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        public Task<CallControlApplication> CreateAsync(CreateCallControlApplicationOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        public CallControlApplication Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        public async Task<CallControlApplication> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        public CallControlApplication Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, string.Empty);
        }

        public async Task<CallControlApplication> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        public TelnyxList<CallControlApplication> List(ListCallControlApplicationOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<CallControlApplication>> ListAsync(ListCallControlApplicationOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }

        public CallControlApplication Update(string id, CreateCallControlApplicationOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, "data");
        }

        public async Task<CallControlApplication> UpdateAsync(string id, CreateCallControlApplicationOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
