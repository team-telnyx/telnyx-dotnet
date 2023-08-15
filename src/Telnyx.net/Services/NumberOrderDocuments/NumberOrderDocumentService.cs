namespace Telnyx.net.Services.NumberOrderDocuments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberOrderDocuments;

    public class NumberOrderDocumentService : Service<NumberOrderDocument>
    {
        public NumberOrderDocumentService()
            : base(null)
        {
        }

        public NumberOrderDocumentService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/number_order_documents";

        public async Task<TelnyxList<NumberOrderDocument>> ListNumberOrderDocumentsAsync(NumberOrderDocumentListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<NumberOrderDocument> ListNumberOrderDocuments(NumberOrderDocumentListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public NumberOrderDocument GetNumberOrderDocument(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<NumberOrderDocument> GetNumberOrderDocumentAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, requestOptions, string.Empty, cancellationToken);
        }

        public NumberOrderDocument CreateNumberOrderDocument(NumberOrderDocumentCreateOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(sendOptions, requestOptions);
        }

        public async Task<NumberOrderDocument> CreateNumberOrderDocumentAsync(NumberOrderDocumentCreateOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(sendOptions, requestOptions, cancellationToken: ct).ConfigureAwait(false);
        }

        public NumberOrderDocument UpdateNumberOrderDocument(string id, NumberOrderDocumentUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, string.Empty);
        }

        public async Task<NumberOrderDocument> UpdateNumberOrderDocumentAsync(string id, NumberOrderDocumentUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
