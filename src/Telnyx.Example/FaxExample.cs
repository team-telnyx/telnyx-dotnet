using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Faxes;
using Telnyx.net.Infrastructure.Public;
using Telnyx.net.Services.Faxes;

namespace Telnyx.Example
{
    [ExcludeFromCodeCoverage]
    public class FaxExample
    {
        private readonly FaxService _faxService;
        public FaxExample()
        {
            _faxService = new FaxService();
        }

        public async Task<Fax> SendFaxAsync()
        {
            FaxSendOptions sendOptions = new FaxSendOptions
            {
                ConnectionId = "1123344",
                From = "3125555555",
                To = "7735555555",
                MediaUrl = "http://imgur.com/randomimage.png",
                Quality = "high"

            };
            return await _faxService.SendFaxAsync(sendOptions);
        }

        public TelnyxWebhook<object> ReceiveWebhook()
        {
            var payload = "{\r\n  \"event_type\": \"fax.delivered\",\r\n  \"id\": \"0ccc7b54-4df3-4bca-a65a-3da1ecc777f0\",\r\n  \"payload\": {\r\n    \"connection_id\": \"234423\",\r\n    \"from\": \"+13125790015\",\r\n    \"id\": \"0ccc7b54-4df3-4bca-a65a-3da1ecc777f0\",\r\n    \"original_media_url\": \"https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf\",\r\n    \"status\": \"delivered\",\r\n    \"to\": \"+13127367276\",\r\n    \"user_id\": \"yfff7c54-4df3-4bca-a65a-3da1ecc777f0\"\r\n  },\r\n  \"record_type\": \"event\"\r\n}";
            var publicKey = "YOUR_PUBLIC_KEY";
            var telnyxSignature = "hk0AvSYv+xze5WKnEwNoE2zisVK6R3whPKkso8drRZhYjkpgXd9MkSnjsJGhQ+sEUqaMF5fQdaHSZnz/ET3pDA==";
            /*From request object example: Request.Headers["telnyx-timestamp"]; */
            var telnyxTimeStamp = 1601667324.ToString();
            var @event = Webhook.ConstructEvent(payload, telnyxSignature, telnyxTimeStamp, publicKey);

            return @event;
        }
    }
}
