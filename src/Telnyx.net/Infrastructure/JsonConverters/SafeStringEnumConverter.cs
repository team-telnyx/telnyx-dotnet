using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Infrastructure.JsonConverters
{
    public class SafeStringEnumConverter : StringEnumConverter
    {
        public object DefaultValue { get; }

        public SafeStringEnumConverter(object defaultValue)
        {
            DefaultValue = defaultValue;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return DefaultValue;
            }
        }
    }
}
