using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.VerifiedNumbers;

namespace Telnyx.net.Services.PhoneNumbers.VerifiedNumbers
{
    public class VerifiedNumberService : Service<VerifiedNumber>
    {
        public override string BasePath => "/verified_numbers";

        public async Task<VerifiedNumber> GetVerifiedNumberAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public VerifiedNumber GetVerifiedNumber(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public VerifiedNumber DeleteVerifiedNumber(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<VerifiedNumber> DeleteVerifiedNumberAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
