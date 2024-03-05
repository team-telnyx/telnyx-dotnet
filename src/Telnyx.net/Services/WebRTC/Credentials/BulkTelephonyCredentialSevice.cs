using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.BulkTelephonyCredentials;

namespace Telnyx.net.Services.PhoneNumbers.BulkTelephonyCredentials
{
    public class BulkTelephonyCredentialSevice : Service<BulkTelephonyCredential>
    {
        public override string BasePath => "/actions/bulk/telephony_credentials";


        public async Task<BulkTelephonyCredential> CreateUpsertBulkTelephonyCredentialAsync(UpsertBulkTelephonyCredential options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public BulkTelephonyCredential CreateUpsertBulkTelephonyCredential(UpsertBulkTelephonyCredential options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public BulkTelephonyCredential DeleteBulkTelephonyCredential(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<BulkTelephonyCredential> DeleteBulkTelephonyCredentialAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<BulkTelephonyCredential> UpdateBulkTelephonyCredentialAsync(string id, UpsertBulkTelephonyCredential options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public BulkTelephonyCredential UpdateBulkTelephonyCredential(string id, UpsertBulkTelephonyCredential options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
