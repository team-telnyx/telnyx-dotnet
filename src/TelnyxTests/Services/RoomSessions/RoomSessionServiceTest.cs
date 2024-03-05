using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.RoomSessions;
using Telnyx.net.Services.RoomSessions;
using Xunit;

namespace TelnyxTests.Services.RoomSessions
{
    public class RoomSessionServiceTest : BaseTelnyxTest
    {
        private readonly RoomSessionService service;
        private readonly UpsertRoomSession createOptions;
        private readonly RequestOptions requestOptions;
        private string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
        private string parentId = "";

        public RoomSessionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new RoomSessionService();

            this.createOptions = new UpsertRoomSession()
            {
                RoomSessionId = Guid.Parse("")
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
