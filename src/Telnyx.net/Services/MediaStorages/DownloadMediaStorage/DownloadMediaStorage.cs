namespace Telnyx.net.Services.MediaStorages.DownloadMediaStorage
{
    using System.Threading;
    using System.Threading.Tasks;

    public class DownloadMediaStorage : FileService
    {
        public override string BasePath => "/media";

        public override string PostPath => "download";

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
