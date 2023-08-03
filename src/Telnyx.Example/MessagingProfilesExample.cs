using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telnyx.net.Entities.Messaging.Messaging_Profiles;
using Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics;

namespace Telnyx.Example
{
    /// <summary>
    /// Messaging Profiles Example
    /// </summary>
    public class MessagingProfilesExample
    {
        private const string MessagingProfileId = "4001722f-5463-460b-adc9-c4ecba582176";
        private readonly MessagingProfileService service = new MessagingProfileService();
        private readonly MessagingProfilePhoneNumbersService phoneNumbersService = new MessagingProfilePhoneNumbersService();
        private readonly MessagingProfileMetricsService metricsService = new MessagingProfileMetricsService();

        /// <summary>
        /// Create messaging profile
        /// </summary>
        public void Create()
        {
            var createOptions = new NewMessagingProfile
            {
                Name = "Summer Campaign",
                UrlShortenerSettings = new UrlShortenerSettings
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
            var listOptions = new ListOptions()
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
            var listOptions = new ListOptions
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
                UrlShortenerSettings = new UrlShortenerSettings
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
            var listOptions = new ListOptions(25, 1);
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

        public async Task GetDetailAsync(string messagingProfileId = null)
        {
            if (string.IsNullOrEmpty(messagingProfileId))
            {
                messagingProfileId = MessagingProfileId;
            }
            var getOptions = new MetricsOptions
            {
                TimeFrame = "16h"
            };
            var response = await metricsService.GetDetailedMetricsAsync(messagingProfileId, getOptions);
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
        }

        public async Task ListOverviewAsync()
        {
            var listOptions = new ListMetricsOptions
            {
                TimeFrame = "16h"
            };
            var response = await metricsService.ListHighLevelMetricsAsync(listOptions);
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
        }
    }
}
