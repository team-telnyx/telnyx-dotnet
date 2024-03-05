using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.NumberOrderDocuments;

namespace Telnyx.net.Services.PhoneNumbers.Orders.OrderDocuments
{
    public class NumberOrderDocumentService : Service<NumberOrderDocument>
    {
        public override string BasePath => "/number_order_documents";

        public async Task<NumberOrderDocument> GetNumberOrderDocumentAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public NumberOrderDocument GetNumberOrderDocument(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

    }
}
