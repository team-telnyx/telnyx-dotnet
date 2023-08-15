namespace Telnyx.net.Services.Messaging.Messaging_URL_Domains
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Messaging.Messaging_URL_Domains;

    public class MessagingURLDomainService : Service<MessagingURLDomain>
    {
        public MessagingURLDomainService()
           : base(null)
        {
        }

        public MessagingURLDomainService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/messaging/url_domains";

        public TelnyxList<MessagingURLDomain> List(RequestOptions requestOptions = null)
        {
            return this.ListEntities(null, requestOptions);
        }

        public async Task<TelnyxList<MessagingURLDomain>> ListAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(null, requestOptions, string.Empty, cancellationToken);
        }
    }
}
