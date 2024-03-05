using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.PhoneNumberCsvDownloads;

namespace Telnyx.net.Services.PhoneNumbers.PhoneNumberCsvDownloadService
{
    public class PhoneNumberCsvDownloadService : Service<PhoneNumberCsvDownload>
    {
        public override string BasePath => "/phone_numbers/csv_downloads";

        public async Task<TelnyxList<PhoneNumberCsvDownload>> ListPhoneNumberCsvDownloadAsync(PhoneNumberCsvDownloadOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<PhoneNumberCsvDownload> ListPhoneNumberCsvDownload(PhoneNumberCsvDownloadOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<PhoneNumberCsvDownload> GetPhoneNumberCsvDownloadAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public PhoneNumberCsvDownload GetPhoneNumberCsvDownload(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public async Task<PhoneNumberCsvDownload> CreatePhoneNumberCsvDownloadAsync(UpsertPhoneNumberCsvDownload options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public PhoneNumberCsvDownload CreatePhoneNumberCsvDownload(UpsertPhoneNumberCsvDownload options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

    }
}
