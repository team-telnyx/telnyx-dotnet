using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telnyx;
using Xunit;
using Gateway = Telnyx.net.Entities.Wireless.PublicInternetGateways.PublicInternetGateway;
using WireGuard = Telnyx.net.Entities.PhoneNumbers.WireGuardInterfaces.WireGuardInterface;

namespace TelnyxTests
{
    public class GatewayInterfaceStatusWireTest
    {
        // GET response captured from the schema-backed local mock, not model-generated JSON.
        // Canonical components/schemas/InterfaceStatus is a read-only string.
        private const string GatewayResponse = @"{""data"":{""id"":""6a09cdc3-8948-47f0-aa62-74ac943d6c58"",""record_type"":""public_internet_gateway"",""created_at"":""2018-02-02T22:25:27.521Z"",""updated_at"":""2018-02-02T22:25:27.521Z"",""network_id"":""6a09cdc3-8948-47f0-aa62-74ac943d6c58"",""name"":""test interface"",""status"":""created"",""region_code"":""ashburn-va"",""public_ip"":""127.0.0.1""}}";

        // GET /v2/wireguard_interfaces/{id}, captured from the same schema-backed mock.
        private const string WireGuardResponse = @"{""data"":{""id"":""6a09cdc3-8948-47f0-aa62-74ac943d6c58"",""record_type"":""wireguard_interface"",""created_at"":""2018-02-02T22:25:27.521Z"",""updated_at"":""2018-02-02T22:25:27.521Z"",""network_id"":""6a09cdc3-8948-47f0-aa62-74ac943d6c58"",""name"":""test interface"",""status"":""created"",""endpoint"":""203.0.113.0:51871"",""public_key"":""qF4EqlZq+5JL2IKYY8ij49daYyfKVhevJrcDxdqC8GU="",""enable_sip_trunking"":false,""region_code"":""ashburn-va"",""region"":{""code"":""ashburn-va"",""name"":""Ashburn"",""record_type"":""region""}}}";

        [Fact]
        public void WireGuardReadsScalarWireStatus()
        {
            var wireguard = Mapper<WireGuard>.MapFromJson(WireGuardResponse, "data");
            Assert.Equal("created", wireguard.Status.Value);
            Assert.Equal("203.0.113.0:51871", wireguard.Endpoint);
        }

        [Theory]
        [InlineData("created")]
        [InlineData("provisioning")]
        [InlineData("provisioned")]
        [InlineData("deleting")]
        [InlineData("future_status")]
        public void ScalarStatusPreservesValueAndLegacySerialization(string status)
        {
            var json = new JObject { ["status"] = status }.ToString();
            var gateway = JsonConvert.DeserializeObject<Gateway>(json);
            var wireguard = JsonConvert.DeserializeObject<WireGuard>(json);
            var gatewayJson = JsonConvert.SerializeObject(gateway);
            var wireguardJson = JsonConvert.SerializeObject(wireguard);
            Assert.Equal(status, (string)JObject.Parse(gatewayJson)["status"]["status"]);
            Assert.Equal(status, (string)JObject.Parse(wireguardJson)["status"]["value"]);
            Assert.Equal(status, JsonConvert.DeserializeObject<Gateway>(gatewayJson).Status.Status);
            Assert.Equal(status, JsonConvert.DeserializeObject<WireGuard>(wireguardJson).Status.Value);
        }

        [Fact]
        public void LegacyObjectsStillDeserialize()
        {
            Assert.Equal("provisioned", JsonConvert.DeserializeObject<Gateway>("{\"status\":{\"status\":\"provisioned\"}}").Status.Status);
            Assert.Equal("provisioned", JsonConvert.DeserializeObject<WireGuard>("{\"status\":{\"value\":\"provisioned\"}}").Status.Value);
        }

        [Theory]
        [InlineData("{}")]
        [InlineData("{\"status\":null}")]
        public void MissingOrNullStatusRemainsNull(string json)
        {
            Assert.Null(JsonConvert.DeserializeObject<Gateway>(json).Status);
            Assert.Null(JsonConvert.DeserializeObject<WireGuard>(json).Status);
        }

        [Theory]
        [InlineData("42")]
        [InlineData("true")]
        [InlineData("[]")]
        public void InvalidScalarStatusIsNotSilentlyCoerced(string value)
        {
            var json = "{\"status\":" + value + "}";
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Gateway>(json));
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<WireGuard>(json));
        }

        [Fact]
        public void NullSerializationSettingsRemainEffective()
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            Assert.Null(JObject.Parse(JsonConvert.SerializeObject(new Gateway(), settings))["status"]);
            Assert.Null(JObject.Parse(JsonConvert.SerializeObject(new WireGuard(), settings))["status"]);
        }

        [Fact]
        public void GatewayReadsScalarWireStatus()
        {
            var gateway = Mapper<Gateway>.MapFromJson(GatewayResponse, "data");
            Assert.Equal("created", gateway.Status.Status);
            Assert.Equal("127.0.0.1", gateway.PublicIp);
        }
    }
}
