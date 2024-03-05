using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.VerifiedNumbers;

namespace Telnyx.net.Services.PhoneNumbers.VerifiedNumbers
{
    public class VerifiedNumberActionService : ServiceNested<VerifiedNumber>
    {

        public override string BasePath => "/verified_numbers/:phone_number/actions/verify";

        public VerifiedNumber Create(string parentId, UpsertVerifiedNumber options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<VerifiedNumber> CreateAsync(string parentId, UpsertVerifiedNumber options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
