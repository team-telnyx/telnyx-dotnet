// <copyright file="BaseTelnyxTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System.IO;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class BaseTelnyxTest : IClassFixture<MockHttpClientFixture>, IClassFixture<TelnyxMockFixture>
    {
        public BaseTelnyxTest()
            : this(null, null)
        {
        }

        public BaseTelnyxTest(TelnyxMockFixture telnyxMockFixture)
            : this(telnyxMockFixture, null)
        {
        }

        public BaseTelnyxTest(MockHttpClientFixture mockHttpClientFixture)
            : this(null, mockHttpClientFixture)
        {
        }

        public BaseTelnyxTest(TelnyxMockFixture telnyxMockFixture, MockHttpClientFixture mockHttpClientFixture)
        {
            this.TelnyxMockFixture = telnyxMockFixture;
            this.MockHttpClientFixture = mockHttpClientFixture;

            if (this.MockHttpClientFixture != null)
            {
                // Reset the mock before each test
                this.MockHttpClientFixture.Reset();
            }
        }

        protected MockHttpClientFixture MockHttpClientFixture { get; }

        protected TelnyxMockFixture TelnyxMockFixture { get; }

        /// <summary>
        /// Gets a resource file and returns its contents in a string.
        /// </summary>
        /// <param name="path">Path to the resource file.</param>
        /// <returns>File contents.</returns>
        protected static string GetResourceAsString(string path)
        {
            var fullpath = "TelnyxTests.Resources." + path;
            var contents = new StreamReader(
                typeof(BaseTelnyxTest).GetTypeInfo().Assembly.GetManifestResourceStream(fullpath),
                Encoding.UTF8).ReadToEnd();

            return contents;
        }

        /// <summary>
        /// Asserts that a single HTTP request was made with the specified method and path.
        /// </summary>
        /// <param name="method"> method used for making the request. </param>
        /// <param name="path"> RequestUri. </param>
        protected void AssertRequest(HttpMethod method, string path)
        {
            if (this.MockHttpClientFixture == null)
            {
                throw new TelnyxTestException(
                    "AssertRequest called from a test class that doesn't have access to "
                    + "MockHttpClientFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives MockHttpClientFixture and calls the "
                    + "base constructor.");
            }

            this.MockHttpClientFixture.AssertRequest(method, path);
        }

        /// <summary>
        /// Gets fixture data with expansions specified.
        /// Use the special <c>*</c> character to specify that all fields should be
        /// expanded.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for telnyx-mock.</param>
        /// <param name="expansions">Set of expansions that should be applied.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        protected string GetFixture(string path, string[] expansions = null)
        {
            if (this.TelnyxMockFixture == null)
            {
                throw new TelnyxTestException(
                    "GetFixture called from a test class that doesn't have access to "
                    + "TelnyxMockFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives TelnyxMockFixture and calls the "
                    + "base constructor.");
            }

            return this.TelnyxMockFixture.GetFixture(path, expansions);
        }
    }
}
