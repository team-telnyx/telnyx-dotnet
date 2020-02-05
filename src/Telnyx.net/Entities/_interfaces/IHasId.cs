namespace Telnyx
{
    /// <summary>
    /// Interface that identifies entities returned by Telnyx that have an `id` attribute.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Gets or sets unique identifier for the object.
        /// </summary>
        string Id { get; set; }
    }
}
