namespace TelnyxTests.Services.Calls.ConferenceCommands.DynamicEmergencyAddressList
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Xunit;

    // Synthetic HTTP boundary fixtures, not canonical examples or recorded API responses.
    internal static class DynamicEmergencyAddressResponseFixture
    {
        internal static async Task<T> Send<T>(Func<Task<T>> invoke, string name, string path)
        {
            byte[] bytes;
            using (var resource = typeof(DynamicEmergencyAddressResponseFixture).Assembly.GetManifestResourceStream(
                "TelnyxTests.Resources.api_fixtures.dynamic_emergency_addresses." + name + ".json"))
            using (var reader = new StreamReader(resource, Encoding.UTF8))
            {
                bytes = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }

            // Parse the actual bytes served, without Newtonsoft normalizing the wire timestamps.
            using (var reader = new JsonTextReader(new StringReader(Encoding.UTF8.GetString(bytes))))
            {
                reader.DateParseHandling = DateParseHandling.None;
                var data = JObject.Load(reader)["data"];
                var address = data is JArray array ? Assert.Single(array) : data;
                Assert.Equal("2018-02-02T22:25:27.521Z", (string)address["created_at"]);
                Assert.Equal("2018-02-02T22:25:27.521Z", (string)address["updated_at"]);
            }

            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var oldBase = TelnyxConfiguration.GetApiBase();
            try
            {
                TelnyxConfiguration.SetApiBase($"http://127.0.0.1:{((IPEndPoint)listener.LocalEndpoint).Port}/v2");
                var request = Task.Run(invoke);
                using (var client = await listener.AcceptTcpClientAsync().WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true))
                {
                    var requestLine = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
                    var contentLength = "0";
                    var chunked = false;
                    string header;
                    while (!string.IsNullOrEmpty(header = await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false)))
                    {
                        if (header.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                        {
                            contentLength = header.Substring("Content-Length:".Length).Trim();
                        }
                        if (header.StartsWith("Transfer-Encoding:", StringComparison.OrdinalIgnoreCase))
                        {
                            chunked = true;
                        }
                    }

                    var headers = Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {bytes.Length}\r\nConnection: close\r\n\r\n");
                    await stream.WriteAsync(headers, 0, headers.Length);
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    await stream.FlushAsync();
                    var result = await request.WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
                    Assert.Equal($"GET {path} HTTP/1.1", requestLine);
                    Assert.Equal("0", contentLength);
                    Assert.False(chunked);
                    return result;
                }
            }
            finally
            {
                listener.Stop();
                TelnyxConfiguration.SetApiBase(oldBase);
            }
        }
    }
}
