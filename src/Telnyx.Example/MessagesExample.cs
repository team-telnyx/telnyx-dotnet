namespace Telnyx.Example
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Messages example
    /// </summary>
    public class MessagesExample
    {
        private const string MessagingSenderId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingSenderIdService service = new MessagingSenderIdService();

        /// <summary>
        /// Send message
        /// </summary>
        public void SendMessage()
        {
            var sendMessageOptions = new NewMessagingSenderId
            {
                From = "+12172031655", // alphanumeric sender id
                To = "+17144968310",
                Text = "Hello, World!"
            };
            Console.WriteLine(JsonConvert.SerializeObject(sendMessageOptions));
                
            try
            {
                var messagingSender = this.service.Create(sendMessageOptions);
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
