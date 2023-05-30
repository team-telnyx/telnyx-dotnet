using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.MediaStorages;

namespace Telnyx.net.Services.MediaStorages
{
    public class MediaStorageService : Service<MediaStorage>
    {
        public MediaStorageService()
           : base(null) { }

        public MediaStorageService(string apiKey)
            : base(apiKey) { }
        public override string BasePath => "managed_accounts";
        public async Task<TelnyxList<MediaStorage>> ListMediaStoragesAsync(MediaStorageListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<MediaStorage> ListMediaStorages(MediaStorageListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<MediaStorage> RetrieveMediaStorageAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }
        public MediaStorage RetrieveMediaStorage(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
        public async Task<MediaStorage> DeleteCredentialConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, ct);
        }
        public MediaStorage DeleteCredentialConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
        public MediaStorage CreateMediaStorage(CreateMediaStorageOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }
        public Task<MediaStorage> CreateMediaStorageAsync(CreateMediaStorageOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }
        public async Task<MediaStorage> UpdateAsync(string id, UpdateMediaStorageOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.UpgradeEntityAsync(id, updateOptions, reqOps, ct);
        }
        public MediaStorage Update(string id, UpdateMediaStorageOptions updateOptions, RequestOptions reqOps = null)
        {
            return this.UpgradeEntity(id, updateOptions, reqOps);
        }
    }
}