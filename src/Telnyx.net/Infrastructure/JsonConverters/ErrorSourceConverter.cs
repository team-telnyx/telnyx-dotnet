namespace Telnyx
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    // Accept structured API error sources without changing the legacy string contract on write.
    internal sealed class ErrorSourceConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => objectType == typeof(string);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null || reader.TokenType == JsonToken.String)
            {
                return reader.Value;
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                return JObject.Load(reader).ToString(Formatting.None);
            }

            throw new JsonSerializationException($"Expected a string, object or null error source at '{reader.Path}'.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
