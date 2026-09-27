namespace TelnyxTests.Services.Wireless.SimCards
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Telnyx.net.Entities.Wireless.OTAUpdates;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    // Passing controls document a retired route, not current API support.
    // Responses are forwarded from the real current pinned-contract HTTP mock.
    [Collection("Telnyx-mock tests")]
    [Trait("Contract", "current-pinned")]
    public class CurrentBulkNetworkPreferenceContractTest
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task BulkUpdateNetworkPreference_CurrentRouteIsAbsent(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new SimCardsService();
            var options = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new[]
                {
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>
                {
                    new MobileOperatorNetworksPreferences
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };
            var error = await Assert.ThrowsAsync<TelnyxException>(async () =>
            {
                if (asynchronous)
                {
                    await service.BulkUpdateNetworkPreferenceAsync(options);
                }
                else
                {
                    service.BulkUpdateNetworkPreference(options);
                }
            });

            Assert.Equal(1, wire.Requests);
            Assert.Equal(HttpStatusCode.NotFound, wire.Status);
            Assert.Equal("https://stoplight.io/prism/errors#NO_PATH_MATCHED_ERROR", (string)wire.Json["type"]);
            Assert.Equal(404, (int)wire.Json["status"]);
            Assert.Contains("/actions/network_preferences/sim_cards", (string)wire.Json["detail"]);
            Assert.Contains("NO_PATH_MATCHED_ERROR", error.Message);
        }

        private sealed class CurrentWire : DelegatingHandler
        {
            private readonly string originalBase = TelnyxConfiguration.GetApiBase();
            private readonly string originalKey = TelnyxConfiguration.GetApiKey();
            private readonly PropertyInfo clientProperty = typeof(TelnyxConfiguration).Assembly
                .GetType("Telnyx.Infrastructure.Requestor").GetProperty("HttpClient", BindingFlags.Static | BindingFlags.NonPublic);
            private readonly HttpClient originalClient;
            private readonly HttpClient client;

            internal CurrentWire()
                : base(new HttpClientHandler { AllowAutoRedirect = false, UseProxy = false })
            {
                // Requestor caches its client: preserve and restore the actual cached value.
                this.originalClient = (HttpClient)this.clientProperty.GetValue(null);
                this.client = new HttpClient(this, disposeHandler: false);
                TelnyxConfiguration.SetApiBase("http://127.0.0.1:12111/v2");
                TelnyxConfiguration.SetApiKey("TEST_ONLY");
                this.clientProperty.SetValue(null, this.client);
            }

            internal int Requests { get; private set; }

            internal HttpStatusCode Status { get; private set; }

            internal JObject Json { get; private set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal("http://127.0.0.1:12111/v2/actions/network_preferences/sim_cards", request.RequestUri.AbsoluteUri);
                Assert.Equal(HttpMethod.Put, request.Method);
                this.Requests++;
                var response = await base.SendAsync(request, cancellationToken);
                this.Status = response.StatusCode;
                this.Json = JObject.Parse(await response.Content.ReadAsStringAsync());
                return response;
            }

            protected override void Dispose(bool disposing)
            {
                this.clientProperty.SetValue(null, this.originalClient);
                this.client.Dispose();
                TelnyxConfiguration.SetApiBase(this.originalBase);
                TelnyxConfiguration.SetApiKey(this.originalKey);
                base.Dispose(disposing);
            }
        }
    }
}
