namespace Telnyx.net.Infrastructure.JsonConverters
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class SafeStringEnumConverter : StringEnumConverter
    {
        public object DefaultValue { get; }

        public SafeStringEnumConverter(object defaultValue)
        {
            this.DefaultValue = defaultValue;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return this.DefaultValue;
            }
        }
    }
}
