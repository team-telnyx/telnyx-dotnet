namespace Telnyx.net.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class Meta 
    {
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
