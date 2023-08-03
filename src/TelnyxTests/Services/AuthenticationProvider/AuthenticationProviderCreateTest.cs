namespace TelnyxTests.Services.AuthenticationProvider
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Entities.AuthenticationProviders;
    using Telnyx.net.Services.AuthentictionProvider;
    using Xunit;

    /// <summary>
    /// Test class for AuthenticationProvider.
    /// </summary>
    public class AuthenticationProviderCreateTest : BaseTelnyxTest
    {
        private readonly AuthenticationProviderService service;
        private readonly AuthenticationProviderCreateOption AuthenticationProviderCreateOption;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private const string Id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public AuthenticationProviderCreateTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new AuthenticationProviderService();
            this.baseOptions = new BaseOptions();
            this.requestOptions = new RequestOptions();
            this.AuthenticationProviderCreateOption = new AuthenticationProviderCreateOption()
            {
                Active = true,
                Name = "Okta",
                Settings = new SettingsObject
                {
                    AssertionConsumerServiceUrl = "https://api.telnyx.com/sso/saml/auth/myorg",
                    IdpCertFingerprint = "https://api.telnyx.com/sso/saml/metadata/myorg",
                    IdpCertFingerprintAlgorithm = "sha1",
                    IdpEntityId = "https://myorg.myidp.com/saml/metadata",
                    IdpSsoTargetUrl = "https://myorg.myidp.com/trust/saml2/http-post/sso",
                    NameIdentifierFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format",
                    ServiceProviderEntityId = "https://api.telnyx.com/sso/saml/metadata/myorg",
                },
                SettingsUrl = "https://myorg.myidp.com/saml/metadata",
                ShortName = "myord",
            };
        }

        [Fact]
        public void Create()
        {
            var result = this.service.CreateAuthenticationProviders(this.AuthenticationProviderCreateOption, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var items = result;
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

        [Fact]
        public async Task CreateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.CreateAuthenticationProvidersAsync(this.AuthenticationProviderCreateOption, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var expectedDateTime = new DateTime(2018, 2, 2, 22, 25, 27, 521);
            var items = result;
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

        [Fact]
        public void Delete()
        {
            var result = this.service.DeleteAuthenticationProviders(Id, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var items = result;
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

        [Fact]
        public async Task DeleteSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.DeleteAuthenticationProvidersAsync(Id, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var expectedDateTime = new DateTime(2018, 2, 2, 22, 25, 27, 521);
            var items = result;
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

        [Fact]
        public void Update()
        {
            var result = this.service.UpdateAuthenticationProviders(Id, this.AuthenticationProviderCreateOption, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var items = result;
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

        [Fact]
        public async Task UpdateSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.UpdateAuthenticationProvidersAsync(Id, this.AuthenticationProviderCreateOption, this.requestOptions, cts.Token);
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var expectedDateTime = new DateTime(2018, 2, 2, 22, 25, 27, 521);
            var items = result;
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

        [Fact]
        public void Retrieve()
        {
            var result = this.service.RetrieveAuthenticationProviders(Id, this.requestOptions);
            RetrieveAsserts(result);
        }

        [Fact]
        public async Task RetrieveSync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.RetrieveAuthenticationProvidersAsync(Id, this.requestOptions, cts.Token);
            RetrieveAsserts(result);
        }

        public static void RetrieveAsserts(AuthenticationProviders result)
        {
            Assert.NotNull(result);
            Assert.Equal(typeof(AuthenticationProviders), result.GetType());
            var items = result;
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
}