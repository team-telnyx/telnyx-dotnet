using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Infrastructure.JsonConverters
{
    /// <summary>
    /// DateTimeOffsetConverter.
    /// </summary>
    public class DateTimeOffsetConverter : DateTimeConverterBase
    {
        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteRawValue(((DateTimeOffset)value).ToString());
            }
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            return DateTimeOffset.Parse(reader.Value.ToString());
        }
    }
}
