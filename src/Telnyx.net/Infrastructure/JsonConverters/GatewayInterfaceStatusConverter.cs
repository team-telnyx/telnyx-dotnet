namespace Telnyx
{
    using System;
    using Newtonsoft.Json;
    using GatewayStatus = Telnyx.net.Entities.Wireless.PublicInternetGateways.InterfaceStatus;
    using WireGuardStatus = Telnyx.net.Entities.PhoneNumbers.WireGuardInterfaces.InterfaceStatus;

    // The API returns a scalar deployment status; keep the legacy object contract on write.
    internal sealed class GatewayInterfaceStatusConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => objectType == typeof(GatewayStatus) || objectType == typeof(WireGuardStatus);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.String)
            {
                if (objectType == typeof(WireGuardStatus))
                {
                    return new WireGuardStatus { Value = (string)reader.Value };
                }

                return new GatewayStatus { Status = (string)reader.Value };
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                return serializer.Deserialize(reader, objectType);
            }

            throw new JsonSerializationException($"Expected a string, object or null interface status at '{reader.Path}'.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
