namespace Telnyx
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>
    /// Messages example.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MessagesExample
    {
        private const string YOURAPIKEY = "YOUR_API_KEY";
        private const string MessagingSenderId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingSenderIdService service = new MessagingSenderIdService();

        /// <summary>
        /// Send message.
        /// </summary>
        public void SendMessage()
        {
            var sendMessageOptions = new NewMessagingSenderId
            {
                From = "+18665552368", // alphanumeric sender id
                To = "+18665552367",
                Text = "Hello, World!"
            };
            Console.WriteLine(JsonConvert.SerializeObject(sendMessageOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingSender = this.service.Create(sendMessageOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingSender));
        }

        /// <summary>
        /// Retrieve message.
        /// </summary>
        public void RetrieveMessage()
        {
            Console.WriteLine(MessagingSenderId);

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var message = this.service.Get(MessagingSenderId, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(message));
        }
    }
}
