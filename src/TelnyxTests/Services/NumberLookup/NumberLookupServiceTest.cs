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
                Type = null
            };

            this.cancellationToken = default(CancellationToken);
        }

        [Fact]
        public void Get()
        {
            var result = this.service.Get(_phoneNumber, this.options);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberLookupRecord), result.GetType());
            Assert.Equal("US", result.CountryCode);
            Assert.NotNull(result.NationalFormat);
            Assert.NotNull(result.PhoneNumber);
            Assert.Null(result.Fraud);
            Assert.NotNull(result.CallerName);
            Assert.NotNull(result.CallerName.ErrorCode);
            Assert.NotNull(result.CallerName._CallerName);
            Assert.NotNull(result.Carrier);
            Assert.NotNull(result.Carrier.Name);
            Assert.NotNull(result.Carrier.Type);
            Assert.NotNull(result.Carrier.MobileCountryCode);
            Assert.NotNull(result.Carrier.MobileNetworkCode);
            Assert.Null(result.Carrier.ErrorCode);
            Assert.NotNull(result.Portability);
            Assert.NotNull(result.Portability.Altspid);
            Assert.NotNull(result.Portability.AltspidCarrierName);
            Assert.NotNull(result.Portability.AltspidCarrierType);
            Assert.NotNull(result.Portability.City);
            Assert.NotNull(result.Portability.LineType);
            Assert.NotNull(result.Portability.Lrn);
            Assert.NotNull(result.Portability.Ocn);
            Assert.NotNull(result.Portability.PortedDate);
            Assert.NotNull(result.Portability.PortedStatus);
            Assert.NotNull(result.Portability.Spid);
            Assert.NotNull(result.Portability.SpidCarrierName);
            Assert.NotNull(result.Portability.SpidCarrierType);
            Assert.NotNull(result.Portability.State);
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
