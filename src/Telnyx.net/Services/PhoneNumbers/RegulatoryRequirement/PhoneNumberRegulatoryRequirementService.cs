namespace Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Searches;

    public class PhoneNumberRegulatoryRequirementService : Service<RegulatoryRequirementPerPhone>
    {
        public override string BasePath => "/phone_numbers_regulatory_requirements";

        public PhoneNumberRegulatoryRequirementService()
            : base(null)
        {
        }

        public PhoneNumberRegulatoryRequirementService(string apiKey)
            : base(apiKey)
        {
        }

        public async Task<TelnyxList<RegulatoryRequirementPerPhone>> GetRequirementsPerPhoneAsync(PhoneNumberRegulatoryRequirementListOptions listOpts, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOpts, reqOpts, string.Empty, ct);
        }

        public TelnyxList<RegulatoryRequirementPerPhone> GetRequirementsPerPhone(PhoneNumberRegulatoryRequirementListOptions listOpts, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(listOpts, reqOpts);
        }
    }
}
