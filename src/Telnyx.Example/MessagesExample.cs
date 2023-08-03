using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.Example
{
    /// <summary>
    /// Messages example
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MessagesExample
    {
        private const string MessagingSenderId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingSenderIdService service = new MessagingSenderIdService();

        /// <summary>
        /// Send message
        /// </summary>
        public async Task SendMessage()
        {
            var sendMessageOptions = new NewMessagingSenderId
            {
                From = "+13115552368", // alphanumeric sender id
                To = "+13115552367",
                Text = "Hello, World!"
            };
            Console.WriteLine(JsonConvert.SerializeObject(sendMessageOptions));

            try
            {
                var messagingSender = await this.service.CreateAsync(sendMessageOptions);
                Console.WriteLine(JsonConvert.SerializeObject(messagingSender));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// Retrieve message
        /// </summary>
        public void RetrieveMessage()
        {
            Console.WriteLine(MessagingSenderId);
            try
            {
                var message = this.service.Get(MessagingSenderId);
                Console.WriteLine(JsonConvert.SerializeObject(message));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
