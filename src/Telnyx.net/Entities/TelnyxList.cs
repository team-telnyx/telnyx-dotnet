namespace Telnyx.net.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.Infrastructure;

    /// <summary>
    /// Telnyx List.
    /// </summary>
    /// <typeparam name="T">Object Type.</typeparam>
    [JsonObject]
    public class TelnyxList<T> : TelnyxEntity, IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets a string describing the object type returned.
        /// </summary>
        [JsonProperty("object")]
        public string Object => typeof(T).Name;

        /// <summary>
        /// Gets or sets a list containing the actual response elements, paginated by any request parameters.
        /// </summary>
        [JsonProperty("data", ItemConverterType = typeof(TelnyxObjectConverter))]
        public List<T> Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether whether or not there are more elements available after this set. If <c>false</c>,
        /// this set comprises the end of the list.
        /// </summary>
        [JsonProperty("has_more")]
        public bool HasMore => this.PageInfo?.HasMore ?? false;

        /// <summary>
        /// Gets or sets the URL for accessing this list.
        /// </summary>
        [JsonProperty("url")]
        public string Url => this?.TelnyxResponse?.Url ?? string.Empty;

        /// <summary>
        /// Gets or sets metadata for list.
        /// </summary>
        [JsonProperty("meta")]
        public PageInfo PageInfo { get; set; }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}
