namespace Telnyx
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Error.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or sets Code.
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Detail.
        /// </summary>
        [DataMember(Name = "detail")]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets Source.
        /// </summary>
        [DataMember(Name = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets Meta.
        /// </summary>
        [DataMember(Name = "meta")]
        public object Meta { get; set; }
    }
}
