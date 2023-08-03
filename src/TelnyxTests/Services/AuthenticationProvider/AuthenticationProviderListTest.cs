namespace TelnyxTests.Services.AuthenticationProvider
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.AuthenticationProviders;
    using Telnyx.net.Entities.Enum.AuthenticationProviders;
    using Telnyx.net.Services.AuthentictionProvider;
    using Xunit;

    /// <summary>
    /// Test class for AuthenticationProvider.
    /// </summary>
    public class AuthenticationProviderListTest : BaseTelnyxTest
    {
        private readonly AuthenticationProviderService service;
        private readonly AuthenticationProviderListOption AuthenticationProviderListOption;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public AuthenticationProviderListTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AuthenticationProviderService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.AuthenticationProviderListOption = new AuthenticationProviderListOption()
            {
                Sort = Sort.Name,
            };
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListAuthenticationProviders(this.AuthenticationProviderListOption, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<AuthenticationProviders>), result.GetType());
            foreach (var items in result.Data)
            {
                var expectedDateTime = new DateTime(2018, 2, 2, 22, 25, 27, 521);
                Assert.True(items.Active);
                Assert.Equal("https://api.telnyx.com/sso/saml/auth/myorg", items.Settings.AssertionConsumerServiceUrl);
                Assert.Equal("urn:oasis:names:tc:SAML:1.1:nameid-format", items.Settings.NameIdentifierFormat);
                Assert.Equal("https://api.telnyx.com/sso/saml/metadata/myorg", items.Settings.ServiceProviderEntityId);
                Assert.Equal("https://myorg.myidp.com/trust/saml2/http-post/sso", items.Settings.IdpSsoTargetUrl);
                Assert.Equal("13:38:C7:BB:C9:FF:4A:70:38:3A:E3:D9:5C:CD:DB:2E:50:1E:80:A7", items.Settings.IdpCertFingerprint);
                Assert.Equal("sha1", items.Settings.IdpCertFingerprintAlgorithm);
                Assert.Equal("https://myorg.myidp.com/saml/metadata", items.Settings.IdpEntityId);
                Assert.Equal("urn:oasis:names:tc:SAML:1.1:nameid-format", items.Settings.NameIdentifierFormat);
                Assert.Equal("myorg", items.ShortName);
                Assert.Equal("Okta", items.Name);
                Assert.Equal(new Guid("35146afd-df93-4963-b1e9-1a085e2ae874"), items.Id);
                Assert.Equal(new Guid("24b4a4bb-c4df-46ad-bbcb-23fc741c5ad7"), items.OrganizationId);
                Assert.Equal("authentication_provider", items.RecordType);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
                Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
            }
        }

        [Fact]
        public async Task ListSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListAuthenticationProvidersAsync(this.AuthenticationProviderListOption, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<AuthenticationProviders>), result.GetType());
            var expectedDateTime = new DateTime(2018, 2, 2, 22, 25, 27, 521);
            foreach (var items in result.Data)
            {
                Assert.True(items.Active);
                Assert.Equal("https://api.telnyx.com/sso/saml/auth/myorg", items.Settings.AssertionConsumerServiceUrl);
                Assert.Equal("urn:oasis:names:tc:SAML:1.1:nameid-format", items.Settings.NameIdentifierFormat);
                Assert.Equal("https://api.telnyx.com/sso/saml/metadata/myorg", items.Settings.ServiceProviderEntityId);
                Assert.Equal("https://myorg.myidp.com/trust/saml2/http-post/sso", items.Settings.IdpSsoTargetUrl);
                Assert.Equal("13:38:C7:BB:C9:FF:4A:70:38:3A:E3:D9:5C:CD:DB:2E:50:1E:80:A7", items.Settings.IdpCertFingerprint);
                Assert.Equal("sha1", items.Settings.IdpCertFingerprintAlgorithm);
                Assert.Equal("https://myorg.myidp.com/saml/metadata", items.Settings.IdpEntityId);
                Assert.Equal("urn:oasis:names:tc:SAML:1.1:nameid-format", items.Settings.NameIdentifierFormat);
                Assert.Equal("myorg", items.ShortName);
                Assert.Equal("Okta", items.Name);
                Assert.Equal(new Guid("35146afd-df93-4963-b1e9-1a085e2ae874"), items.Id);
                Assert.Equal(new Guid("24b4a4bb-c4df-46ad-bbcb-23fc741c5ad7"), items.OrganizationId);
                Assert.Equal("authentication_provider", items.RecordType);
                Assert.Equal(expectedDateTime.ToString("s") + "Z", items.UpdatedAt.ToString("s") + "Z");
                Assert.Equal(expectedDateTime.ToString("s") + "Z", items.CreatedAt.ToString("s") + "Z");
            }
        }
    }
}