using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    public class NumberConfigurationVoiceService : Service<PhoneNumberVoiceSettings>
    {
        public override string BasePath => throw new NotImplementedException();
    }
}
