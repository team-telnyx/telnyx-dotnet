namespace Telnyx.Example
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles;

    /// <summary>
    /// Messaging Profiles Example
    /// </summary>
    public class MessagingProfilesExample
    {
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
                Name = "Summer Campaign",
                UrlShortnerSettings = new UrlShortnerSettings
                {
                    Domain = "google.com",
                    ReplaceBlackListOnly = true,
                    SendWebhooks = true,
                }
            };
            Console.WriteLine(JsonConvert.SerializeObject(createOptions));

            try
            {
                var messagingProfile = this.service.Create(createOptions);
                Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// Delete messaging profile id
        /// </summary>
        public void Delete()
        {
            Console.WriteLine(MessagingProfileId);

            try
            {
                var deleted = this.service.Get(MessagingProfileId);
                Console.WriteLine(JsonConvert.SerializeObject(deleted));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// Get messaging profile
        /// </summary>
        public void Get()
        {
            Console.WriteLine(MessagingProfileId);

            try
            {
                var messagingProfile = this.service.Get(MessagingProfileId);
                Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// List messaging profile phone numbers
        /// </summary>
        public void List()
        {
            var listOptions = new ListMessagingProfilesPhoneNumbersOptions()
            {
                PageSize = 2,
                PageNumber = 1,
                NumberOfPagesToFetch = 3
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                var messagingProfile = this.service.List(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
        /// <summary>
        /// List messaging profile phone numbers
        /// </summary>
        public void ListPaged()
        {
            var listOptions = new ListMessagingProfilesPhoneNumbersOptions
            {
                PageSize = 2,
                PageNumber = 1
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                var messagingProfile = this.service.ListPaged(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// Update messaging profile
        /// </summary>
        public void Update()
        {
            var updateOptions = new MessagingProfileUpdate
            {
                Name = "Summer Campaign",
                UrlShortnerSettings = new UrlShortnerSettings
                {
                    Domain = "yahoo.com",
                    ReplaceBlackListOnly = true,
                    SendWebhooks = true,
                }
            };
            Console.WriteLine(JsonConvert.SerializeObject(updateOptions));

            try
            {
                var messagingProfile = this.service.Update(MessagingProfileId, updateOptions);
                Console.WriteLine(JsonConvert.SerializeObject(messagingProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// List all messaging profile phone numbers
        /// </summary>
        public void ListAllMessagingProfilePhoneNumbers()
        {
            var listOptions = new ListMessagingProfilesPhoneNumbersOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                var messagingPhoneNumber = this.phoneNumbersService.List(MessagingProfileId, listOptions);
                
                Console.WriteLine(JsonConvert.SerializeObject(messagingPhoneNumber));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
