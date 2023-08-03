namespace Telnyx.net.Entities.AuthenticationProviders
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.AuthenticationProviders;

    public class AuthenticationProviderListOption : ListOptions
    {
        [JsonProperty("sort")]
        public Sort Sort { get; set; } = Sort.Name;
    }
}
