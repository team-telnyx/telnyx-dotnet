namespace TelnyxTests.Services.Calls.ConferenceCommands.EnableManagedAccounts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.ManagedAccounts;
    using Telnyx.net.Services.ManagedAccounts;
    using Xunit;

    /// <summary>
    /// Test class for EnableManagedAccounts.
    /// </summary>
    public class EnableManagedAccountsTest : BaseTelnyxTest
    {
        private readonly EnableManagedAccountService service;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public EnableManagedAccountsTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new EnableManagedAccountService();

            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Enable()
        {
            var result = this.service.EnableManagedAccount(Id, this.requestOptions);
            AssertResponse(result);
        }

        [Fact]
        public async Task EnableAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.EnableManagedAccountAsync(Id, this.requestOptions, cts.Token);
            AssertResponse(result);
        }

        private static void AssertResponse(ManagedAccount result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(ManagedAccount), result.GetType());
            Assert.Equal("KEY01236170692E74656C6E79782E636F6D_YmlnIGlyb24gaXMgZGVhZA", result.ApiKey);
            Assert.Equal("x6oexQNHTs-fZ7-QsDMOeg", result.ApiToken);
            Assert.Equal("managed_account@example.com", result.ApiUser);
            Assert.Equal(300, result.Balance.AccountBalance);
            Assert.Equal(400, result.Balance.AvailableCredit);
            Assert.Equal(100, result.Balance.CreditLimit);
            Assert.Equal("USD", result.Balance.Currency);
            Assert.Equal("balance", result.Balance.RecordType);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.CreatedAt);
            Assert.Equal("user@example.com", result.Email);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.Id);
            Assert.True(result.ManagedAccountAllowCustomPricing);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.ManagerAccountId);
            Assert.Equal("Example Company LLC", result.OrganizationName);
            Assert.Equal("managed_account", result.RecordType);
            Assert.False(result.RollupBilling);
            Assert.Equal("2018-02-02T22:25:27.521Z", result.UpdatedAt);
        }
    }
}
