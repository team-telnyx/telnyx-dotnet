using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Faxes;
using Telnyx.net.Services.Faxes.Applications;
using Xunit;

namespace TelnyxTests.Services.Faxes.Applications
{
    public class FaxActionCancelServiceTest : BaseTelnyxTest
    {
        private readonly FaxActionCancelService service;
        private readonly UpsertFaxActionCancel createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public FaxActionCancelServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new FaxActionCancelService();

            this.createOptions = new UpsertFaxActionCancel()
            {
            };


            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var result = this.service.Create(this.Id, this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAsync(this.Id, this.createOptions, this.requestOptions, parentId, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxApiResponse), result.GetType());
        }
    }
}
