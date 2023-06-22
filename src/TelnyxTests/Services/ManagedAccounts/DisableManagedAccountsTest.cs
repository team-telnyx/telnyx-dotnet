using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Services.ManagedAccounts;
using Telnyx.net.Services.Documents;
using Telnyx.net.Services.WebRTC.Credentials;
using Xunit;
using System.Threading;
using Telnyx.net.Entities.ManagedAccounts;

namespace TelnyxTests.Services.Calls.ConferenceCommands.DisableManagedAccounts
{
    /// <summary>
    /// Test class for DisableManagedAccounts.
    /// </summary>
    public class DisableManagedAccountsTest : BaseTelnyxTest
    {
        private readonly DisableManagedAccountService service;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public DisableManagedAccountsTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new DisableManagedAccountService();

            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Disable()
        {
            var result = this.service.DisableManagedAccount(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(ManagedAccount), result.GetType());
            Assert.Equal("KEY01236170692E74656C6E79782E636F6D_YmlnIGlyb24gaXMgZGVhZA", result  .ApiKey);
            Assert.Equal("USD", result.Balance.Currency);
            Assert.Equal("balance", result.Balance.RecordType);
            Assert.Equal(100, result.Balance.CreditLimit);
            Assert.Equal(300, result.Balance.AccountBalance);
            Assert.Equal(300, result.Balance.AvailableCredit);
            Assert.Equal("managed_account", result.RecordType);
            Assert.Equal(Id, result.Id);
            Assert.Equal("user@example.com", result.Email);
            Assert.Equal("managed_account@example.com", result.ApiUser);
            Assert.Equal("x6oexQNHTs-fZ7-QsDMOeg", result.ApiToken);
            Assert.Equal("Example Company LLC", result.OrganizationName);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.ManagerAccountId);
        }

        [Fact]
        public async Task DisableAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DisableManagedAccountAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(ManagedAccount), result.GetType());
            Assert.Equal("KEY01236170692E74656C6E79782E636F6D_YmlnIGlyb24gaXMgZGVhZA", result.ApiKey);
            Assert.Equal("USD", result.Balance.Currency);
            Assert.Equal("balance", result.Balance.RecordType);
            Assert.Equal(100, result.Balance.CreditLimit);
            Assert.Equal(300, result.Balance.AccountBalance);
            Assert.Equal(300, result.Balance.AvailableCredit);
            Assert.Equal("managed_account", result.RecordType);
            Assert.Equal(Id, result.Id);
            Assert.Equal("user@example.com", result.Email);
            Assert.Equal("managed_account@example.com", result.ApiUser);
            Assert.Equal("x6oexQNHTs-fZ7-QsDMOeg", result.ApiToken);
            Assert.Equal("Example Company LLC", result.OrganizationName);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", result.ManagerAccountId);
        }
    }
}
