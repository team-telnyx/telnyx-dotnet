// <copyright file="NumberLookupServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.NumberLookup
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.NumberLookup;
    using Telnyx.net.Services;
    using Xunit;

    public class NumberLookupServiceTest : BaseTelnyxTest
    {
        private readonly NumberLookupService service;
        private readonly NumberLookupRecordListOptions listOptions;
        private readonly CancellationToken cancellationToken;

        public NumberLookupServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberLookupService();

            this.listOptions = new NumberLookupRecordListOptions()
            {
                PhoneNumber = "+18665552368",
                Type = "undefined",
            };

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, null);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberLookupRecord), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, null, this.cancellationToken);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberLookupRecord), result.GetType());
        }
    }
}
