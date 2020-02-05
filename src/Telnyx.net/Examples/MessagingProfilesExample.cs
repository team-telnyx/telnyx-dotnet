namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Messaging Profiles Example
    /// </summary>
    public class MessagingProfilesExample
    {
        private const string YOURAPIKEY = "YOUR_API_KEY";
        private const string MessagingProfileId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        private readonly MessagingProfileService service = new MessagingProfileService();
        private readonly MessagingProfilePhoneNumbersService phoneNumbersService = new MessagingProfilePhoneNumbersService();

        /// <summary>
        /// Create messaging profile
        /// </summary>
        public void Create()
        {
            var createOptions = new NewMessagingProfile
            {
                Name = "Summer Campaign"
            };
            Console.WriteLine(JsonConvert.SerializeObject(createOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingProfile = this.service.Create(createOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
        }

        /// <summary>
        /// Delete messaging profile id
        /// </summary>
        public void Delete()
        {
            Console.WriteLine(MessagingProfileId);

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var deleted = this.service.Get(MessagingProfileId, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(deleted));
        }

        /// <summary>
        /// Get messaging profile
        /// </summary>
        public void Get()
        {
            Console.WriteLine(MessagingProfileId);

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingProfile = this.service.Get(MessagingProfileId, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
        }

        /// <summary>
        /// List messaging profile phone numbers
        /// </summary>
        public void List()
        {
            var listOptions = new ListMessagingProfilesPhoneNumbersOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingProfile = this.service.List(listOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
        }

        /// <summary>
        /// Update messaging profile
        /// </summary>
        public void Update()
        {
            var updateOptions = new MessagingProfileUpdate
            {
                Name = "Summer Campaign"
            };
            Console.WriteLine(JsonConvert.SerializeObject(updateOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingProfile = this.service.Update(MessagingProfileId, updateOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
        }

        /// <summary>
        /// List all messaging profile phone numbers
        /// </summary>
        public void ListAllMessagingProfilePhoneNumbers()
        {
            var listOptions = new ListMessagingProfilesPhoneNumbersOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var messagingPhoneNumber = this.phoneNumbersService.List(MessagingProfileId, listOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(messagingPhoneNumber));
        }

    }
}
