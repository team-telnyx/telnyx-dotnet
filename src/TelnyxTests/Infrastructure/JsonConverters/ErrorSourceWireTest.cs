namespace TelnyxTests.Infrastructure.JsonConverters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Xunit;

    public class ErrorSourceWireTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("/data/attributes/phone_number")]
        [InlineData("{\"pointer\":\"/phone_number\"}")]
        [InlineData("{not valid JSON")]
        public void LegacySourceStringsAndNullRoundTripUnchanged(string source)
        {
            var json = JsonConvert.SerializeObject(new Error { Source = source });
            var token = JObject.Parse(json)["Source"];

            Assert.Equal(source == null ? JTokenType.Null : JTokenType.String, token.Type);
            Assert.Equal(source, token.ToObject<string>());
            Assert.Equal(source, Mapper<Error>.MapFromJson(json).Source);
            Assert.Equal(source, JsonConvert.DeserializeObject<Error>(json).Source);
        }

        [Theory]
        [InlineData("[]")]
        [InlineData("[{}]")]
        [InlineData("true")]
        [InlineData("false")]
        [InlineData("123")]
        [InlineData("1.5")]
        public void InvalidSourceShapesFail(string source)
        {
            var json = "{\"source\":" + source + "}";

            Assert.Throws<JsonSerializationException>(() => Mapper<Error>.MapFromJson(json));
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Error>(json));
        }

        [Fact]
        public void EmptySourceObjectRemainsAnObjectTextString()
        {
            Assert.Equal("{}", Mapper<Error>.MapFromJson("{\"source\":{}}").Source);
        }

        [Fact]
        public void MapperPreservesCompleteSourceObjectAsCompactJson()
        {
            const string source = "{\"pointer\":\"/data/attributes/phone_number\",\"parameter\":\"phone_number\",\"extra\":{\"nested\":[1,true,null,\"value\"]}}";
            var error = Mapper<Error>.MapFromJson("{\"data\":{\"source\":" + source + "}}", "data");

            Assert.Equal(source, error.Source);
            Assert.True(JToken.DeepEquals(JObject.Parse(source), JObject.Parse(error.Source)));
            Assert.Equal(source, JsonConvert.DeserializeObject<Error>("{\"source\":" + source + "}").Source);
            var writtenSource = JObject.Parse(JsonConvert.SerializeObject(error))["Source"];
            Assert.Equal(JTokenType.String, writtenSource.Type);
            Assert.Equal(source, writtenSource.ToObject<string>());
        }
    }
}
