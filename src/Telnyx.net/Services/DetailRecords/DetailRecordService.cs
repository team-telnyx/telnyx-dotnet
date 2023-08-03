namespace Telnyx.net.Services.DetailRecords
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.DetailRecords;

    public class DetailRecordService : Service<DetailRecord>
    {
        public DetailRecordService()
           : base(null)
        {
        }

        public DetailRecordService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/detail_records";

        public async Task<TelnyxList<DetailRecord>> ListDocumentsAsync(DetailRecordOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<DetailRecord> ListDocuments(DetailRecordOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
