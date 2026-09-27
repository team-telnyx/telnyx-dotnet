using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk;

/// <summary>
/// A client for interacting with the Telnyx REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITelnyxClient
: IDisposable{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    string? PublicKey { get; init; }

    string? ClientID { get; init; }

    string? ClientSecret { get; init; }

    /// <summary>
    /// Complete Payment authorization credential. Only sent to Payment-enabled operations.
    /// Bearer takes precedence when both are set; clear ApiKey on a scoped WithOptions
    /// copy for an explicit paid retry. Never constructed or retried automatically.
    /// </summary>
    string? PaymentAuthorization { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITelnyxClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelnyxClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ILegacyService Legacy { get; }

    IOAuthService OAuth { get; }

    IOAuthClientService OAuthClients { get; }

    IOAuthGrantService OAuthGrants { get; }

    IWebhookService Webhooks { get; }

    IAccessIPAddressService AccessIPAddress { get; }

    IAccessIPRangeService AccessIPRanges { get; }

    IActionService Actions { get; }

    IAddressService Addresses { get; }

    IAdvancedOrderService AdvancedOrders { get; }

    IAIService AI { get; }

    IAuditEventService AuditEvents { get; }

    IAuthenticationProviderService AuthenticationProviders { get; }

    IAvailablePhoneNumberBlockService AvailablePhoneNumberBlocks { get; }

    IAvailablePhoneNumberService AvailablePhoneNumbers { get; }

    IBalanceService Balance { get; }

    IBillingGroupService BillingGroups { get; }

    IBulkSimCardActionService BulkSimCardActions { get; }

    IBundlePricingService BundlePricing { get; }

    ICallControlApplicationService CallControlApplications { get; }

    ICallEventService CallEvents { get; }

    ICallService Calls { get; }

    IChannelZoneService ChannelZones { get; }

    IChargesBreakdownService ChargesBreakdown { get; }

    IChargesSummaryService ChargesSummary { get; }

    ICommentService Comments { get; }

    IConferenceService Conferences { get; }

    IConnectionService Connections { get; }

    ICountryCoverageService CountryCoverage { get; }

    ICredentialConnectionService CredentialConnections { get; }

    ICustomStorageCredentialService CustomStorageCredentials { get; }

    ICustomerServiceRecordService CustomerServiceRecords { get; }

    IDetailRecordService DetailRecords { get; }

    IDialogflowConnectionService DialogflowConnections { get; }

    IDocumentLinkService DocumentLinks { get; }

    IDocumentService Documents { get; }

    IDynamicEmergencyAddressService DynamicEmergencyAddresses { get; }

    IDynamicEmergencyEndpointService DynamicEmergencyEndpoints { get; }

    IExternalConnectionService ExternalConnections { get; }

    IFaxApplicationService FaxApplications { get; }

    IFaxService Faxes { get; }

    IFqdnConnectionService FqdnConnections { get; }

    IFqdnService Fqdns { get; }

    IGlobalIPAllowedPortService GlobalIPAllowedPorts { get; }

    IGlobalIPAssignmentHealthService GlobalIPAssignmentHealth { get; }

    IGlobalIPAssignmentService GlobalIPAssignments { get; }

    IGlobalIPAssignmentsUsageService GlobalIPAssignmentsUsage { get; }

    IGlobalIPHealthCheckTypeService GlobalIPHealthCheckTypes { get; }

    IGlobalIPHealthCheckService GlobalIPHealthChecks { get; }

    IGlobalIPLatencyService GlobalIPLatency { get; }

    IGlobalIPProtocolService GlobalIPProtocols { get; }

    IGlobalIPUsageService GlobalIPUsage { get; }

    IGlobalIPService GlobalIps { get; }

    IInboundChannelService InboundChannels { get; }

    IIntegrationSecretService IntegrationSecrets { get; }

    IInventoryCoverageService InventoryCoverage { get; }

    IInvoiceService Invoices { get; }

    IIPConnectionService IPConnections { get; }

    IIPService Ips { get; }

    ILedgerBillingGroupReportService LedgerBillingGroupReports { get; }

    IListService List { get; }

    IManagedAccountService ManagedAccounts { get; }

    IMediaService Media { get; }

    IMessageService Messages { get; }

    IMessagingService Messaging { get; }

    IMessagingHostedNumberOrderService MessagingHostedNumberOrders { get; }

    IMessagingHostedNumberService MessagingHostedNumbers { get; }

    IMessagingNumbersBulkUpdateService MessagingNumbersBulkUpdates { get; }

    IMessagingOptoutService MessagingOptouts { get; }

    IMessagingProfileService MessagingProfiles { get; }

    IMessagingTollfreeService MessagingTollfree { get; }

    IMessagingUrlDomainService MessagingUrlDomains { get; }

    IMobileNetworkOperatorService MobileNetworkOperators { get; }

    IMobilePushCredentialService MobilePushCredentials { get; }

    INetworkCoverageService NetworkCoverage { get; }

    INetworkService Networks { get; }

    INotificationChannelService NotificationChannels { get; }

    INotificationEventConditionService NotificationEventConditions { get; }

    INotificationEventService NotificationEvents { get; }

    INotificationProfileService NotificationProfiles { get; }

    INotificationSettingService NotificationSettings { get; }

    INumberBlockOrderService NumberBlockOrders { get; }

    INumberLookupService NumberLookup { get; }

    INumberOrderPhoneNumberService NumberOrderPhoneNumbers { get; }

    INumberOrderService NumberOrders { get; }

    INumberReservationService NumberReservations { get; }

    INumbersFeatureService NumbersFeatures { get; }

    IOperatorConnectService OperatorConnect { get; }

    IOtaUpdateService OtaUpdates { get; }

    IOutboundVoiceProfileService OutboundVoiceProfiles { get; }

    IPaymentService Payment { get; }

    IPhoneNumberBlockService PhoneNumberBlocks { get; }

    IPhoneNumberService PhoneNumbers { get; }

    IPhoneNumbersRegulatoryRequirementService PhoneNumbersRegulatoryRequirements {
        get;
    }

    IPortabilityCheckService PortabilityChecks { get; }

    IPortingService Porting { get; }

    IPortingOrderService PortingOrders { get; }

    IPortingPhoneNumberService PortingPhoneNumbers { get; }

    IPortoutService Portouts { get; }

    IPrivateWirelessGatewayService PrivateWirelessGateways { get; }

    IPublicInternetGatewayService PublicInternetGateways { get; }

    IQueueService Queues { get; }

    IRcService Rcs { get; }

    IRecordingTranscriptionService RecordingTranscriptions { get; }

    IRecordingService Recordings { get; }

    IRegionService Regions { get; }

    IRegulatoryRequirementService RegulatoryRequirements { get; }

    IReportService Reports { get; }

    ISpeechToTextService SpeechToText { get; }

    IRequirementGroupService RequirementGroups { get; }

    IRequirementTypeService RequirementTypes { get; }

    IRequirementService Requirements { get; }

    IRoomCompositionService RoomCompositions { get; }

    IRoomParticipantService RoomParticipants { get; }

    IRoomRecordingService RoomRecordings { get; }

    IRoomService Rooms { get; }

    ISetiService Seti { get; }

    IShortCodeService ShortCodes { get; }

    ISimCardDataUsageNotificationService SimCardDataUsageNotifications { get; }

    ISimCardGroupService SimCardGroups { get; }

    ISimCardOrderPreviewService SimCardOrderPreview { get; }

    ISimCardOrderService SimCardOrders { get; }

    ISimCardService SimCards { get; }

    ISiprecConnectorService SiprecConnectors { get; }

    IStorageService Storage { get; }

    ISubNumberOrderService SubNumberOrders { get; }

    ISubNumberOrdersReportService SubNumberOrdersReport { get; }

    ITelephonyCredentialService TelephonyCredentials { get; }

    ITexmlService Texml { get; }

    ITexmlApplicationService TexmlApplications { get; }

    ITextToSpeechService TextToSpeech { get; }

    IUsageReportService UsageReports { get; }

    IUserAddressService UserAddresses { get; }

    IUserTagService UserTags { get; }

    IVerificationService Verifications { get; }

    IVerifiedNumberService VerifiedNumbers { get; }

    IVerifyProfileService VerifyProfiles { get; }

    IVirtualCrossConnectService VirtualCrossConnects { get; }

    IVirtualCrossConnectsCoverageService VirtualCrossConnectsCoverage { get; }

    IWebhookDeliveryService WebhookDeliveries { get; }

    IWireguardInterfaceService WireguardInterfaces { get; }

    IWireguardPeerService WireguardPeers { get; }

    IWirelessService Wireless { get; }

    IWirelessBlocklistValueService WirelessBlocklistValues { get; }

    IWirelessBlocklistService WirelessBlocklists { get; }

    IWellKnownService WellKnown { get; }

    IInexplicitNumberOrderService InexplicitNumberOrders { get; }

    IMobilePhoneNumberService MobilePhoneNumbers { get; }

    IMobileVoiceConnectionService MobileVoiceConnections { get; }

    IMessaging10dlcService Messaging10dlc { get; }

    IOrganizationService Organizations { get; }

    IAlphanumericSenderIDService AlphanumericSenderIds { get; }

    IMessagingProfileMetricService MessagingProfileMetrics { get; }

    ISessionAnalysisService SessionAnalysis { get; }

    IWhatsappService Whatsapp { get; }

    IWhatsappMessageTemplateService WhatsappMessageTemplates { get; }

    IX402Service X402 { get; }

    IVoiceCloneService VoiceClones { get; }

    IVoiceDesignService VoiceDesigns { get; }

    ITrafficPolicyProfileService TrafficPolicyProfiles { get; }

    IEnterpriseService Enterprises { get; }

    IReputationService Reputation { get; }

    ITermsOfServiceService TermsOfService { get; }

    IPronunciationDictService PronunciationDicts { get; }

    IUacConnectionService UacConnections { get; }

    IVoiceSdkCallReportService VoiceSdkCallReports { get; }

    ICallReasonService CallReasons { get; }

    IDirService Dir { get; }

    IInfringementClaimService InfringementClaims { get; }

    IEmailBlockService EmailBlocks { get; }

    IEmailDomainService EmailDomains { get; }

    IEmailEventService EmailEvents { get; }

    IEmailInboxService EmailInboxes { get; }

    IEmailMessageService EmailMessages { get; }

    IEmailTemplateService EmailTemplates { get; }

    IEmailThreadService EmailThreads { get; }

    IEmailUnsubscribeGroupService EmailUnsubscribeGroups { get; }

    IEmailValidationService EmailValidations { get; }

    IPricingService Pricing { get; }

    IWebSearchService WebSearch { get; }

    IMeetingSessionService MeetingSessions { get; }

    IExternalRequirementService ExternalRequirements { get; }

    IComputeService Compute { get; }

    INoiseSuppressionEngineService NoiseSuppressionEngines { get; }

    IBotChallengeService BotChallenge { get; }

    IBotSessionService BotSessions { get; }

    IBotSignupService BotSignup { get; }

    IMachinePaymentService MachinePayments { get; }
}

/// <summary>
/// A view of <see cref="ITelnyxClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ITelnyxClientWithRawResponse
: IDisposable{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    string? PublicKey { get; init; }

    string? ClientID { get; init; }

    string? ClientSecret { get; init; }

    /// <summary>
    /// Complete Payment authorization credential. Only sent to Payment-enabled operations.
    /// Bearer takes precedence when both are set; clear ApiKey on a scoped WithOptions
    /// copy for an explicit paid retry. Never constructed or retried automatically.
    /// </summary>
    string? PaymentAuthorization { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelnyxClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ILegacyServiceWithRawResponse Legacy { get; }

    IOAuthServiceWithRawResponse OAuth { get; }

    IOAuthClientServiceWithRawResponse OAuthClients { get; }

    IOAuthGrantServiceWithRawResponse OAuthGrants { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    IAccessIPAddressServiceWithRawResponse AccessIPAddress { get; }

    IAccessIPRangeServiceWithRawResponse AccessIPRanges { get; }

    IActionServiceWithRawResponse Actions { get; }

    IAddressServiceWithRawResponse Addresses { get; }

    IAdvancedOrderServiceWithRawResponse AdvancedOrders { get; }

    IAIServiceWithRawResponse AI { get; }

    IAuditEventServiceWithRawResponse AuditEvents { get; }

    IAuthenticationProviderServiceWithRawResponse AuthenticationProviders {
        get;
    }

    IAvailablePhoneNumberBlockServiceWithRawResponse AvailablePhoneNumberBlocks {
        get;
    }

    IAvailablePhoneNumberServiceWithRawResponse AvailablePhoneNumbers { get; }

    IBalanceServiceWithRawResponse Balance { get; }

    IBillingGroupServiceWithRawResponse BillingGroups { get; }

    IBulkSimCardActionServiceWithRawResponse BulkSimCardActions { get; }

    IBundlePricingServiceWithRawResponse BundlePricing { get; }

    ICallControlApplicationServiceWithRawResponse CallControlApplications {
        get;
    }

    ICallEventServiceWithRawResponse CallEvents { get; }

    ICallServiceWithRawResponse Calls { get; }

    IChannelZoneServiceWithRawResponse ChannelZones { get; }

    IChargesBreakdownServiceWithRawResponse ChargesBreakdown { get; }

    IChargesSummaryServiceWithRawResponse ChargesSummary { get; }

    ICommentServiceWithRawResponse Comments { get; }

    IConferenceServiceWithRawResponse Conferences { get; }

    IConnectionServiceWithRawResponse Connections { get; }

    ICountryCoverageServiceWithRawResponse CountryCoverage { get; }

    ICredentialConnectionServiceWithRawResponse CredentialConnections { get; }

    ICustomStorageCredentialServiceWithRawResponse CustomStorageCredentials {
        get;
    }

    ICustomerServiceRecordServiceWithRawResponse CustomerServiceRecords { get; }

    IDetailRecordServiceWithRawResponse DetailRecords { get; }

    IDialogflowConnectionServiceWithRawResponse DialogflowConnections { get; }

    IDocumentLinkServiceWithRawResponse DocumentLinks { get; }

    IDocumentServiceWithRawResponse Documents { get; }

    IDynamicEmergencyAddressServiceWithRawResponse DynamicEmergencyAddresses {
        get;
    }

    IDynamicEmergencyEndpointServiceWithRawResponse DynamicEmergencyEndpoints {
        get;
    }

    IExternalConnectionServiceWithRawResponse ExternalConnections { get; }

    IFaxApplicationServiceWithRawResponse FaxApplications { get; }

    IFaxServiceWithRawResponse Faxes { get; }

    IFqdnConnectionServiceWithRawResponse FqdnConnections { get; }

    IFqdnServiceWithRawResponse Fqdns { get; }

    IGlobalIPAllowedPortServiceWithRawResponse GlobalIPAllowedPorts { get; }

    IGlobalIPAssignmentHealthServiceWithRawResponse GlobalIPAssignmentHealth {
        get;
    }

    IGlobalIPAssignmentServiceWithRawResponse GlobalIPAssignments { get; }

    IGlobalIPAssignmentsUsageServiceWithRawResponse GlobalIPAssignmentsUsage {
        get;
    }

    IGlobalIPHealthCheckTypeServiceWithRawResponse GlobalIPHealthCheckTypes {
        get;
    }

    IGlobalIPHealthCheckServiceWithRawResponse GlobalIPHealthChecks { get; }

    IGlobalIPLatencyServiceWithRawResponse GlobalIPLatency { get; }

    IGlobalIPProtocolServiceWithRawResponse GlobalIPProtocols { get; }

    IGlobalIPUsageServiceWithRawResponse GlobalIPUsage { get; }

    IGlobalIPServiceWithRawResponse GlobalIps { get; }

    IInboundChannelServiceWithRawResponse InboundChannels { get; }

    IIntegrationSecretServiceWithRawResponse IntegrationSecrets { get; }

    IInventoryCoverageServiceWithRawResponse InventoryCoverage { get; }

    IInvoiceServiceWithRawResponse Invoices { get; }

    IIPConnectionServiceWithRawResponse IPConnections { get; }

    IIPServiceWithRawResponse Ips { get; }

    ILedgerBillingGroupReportServiceWithRawResponse LedgerBillingGroupReports {
        get;
    }

    IListServiceWithRawResponse List { get; }

    IManagedAccountServiceWithRawResponse ManagedAccounts { get; }

    IMediaServiceWithRawResponse Media { get; }

    IMessageServiceWithRawResponse Messages { get; }

    IMessagingServiceWithRawResponse Messaging { get; }

    IMessagingHostedNumberOrderServiceWithRawResponse MessagingHostedNumberOrders {
        get;
    }

    IMessagingHostedNumberServiceWithRawResponse MessagingHostedNumbers { get; }

    IMessagingNumbersBulkUpdateServiceWithRawResponse MessagingNumbersBulkUpdates {
        get;
    }

    IMessagingOptoutServiceWithRawResponse MessagingOptouts { get; }

    IMessagingProfileServiceWithRawResponse MessagingProfiles { get; }

    IMessagingTollfreeServiceWithRawResponse MessagingTollfree { get; }

    IMessagingUrlDomainServiceWithRawResponse MessagingUrlDomains { get; }

    IMobileNetworkOperatorServiceWithRawResponse MobileNetworkOperators { get; }

    IMobilePushCredentialServiceWithRawResponse MobilePushCredentials { get; }

    INetworkCoverageServiceWithRawResponse NetworkCoverage { get; }

    INetworkServiceWithRawResponse Networks { get; }

    INotificationChannelServiceWithRawResponse NotificationChannels { get; }

    INotificationEventConditionServiceWithRawResponse NotificationEventConditions {
        get;
    }

    INotificationEventServiceWithRawResponse NotificationEvents { get; }

    INotificationProfileServiceWithRawResponse NotificationProfiles { get; }

    INotificationSettingServiceWithRawResponse NotificationSettings { get; }

    INumberBlockOrderServiceWithRawResponse NumberBlockOrders { get; }

    INumberLookupServiceWithRawResponse NumberLookup { get; }

    INumberOrderPhoneNumberServiceWithRawResponse NumberOrderPhoneNumbers {
        get;
    }

    INumberOrderServiceWithRawResponse NumberOrders { get; }

    INumberReservationServiceWithRawResponse NumberReservations { get; }

    INumbersFeatureServiceWithRawResponse NumbersFeatures { get; }

    IOperatorConnectServiceWithRawResponse OperatorConnect { get; }

    IOtaUpdateServiceWithRawResponse OtaUpdates { get; }

    IOutboundVoiceProfileServiceWithRawResponse OutboundVoiceProfiles { get; }

    IPaymentServiceWithRawResponse Payment { get; }

    IPhoneNumberBlockServiceWithRawResponse PhoneNumberBlocks { get; }

    IPhoneNumberServiceWithRawResponse PhoneNumbers { get; }

    IPhoneNumbersRegulatoryRequirementServiceWithRawResponse PhoneNumbersRegulatoryRequirements {
        get;
    }

    IPortabilityCheckServiceWithRawResponse PortabilityChecks { get; }

    IPortingServiceWithRawResponse Porting { get; }

    IPortingOrderServiceWithRawResponse PortingOrders { get; }

    IPortingPhoneNumberServiceWithRawResponse PortingPhoneNumbers { get; }

    IPortoutServiceWithRawResponse Portouts { get; }

    IPrivateWirelessGatewayServiceWithRawResponse PrivateWirelessGateways {
        get;
    }

    IPublicInternetGatewayServiceWithRawResponse PublicInternetGateways { get; }

    IQueueServiceWithRawResponse Queues { get; }

    IRcServiceWithRawResponse Rcs { get; }

    IRecordingTranscriptionServiceWithRawResponse RecordingTranscriptions {
        get;
    }

    IRecordingServiceWithRawResponse Recordings { get; }

    IRegionServiceWithRawResponse Regions { get; }

    IRegulatoryRequirementServiceWithRawResponse RegulatoryRequirements { get; }

    IReportServiceWithRawResponse Reports { get; }

    ISpeechToTextServiceWithRawResponse SpeechToText { get; }

    IRequirementGroupServiceWithRawResponse RequirementGroups { get; }

    IRequirementTypeServiceWithRawResponse RequirementTypes { get; }

    IRequirementServiceWithRawResponse Requirements { get; }

    IRoomCompositionServiceWithRawResponse RoomCompositions { get; }

    IRoomParticipantServiceWithRawResponse RoomParticipants { get; }

    IRoomRecordingServiceWithRawResponse RoomRecordings { get; }

    IRoomServiceWithRawResponse Rooms { get; }

    ISetiServiceWithRawResponse Seti { get; }

    IShortCodeServiceWithRawResponse ShortCodes { get; }

    ISimCardDataUsageNotificationServiceWithRawResponse SimCardDataUsageNotifications {
        get;
    }

    ISimCardGroupServiceWithRawResponse SimCardGroups { get; }

    ISimCardOrderPreviewServiceWithRawResponse SimCardOrderPreview { get; }

    ISimCardOrderServiceWithRawResponse SimCardOrders { get; }

    ISimCardServiceWithRawResponse SimCards { get; }

    ISiprecConnectorServiceWithRawResponse SiprecConnectors { get; }

    IStorageServiceWithRawResponse Storage { get; }

    ISubNumberOrderServiceWithRawResponse SubNumberOrders { get; }

    ISubNumberOrdersReportServiceWithRawResponse SubNumberOrdersReport { get; }

    ITelephonyCredentialServiceWithRawResponse TelephonyCredentials { get; }

    ITexmlServiceWithRawResponse Texml { get; }

    ITexmlApplicationServiceWithRawResponse TexmlApplications { get; }

    ITextToSpeechServiceWithRawResponse TextToSpeech { get; }

    IUsageReportServiceWithRawResponse UsageReports { get; }

    IUserAddressServiceWithRawResponse UserAddresses { get; }

    IUserTagServiceWithRawResponse UserTags { get; }

    IVerificationServiceWithRawResponse Verifications { get; }

    IVerifiedNumberServiceWithRawResponse VerifiedNumbers { get; }

    IVerifyProfileServiceWithRawResponse VerifyProfiles { get; }

    IVirtualCrossConnectServiceWithRawResponse VirtualCrossConnects { get; }

    IVirtualCrossConnectsCoverageServiceWithRawResponse VirtualCrossConnectsCoverage {
        get;
    }

    IWebhookDeliveryServiceWithRawResponse WebhookDeliveries { get; }

    IWireguardInterfaceServiceWithRawResponse WireguardInterfaces { get; }

    IWireguardPeerServiceWithRawResponse WireguardPeers { get; }

    IWirelessServiceWithRawResponse Wireless { get; }

    IWirelessBlocklistValueServiceWithRawResponse WirelessBlocklistValues {
        get;
    }

    IWirelessBlocklistServiceWithRawResponse WirelessBlocklists { get; }

    IWellKnownServiceWithRawResponse WellKnown { get; }

    IInexplicitNumberOrderServiceWithRawResponse InexplicitNumberOrders { get; }

    IMobilePhoneNumberServiceWithRawResponse MobilePhoneNumbers { get; }

    IMobileVoiceConnectionServiceWithRawResponse MobileVoiceConnections { get; }

    IMessaging10dlcServiceWithRawResponse Messaging10dlc { get; }

    IOrganizationServiceWithRawResponse Organizations { get; }

    IAlphanumericSenderIDServiceWithRawResponse AlphanumericSenderIds { get; }

    IMessagingProfileMetricServiceWithRawResponse MessagingProfileMetrics {
        get;
    }

    ISessionAnalysisServiceWithRawResponse SessionAnalysis { get; }

    IWhatsappServiceWithRawResponse Whatsapp { get; }

    IWhatsappMessageTemplateServiceWithRawResponse WhatsappMessageTemplates {
        get;
    }

    IX402ServiceWithRawResponse X402 { get; }

    IVoiceCloneServiceWithRawResponse VoiceClones { get; }

    IVoiceDesignServiceWithRawResponse VoiceDesigns { get; }

    ITrafficPolicyProfileServiceWithRawResponse TrafficPolicyProfiles { get; }

    IEnterpriseServiceWithRawResponse Enterprises { get; }

    IReputationServiceWithRawResponse Reputation { get; }

    ITermsOfServiceServiceWithRawResponse TermsOfService { get; }

    IPronunciationDictServiceWithRawResponse PronunciationDicts { get; }

    IUacConnectionServiceWithRawResponse UacConnections { get; }

    IVoiceSdkCallReportServiceWithRawResponse VoiceSdkCallReports { get; }

    ICallReasonServiceWithRawResponse CallReasons { get; }

    IDirServiceWithRawResponse Dir { get; }

    IInfringementClaimServiceWithRawResponse InfringementClaims { get; }

    IEmailBlockServiceWithRawResponse EmailBlocks { get; }

    IEmailDomainServiceWithRawResponse EmailDomains { get; }

    IEmailEventServiceWithRawResponse EmailEvents { get; }

    IEmailInboxServiceWithRawResponse EmailInboxes { get; }

    IEmailMessageServiceWithRawResponse EmailMessages { get; }

    IEmailTemplateServiceWithRawResponse EmailTemplates { get; }

    IEmailThreadServiceWithRawResponse EmailThreads { get; }

    IEmailUnsubscribeGroupServiceWithRawResponse EmailUnsubscribeGroups { get; }

    IEmailValidationServiceWithRawResponse EmailValidations { get; }

    IPricingServiceWithRawResponse Pricing { get; }

    IWebSearchServiceWithRawResponse WebSearch { get; }

    IMeetingSessionServiceWithRawResponse MeetingSessions { get; }

    IExternalRequirementServiceWithRawResponse ExternalRequirements { get; }

    IComputeServiceWithRawResponse Compute { get; }

    INoiseSuppressionEngineServiceWithRawResponse NoiseSuppressionEngines {
        get;
    }

    IBotChallengeServiceWithRawResponse BotChallenge { get; }

    IBotSessionServiceWithRawResponse BotSessions { get; }

    IBotSignupServiceWithRawResponse BotSignup { get; }

    IMachinePaymentServiceWithRawResponse MachinePayments { get; }

    /// <summary>
    /// Sends a request to the Telnyx REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>
    (
        HttpRequest<T> request, CancellationToken cancellationToken = default
    ) where T: ParamsBase
    ;
}