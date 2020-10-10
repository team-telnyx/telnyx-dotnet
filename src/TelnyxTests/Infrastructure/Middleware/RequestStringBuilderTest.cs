namespace TelnyxTests
{
    using Newtonsoft.Json.Linq;
    using Telnyx.Infrastructure.Middleware;
    using Xunit;

    public class RequestStringBuilderTest : BaseTelnyxTest
    {
        [Fact]
        public void BuildRequestStringFromJObject()
        {
            JObject jObject = JObject.Parse(@"{ 'CPU': 'Intel'}");

            var response = RequestStringBuilder.BuildRequestStringFromJObject(jObject);
            Assert.NotNull(response);
        }
    }
}


