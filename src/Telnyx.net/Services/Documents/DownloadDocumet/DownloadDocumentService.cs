namespace Telnyx.net.Services.Documents.DownloadDocumet
{
    using System.Threading;
    using System.Threading.Tasks;

    class DownloadDocumentService : FileService
    {
        public DownloadDocumentService()
           : base(null)
        {
        }

        public DownloadDocumentService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/documents";

        public override string PostPath => "/download";

        public async Task<byte[]> GetFileAsync(string id, RequestOptions options, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, ct, postPath: this.PostPath);
        }

        public byte[] GetFile(string id, RequestOptions options, RequestOptions requestOptions)
        {
            return this.GetEntity(id, null, requestOptions, postPath: this.PostPath);
        }
    }
}
