// <copyright file="ClientTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System.Linq;
    using System.Net.Http;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Telnyx.Infrastructure;
    using Xunit;

    public class ClientTest : BaseTelnyxTest
    {
        [Fact]
        public void SetsUserAgent()
        {
            var request = new HttpRequestMessage();
            Assert.NotNull(request);

            var client = new Client(request);
            client.ApplyClientData();
            client.ApplyUserAgent();

            var expectedUserAgent = $"Telnyx/v1 .NetBindings/{TelnyxConfiguration.TelnyxNetVersion}";
            Assert.Equal(expectedUserAgent, request.Headers.UserAgent.ToString());
            Assert.NotNull(request.Headers.GetValues("X-Telnyx-Client-User-Agent"));

            var userAgentJson = JToken.Parse(request.Headers.GetValues("X-Telnyx-Client-User-Agent").FirstOrDefault());
            Assert.NotNull(userAgentJson);
            Assert.Equal(TelnyxConfiguration.TelnyxNetVersion, userAgentJson["bindings_version"]);
            Assert.Equal(".net", userAgentJson["lang"]);
            Assert.Equal("Telnyx", userAgentJson["publisher"]);
            Assert.NotNull(userAgentJson["lang_version"]);
            Assert.NotNull(userAgentJson["os_version"]);
        }
    }
}
