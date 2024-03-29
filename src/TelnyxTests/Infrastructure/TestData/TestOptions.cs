// <copyright file="TestOptions.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Infrastructure.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx;

    public class TestOptions : BaseOptions
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TestEnum
        {
            [EnumMember(Value = "test_one")]
            TestOne,

            // TestTwo doesn't define a serialization value
            TestTwo,
        }

        [JsonProperty("array")]
        public string[] Array { get; set; }

        [JsonProperty("bool")]
        public bool? Bool { get; set; }

        [JsonProperty("date_filter")]
        public DateRangeOptions DateRangeOptions { get; set; }

        [JsonProperty("datetime")]
        public DateTime? DateTime { get; set; }

        [JsonProperty("decimal")]
        public decimal? Decimal { get; set; }

        [JsonProperty("dictionary")]
        public Dictionary<string, object> Dictionary { get; set; }

        [JsonProperty("enum")]
        public TestEnum? Enum { get; set; }

        [JsonProperty("list")]
        public List<object> List { get; set; }

        [JsonProperty("long")]
        public long? Long { get; set; }

        [JsonProperty("string")]
        public string String { get; set; }
    }
}
