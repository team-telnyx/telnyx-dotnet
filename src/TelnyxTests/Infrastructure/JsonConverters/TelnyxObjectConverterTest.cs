namespace TelnyxTests
{
    using Telnyx.Infrastructure;
    using Xunit;

    public class TelnyxObjectConverterTest : BaseTelnyxTest
    {
        private readonly TelnyxObjectConverter telnyxObjectConverter;
        public TelnyxObjectConverterTest()
        {
            telnyxObjectConverter = new TelnyxObjectConverter();
        }

        [Fact]
        public void ReadJson()
        {
            var response = telnyxObjectConverter.CanConvert(typeof(TelnyxObjectConverterTest));
            Assert.False(response);
        }
    }
}



