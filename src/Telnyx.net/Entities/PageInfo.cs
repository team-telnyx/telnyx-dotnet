namespace Telnyx.net.Entities
{
    using Newtonsoft.Json;

    public class PageInfo
    {
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        public bool HasMore => this.PageNumber < this.TotalPages;

        public int NextPage => this.HasMore ? this.PageNumber + 1 : 1; //if no more can set NextPage to FirstPage

        public string NextPageUrl { get; set; }
    }
}
