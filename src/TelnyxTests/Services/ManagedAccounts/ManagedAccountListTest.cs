namespace TelnyxTests.Services.Calls.ConferenceCommands.ManagedAccountList
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.ManagedAccounts;
    using Telnyx.net.Services.ManagedAccounts;
    using Xunit;

    /// <summary>
    /// Test class for ManagedAccountList.
    /// </summary>
    public class ManagedAccountListTest : BaseTelnyxTest
    {
        private readonly ManagedAccountService service;
        private readonly ManagedAccountListOptions managedAccountListOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public ManagedAccountListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new ManagedAccountService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.managedAccountListOptions = new ManagedAccountListOptions()
            {
                EmailContains = null,
                EmailEquals = null,
                Sort = "created_at",
                IncludeCancelledAccounts = false,
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListManagedAccounts(this.managedAccountListOptions, this.requestOptions);
            AssertResponse(result);
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListManagedAccountsAsync(this.managedAccountListOptions, this.requestOptions, cts.Token);
            AssertResponse(result);
        }

        private static void AssertResponse(TelnyxList<ManagedAccount> result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<ManagedAccount>), result.GetType());
            foreach (var item in result.Data)
            {
                Assert.Equal("KEY01236170692E74656C6E79782E636F6D_YmlnIGlyb24gaXMgZGVhZA", item.ApiKey);
                Assert.Equal("x6oexQNHTs-fZ7-QsDMOeg", item.ApiToken);
                Assert.Equal("managed_account@example.com", item.ApiUser);
                Assert.Equal("02/02/2018 22:25:27", item.CreatedAt);
                Assert.Equal("user@example.com", item.Email);
                Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", item.Id);
                Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", item.ManagerAccountId);
                Assert.Equal("managed_account", item.RecordType);
                Assert.Equal("02/02/2018 22:25:27", item.UpdatedAt);
            }
        }
    }
}
