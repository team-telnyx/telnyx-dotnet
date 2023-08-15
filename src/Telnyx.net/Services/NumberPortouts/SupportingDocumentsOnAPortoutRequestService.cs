namespace Telnyx.net.Services.NumberPortouts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberPortouts;

    public class SupportingDocumentsOnAPortoutRequestService : Service<PortOutSupportingDocument>
    {
        public SupportingDocumentsOnAPortoutRequestService()
           : base(null)
        {
        }

        public SupportingDocumentsOnAPortoutRequestService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/portouts";

        public override string PostPath => "/supporting_documents";

        public TelnyxList<PortOutSupportingDocument> ListSupportingDocumentsOnAPortoutRequest(string id, RequestOptions reqOpts = null)
        {
            return this.ListEntities(this.PostPath, null, reqOpts, id: id);
        }

        public async Task<TelnyxList<PortOutSupportingDocument>> ListSupportingDocumentsOnAPortoutRequestAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(this.PostPath, null, reqOpts, string.Empty, id, ct);
        }

        public virtual TelnyxList<PortOutSupportingDocument> CreateAListOfSupportingDocumentsOnAPortoutRequest(string id, CreateAListOfSupportingDocumentsOnAPortoutRequestOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateListEntity(id, options, requestOptions, this.PostPath, true);
        }

        public async Task<TelnyxList<PortOutSupportingDocument>> CreateAListOfSupportingDocumentsOnAPortoutRequestAsync(string id, CreateAListOfSupportingDocumentsOnAPortoutRequestOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateListEntityAsync(id, createOptions, requestOptions, this.PostPath, true, cancellationToken: cancellationToken);
        }

        public virtual PortOutSupportingDocument UpdateAListOfSupportingDocumentsOnAPortoutRequest(string id, string status, UpdateAListOfSupportingDocumentsOnAPortoutRequestOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, options, requestOptions, status, parentToken: "data");
        }

        public async Task<PortOutSupportingDocument> UpdateAListOfSupportingDocumentsOnAPortoutRequestAsync(string id, string status, UpdateAListOfSupportingDocumentsOnAPortoutRequestOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, status, parentToken: "data", cancellationToken);
        }
    }
}
