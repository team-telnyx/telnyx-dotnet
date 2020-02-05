namespace Telnyx
{
    /// <summary>
    /// NumberOrderUpdateOptions
    /// </summary>
    public class NumberOrderUpdateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets body
        /// </summary>
        public NumberOrder Body { get; set; }

        /// <summary>
        /// Gets or sets numberOrderId
        /// </summary>
        public string NumberOrderId { get; set; }
    }
}