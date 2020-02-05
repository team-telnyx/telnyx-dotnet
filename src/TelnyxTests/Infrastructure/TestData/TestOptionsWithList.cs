// <copyright file="TestOptionsWithList.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Infrastructure.TestData
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx;

    public class TestOptionsWithList : BaseOptions
    {
        public TestOptionsWithList()
        {
            this.SomeList = new List<TestNestedOptions>
            {
                new TestNestedOptions
                {
                    ALong = 1,
                    AString = "foo",
                },
                new TestNestedOptions
                {
                    ALong = 2,
                    AString = "bar",
                },
            };
        }

        [JsonProperty("some_list")]
        public List<TestNestedOptions> SomeList { get; set; }
    }
}
