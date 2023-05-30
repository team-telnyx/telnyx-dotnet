using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.DynamicEmergencyAddresses;

namespace Telnyx.net.Services.DynamicEmergencyAddresses
{
    public class CreateDynamicEmergencyAddressOptions : BaseOptions
    {
        [JsonProperty("administrative_area")]
        public string AdministrativeArea { get; set; }

        [JsonProperty("country_code")]
        public CountryCode CountryCode { get; set; }

        [JsonProperty("extended_address")]
        public string ExtendedAddress { get; set; }

        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }

        [JsonProperty("house_suffix")]
        public string HouseSuffix { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("street_name")]
        public string StreetName { get; set; }

        [JsonProperty("street_post_directional")]
        public string StreetPostDirectional { get; set; }

        [JsonProperty("street_pre_directional")]
        public string StreetPreDirectional { get; set; }

        [JsonProperty("street_suffix")]
        public string StreetSuffix { get; set; }
    }
}
