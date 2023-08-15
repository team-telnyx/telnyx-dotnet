namespace Telnyx.net.Services.Documents
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Documents;

    public class DocumentService : Service<Document>
    {
        public DocumentService()
              : base(null)
        {
        }

        public DocumentService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/documents";

        public async Task<TelnyxList<Document>> ListDocumentsAsync(DocumentListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<Document> ListDocuments(DocumentListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public Document SendDocument(DocumentCreateOptions sendOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(sendOptions, requestOptions, parentToken: "data");
        }

        public async Task<Document> SendDocumentAsync(DocumentCreateOptions sendOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(sendOptions, requestOptions, parentToken: "data", cancellationToken: ct).ConfigureAwait(false);
        }

        public async Task<Document> RetrieveDocumentAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", ct);
        }

        public Document RetrieveDocument(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public Document DeleteDocument(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions, parentToken: "data");
        }

        public async Task<Document> DeleteDocumentAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, parentToken: "data", ct).ConfigureAwait(false);
        }
    }
}
