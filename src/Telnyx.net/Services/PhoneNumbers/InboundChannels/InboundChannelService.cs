

namespace Telnyx.net.Services.PhoneNumbers.InboundChannels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.PhoneNumbers.InboundChannels;

    /// <summary>
    /// Returns the inbound channels for your account. Inbound channels allows you to use Channel Billing for calls to your Telnyx phone numbers.
    /// Please check the Telnyx Support Articles section for full information and examples of how to utilize Channel Billing.
    /// </summary>
    public class InboundChannelService : Service<InboundChannel>
    {
        public InboundChannelService():base(null)
        {

        }
        public InboundChannelService(string apiKey) : base(apiKey)
        {

        }
        public override string BasePath => "phone_numbers/inbound_channels";

        public async Task<InboundChannel> GetInboundChannelAsync(RequestOptions reqOptions = null, CancellationToken cancelToken = default)
        {
            return await this.GetRequestAsync<InboundChannel>(BasePath, null, reqOptions, false, cancelToken);
        }
        public InboundChannel GetInboundChannel(RequestOptions reqOptions = null)
        {
            return this.GetRequest<InboundChannel>(BasePath, null, reqOptions, false);
        }
        public async Task<InboundChannel> UpdateInboundChannelAsync(InboundChannelUpdateOptions options, RequestOptions reqOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.PatchRequestAsync<InboundChannel>(BasePath, options, reqOptions, cancellationToken);
        }
        public InboundChannel UpdateInboundChannel(InboundChannelUpdateOptions options, RequestOptions reqOptions = null)
        {
            return this.PatchRequest<InboundChannel>(BasePath, options, reqOptions);
        }
    }
}
