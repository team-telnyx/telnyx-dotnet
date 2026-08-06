using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telnyx.net.Entities.Enum.DetailRecords;

namespace Telnyx.Example
{
    /// <summary>
    /// Example demonstrating the use of Type and AutoDetect parameters in messages
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MessageTypeExample
    {
        private readonly MessageService service = new MessageService();

        /// <summary>
        /// Send SMS message with explicit type and auto-detect
        /// </summary>
        public async Task SendSmsWithTypeAndAutoDetect()
        {
            var sendMessageOptions = new NewMessage
            {
                From = "+13115552368",
                To = "+13115552367",
                Text = "Hello, World! This is a test message demonstrating the use of the Type and AutoDetect parameters.",
                Type = MessageType.SMS,
                AutoDetect = true
            };
            Console.WriteLine("Sending SMS with Type and AutoDetect:");
            Console.WriteLine(JsonConvert.SerializeObject(sendMessageOptions));

            try
            {
                var message = await this.service.CreateAsync(sendMessageOptions);
                Console.WriteLine("Response:");
                Console.WriteLine(JsonConvert.SerializeObject(message));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// Send MMS message with explicit type
        /// </summary>
        public async Task SendMmsWithType()
        {
            var sendMessageOptions = new NewMessage
            {
                From = "+13115552368",
                To = "+13115552367",
                Text = "Hello, World! This is an MMS message.",
                MediaUrls = new System.Collections.Generic.List<string>
                {
                    "https://example.com/image.jpg"
                },
                Type = MessageType.MMS
            };
            Console.WriteLine("Sending MMS with Type parameter:");
            Console.WriteLine(JsonConvert.SerializeObject(sendMessageOptions));

            try
            {
                var message = await this.service.CreateAsync(sendMessageOptions);
                Console.WriteLine("Response:");
                Console.WriteLine(JsonConvert.SerializeObject(message));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}