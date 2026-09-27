namespace TelnyxTests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Telnyx.net.Entities.ManagedAccounts;
    using Telnyx.net.Services.ManagedAccounts;
    using Telnyx.net.Services.Messaging.Messaging_Profiles.Metrics;
    using Xunit;

    /// <summary>
    /// Current pinned-contract controls, separate from historical response compatibility.
    /// Every response comes from the real current-spec HTTP mock, never a canned success.
    /// Expected incompatibilities below document SDK limitations; passing them does NOT
    /// mean those legacy methods are supported by the current API (or deployed API).
    /// </summary>
    [Collection("Telnyx-mock tests")]
    [Trait("Contract", "current-pinned")]
    public class CurrentContractCompatibilityTest
    {
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public static IEnumerable<object[]> RetiredOperations()
        {
            foreach (var operation in new[] { "documents", "regions", "mdr", "campaigns", "channel-numbers", "channel-read", "allowed-ips", "provision", "bulk", "register" })
            {
                yield return new object[] { operation, false };
                yield return new object[] { operation, true };
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ManagedAccounts_CurrentListOmitsLegacyCredentials(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new ManagedAccountService();
            var options = new ManagedAccountListOptions { Sort = "created_at", IncludeCancelledAccounts = false };
            var result = asynchronous ? await service.ListManagedAccountsAsync(options) : service.ListManagedAccounts(options);
            wire.AssertResponse("GET", "/managed_accounts", 200);
            var raw = Assert.Single((JArray)wire.Json["data"]);
            Assert.Null(raw["api_key"]);
            Assert.Null(raw["api_token"]);
            var account = Assert.Single(result.Data);
            Assert.Equal((string)raw["id"], account.Id);
            Assert.Equal("f65ceda4-6522-4ad6-aede-98de83385123", account.Id);
            Assert.Equal((string)raw["email"], account.Email);
            Assert.Equal((string)raw["api_user"], account.ApiUser);
            Assert.Equal("managed_account", account.RecordType);
            Assert.Null(account.ApiKey);
            Assert.Null(account.ApiToken);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task MessagingMetrics_CurrentEmptySchemaDoesNotSupplyLegacyDetail(bool asynchronous, bool facade)
        {
            using var wire = new CurrentWire();
            object result = null;
            var error = await Record.ExceptionAsync(async () =>
            {
                if (facade)
                {
                    var service = new MessagingProfileMetricsService();
                    result = asynchronous ? await service.GetDetailedMetricsAsync(Id, null) : service.GetDetailedMetrics(Id, null);
                }
                else
                {
                    var service = new MessagingProfileMetricsDetailService();
                    result = asynchronous ? await service.GetByIdAsync(Id, null, null) : service.GetById(Id, null, null);
                }
            });
            wire.AssertResponse("GET", "/messaging_profiles/" + Id + "/metrics", 200);
            Assert.Empty(wire.Json.Properties());

            // Missing data is silently returned as null by the legacy deserializer.
            Assert.Null(result);
            Assert.Null(error);
        }

        [Theory]
        [MemberData(nameof(RetiredOperations))]
        public async Task RetiredOperations_CurrentMockRejectsActualSdkRequest(string operation, bool asynchronous)
        {
            using var wire = new CurrentWire();
            var error = await Record.ExceptionAsync(() => InvokeRetired(operation, asynchronous));
            var expected = RetiredRoute(operation);
            var status = (operation == "register" || operation == "channel-read") ? 405 : 404;
            wire.AssertResponse(expected.Method, expected.Path, status);
            Assert.Equal(status, (int)wire.Json["status"]);
            Assert.Equal("https://stoplight.io/prism/errors#" + (status == 405 ? "NO_METHOD_MATCHED_ERROR" : "NO_PATH_MATCHED_ERROR"), (string)wire.Json["type"]);
            var sdkError = Assert.IsType<TelnyxException>(error);
            Assert.Equal((HttpStatusCode)status, sdkError.HttpStatusCode);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CredentialTags_CurrentRouteCollidesWithCredentialId_NotAList(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new Telnyx.net.Services.WebRTC.Credentials.TelephonyCredentialTagsService();
            var error = await Record.ExceptionAsync(async () =>
            {
                if (asynchronous)
                {
                    await service.ListTelephonyCredentialAsync(null);
                }
                else
                {
                    service.ListTelephonyCredential(null);
                }
            });
            wire.AssertResponse("GET", "/telephony_credentials/tags", 200);
            Assert.Equal(JTokenType.Object, wire.Json["data"].Type);
            Assert.Equal("credential", (string)wire.Json["data"]["record_type"]);
            Assert.IsType<Newtonsoft.Json.JsonSerializationException>(error);
            Assert.Contains("Cannot deserialize the current JSON object", error.Message);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task PortingRequirements_CurrentStructuredCriteriaCannotPopulateLegacyString(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new Telnyx.net.Services.PortingOrders.PortingOrderRequirements.PortingOrderRequirementService();
            var error = await Record.ExceptionAsync(async () =>
            {
                if (asynchronous)
                {
                    await service.ListAsync(Id);
                }
                else
                {
                    service.List(Id);
                }
            });
            wire.AssertResponse("GET", "/porting_orders/" + Id + "/requirements", 200);
            var item = Assert.Single((JArray)wire.Json["data"]);
            Assert.Equal(JTokenType.Object, item["requirement_type"]["acceptance_criteria"].Type);
            Assert.IsType<Newtonsoft.Json.JsonReaderException>(error);
            Assert.Contains("acceptance_criteria", error.Message);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CdrUsage_CurrentObjectPreservedAsSingletonList(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new Telnyx.net.Services.Reports.ReportCdrUsageReportSyncs.ReportCdrUsageReportSyncService();
            var options = new Telnyx.net.Entities.Reports.ReportCdrUsageReportSyncs.ReportCdrUsageReportSyncOption
            {
                StartDate = DateTime.Parse("2018-02-02T22:25:27.521Z").ToUniversalTime(),
                EndDate = DateTime.Parse("2018-02-02T22:25:27.521Z").ToUniversalTime(),
                ProductBreakdown = "NO_BREAKDOWN",
                AggregationType = "NO_AGGREGATION",
                Connections = new long[] { 1234567890, 9876543210 },
            };
            var result = asynchronous
                ? await service.ListReportCdrUsageReportSyncAsync(options)
                : service.ListReportCdrUsageReportSync(options);
            wire.AssertResponse("GET", "/reports/cdr_usage_reports/sync", 200);
            var raw = Assert.IsType<JObject>(wire.Json["data"]);
            var report = Assert.Single(result.Data);
            Assert.Equal((string)raw["id"], report.Id.ToString());
            Assert.Equal((string)raw["record_type"], report.RecordType);
            Assert.True(JToken.DeepEquals(raw["result"], JToken.FromObject(report.Result)));
            Assert.True(JToken.DeepEquals(wire.Json, JObject.Parse(result.TelnyxResponse.ResponseJson)));
            Assert.Equal(result.TelnyxResponse.ResponseJson, report.TelnyxResponse.ResponseJson);
            Assert.Null(result.PageInfo);
            Assert.False(result.HasMore);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CsvRetrieve_CurrentArrayCannotPopulateLegacyObject(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new Telnyx.net.Services.PhoneNumbers.PhoneNumberCsvDownloadService.PhoneNumberCsvDownloadService();
            var error = await Record.ExceptionAsync(async () =>
            {
                if (asynchronous)
                {
                    await service.GetPhoneNumberCsvDownloadAsync(Id);
                }
                else
                {
                    service.GetPhoneNumberCsvDownload(Id);
                }
            });
            wire.AssertResponse("GET", "/phone_numbers/csv_downloads/" + Id, 200);
            var item = Assert.Single((JArray)wire.Json["data"]);
            Assert.Equal("csv_download", (string)item["record_type"]);
            Assert.IsType<Newtonsoft.Json.JsonSerializationException>(error);
            Assert.Contains("Cannot deserialize the current JSON array", error.Message);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task CsvCreate_CurrentArrayCannotPopulateLegacyObject(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new Telnyx.net.Services.PhoneNumbers.PhoneNumberCsvDownloadService.PhoneNumberCsvDownloadService();
            var options = new Telnyx.net.Entities.PhoneNumbers.PhoneNumberCsvDownloads.UpsertPhoneNumberCsvDownload();
            var error = await Record.ExceptionAsync(async () =>
            {
                if (asynchronous)
                {
                    await service.CreatePhoneNumberCsvDownloadAsync(options);
                }
                else
                {
                    service.CreatePhoneNumberCsvDownload(options);
                }
            });
            wire.AssertResponse("POST", "/phone_numbers/csv_downloads", 200);
            var item = Assert.Single((JArray)wire.Json["data"]);
            Assert.Equal("csv_download", (string)item["record_type"]);
            Assert.IsType<Newtonsoft.Json.JsonSerializationException>(error);
            Assert.Contains("Cannot deserialize the current JSON array", error.Message);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task SimValidation_CurrentArrayCannotPopulateLegacyObject(bool asynchronous)
        {
            using var wire = new CurrentWire();
            var service = new Telnyx.net.Services.Wireless.ValidateSIMCardsRegistrationCodes.ValidateSIMCardsRegistrationCodeService();
            var options = new Telnyx.net.Entities.Wireless.ValidateSIMCardsRegistrationCodes.UpsertValidateSIMCardsRegistrationCode
            {
                RegistrationCode = new[] { "123456780", "1231231230" },
            };
            var error = await Record.ExceptionAsync(async () =>
            {
                if (asynchronous)
                {
                    await service.CreateValidateSIMCardsRegistrationCodeAsync(options);
                }
                else
                {
                    service.CreateValidateSIMCardsRegistrationCode(options);
                }
            });
            wire.AssertResponse("POST", "/sim_cards/actions/validate_registration_codes", 200);
            var item = Assert.Single((JArray)wire.Json["data"]);
            Assert.Equal("sim_card_registration_code_validation", (string)item["record_type"]);
            Assert.IsType<Newtonsoft.Json.JsonSerializationException>(error);
            Assert.Contains("Cannot deserialize the current JSON array", error.Message);
        }

        private static (string Method, string Path) RetiredRoute(string operation)
        {
            switch (operation)
            {
                case "documents": return ("GET", "/number_order_documents");
                case "regions": return ("GET", "/virtual_cross_connect_regions");
                case "mdr": return ("GET", "/reports/batch_mdr_reports");
                case "campaigns": return ("GET", "/partnerCampaign/sharedByMe");
                case "channel-read": return ("GET", "/channel_zones/" + Id);
                case "channel-numbers": return ("GET", "/channel_zones/" + Id + "/channel_zone_phone_numbers");
                case "allowed-ips": return ("GET", "/wireguard_peers/" + Id + "/allowed_ips");
                case "provision": return ("POST", "/virtual_cross_connects/" + Id + "/actions/provision");
                case "bulk": return ("POST", "/actions/bulk/telephony_credentials");
                case "register": return ("POST", "/calls/register");
                default: throw new ArgumentOutOfRangeException(nameof(operation));
            }
        }

        private static async Task InvokeRetired(string operation, bool asynchronous)
        {
            switch (operation)
            {
                case "documents":
                    var documents = new Telnyx.net.Services.NumberOrderDocuments.NumberOrderDocumentService();
                    if (asynchronous)
                    {
                        await documents.ListNumberOrderDocumentsAsync(null);
                    }
                    else
                    {
                        documents.ListNumberOrderDocuments(null);
                    }

                    break;
                case "regions":
                    var regions = new Telnyx.net.Services.VirtualCrossConnectCloudRegions.VirtualCrossConnectCloudRegionService();
                    if (asynchronous)
                    {
                        await regions.ListVirtualCrossConnectCloudRegionAsync(null);
                    }
                    else
                    {
                        regions.ListVirtualCrossConnectCloudRegion(null);
                    }

                    break;
                case "mdr":
                    var mdr = new Telnyx.net.Services.Reports.ReportBatchMdrReports.ReportBatchMdrReportService();
                    if (asynchronous)
                    {
                        await mdr.ListReportBatchMdrReportAsync(null);
                    }
                    else
                    {
                        mdr.ListReportBatchMdrReport(null);
                    }

                    break;
                case "campaigns":
                    var campaigns = new Telnyx.net.Services.PhoneNumbers.Campaigns.PartnerCampaign.PartnerCampaignSharedByMeService();
                    if (asynchronous)
                    {
                        await campaigns.ListPartnerCampaignSharedByMeAsync(null);
                    }
                    else
                    {
                        campaigns.ListPartnerCampaignSharedByMe(null);
                    }

                    break;
                case "channel-read":
                    var zones = new ChannelZoneService();
                    if (asynchronous) await zones.GetAsync(Id);
                    else zones.Get(Id);
                    break;
                case "channel-numbers":
                    var numbers = new Telnyx.net.Services.ChannelZones.ChannelZonePhoneNumberService();
                    if (asynchronous)
                    {
                        await numbers.ListAsync(Id);
                    }
                    else
                    {
                        numbers.List(Id);
                    }

                    break;
                case "allowed-ips":
                    var ips = new Telnyx.net.Services.PhoneNumbers.WireGuardPeersallowedIps.WireGuardPeersallowedIpService();
                    if (asynchronous)
                    {
                        await ips.ListAsync(Id);
                    }
                    else
                    {
                        ips.List(Id);
                    }

                    break;
                case "provision":
                    var provision = new Telnyx.net.Services.VirtualCrossConnects.ProvisionVirtualCrossConnectService();
                    if (asynchronous)
                    {
                        await provision.CreateAsync(Id, null, null, "data", CancellationToken.None);
                    }
                    else
                    {
                        provision.Create(Id, null, null);
                    }

                    break;
                case "bulk":
                    var bulk = new Telnyx.net.Services.PhoneNumbers.BulkTelephonyCredentials.BulkTelephonyCredentialSevice();
                    var bulkOptions = new Telnyx.net.Entities.PhoneNumbers.BulkTelephonyCredentials.UpsertBulkTelephonyCredential();
                    if (asynchronous)
                    {
                        await bulk.CreateUpsertBulkTelephonyCredentialAsync(bulkOptions);
                    }
                    else
                    {
                        bulk.CreateUpsertBulkTelephonyCredential(bulkOptions);
                    }

                    break;
                case "register":
                    var register = new Telnyx.net.Services.PhoneNumbers.CallRegisters.CallRegisterService();
                    var registerOptions = new Telnyx.net.Entities.PhoneNumbers.CallRegisters.UpsertCallRegister();
                    if (asynchronous)
                    {
                        await register.CreateCallRegisterAsync(registerOptions);
                    }
                    else
                    {
                        register.CreateCallRegister(registerOptions);
                    }

                    break;
                default: throw new ArgumentOutOfRangeException(nameof(operation));
            }
        }

        // Observes (but never replaces) real HTTP response bytes. Global SDK configuration
        // is restored even on failure; this class shares the nonparallel legacy collection.
        private sealed class CurrentWire : DelegatingHandler
        {
            private readonly string originalBase = TelnyxConfiguration.GetApiBase();
            private readonly string originalKey = TelnyxConfiguration.GetApiKey();
            private readonly System.Reflection.PropertyInfo clientProperty = typeof(TelnyxConfiguration).Assembly
                .GetType("Telnyx.Infrastructure.Requestor").GetProperty("HttpClient", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            private readonly HttpClient originalClient;
            private readonly HttpClient client;
            private Uri uri;
            private string method;
            private int status;
            private int requests;

            internal CurrentWire()
                : base(new HttpClientHandler { AllowAutoRedirect = false, UseProxy = false })
            {
                TelnyxConfiguration.SetApiBase("http://127.0.0.1:12111/v2");
                TelnyxConfiguration.SetApiKey("TEST_ONLY");

                // The legacy Requestor caches its client once; swapping only the public
                // handler property would silently leave later tests on an earlier client.
                this.originalClient = (HttpClient)this.clientProperty.GetValue(null);
                this.client = new HttpClient(this, disposeHandler: false);
                this.clientProperty.SetValue(null, this.client);
            }

            internal JObject Json { get; private set; }

            internal void AssertResponse(string expectedMethod, string expectedPath, int expectedStatus)
            {
                Assert.Equal(1, this.requests);
                Assert.Equal(expectedMethod, this.method);
                Assert.Equal("/v2" + expectedPath, this.uri.AbsolutePath);
                Assert.Equal(expectedStatus, this.status);
                Assert.NotNull(this.Json);
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal("127.0.0.1", request.RequestUri.Host);
                Assert.Equal(12111, request.RequestUri.Port);
                Assert.Equal("http", request.RequestUri.Scheme);
                this.requests++;
                this.uri = request.RequestUri;
                this.method = request.Method.Method;
                var response = await base.SendAsync(request, cancellationToken);
                this.status = (int)response.StatusCode;
                this.Json = JObject.Parse(await response.Content.ReadAsStringAsync());
                return response;
            }

            protected override void Dispose(bool disposing)
            {
                this.clientProperty.SetValue(null, this.originalClient);
                this.client.Dispose();
                TelnyxConfiguration.SetApiBase(this.originalBase);
                TelnyxConfiguration.SetApiKey(this.originalKey);
                base.Dispose(disposing);
            }
        }
    }
}
