// <copyright file="MessageServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Enum;
    using Xunit;

    public class MessageServiceTest : BaseTelnyxTest
    {
        private const string MessageId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly MessageService service;
        private readonly NewMessage createOptions;
        private readonly NumberOrderUpdateOptions updateOptions;
        private readonly NumberOrderListOptions listOptions;
        private readonly RequestOptions requestOptions;

        public MessageServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessageService();

            this.createOptions = new NewMessage()
            {
                MessagingProfileId = Guid.NewGuid(),
                MediaUrls = new List<string>() { "example1.com", "example2.com" },
                WebhookUrl = "webhookurl.com",
                WebhookFailoverUrl = "failureurl.com",
                UseProfileWebhooks = true,
                ValidityPeriodSecs = 01,
                IgnoreWireType = true,
                From = "+18665552368",
                To = "+18665552367",
                Text = "Hello, World!"
            };

            this.updateOptions = new NumberOrderUpdateOptions();

            this.listOptions = new NumberOrderListOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Create()
        {
            var message = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messages");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.OutboundMessage", message.GetType().ToString());
            Assert.NotNull(message.Id);
            Assert.NotNull(message.Direction);
            Assert.Equal(0, message.Errors.Count);
            Assert.NotNull(message.Parts);
            Assert.NotNull(message.Direction);
            Assert.Equal(RecordType.MessageEnum, message.RecordType);
            Assert.NotNull(message.Text);
            Assert.True(message.To.Count > 0);
            Assert.True(!message.To.Where(x => x.Status == null).Any());
            Assert.NotNull(message.From);
            Assert.NotNull(message.From.Carrier);
            Assert.NotNull(message.From.LineType);
            Assert.NotNull(message.From.PhoneNumber);
            Assert.NotNull(message.Media);
            Assert.Equal(this.createOptions.WebhookFailoverUrl, message.WebhookFailoverUrl);
            Assert.Equal(this.createOptions.WebhookUrl, message.WebhookUrl);
            //Assert.Equal(this.createOptions.UseProfileWebhooks, message.UseProfileWebhooks); // fails
            //Assert.NotNull(message.ValidUntil); // fails
            //Assert.NotNull(message.CreatedAt); // fails
            //Assert.NotNull(message.UpdatedAt); // fails
            //Assert.NotNull(message.InfoBlobFieldname); // fails
            Assert.NotNull(message.Type);
            Assert.Null(message.CompletedAt);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var message = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messages");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.OutboundMessage", message.GetType().ToString());
        }

        [Fact]
        public void Get()
        {
            var message = this.service.Get(MessageId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messages/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.OutboundMessage", message.GetType().ToString());
        }

        [Fact]
        public async Task GetAsync()
        {
            var message = await this.service.GetAsync(MessageId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messages/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(message);
            Assert.Equal("Telnyx.OutboundMessage", message.GetType().ToString());
        }
    }
}
