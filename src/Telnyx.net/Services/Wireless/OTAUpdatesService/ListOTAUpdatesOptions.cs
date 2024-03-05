namespace Telnyx.net.Services.Wireless.OTAUpdatesService
{
    public class ListOTAUpdatesOptions : ListOptions
    {
        public string FilterSimCardId { get; set; }

        public string FilterStatus { get; set; }

        public string FilterType { get; set; }
    }
}
