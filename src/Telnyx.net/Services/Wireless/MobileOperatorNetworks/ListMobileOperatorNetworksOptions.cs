namespace Telnyx.net.Services.Wireless.MobileOperatorNetworks
{
    public class ListMobileOperatorNetworksOptions : ListOptions
    {
        public string FilterNameStartsWith { get; set; }

        public string FilterNameContains { get; set; }

        public string FilterNameEndsWith { get; set; }

        public string FilterCountryCode { get; set; }

        public string FilterMcc { get; set; }

        public string FilterMnc { get; set; }

        public string FilterTadig { get; set; }
    }
}