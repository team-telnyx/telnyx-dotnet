// <copyright file="NumberLookupServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.NumberLookup
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.NumberLookup;
    using Telnyx.net.Services;
    using Xunit;

    public class NumberLookupServiceTest : BaseTelnyxTest
    {
        private readonly NumberLookupService service;
        private readonly NumberLookupRecordOptions options;
        private readonly RequestOptions reqOptions;
        private readonly CancellationToken cancellationToken;
        private const string _phoneNumber = "+18665552368";

        public NumberLookupServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberLookupService();

            this.options = new NumberLookupRecordOptions()
            {

            };

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(_phoneNumber, this.options);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberLookupRecord), result.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(_phoneNumber, this.options, cancellationToken: this.cancellationToken);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberLookupRecord), result.GetType());
        }
    }
}
