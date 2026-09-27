namespace Telnyx.net.Entities.Wireless.SimCards
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    // Preserve the public decimal API while matching the documented string wire type.
    internal sealed class DataUsageAmountConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType) => objectType == typeof(decimal);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((decimal)value).ToString(CultureInfo.InvariantCulture));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException("Default decimal deserialization is used.");
        }
    }
}
