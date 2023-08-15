// <copyright file="RequestorTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using Telnyx;
    using Telnyx.Infrastructure;
    using Xunit;

    public class RequestorTest : BaseTelnyxTest
    {
        [Fact]
        public void SetsHeaders()
        {
            RequestOptions options = new RequestOptions
            {
                ApiKey = "TESTKEY",
                IdempotencyKey = "123",
            };
            var request = Requestor.GetRequestMessage("http://localhost", HttpMethod.Get, options);
            Assert.NotNull(request);
            Assert.Equal($"Bearer {options.ApiKey}", request.Headers.GetValues("Authorization").FirstOrDefault());
            Assert.Equal(options.IdempotencyKey, request.Headers.GetValues("Idempotency-Key").FirstOrDefault());
            Assert.Equal(TelnyxConfiguration.TelnyxApiVersion, request.Headers.GetValues("Telnyx-Version").FirstOrDefault());
        }

        [Fact]
        public void BuildTelnyxException()
        {
            var telnyxResponse = new TelnyxResponse()
            {
                ObjectJson = "{\"a\":\"x\", \"b\":\"y\", \"z\":\"c\"}",
                RequestId = "1",
                RequestDate = DateTime.Now,
                ResponseJson = "{\"a\":\"x\", \"b\":\"y\", \"z\":\"c\"}",
                Url = "https://www.example.com"
            };
            //Requestor.BuildTelnyxException(telnyxResponse, HttpStatusCode.BadRequest, "https://www.example.com", "");
        }

        [Fact]
        public void PostFile()
        {
            byte[] bytes = null;
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);
                tw.Write("blabla");
                tw.Flush();
                ms.Position = 0;

                try
                {
                    var response = Requestor.PostFile("https://api.telnyx.com/v2/telephony_credentials/12345", ms, "test", new RequestOptions());
                }
                catch (Exception ex)
                {
                    Assert.Equal(typeof(TelnyxException), ex.GetType());
                    var actualException = (TelnyxException)ex;
                    var telError = actualException.TelnyxErrors.First();
                    Assert.Equal(typeof(TelnyxError), telError.GetType());
                    Assert.NotNull(telError.Code);
                    Assert.NotNull(telError.ErrorDetail);
                    Assert.NotNull(telError.ErrorTitle);
                    Assert.Null(telError.ChargeId);
                    Assert.Null(telError.DeclineCode);
                    Assert.Null(telError.Message);
                    Assert.Null(telError.Parameter);
                    Assert.Null(telError.Error);
                    Assert.Null(telError.ErrorType);
                    Assert.Null(telError.RequestUri);
                    Assert.Null(telError.TelnyxResponse);
                }
            }
        }

        [Fact]
        public void PostFileAsync()
        {
            byte[] bytes = null;
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);
                tw.Write("blabla");
                tw.Flush();
                ms.Position = 0;

                try
                {
                    var response = Requestor.PostFileAsync("https://api.telnyx.com/v2/telephony_credentials/12345", ms, "test", new RequestOptions()).Result;
                }
                catch (Exception ex)
                {
                    Assert.Equal(typeof(TelnyxException), ex.InnerException.GetType());
                    var actualException = (TelnyxException)ex.InnerException;
                    var telError = actualException.TelnyxErrors.First();
                    Assert.Equal(typeof(TelnyxError), telError.GetType());
                    Assert.NotNull(telError.Code);
                    Assert.NotNull(telError.ErrorDetail);
                    Assert.NotNull(telError.ErrorTitle);
                    Assert.Null(telError.ChargeId);
                    Assert.Null(telError.DeclineCode);
                    Assert.Null(telError.Message);
                    Assert.Null(telError.Parameter);
                    Assert.Null(telError.Error);
                    Assert.Null(telError.ErrorType);
                    Assert.Null(telError.RequestUri);
                    Assert.Null(telError.TelnyxResponse);
                }
            }
        }
    }
}
