namespace Telnyx
{
    using System.Collections.Generic;

    /// <summary>
    /// BaseOptions
    /// </summary>
    public class BaseOptions : INestedOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOptions"/> class.
        /// </summary>
        public BaseOptions()
        {
            this.ExtraParams = new Dictionary<string, string>();
            this.Expand = new List<string>();
        }

        /// <summary>
        /// Gets or sets extraParams
        /// </summary>
        public Dictionary<string, string> ExtraParams { get; set; }

        /// <summary>
        /// Gets or sets expand
        /// </summary>
        public List<string> Expand { get; set; }

        /// <summary>
        /// AddExtraParam
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void AddExtraParam(string key, string value)
        {
            this.ExtraParams.Add(key, value);
        }

        /// <summary>
        /// AddExpand
        /// </summary>
        /// <param name="value">value</param>
        public void AddExpand(string value)
        {
            this.Expand.Add(value);
        }
    }
}
