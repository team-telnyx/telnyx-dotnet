namespace TelnyxTests
{
    using Telnyx.Infrastructure;
    using Xunit;

    public class TelnyxObjectConverterTest : BaseTelnyxTest
    {
        private readonly TelnyxObjectConverter telnyxObjectConverter;

        public TelnyxObjectConverterTest()
        {
            this.telnyxObjectConverter = new TelnyxObjectConverter();
        }

        [Fact]
        public void ReadJson()
        {
            var response = this.telnyxObjectConverter.CanConvert(typeof(TelnyxObjectConverterTest));
            Assert.False(response);
        }
    }
}



