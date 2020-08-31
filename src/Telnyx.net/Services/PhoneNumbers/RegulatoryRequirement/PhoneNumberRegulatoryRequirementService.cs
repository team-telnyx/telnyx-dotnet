using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.Searches;

namespace Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement
{
    public class PhoneNumberRegulatoryRequirementService : Service<RegulatoryRequirementPerPhone>
    {
        public override string BasePath => "/phone_number_regulatory_requirements";
        public PhoneNumberRegulatoryRequirementService():base(null)
        {

        }
        public PhoneNumberRegulatoryRequirementService(string apiKey) : base(apiKey)
        {

        }
        public async Task<TelnyxList<RegulatoryRequirementPerPhone>> GetRequirementsPerPhoneAsync(PhoneNumberRegulatoryRequirementListOptions listOpts, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOpts, reqOpts, ct);
        }
        public TelnyxList<RegulatoryRequirementPerPhone> GetRequirementsPerPhone(PhoneNumberRegulatoryRequirementListOptions listOpts, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(listOpts, reqOpts);
        }
    }
}
