//using System.Threading.Tasks;
//using Telnyx;
//using Telnyx.net.Entities;
//using Telnyx.net.Services.AccessTokens;

//using Xunit;
//using System.Threading;
//using Telnyx.net.Entities.AccessToken;
//using Castle.Core.Resource;
//using System;

//namespace TelnyxTests.Services.AccessToken
//{
//    /// <summary>
//    /// Test class for AccessToken.
//    /// </summary>
//    public class AccessTokenTest : BaseTelnyxTest
//    {
//        private readonly AccessTokensService service;
//        private readonly RequestOptions requestOptions;
//        private readonly BaseOptions baseOptions;
//        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

//        public AccessTokenTest(MockHttpClientFixture mockHttpClientFixture)
//            : base(mockHttpClientFixture)
//        {
//            this.service = new AccessTokensService();
//            this.baseOptions = new BaseOptions();
//            this.requestOptions = new RequestOptions();
//        }
//        [Fact]
//        public void Create()
//        {
//            var result = this.service.CreateAccessToken(Id, this.requestOptions);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(AccessTokensService), result.GetType());
//        }

//        [Fact]
//        public async Task CreateSync()
//        {
//            var cts = new CancellationTokenSource();
//            var result = await this.service.CreateAccessTokenAsync(Id, this.requestOptions, cts.Token);
//            Assert.NotNull(result);
//            Assert.Equal(typeof(AccessTokensService), result.GetType());


//        }
//    }
//}