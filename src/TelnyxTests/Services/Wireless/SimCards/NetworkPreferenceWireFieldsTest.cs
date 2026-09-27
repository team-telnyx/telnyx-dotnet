namespace TelnyxTests.Services.Wireless.SimCards
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx.net.Entities.Wireless.OTAUpdates;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class NetworkPreferenceWireFieldsTest : BaseTelnyxTest
    {
        private const string OperatorId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private const string Preferences = "[{\"mobile_network_operator_id\":\"" + OperatorId + "\",\"mobile_network_operator_name\":\"first\",\"priority\":0},{\"mobile_network_operator_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"mobile_network_operator_name\":\"second\",\"priority\":1}]";

        public NetworkPreferenceWireFieldsTest(MockHttpClientFixture fixture) : base(fixture) { }

        [Fact]
        public void BulkOptionsUseDocumentedWireFields()
        {
            var options = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new[] { "6b14e151-8493-4fa1-8664-1cc4e6d14158" },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>
                {
                    new MobileOperatorNetworksPreferences { MobileOperatorNetworkId = Guid.Parse(OperatorId), Priority = 0 },
                },
            };
            var json = JObject.Parse(JsonConvert.SerializeObject(options));
            Assert.Null(json["mobile_operator_networks_preferences"]);
            var preferences = Assert.IsType<JArray>(json["mobile_network_operators_preferences"]);
            Assert.Single(preferences);
            Assert.Equal(OperatorId, (string)preferences[0]["mobile_network_operator_id"]);
            Assert.Null(preferences[0]["mobile_operator_network_id"]);
            Assert.Equal(0, (int)preferences[0]["priority"]);
        }

        [Fact]
        public void PreferenceRecordPreservesEveryOperator()
        {
            var record = JsonConvert.DeserializeObject<MobileOperatorNetworksPreferencesRecord>("{\"mobile_network_operators_preferences\":" + Preferences + "}");
            AssertPreferences(record.MobileOperatorNetworksPreferences);
        }

        [Fact]
        public void OtaSettingsPreserveEveryOperator()
        {
            var settings = JsonConvert.DeserializeObject<CompleteOTAUpdateSettings>("{\"mobile_network_operators_preferences\":" + Preferences + "}");
            AssertPreferences(settings.MobileOperatorNetworksPreferences);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task HistoricalBulkResponsePreservesPreferences(bool asynchronous)
        {
            using var contract = new HistoricalContractScope();
            var options = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new[] { "6b14e151-8493-4fa1-8664-1cc4e6d14158" },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>
                {
                    new MobileOperatorNetworksPreferences { MobileOperatorNetworkId = Guid.Parse(OperatorId), Priority = 0 },
                },
            };
            var service = new SimCardsService();
            var result = asynchronous ? await service.BulkUpdateNetworkPreferenceAsync(options) : service.BulkUpdateNetworkPreference(options);
            Assert.NotEmpty(result);
            foreach (var record in result)
            {
                Assert.NotEmpty(record.MobileOperatorNetworksPreferences);
                foreach (var preference in record.MobileOperatorNetworksPreferences)
                {
                    Assert.NotNull(preference.MobileOperatorNetworkId);
                    Assert.False(string.IsNullOrEmpty(preference.MobileOperatorNetworkName));
                    Assert.NotNull(preference.Priority);
                }
            }
        }

        private static void AssertPreferences(IList<MobileOperatorNetworksPreferences> preferences)
        {
            Assert.NotNull(preferences);
            Assert.Collection(preferences,
                first => { Assert.Equal(Guid.Parse(OperatorId), first.MobileOperatorNetworkId); Assert.Equal("first", first.MobileOperatorNetworkName); Assert.Equal(0, first.Priority); },
                second => { Assert.Equal(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), second.MobileOperatorNetworkId); Assert.Equal("second", second.MobileOperatorNetworkName); Assert.Equal(1, second.Priority); });
        }
    }
}
