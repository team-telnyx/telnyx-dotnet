using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
                Status = Telnyx.net.Entities.PhoneNumbers.NumberConfigurations.NumberConfigStatus.Active,
                Size = 10,
            };
           var res = await numConfigService.ListPhoneNumbersAsync(listOptions);
        }
        public async Task ListMessagingOptionsAsync()
        {
            var res = await numMessagingService.ListMessagingSettingsAsync();

        }
        public async Task ListVoiceSettingsWithFiltersAsync()
        {
            var options = new VoiceSettingsListOptions
            {
                Size = 10,

            };
            var res = await numVoiceService.ListPhoneNumberVoiceAsync(options);
        }

    }
}
