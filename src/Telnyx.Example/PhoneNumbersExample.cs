using System;
using Newtonsoft.Json;

namespace Telnyx.Example
{
    /// <summary>
    /// Phone Numbers Example
    /// </summary>
    public class PhoneNumbersExample
    {
        private readonly MessagingPhoneNumbersService service = new MessagingPhoneNumbersService();

        /// <summary>
        /// Get phone number
        /// </summary>
        public void GetPhoneNumber()
        {
            var id = "+18665550001";
            Console.WriteLine(id);

            try
            {
                var messagingList = this.service.Get(id);
                Console.WriteLine(JsonConvert.SerializeObject(messagingList));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// List phone number
        /// </summary>
        public void ListNumberOrder()
        {
            var listOptions = new MessagingPhoneNumberListOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                var messagingList = this.service.List(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(messagingList));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// Update phone number
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

            try
            {
                var numberOrder = this.service.Update(id, updateOptions);
                Console.WriteLine(JsonConvert.SerializeObject(numberOrder));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
