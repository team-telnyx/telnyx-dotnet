namespace TelnyxTests.Services
{
    using Telnyx.net.Services;
    using Xunit;

    public class UriParserTests
    {

        [Fact]
        public void TestUri()
        {
            var uri = "https://api.telnyx.com".UrlCombine("/calls/");
            Assert.Equal("https://api.telnyx.com/calls", uri);
        }

        [Fact]
        public void TestUriWithId()
        {
            var url = "https://api.telnyx.com".UrlCombine("calls", "1234", "updateCalls");
            Assert.Equal("https://api.telnyx.com/calls/1234/updateCalls", url);
        }

        [Fact]
        public void TestUriMultipleSlashes()
        {
            var url = "https://api.telnyx.com".UrlCombine("calls", "//1234", "/updateCalls/");
            Assert.Equal("https://api.telnyx.com/calls/1234/updateCalls", url);
        }
    }
}
