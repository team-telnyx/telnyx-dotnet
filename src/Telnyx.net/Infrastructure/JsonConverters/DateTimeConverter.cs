// <copyright file="DateTimeConverter.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// DateTimeConverter.
    /// </summary>
    public class DateTimeConverter : DateTimeConverterBase
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
                writer.WriteRawValue(((DateTime)value).ConvertDateTimeToEpoch().ToString());
            }
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                return EpochTime.ConvertEpochToDateTime((long)reader.Value);
            }

            return DateTime.Parse(reader.Value.ToString());
        }
    }
}
