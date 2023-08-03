namespace TelnyxTests.Services.Calls.ConferenceCommands.CreateManagedAccounts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.ManagedAccounts;
    using Telnyx.net.Services.ManagedAccounts;
    using Xunit;

    /// <summary>
    /// Test class for CreateManagedAccounts.
    /// </summary>
    public class CreateManagedAccountsTest : BaseTelnyxTest
    {
        private readonly ManagedAccountService service;
        private readonly CreateManagedAccountOptions createOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public CreateManagedAccountsTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ManagedAccountService();

            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
            this.createOptions = new CreateManagedAccountOptions()
            {
                BusinessName = "Larry\'s Cat Food Inc",
                Email = "larry_cat_food@customer.org",
                ManagedAccountAllowCustomPricing = false,
                Password = "3jVjLq!tMuWKyWx4NN*CvhnB",
                RollupBilling = false,
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateManagedAccount(this.createOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ManagedAccount), result.GetType());
            Assert.Equal("KEY01236170692E74656C6E79782E636F6D_YmlnIGlyb24gaXMgZGVhZA", result.ApiKey);
            Assert.Equal("x6oexQNHTs-fZ7-QsDMOeg", result.ApiToken);
            Assert.Equal("managed_account@example.com", result.ApiUser);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.CreatedAt);
            Assert.Equal("user@example.com", result.Email);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.Id);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.ManagerAccountId);
            Assert.Equal("managed_account", result.RecordType);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.UpdatedAt);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateManagedAccountAsync(this.createOptions, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(ManagedAccount), result.GetType());
            Assert.Equal("KEY01236170692E74656C6E79782E636F6D_YmlnIGlyb24gaXMgZGVhZA", result.ApiKey);
            Assert.Equal("x6oexQNHTs-fZ7-QsDMOeg", result.ApiToken);
            Assert.Equal("managed_account@example.com", result.ApiUser);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.CreatedAt);
            Assert.Equal("user@example.com", result.Email);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.Id);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.ManagerAccountId);
            Assert.Equal("managed_account", result.RecordType);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.UpdatedAt);
        }
    }
}
