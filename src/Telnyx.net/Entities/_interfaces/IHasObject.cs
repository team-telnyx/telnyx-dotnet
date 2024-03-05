namespace Telnyx
{
    /// <summary>
    /// Interface that identifies entities returned by Telnyx that have an `object` attribute.
    /// </summary>
    public interface IHasObject
    {
        /// <summary>
        /// Gets or sets string representing the object's type. Objects of the same type share the same value.
        /// </summary>
        string Object { get; set; }
    }
}
