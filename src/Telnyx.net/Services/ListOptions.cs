namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// ListOptions
    /// Possible base list options can be added here. 
    /// </summary>
    public class ListOptions : BaseOptions
    {
        public ListOptions()
        {
        }

        public ListOptions(int pageSize, int pageNumber)
        {
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
        }

        /// <summary>
        /// The size of the page.
        /// </summary>
        [JsonProperty("page[size]")]
        public int? PageSize { get; set; }

        /// <summary>
        /// The page number to load.
        /// </summary>
        [JsonProperty("page[number]")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Set number of pages to get and return as list of entities. Default: null (all pages)
        /// Can page a set amount by specifying the amount of pages to fetch. 
        /// If greater than actual pages will just return the total amount of results. 
        /// </summary>
        public int? NumberOfPagesToFetch { get; set; }
    }
}
