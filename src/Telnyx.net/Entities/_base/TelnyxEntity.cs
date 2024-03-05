namespace Telnyx
{
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Newtonsoft.Json;

    /// <summary>
    /// Telnyx Entity.
    /// </summary>
    public abstract class TelnyxEntity : ITelnyxEntity
    {
        /// <inheritdoc/>
        [JsonIgnore]
        public TelnyxResponse TelnyxResponse { get; set; }

        /// <summary>Reports a Telnyx object as a string.</summary>
        /// <returns>
        /// A string representing the Telnyx object, including its JSON serialization.
        /// </returns>
        /// <seealso cref="ToJson"/>
        public override string ToString()
        {
            return string.Format(
                "<{0}@{1} id={2}> JSON: {3}",
                this.GetType().FullName,
                RuntimeHelpers.GetHashCode(this),
                this.GetIdString(),
                this.ToJson());
        }

        /// <summary>Serializes the Telnyx object as a JSON string.</summary>
        /// <returns>An indented JSON string represensation of the object.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        private object GetIdString()
        {
            foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties)
            {
                if (property.Name == "Id")
                {
                    return property.GetValue(this);
                }
            }

            return null;
        }
    }
}
