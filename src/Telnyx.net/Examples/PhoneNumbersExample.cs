namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Phone Numbers Example.
    /// </summary>
    public class PhoneNumbersExample
    {
        private const string YOURAPIKEY = "YOUR_API_KEY";
        private readonly MessagingPhoneNumbersService service = new MessagingPhoneNumbersService();

        /// <summary>
        /// Get phone number.
        /// </summary>
        public void GetPhoneNumber()
        {
            var id = "+18665550001";
            Console.WriteLine(id);

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingList = this.service.Get(id);
            Console.WriteLine(JsonConvert.SerializeObject(messagingList));
        }

        /// <summary>
        /// List phone number.
        /// </summary>
        public void ListNumberOrder()
        {
            var listOptions = new MessagingPhoneNumerListOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingList = this.service.List(listOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingList));
        }

        /// <summary>
        /// Update phone number.
        /// </summary>
        public void UpdatePhoneNumber()
        {
            var id = "+18665550001";
            var guid = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            var updateOptions = new MessagingPhoneNumberUpdate
            {
                MessagingProfileId = new Guid(guid)
            };
            Console.WriteLine(JsonConvert.SerializeObject(updateOptions));

            var numberOrder = this.service.Update(id, updateOptions);
            Console.WriteLine(JsonConvert.SerializeObject(numberOrder));
        }
    }
}
