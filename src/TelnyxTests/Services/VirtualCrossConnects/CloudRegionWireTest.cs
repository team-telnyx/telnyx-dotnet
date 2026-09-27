namespace TelnyxTests.Services.VirtualCrossConnects
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx.net.Entities.VirtualCrossConnects;
    using Xunit;

    public class CloudRegionWireTest
    {
        [Fact]
        public void ExistingPropertyWritesRequiredWireName()
        {
            var json = JObject.Parse(JsonConvert.SerializeObject(new UpsertVirtualCrossConnect { CloudRegion = "us-east-1" }));
            Assert.Equal("us-east-1", (string)json["cloud_provider_region"]);
            Assert.Null(json["cloud_region"]);
        }

        [Theory]
        [InlineData("cloud_provider_region")]
        [InlineData("cloud_region")]
        public void ReadsCurrentAndLegacyWireNames(string name)
        {
            var json = new JObject { [name] = "us-east-1" }.ToString();
            Assert.Equal("us-east-1", JsonConvert.DeserializeObject<UpsertVirtualCrossConnect>(json).CloudRegion);
            Assert.Equal("us-east-1", JsonConvert.DeserializeObject<VirtualCrossConnect>(json).CloudRegion);
        }
    }
}
