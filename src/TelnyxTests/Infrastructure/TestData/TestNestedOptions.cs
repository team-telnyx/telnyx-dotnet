// <copyright file="TestNestedOptions.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Infrastructure.TestData
{
    using Newtonsoft.Json;
    using Telnyx;

    public class TestNestedOptions : INestedOptions
    {
        [JsonProperty("a_long")]
        public long? ALong { get; set; }

        [JsonProperty("a_string")]
        public string AString { get; set; }
    }
}
