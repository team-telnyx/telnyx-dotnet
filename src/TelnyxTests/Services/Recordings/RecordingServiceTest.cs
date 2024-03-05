using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities.Recordings;
using Telnyx.net.Services.Recordings;
using Xunit;

namespace TelnyxTests.Services.Recordings
{
    public class RecordingServiceTest : BaseTelnyxTest
    {
        private readonly RecordingService service;
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public RecordingServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new RecordingService();
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetRecording(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Recording), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetRecordingAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(Recording), message.GetType());
        }

        [Fact]
        public void Delete()
        {
            var message = this.service.DeleteRecording(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(Recording), message.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var message = await this.service.DeleteRecordingAsync(Id);
            Assert.NotNull(message);
            Assert.Equal(typeof(Recording), message.GetType());
        }
    }
}
