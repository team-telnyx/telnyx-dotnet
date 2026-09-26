using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles
{
    // Property-scoped: direct StatusObject serialization retains its historical object contract.
    internal sealed class AssignmentStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(StatusObject);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.String)
            {
                return new StatusObject { Status = (string)reader.Value, IsScalar = true };
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                return serializer.Deserialize<StatusObject>(reader);
            }

            throw new JsonSerializationException("Assignment status must be a string, legacy status object, or null.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is StatusObject status && status.IsScalar)
            {
                writer.WriteValue(status.Status);
                return;
            }

            serializer.Serialize(writer, value);
        }
    }
}
