namespace TelnyxTests
{
    using System.Collections.Generic;
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

        [Fact]
        public void ApplyParameterToRequestString()
        {
            string requestString = "https://example.com";
            var pairs = new Dictionary<string, string>() {
                {"a", "x"},
                {"b", "y"},
                {"c", "z"},
            };

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                //var key = WebUtility.UrlEncode(pair.Key);
                RequestStringBuilder.ApplyParameterToRequestString(ref requestString, pair.Key, pair.Value);
            }

            var expected = "https://example.com?a=x&b=y&c=z";

            Assert.Equal(expected, requestString);
        }
    }
}


