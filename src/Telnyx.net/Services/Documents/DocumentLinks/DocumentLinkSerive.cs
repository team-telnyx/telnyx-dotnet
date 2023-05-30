using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Documents;

namespace Telnyx.net.Services.Documents.DocumentLinks
{
    public class DocumentLinkSerive : Service<DocumentLink>
    {
        public DocumentLinkSerive()
           : base(null) { }

        public DocumentLinkSerive(string apiKey)
            : base(apiKey) { }
        public override string BasePath => "/document_links";

        public async Task<TelnyxList<DocumentLink>> ListDocumentsAsync(DocumentLinkOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }

        public TelnyxList<DocumentLink> ListDocuments(DocumentLinkOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}