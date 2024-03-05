using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.ShortCode;

namespace Telnyx.net.Services.ShortCode
{
    public class ShortCodeService : Service<ShortCodes>
    {
        public override string BasePath => "/short_codes";

        public async Task<TelnyxList<ShortCodes>> ListShortCodesAsync(ShortCodeOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<ShortCodes> ListShortCodes(ShortCodeOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<ShortCodes> GetShortCodesAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public ShortCodes GetShortCodes(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
        public async Task<ShortCodes> UpdateShortCodesAsync(string id, UpsertShortCode options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public ShortCodes UpdateShortCodes(string id, UpsertShortCode options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
