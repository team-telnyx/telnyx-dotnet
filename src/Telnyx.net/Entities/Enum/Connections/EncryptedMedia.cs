namespace Telnyx.net.Entities.Enum.Connections
{
    using Newtonsoft.Json;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum EncryptedMedia
    {
        SRTP = 0,
        ZRTP = 1
    }
}
