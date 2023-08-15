namespace TelnyxTests.Services.Notifications.Notifications.UpdateTheEmergencySettingsFromABatchOfNumberss

{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.PhoneNumbers.NumberBackgroundJobs;
    using Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs;
    using Xunit;

    /// <summary>
    /// Test class for UpdateTheEmergencySettingsFromABatchOfNumbersTest.
    /// </summary>
    public class UpdateTheEmergencySettingsFromABatchOfNumbersTest : BaseTelnyxTest
    {
        private readonly NumberBackgroundJobService service;
        private readonly UpdateTheEmergencySettingsFromABatchOfNumbersOptions UpdateTheEmergencySettingsFromABatchOfNumbersOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public UpdateTheEmergencySettingsFromABatchOfNumbersTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new NumberBackgroundJobService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.UpdateTheEmergencySettingsFromABatchOfNumbersOptions = new UpdateTheEmergencySettingsFromABatchOfNumbersOptions()
            {
                PhoneNumber = new List<string>
                {
                    "+18665552368",
                },
                EmergencyAddressId = "dc8e4d67-33a0-4cbb-af74-7b58f05bd494",
                EmergencyEnabled = false,
            };
        }

        [Fact]
        public void Update()
        {
            var result = this.service.UpdateTheEmergencySettingsFromABatchOfNumbers(this.UpdateTheEmergencySettingsFromABatchOfNumbersOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberBackgroundJob), result.GetType());
        }

        [Fact]
        public async Task UpdateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.UpdateTheEmergencySettingsFromABatchOfNumbersAsync(this.UpdateTheEmergencySettingsFromABatchOfNumbersOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(NumberBackgroundJob), result.GetType());
        }
    }
}
