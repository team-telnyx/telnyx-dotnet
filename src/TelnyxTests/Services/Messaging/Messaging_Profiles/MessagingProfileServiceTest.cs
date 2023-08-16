// <copyright file="MessagingProfileServiceTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests.Services.Messages.MessagingProfiles
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles;
    using Xunit;

    public class MessagingProfileServiceTest : BaseTelnyxTest
    {
        private const string MessagingProfileId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        private readonly MessagingProfileService service;
        private readonly MessagingProfilePhoneNumbersService phoneNumbersService;
        private readonly NewMessagingProfile createOptions;
        private readonly MessagingProfileUpdate updateOptions;
        private readonly MockMessagingProfilePhoneNumbersService _mockServiceForListMethod;
        private readonly ListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly CancellationToken cancellationToken;

        public MessagingProfileServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new MessagingProfileService();
            this.phoneNumbersService = new MessagingProfilePhoneNumbersService();

            this.createOptions = new NewMessagingProfile
            {
                Name = "Profile for Messages",
                Enabled = true,
                NumberPoolSettings = new NumberPoolSettings()
                {
                    Geomatch = false,
                    LongCodeWeight = new decimal(2),
                    SkipUnhealthy = true,
                    StickySender = false,
                    TollFreeWeight = new decimal(10),
                },
                UrlShortenerSettings = new UrlShortenerSettings()
                {
                    Domain = "example.ex",
                    Prefix = "cmpny",
                    ReplaceBlackListOnly = true,
                    SendWebhooks = false,
                },
                ResourceGroupId = Guid.NewGuid(),
                WebhookApiVersion = Telnyx.net.Entities.Enum.WebhookAPIVersion.V2,
                WebhookUrl = "https://www.example.com/hooks",
                WebhookFailoverUrl = "https://www.example.com/hooks",
            };
            this.updateOptions = new MessagingProfileUpdate
            {
                Name = "Summer Campaign 2",
                Enabled = false,
                NumberPoolSettings = new NumberPoolSettings()
                {
                    Geomatch = false,
                    LongCodeWeight = new decimal(2),
                    SkipUnhealthy = false,
                    StickySender = true,
                    TollFreeWeight = new decimal(26),
                },
                UrlShortenerSettings = new UrlShortenerSettings()
                {
                    Domain = "example.px",
                    Prefix = "xyz",
                    ReplaceBlackListOnly = false,
                    SendWebhooks = true,
                },
                WhitelistedDestinations = new List<string>() { "US", "CA" },
                WebhookApiVersion = Telnyx.net.Entities.Enum.WebhookAPIVersion.V2,
                WebhookUrl = "https://webhookurlupdate.com",
                WebhookFailoverUrl = "https://backup.example.com/hooks",
            };
            this.cancellationToken = default(CancellationToken);
            this._mockServiceForListMethod = new MockMessagingProfilePhoneNumbersService();
        }

        [Fact]
        public void Create()
        {
            var messagingProfile = this.service.Create(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.GetType());
            Assert.NotNull(messagingProfile.Id);
            Assert.Equal("Profile for Messages", messagingProfile.Name);
            Assert.Equal(this.createOptions.Enabled, messagingProfile.Enabled);
            Assert.NotNull(messagingProfile.NumberPoolSettings);
            Assert.Equal(this.createOptions.NumberPoolSettings.Geomatch, messagingProfile.NumberPoolSettings.Geomatch);
            Assert.Equal(2, messagingProfile.NumberPoolSettings.LongCodeWeight);
            Assert.False(messagingProfile.NumberPoolSettings.SkipUnhealthy);
            Assert.True(messagingProfile.NumberPoolSettings.StickySender);
            Assert.Equal(10, messagingProfile.NumberPoolSettings.TollFreeWeight);
            Assert.Equal(this.createOptions.WebhookApiVersion, messagingProfile.WebhookApiVersion);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.ProfileEnum, messagingProfile.RecordType);
            Assert.Equal(this.createOptions.WebhookUrl, messagingProfile.WebhookUrl);
            Assert.Equal("https://backup.example.com/hooks", messagingProfile.WebhookFailoverUrl);
            Assert.NotNull(messagingProfile.UrlShortenerSetting);
            Assert.Equal("example.ex", messagingProfile.UrlShortenerSetting.Domain);
            Assert.Equal("cmpny", messagingProfile.UrlShortenerSetting.Prefix);
            Assert.Equal(this.createOptions.UrlShortenerSettings.ReplaceBlackListOnly, messagingProfile.UrlShortenerSetting.ReplaceBlackListOnly);
            Assert.Equal(this.createOptions.UrlShortenerSettings.SendWebhooks, messagingProfile.UrlShortenerSetting.SendWebhooks);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var messagingProfile = await this.service.CreateAsync(this.createOptions);
            //this.AssertRequest(HttpMethod.Post, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.GetType());
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Delete, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(deleted);
            Assert.Equal(typeof(MessagingProfile), deleted.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Delete, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(deleted);
            Assert.Equal(typeof(MessagingProfile), deleted.GetType());
        }

        [Fact]
        public void Get()
        {
            var messagingProfile = this.service.Get(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.GetType());
        }

        [Fact]
        public async Task GetAsync()
        {
            var messagingProfile = await this.service.GetAsync(MessagingProfileId);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.GetType());
        }

        [Fact]
        public void List()
        {
            var messagingProfile = this.service.List(this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Single(messagingProfile.Data);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var messagingProfile = await this.service.ListAsync(this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.Data[0].GetType());
            Assert.Single(messagingProfile.Data);
        }

        [Fact]
        public void Update()
        {
            var messagingProfile = this.service.Update(MessagingProfileId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.GetType());
            Assert.NotNull(messagingProfile.Id);
            Assert.Equal("Profile for Messages", messagingProfile.Name);
            Assert.Equal(this.createOptions.Enabled, messagingProfile.Enabled);
            Assert.NotNull(messagingProfile.NumberPoolSettings);
            Assert.Equal(this.createOptions.NumberPoolSettings.Geomatch, messagingProfile.NumberPoolSettings.Geomatch);
            Assert.Equal(2, messagingProfile.NumberPoolSettings.LongCodeWeight);
            Assert.False(messagingProfile.NumberPoolSettings.SkipUnhealthy);
            Assert.True(messagingProfile.NumberPoolSettings.StickySender);
            Assert.Equal(10, messagingProfile.NumberPoolSettings.TollFreeWeight);
            Assert.Equal(this.createOptions.WebhookApiVersion, messagingProfile.WebhookApiVersion);
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.ProfileEnum, messagingProfile.RecordType);
            Assert.Equal(this.createOptions.WebhookUrl, messagingProfile.WebhookUrl);
            Assert.Equal("https://backup.example.com/hooks", messagingProfile.WebhookFailoverUrl);
            Assert.NotNull(messagingProfile.UrlShortenerSetting);
            Assert.Equal("example.ex", messagingProfile.UrlShortenerSetting.Domain);
            Assert.Equal("cmpny", messagingProfile.UrlShortenerSetting.Prefix);
            Assert.Equal(this.createOptions.UrlShortenerSettings.ReplaceBlackListOnly, messagingProfile.UrlShortenerSetting.ReplaceBlackListOnly);
            Assert.Equal(this.createOptions.UrlShortenerSettings.SendWebhooks, messagingProfile.UrlShortenerSetting.SendWebhooks);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var messagingProfile = await this.service.UpdateAsync(MessagingProfileId, this.updateOptions);
            //this.AssertRequest(new HttpMethod("PATCH"), "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            Assert.NotNull(messagingProfile);
            Assert.Equal(typeof(MessagingProfile), messagingProfile.GetType());
        }

        [Fact]
        public void ListAllPhoneNumbers()
        {
            var messagingPhoneNumber = this._mockServiceForListMethod.List(MessagingProfileId, this.listOptions, this.requestOptions);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6/phone_numbers");
            Assert.NotNull(messagingPhoneNumber);
            Assert.NotNull(messagingPhoneNumber.Data[0]);
            Assert.Equal(typeof(MockMessagingPhoneNumber), messagingPhoneNumber.Data[0].GetType());
        }

        [Fact]
        public async Task ListAllPhoneNumbersAsync()
        {

            var messagingPhoneNumber = await this._mockServiceForListMethod.ListAsync(MessagingProfileId, this.listOptions, this.requestOptions, this.cancellationToken);
            //this.AssertRequest(HttpMethod.Get, "/v2/messaging_profiles/3fa85f64-5717-4562-b3fc-2c963f66afa6/phone_numbers");
            Assert.NotNull(messagingPhoneNumber);
            Assert.NotNull(messagingPhoneNumber.Data[0]);
            Assert.Equal(typeof(MockMessagingPhoneNumber), messagingPhoneNumber.Data[0].GetType());
        }
    }

    internal class MockMessagingProfilePhoneNumbersService : ServiceNested<MockMessagingPhoneNumber>,
    INestedListable<MockMessagingPhoneNumber, ListOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingProfilePhoneNumbersService"/> class.
        /// </summary>
        public MockMessagingProfilePhoneNumbersService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingProfilePhoneNumbersService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public MockMessagingProfilePhoneNumbersService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messaging_profiles/{PARENT_ID}/phone_numbers";

        /// <inheritdoc/>
        public TelnyxList<MockMessagingPhoneNumber> List(string id, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MockMessagingPhoneNumber>> ListAsync(string id, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<MockMessagingPhoneNumber> ListPaged(string id, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MockMessagingPhoneNumber>> ListPagedAsync(string id, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAutoPagingAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }

    public class MockMessagingPhoneNumber : MessagingPhoneNumber
    {
        [JsonProperty("type")]
        public new MockPhoneNumberTypeEnum? Type { get; set; }
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MockPhoneNumberTypeEnum
    {
        /// <summary>
        /// long-code
        /// </summary>
        [EnumMember(Value = "longcode")]
        LongCodeEnum = 0,

        /// <summary>
        /// toll-free
        /// </summary>
        [EnumMember(Value = "toll-free")]
        TollFreeEnum = 1,

        /// <summary>
        /// short-code
        /// </summary>
        [EnumMember(Value = "shortcode")]
        ShortCodeEnum = 2
    }
}
