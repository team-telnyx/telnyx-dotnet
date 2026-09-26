namespace TelnyxTests.Services.Wireless.SimCards
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Xunit;

    public class DataUsageThresholdSerializationTest
    {
        [Fact]
        public void AmountUsesDocumentedStringWireType()
        {
            var threshold = new DataUsageThreshold { Amount = 2048.1m, Unit = "MB" };
            var wire = JObject.Parse(JsonConvert.SerializeObject(threshold));
            Assert.Equal(JTokenType.String, wire["amount"].Type);
            Assert.Equal("2048.1", (string)wire["amount"]);
            Assert.Equal(2048.1m, JsonConvert.DeserializeObject<DataUsageThreshold>(wire.ToString()).Amount);
        }

        [Theory]
        [InlineData("{\"amount\":\"2048.1\",\"unit\":\"MB\"}")]
        [InlineData("{\"amount\":2048.1,\"unit\":\"MB\"}")]
        public void ExistingNumericAndStringResponsesAreAccepted(string json)
        {
            Assert.Equal(2048.1m, JsonConvert.DeserializeObject<DataUsageThreshold>(json).Amount);
        }
    }
}
