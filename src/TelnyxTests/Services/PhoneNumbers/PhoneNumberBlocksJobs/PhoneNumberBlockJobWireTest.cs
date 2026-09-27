namespace TelnyxTests.Services.PhoneNumbers.PhoneNumberBlocksJobs
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Telnyx.net.Entities.PhoneNumbers.PhoneNumberBlocksJobs;
    using Telnyx.net.Services.PhoneNumbers.PhoneNumberBlockJobs;
    using Xunit;

    [Collection("Telnyx-mock tests")]
    public class PhoneNumberBlockJobWireTest
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CreatesDeletionJobAtDocumentedAction(bool asynchronous)
        {
            const string id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var original = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var options = new UpsertPhoneNumberBlocksJob { PhoneNumberBlockId = id };
                var requestOptions = new RequestOptions { ApiKey = "test-only", IdempotencyKey = "block-job" };
                var service = new PhoneNumberBlockJobService();
                var call = Task.Run(async () => asynchronous
                    ? await service.CreatePhoneNumberblockJobAsync(options, requestOptions)
                    : service.CreatePhoneNumberblockJob(options, requestOptions));
                using var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10));
                using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true);
                var first = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10));
                var length = 0;
                string header;
                while (!string.IsNullOrEmpty(header = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10))))
                {
                    if (header.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                        length = int.Parse(header.Substring("Content-Length:".Length));
                }
                var body = new char[length];
                await reader.ReadBlockAsync(body, 0, length).WaitAsync(TimeSpan.FromSeconds(10));
                var response = Encoding.UTF8.GetBytes("{\"data\":{\"id\":\"" + id + "\",\"record_type\":\"phone_number_blocks_job\"}}");
                var prefix = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {response.Length}\r\nConnection: close\r\n\r\n");
                await stream.WriteAsync(prefix);
                await stream.WriteAsync(response);
                await stream.FlushAsync();
                var result = await call.WaitAsync(TimeSpan.FromSeconds(10));
                Assert.NotNull(result);
                Assert.Equal("POST /v2/phone_number_blocks/jobs/delete_phone_number_block HTTP/1.1", first);
                Assert.Equal(id, JObject.Parse(new string(body))["phone_number_block_id"]?.Value<string>());
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(original);
            }
        }
    }
}
