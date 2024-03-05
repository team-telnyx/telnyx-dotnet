using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Xunit;

namespace TelnyxTests.Services.ChannelZone
{
    public class ChannelZoneServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly ChannelZoneService service;
        private readonly ChannelZoneOptions listOptions;
        private readonly ChannelZoneUpdate updateOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private object options;
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public ChannelZoneServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ChannelZoneService();

            this.listOptions = new ChannelZoneOptions()
            {
            };
            this.updateOptions = new ChannelZoneUpdate()
            {
                 Channels = 0
            };


            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ChannelZones>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ChannelZones>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.Get(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ChannelZones), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ChannelZones), message.GetType());
        }

        [Fact]
        public void Update()
        {
            var message = this.service.Update(this.credConnId, this.updateOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ChannelZones), message.GetType());
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var message = await this.service.UpdateAsync(this.credConnId, this.updateOptions);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(ChannelZones), message.GetType());
        }
    }
}
