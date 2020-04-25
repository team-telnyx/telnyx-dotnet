// <copyright file="RequestorTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System.Linq;
    using System.Net.Http;
    using Telnyx;
    using Telnyx.Infrastructure;
    using Xunit;

    public class RequestorTest : BaseTelnyxTest
    {
        [Fact]
        public void SetsHeaders()
        {
            RequestOptions options = new RequestOptions
            {
                ApiKey = "TESTKEY",
                IdempotencyKey = "123",
            };
            var request = Requestor.GetRequestMessage("http://localhost", HttpMethod.Get, options);
            Assert.NotNull(request);
            Assert.Equal($"Bearer {options.ApiKey}", request.Headers.GetValues("Authorization").FirstOrDefault());
            Assert.Equal(options.IdempotencyKey, request.Headers.GetValues("Idempotency-Key").FirstOrDefault());
            Assert.Equal(TelnyxConfiguration.TelnyxApiVersion, request.Headers.GetValues("Telnyx-Version").FirstOrDefault());
        }
    }
}
