namespace Telnyx.net.Services.PhoneNumbers.InboundChannels
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.PhoneNumbers.InboundChannels;

    /// <summary>
    /// Returns the inbound channels for your account. Inbound channels allows you to use Channel Billing for calls to your Telnyx phone numbers.
    /// Please check the Telnyx Support Articles section for full information and examples of how to utilize Channel Billing.
    /// </summary>
    public class InboundChannelService : Service<InboundChannel>,
        IRetrievable<InboundChannel>,
        IUpdatable<InboundChannel, InboundChannelUpdateOptions>
    {
        public InboundChannelService()
            : base(null)
        {
        }

        public InboundChannelService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/phone_numbers";

        public InboundChannel Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity("inbound_channels", null, requestOptions, parentToken: "data");
        }

        public async Task<InboundChannel> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync("inbound_channels", null, requestOptions, parentToken: "data", cancellationToken);
        }

        public InboundChannel Update(string id, InboundChannelUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity("inbound_channels", updateOptions, requestOptions, parentToken: "data");
        }

        public async Task<InboundChannel> UpdateAsync(string id, InboundChannelUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync("inbound_channels", updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
