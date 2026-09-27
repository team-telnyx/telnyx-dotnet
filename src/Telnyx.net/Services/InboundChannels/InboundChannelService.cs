namespace Telnyx.net.Services.InboundChannels
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.InboundChannels;

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

        public override string BasePath => "/inbound_channels";

        public InboundChannel Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetRequest<InboundChannel>(this.ClassUrl(), null, requestOptions, false, "data");
        }

        public async Task<InboundChannel> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<InboundChannel>(this.ClassUrl(), null, requestOptions, false, "data", cancellationToken);
        }

        public InboundChannel Update(string id, InboundChannelUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.PatchRequest<InboundChannel>(this.ClassUrl(), updateOptions, requestOptions, "data");
        }

        public async Task<InboundChannel> UpdateAsync(string id, InboundChannelUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.PatchRequestAsync<InboundChannel>(this.ClassUrl(), updateOptions, requestOptions, "data", cancellationToken);
        }
    }
}
