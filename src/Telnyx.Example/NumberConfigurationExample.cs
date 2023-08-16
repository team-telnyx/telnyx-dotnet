using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;
using Telnyx.net.Services.PhoneNumbers.NumberConfigurations;

namespace Telnyx.Example
{
    public class NumberConfigurationExample
    {
        private readonly NumberConfigurationService numConfigService = new NumberConfigurationService();
        private readonly NumberConfigurationMessagingService numMessagingService = new NumberConfigurationMessagingService();
        private readonly NumberConfigurationVoiceService numVoiceService = new NumberConfigurationVoiceService();
        public async Task ListPhoneNumbersWithFiltersAsync()
        {
            var listOptions = new NumberConfigurationsListOptions
            {
                Status = NumberConfigStatus.Active,
                PageNumber = 1,
                NumberOfPagesToFetch = 3,
                PageSize = 3

            };
            var res = await numConfigService.ListPhoneNumbersAsync(listOptions);
            Console.WriteLine(res.TelnyxResponse.ObjectJson);

        }
        public async Task ListPhoneNumbersWithPagingAsync()
        {
            var listOptions = new NumberConfigurationsListOptions
            {

                PageNumber = 1,
                PageSize = 2

            };
            var res = await numConfigService.ListPhoneNumbersAsync(listOptions);
            Console.WriteLine(JsonConvert.SerializeObject(res));
        }
        public async Task ListMessagingOptionsAsync()
        {
            var res = await numMessagingService.ListMessagingSettingsAsync();
            Console.WriteLine(res.TelnyxResponse.ObjectJson);

        }
        public async Task ListVoiceSettingsWithFiltersAsync()
        {
            var options = new VoiceSettingsListOptions
            {
                PageSize = 10,

            };
            var res = await numVoiceService.ListPhoneNumberVoiceAsync(options);
            Console.WriteLine(res.TelnyxResponse.ObjectJson);
        }

    }
}
