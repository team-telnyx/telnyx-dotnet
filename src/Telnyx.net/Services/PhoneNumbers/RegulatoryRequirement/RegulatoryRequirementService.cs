namespace Telnyx.net.Services.PhoneNumbers.RegulatoryRequirements
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Searches;
    using Telnyx.net.Services.PhoneNumbers.RegulatoryRequirement;

    public class RegulatoryRequirementService : Service<RegulatoryRequirement>
    {
        public override string BasePath => "/regulatory_requirements";

        public RegulatoryRequirementService()
            : base(null)
        {
        }

        public RegulatoryRequirementService(string apiKey)
            : base(apiKey)
        {
        }

        public async Task<TelnyxList<RegulatoryRequirement>> GetRegulatoryRequirementsAsync(RegulatoryRequirementListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<RegulatoryRequirement> GetRegulatoryRequirements(RegulatoryRequirementListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<RegulatoryRequirement> GetRegulatoryRequirementByIdAsync(string id, RegulatoryRequirementListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", ct);
        }

        public RegulatoryRequirement GetRegulatoryRequirementById(string id, RegulatoryRequirementListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
