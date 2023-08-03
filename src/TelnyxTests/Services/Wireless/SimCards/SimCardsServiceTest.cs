namespace TelnyxTests.Services.Wireless.SimCards
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.OTAUpdates;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards;
    using Xunit;

    public class SimCardsServiceTest : BaseTelnyxTest
    {
        private readonly SimCardsService service;
        private readonly ListOptions listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private readonly UpdateSimCardOptions updateSimCardOptions;
        private readonly SimCardRegisterOptions simCardRegisterOptions;
        private readonly SimCardBulkNetworkPreferenceUpdateOptions simCardBulkNetworkPreferenceUpdateOptions;

        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardsServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardsService();

            this.listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20,
            };

            this.baseOptions = new BaseOptions();
            this.baseOptions.AddExtraParam("include_sim_card_group", "true");

            this.requestOptions = new RequestOptions();
            this.updateSimCardOptions = new UpdateSimCardOptions()
            {
                Id = "001",
                SimCardGroupId = Guid.NewGuid(),
                Tags = new List<string>()
                {
                    "personal",
                    "active-customers",
                },
            };

            this.simCardRegisterOptions = new SimCardRegisterOptions
            {
                RegistrationCodes = new string[]
                {
                    "0000000001",
                    "0000000002",
                    "0000000003",
                },
                SimCardGroupId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58",
                Tags = new string[]
                {
                    "personal",
                    "customers",
                    "active-customers",
                },
            };

            this.simCardBulkNetworkPreferenceUpdateOptions = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new string[]
               {
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
               },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };
        }

        [Fact(Skip = "Mock not working")]
        public void Get()
        {
            var result = this.service.Get(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public async Task GetAsync()
        {
            var result = await this.service.GetAsync(Id, this.baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public void List()
        {
            var result = this.service.List(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.Data[0].GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var result = await this.service.ListAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.Data[0].GetType());
        }

        [Fact]
        public void Delete()
        {
            var result = this.service.Delete(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public void Update()
        {
            var result = this.service.Update(Id, this.updateSimCardOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
            Assert.Equal(Telnyx.net.Entities.Enum.RecordType.SimCard, result.RecordType);
            Assert.NotNull(result.Iccid);
            Assert.NotNull(result.Imsi);
            Assert.NotNull(result.Msisdn);
            Assert.NotNull(result.Tags);
            Assert.NotNull(result.Status);
            Assert.NotNull(result.CreatedAt);
            Assert.NotNull(result.UpdatedAt);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var result = await this.service.UpdateAsync(Id, this.updateSimCardOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var result = await this.service.DeleteAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public void Enable()
        {
            var result = this.service.Enable(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public async Task EnableAsync()
        {
            var result = await this.service.EnableAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public void Disable()
        {
            var result = this.service.Disable(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public async Task DisableAsync()
        {
            var result = await this.service.DisableAsync(Id);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public void Register()
        {
            var result = this.service.Register(this.simCardRegisterOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SimCardRecord>), result.GetType());
        }

        [Fact]
        public async Task RegisterAsync()
        {
            var result = await this.service.RegisterAsync(this.simCardRegisterOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<SimCardRecord>), result.GetType());
        }

        [Fact]
        public void BulkUpdateNetworkPreference()
        {
            var result = this.service.BulkUpdateNetworkPreference(this.simCardBulkNetworkPreferenceUpdateOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<MobileOperatorNetworksPreferencesRecord>), result.GetType());
        }

        [Fact]
        public async Task BulkUpdateNetworkPreferenceAsync()
        {
            var result = await this.service.BulkUpdateNetworkPreferenceAsync(this.simCardBulkNetworkPreferenceUpdateOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxCollection<MobileOperatorNetworksPreferencesRecord>), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public void GetNetworkPreference()
        {
            var baseOptions = new BaseOptions();
            baseOptions.AddExtraParam("include_ota_updates", "true");
            var result = this.service.GetNetworkPreference(Id, baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact(Skip = "Mock not working")]
        public async Task GetNetworkPreferenceAsync()
        {
            var baseOptions = new BaseOptions();
            baseOptions.AddExtraParam("include_ota_updates", "true");
            var result = await this.service.GetNetworkPreferenceAsync(Id, baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(SimCardRecord), result.GetType());
        }

        [Fact]
        public void SetNetworkPreference()
        {
            var baseOptions = new SimCardNetworkPreferenceUpdateOptions
            {
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };
            var result = this.service.SetNetworkPreference(Id, baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public async Task SetNetworkPreferenceAsync()
        {
            var baseOptions = new SimCardNetworkPreferenceUpdateOptions
            {
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };
            var result = await this.service.SetNetworkPreferenceAsync(Id, baseOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public void DeleteNetworkPreference()
        {
            var result = this.service.DeleteNetworkPreference(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }

        [Fact]
        public async Task DeleteNetworkPreferenceAsync()
        {
            var result = await this.service.DeleteNetworkPreferenceAsync(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(MobileOperatorNetworksPreferencesRecord), result.GetType());
        }
    }
}
