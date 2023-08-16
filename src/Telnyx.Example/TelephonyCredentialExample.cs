using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.WebRTC.Credentials;
using Telnyx.net.Services.WebRTC.Credentials;

namespace Telnyx.Example
{
    public class TelephonyCredentialExample
    {
        private readonly TelephonyCredentialService service = new TelephonyCredentialService();
        private const string id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public WebRtcCredential Get()
        {
            WebRtcCredential result = new WebRtcCredential();

            try
            {
                var requestOptions = new RequestOptions();

                result = service.Get(id, requestOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<WebRtcCredential> GetAsync()
        {
            WebRtcCredential result = new WebRtcCredential();

            try
            {
                var requestOptions = new RequestOptions();

                result = await service.GetAsync(id, requestOptions, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public TelnyxList<WebRtcCredential> List()
        {
            TelnyxList<WebRtcCredential> result = new TelnyxList<WebRtcCredential>();
            ListOptions listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                result = service.List(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<TelnyxList<WebRtcCredential>> ListAsync()
        {
            TelnyxList<WebRtcCredential> result = new TelnyxList<WebRtcCredential>();
            ListOptions listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                result = await service.ListAsync(listOptions, null, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public WebRtcCredential Create()
        {
            WebRtcCredential result = new WebRtcCredential();

            try
            {
                var createOptions = new TelephonyCredentialCreateOptions()
                {
                    ConnectionId = "1234567890",
                    ExpiresAt = "2018-02-02T22:25:27.521Z",
                };

                result = service.Create(createOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<WebRtcCredential> CreateAsync()
        {
            WebRtcCredential result = new WebRtcCredential();
            try
            {
                var createOptions = new TelephonyCredentialCreateOptions()
                {
                    ConnectionId = "1234567890",
                    ExpiresAt = "2018-02-02T22:25:27.521Z",
                };

                result = await service.CreateAsync(createOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public WebRtcCredential Update()
        {
            WebRtcCredential result = new WebRtcCredential();

            try
            {
                var updateOptions = new TelephonyCredentialUpdateOptions()
                {
                    ConnectionId = "987654321",
                    ExpiresAt = "2018-02-02T22:25:27.521Z",
                    Name = "My Creds",
                };

                result = service.Update(id, updateOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<WebRtcCredential> UpdateAsync()
        {
            WebRtcCredential result = new WebRtcCredential();
            try
            {
                var updateOptions = new TelephonyCredentialUpdateOptions()
                {
                    ConnectionId = "987654321",
                    ExpiresAt = "2018-02-02T22:25:27.521Z",
                    Name = "My Creds",
                };

                result = await service.UpdateAsync(id, updateOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public WebRtcCredential Delete()
        {
            WebRtcCredential result = new WebRtcCredential();

            try
            {
                result = service.Delete(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<WebRtcCredential> DeleteAsync()
        {
            WebRtcCredential result = new WebRtcCredential();

            try
            {
                result = await service.DeleteAsync(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public string GetToken()
        {
            string result = string.Empty;

            try
            {
                var requestOptions = new RequestOptions();

                result = service.GetToken(id, requestOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<string> GetTokenAsync()
        {
            string result = string.Empty;

            try
            {
                var requestOptions = new RequestOptions();

                result = await service.GetTokenAsync(id, requestOptions, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }
    }
}
