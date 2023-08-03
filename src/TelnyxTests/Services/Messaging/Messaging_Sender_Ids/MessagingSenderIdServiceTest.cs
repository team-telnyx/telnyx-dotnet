// <copyright file="MessagingSenderIdServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingSenderId
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.Enum;
    using Xunit;

    public class MessagingSenderIdServiceTest : BaseTelnyxTest
    {
        private const string MessagingSenderId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly MessagingSenderIdService service;
        private readonly NewMessagingSenderId sendMessageOptions;
        private readonly NewMessagingSenderId sendMessageUsingNumberPoolOptions;
        private readonly MessagingSenderIdListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        public MessagingSenderIdServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingSenderIdService();

            this.sendMessageOptions = new NewMessagingSenderId
            {
                From = "+18665552368", // alphanumeric sender id
                To = "+18665552367",
                Text = "Hello, World!",
                MessagingProfileId = Guid.NewGuid(),
                Subject = "Subject",
                MediaUrls = new List<string> { "https://www.url1.com", "https://www.url2.com" },
                WebhookUrl = "https://www.webhookUrl.com",
                WebhookFailoverUrl = "https://www.failureUrl.com",
                UseProfileWebhooks = true,
                AutoDetect = true,
            };

            this.sendMessageUsingNumberPoolOptions = new NewMessagingSenderId
            {
                MessagingProfileId = new Guid("dd50eba1-a0c0-4563-9925-b25e842a7cb6"),
                From = "+18665552368",
                To = "+18005550199",
                Text = "Hello, World!",
                Subject = "Subject",
                MediaUrls = new List<string> { "url1", "url2" },
                WebhookUrl = "webhookUrl",
                WebhookFailoverUrl = "failureUrl",
                UseProfileWebhooks = false
            };

            this.requestOptions = new RequestOptions();

            this.cancellationToken = default(CancellationToken);
        }

        /*
         *  Send a message -- https://api.telnyx.com/v2/messages
            Send a Long Code message
            Send a message using Number Pool
            Send a Short Code message
            Retrieve a message (Get / GetAsync) -- https://api.telnyx.com/v2/messages/%7Bid
         * */
        [Fact]
        public void Get()
        {
            var messagingSender = this.service.Get(MessagingSenderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messages/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingSender);
            Assert.Equal("Telnyx.MessagingSenderId", messagingSender.GetType().ToString());
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingSender = await this.service.GetAsync(MessagingSenderId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messages/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingSender);
            Assert.Equal("Telnyx.MessagingSenderId", messagingSender.GetType().ToString());
        }

        [Fact]
        public void SendMessage()
        {
            var messagingSender = this.service.Create(this.sendMessageOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messages");
            Assert.NotNull(messagingSender);
            Assert.Equal("Telnyx.MessagingSenderId", messagingSender.GetType().ToString());
            Assert.NotNull(messagingSender.Id);
            Assert.NotNull(messagingSender.MessagingProfileId);
            Assert.Equal(RecordType.MessageEnum, messagingSender.RecordType);
        }

        [Fact]
        public async Task SendMessageAsync()
        {
            var messagingSender = await this.service.CreateAsync(this.sendMessageOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messages");
            Assert.NotNull(messagingSender);
            Assert.Equal("Telnyx.MessagingSenderId", messagingSender.GetType().ToString());
        }

        [Fact(Skip = "Invalid request error. Corresponding service should be deprecated")]
        public void List()
        {
            var messagingList = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(messagingList);
            Assert.Single(messagingList.Data);
            Assert.Equal("Telnyx.MessagingSenderId", messagingList.Data[0].GetType().ToString());
        }
    }
}
