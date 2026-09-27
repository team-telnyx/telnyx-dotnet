using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk;

/// <inheritdoc/>
public sealed class TelnyxClient : ITelnyxClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? PublicKey {
        get { return this._options.PublicKey; }
        init { this._options.PublicKey = value; }
    }

    /// <inheritdoc/>
    public string? ClientID {
        get { return this._options.ClientID; }
        init { this._options.ClientID = value; }
    }

    /// <inheritdoc/>
    public string? ClientSecret {
        get { return this._options.ClientSecret; }
        init { this._options.ClientSecret = value; }
    }

    /// <inheritdoc/>
    public string? PaymentAuthorization {
        get { return this._options.PaymentAuthorization; }
        init { this._options.PaymentAuthorization = value; }
    }

    readonly Lazy<ITelnyxClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITelnyxClientWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public ITelnyxClient WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TelnyxClient(modifier(this._options)); }

    readonly Lazy<ILegacyService> _legacy;
    public ILegacyService Legacy { get { return _legacy.Value; } }

    readonly Lazy<IOAuthService> _oauth;
    public IOAuthService OAuth { get { return _oauth.Value; } }

    readonly Lazy<IOAuthClientService> _oauthClients;
    public IOAuthClientService OAuthClients {
        get { return _oauthClients.Value; }
    }

    readonly Lazy<IOAuthGrantService> _oauthGrants;
    public IOAuthGrantService OAuthGrants { get { return _oauthGrants.Value; } }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks { get { return _webhooks.Value; } }

    readonly Lazy<IAccessIPAddressService> _accessIPAddress;
    public IAccessIPAddressService AccessIPAddress {
        get { return _accessIPAddress.Value; }
    }

    readonly Lazy<IAccessIPRangeService> _accessIPRanges;
    public IAccessIPRangeService AccessIPRanges {
        get { return _accessIPRanges.Value; }
    }

    readonly Lazy<IActionService> _actions;
    public IActionService Actions { get { return _actions.Value; } }

    readonly Lazy<IAddressService> _addresses;
    public IAddressService Addresses { get { return _addresses.Value; } }

    readonly Lazy<IAdvancedOrderService> _advancedOrders;
    public IAdvancedOrderService AdvancedOrders {
        get { return _advancedOrders.Value; }
    }

    readonly Lazy<IAIService> _ai;
    public IAIService AI { get { return _ai.Value; } }

    readonly Lazy<IAuditEventService> _auditEvents;
    public IAuditEventService AuditEvents { get { return _auditEvents.Value; } }

    readonly Lazy<IAuthenticationProviderService> _authenticationProviders;
    public IAuthenticationProviderService AuthenticationProviders {
        get { return _authenticationProviders.Value; }
    }

    readonly Lazy<IAvailablePhoneNumberBlockService> _availablePhoneNumberBlocks;
    public IAvailablePhoneNumberBlockService AvailablePhoneNumberBlocks {
        get { return _availablePhoneNumberBlocks.Value; }
    }

    readonly Lazy<IAvailablePhoneNumberService> _availablePhoneNumbers;
    public IAvailablePhoneNumberService AvailablePhoneNumbers {
        get { return _availablePhoneNumbers.Value; }
    }

    readonly Lazy<IBalanceService> _balance;
    public IBalanceService Balance { get { return _balance.Value; } }

    readonly Lazy<IBillingGroupService> _billingGroups;
    public IBillingGroupService BillingGroups {
        get { return _billingGroups.Value; }
    }

    readonly Lazy<IBulkSimCardActionService> _bulkSimCardActions;
    public IBulkSimCardActionService BulkSimCardActions {
        get { return _bulkSimCardActions.Value; }
    }

    readonly Lazy<IBundlePricingService> _bundlePricing;
    public IBundlePricingService BundlePricing {
        get { return _bundlePricing.Value; }
    }

    readonly Lazy<ICallControlApplicationService> _callControlApplications;
    public ICallControlApplicationService CallControlApplications {
        get { return _callControlApplications.Value; }
    }

    readonly Lazy<ICallEventService> _callEvents;
    public ICallEventService CallEvents { get { return _callEvents.Value; } }

    readonly Lazy<ICallService> _calls;
    public ICallService Calls { get { return _calls.Value; } }

    readonly Lazy<IChannelZoneService> _channelZones;
    public IChannelZoneService ChannelZones {
        get { return _channelZones.Value; }
    }

    readonly Lazy<IChargesBreakdownService> _chargesBreakdown;
    public IChargesBreakdownService ChargesBreakdown {
        get { return _chargesBreakdown.Value; }
    }

    readonly Lazy<IChargesSummaryService> _chargesSummary;
    public IChargesSummaryService ChargesSummary {
        get { return _chargesSummary.Value; }
    }

    readonly Lazy<ICommentService> _comments;
    public ICommentService Comments { get { return _comments.Value; } }

    readonly Lazy<IConferenceService> _conferences;
    public IConferenceService Conferences { get { return _conferences.Value; } }

    readonly Lazy<IConnectionService> _connections;
    public IConnectionService Connections { get { return _connections.Value; } }

    readonly Lazy<ICountryCoverageService> _countryCoverage;
    public ICountryCoverageService CountryCoverage {
        get { return _countryCoverage.Value; }
    }

    readonly Lazy<ICredentialConnectionService> _credentialConnections;
    public ICredentialConnectionService CredentialConnections {
        get { return _credentialConnections.Value; }
    }

    readonly Lazy<ICustomStorageCredentialService> _customStorageCredentials;
    public ICustomStorageCredentialService CustomStorageCredentials {
        get { return _customStorageCredentials.Value; }
    }

    readonly Lazy<ICustomerServiceRecordService> _customerServiceRecords;
    public ICustomerServiceRecordService CustomerServiceRecords {
        get { return _customerServiceRecords.Value; }
    }

    readonly Lazy<IDetailRecordService> _detailRecords;
    public IDetailRecordService DetailRecords {
        get { return _detailRecords.Value; }
    }

    readonly Lazy<IDialogflowConnectionService> _dialogflowConnections;
    public IDialogflowConnectionService DialogflowConnections {
        get { return _dialogflowConnections.Value; }
    }

    readonly Lazy<IDocumentLinkService> _documentLinks;
    public IDocumentLinkService DocumentLinks {
        get { return _documentLinks.Value; }
    }

    readonly Lazy<IDocumentService> _documents;
    public IDocumentService Documents { get { return _documents.Value; } }

    readonly Lazy<IDynamicEmergencyAddressService> _dynamicEmergencyAddresses;
    public IDynamicEmergencyAddressService DynamicEmergencyAddresses {
        get { return _dynamicEmergencyAddresses.Value; }
    }

    readonly Lazy<IDynamicEmergencyEndpointService> _dynamicEmergencyEndpoints;
    public IDynamicEmergencyEndpointService DynamicEmergencyEndpoints {
        get { return _dynamicEmergencyEndpoints.Value; }
    }

    readonly Lazy<IExternalConnectionService> _externalConnections;
    public IExternalConnectionService ExternalConnections {
        get { return _externalConnections.Value; }
    }

    readonly Lazy<IFaxApplicationService> _faxApplications;
    public IFaxApplicationService FaxApplications {
        get { return _faxApplications.Value; }
    }

    readonly Lazy<IFaxService> _faxes;
    public IFaxService Faxes { get { return _faxes.Value; } }

    readonly Lazy<IFqdnConnectionService> _fqdnConnections;
    public IFqdnConnectionService FqdnConnections {
        get { return _fqdnConnections.Value; }
    }

    readonly Lazy<IFqdnService> _fqdns;
    public IFqdnService Fqdns { get { return _fqdns.Value; } }

    readonly Lazy<IGlobalIPAllowedPortService> _globalIPAllowedPorts;
    public IGlobalIPAllowedPortService GlobalIPAllowedPorts {
        get { return _globalIPAllowedPorts.Value; }
    }

    readonly Lazy<IGlobalIPAssignmentHealthService> _globalIPAssignmentHealth;
    public IGlobalIPAssignmentHealthService GlobalIPAssignmentHealth {
        get { return _globalIPAssignmentHealth.Value; }
    }

    readonly Lazy<IGlobalIPAssignmentService> _globalIPAssignments;
    public IGlobalIPAssignmentService GlobalIPAssignments {
        get { return _globalIPAssignments.Value; }
    }

    readonly Lazy<IGlobalIPAssignmentsUsageService> _globalIPAssignmentsUsage;
    public IGlobalIPAssignmentsUsageService GlobalIPAssignmentsUsage {
        get { return _globalIPAssignmentsUsage.Value; }
    }

    readonly Lazy<IGlobalIPHealthCheckTypeService> _globalIPHealthCheckTypes;
    public IGlobalIPHealthCheckTypeService GlobalIPHealthCheckTypes {
        get { return _globalIPHealthCheckTypes.Value; }
    }

    readonly Lazy<IGlobalIPHealthCheckService> _globalIPHealthChecks;
    public IGlobalIPHealthCheckService GlobalIPHealthChecks {
        get { return _globalIPHealthChecks.Value; }
    }

    readonly Lazy<IGlobalIPLatencyService> _globalIPLatency;
    public IGlobalIPLatencyService GlobalIPLatency {
        get { return _globalIPLatency.Value; }
    }

    readonly Lazy<IGlobalIPProtocolService> _globalIPProtocols;
    public IGlobalIPProtocolService GlobalIPProtocols {
        get { return _globalIPProtocols.Value; }
    }

    readonly Lazy<IGlobalIPUsageService> _globalIPUsage;
    public IGlobalIPUsageService GlobalIPUsage {
        get { return _globalIPUsage.Value; }
    }

    readonly Lazy<IGlobalIPService> _globalIps;
    public IGlobalIPService GlobalIps { get { return _globalIps.Value; } }

    readonly Lazy<IInboundChannelService> _inboundChannels;
    public IInboundChannelService InboundChannels {
        get { return _inboundChannels.Value; }
    }

    readonly Lazy<IIntegrationSecretService> _integrationSecrets;
    public IIntegrationSecretService IntegrationSecrets {
        get { return _integrationSecrets.Value; }
    }

    readonly Lazy<IInventoryCoverageService> _inventoryCoverage;
    public IInventoryCoverageService InventoryCoverage {
        get { return _inventoryCoverage.Value; }
    }

    readonly Lazy<IInvoiceService> _invoices;
    public IInvoiceService Invoices { get { return _invoices.Value; } }

    readonly Lazy<IIPConnectionService> _ipConnections;
    public IIPConnectionService IPConnections {
        get { return _ipConnections.Value; }
    }

    readonly Lazy<IIPService> _ips;
    public IIPService Ips { get { return _ips.Value; } }

    readonly Lazy<ILedgerBillingGroupReportService> _ledgerBillingGroupReports;
    public ILedgerBillingGroupReportService LedgerBillingGroupReports {
        get { return _ledgerBillingGroupReports.Value; }
    }

    readonly Lazy<IListService> _list;
    public IListService List { get { return _list.Value; } }

    readonly Lazy<IManagedAccountService> _managedAccounts;
    public IManagedAccountService ManagedAccounts {
        get { return _managedAccounts.Value; }
    }

    readonly Lazy<IMediaService> _media;
    public IMediaService Media { get { return _media.Value; } }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages { get { return _messages.Value; } }

    readonly Lazy<IMessagingService> _messaging;
    public IMessagingService Messaging { get { return _messaging.Value; } }

    readonly Lazy<IMessagingHostedNumberOrderService> _messagingHostedNumberOrders;
    public IMessagingHostedNumberOrderService MessagingHostedNumberOrders {
        get { return _messagingHostedNumberOrders.Value; }
    }

    readonly Lazy<IMessagingHostedNumberService> _messagingHostedNumbers;
    public IMessagingHostedNumberService MessagingHostedNumbers {
        get { return _messagingHostedNumbers.Value; }
    }

    readonly Lazy<IMessagingNumbersBulkUpdateService> _messagingNumbersBulkUpdates;
    public IMessagingNumbersBulkUpdateService MessagingNumbersBulkUpdates {
        get { return _messagingNumbersBulkUpdates.Value; }
    }

    readonly Lazy<IMessagingOptoutService> _messagingOptouts;
    public IMessagingOptoutService MessagingOptouts {
        get { return _messagingOptouts.Value; }
    }

    readonly Lazy<IMessagingProfileService> _messagingProfiles;
    public IMessagingProfileService MessagingProfiles {
        get { return _messagingProfiles.Value; }
    }

    readonly Lazy<IMessagingTollfreeService> _messagingTollfree;
    public IMessagingTollfreeService MessagingTollfree {
        get { return _messagingTollfree.Value; }
    }

    readonly Lazy<IMessagingUrlDomainService> _messagingUrlDomains;
    public IMessagingUrlDomainService MessagingUrlDomains {
        get { return _messagingUrlDomains.Value; }
    }

    readonly Lazy<IMobileNetworkOperatorService> _mobileNetworkOperators;
    public IMobileNetworkOperatorService MobileNetworkOperators {
        get { return _mobileNetworkOperators.Value; }
    }

    readonly Lazy<IMobilePushCredentialService> _mobilePushCredentials;
    public IMobilePushCredentialService MobilePushCredentials {
        get { return _mobilePushCredentials.Value; }
    }

    readonly Lazy<INetworkCoverageService> _networkCoverage;
    public INetworkCoverageService NetworkCoverage {
        get { return _networkCoverage.Value; }
    }

    readonly Lazy<INetworkService> _networks;
    public INetworkService Networks { get { return _networks.Value; } }

    readonly Lazy<INotificationChannelService> _notificationChannels;
    public INotificationChannelService NotificationChannels {
        get { return _notificationChannels.Value; }
    }

    readonly Lazy<INotificationEventConditionService> _notificationEventConditions;
    public INotificationEventConditionService NotificationEventConditions {
        get { return _notificationEventConditions.Value; }
    }

    readonly Lazy<INotificationEventService> _notificationEvents;
    public INotificationEventService NotificationEvents {
        get { return _notificationEvents.Value; }
    }

    readonly Lazy<INotificationProfileService> _notificationProfiles;
    public INotificationProfileService NotificationProfiles {
        get { return _notificationProfiles.Value; }
    }

    readonly Lazy<INotificationSettingService> _notificationSettings;
    public INotificationSettingService NotificationSettings {
        get { return _notificationSettings.Value; }
    }

    readonly Lazy<INumberBlockOrderService> _numberBlockOrders;
    public INumberBlockOrderService NumberBlockOrders {
        get { return _numberBlockOrders.Value; }
    }

    readonly Lazy<INumberLookupService> _numberLookup;
    public INumberLookupService NumberLookup {
        get { return _numberLookup.Value; }
    }

    readonly Lazy<INumberOrderPhoneNumberService> _numberOrderPhoneNumbers;
    public INumberOrderPhoneNumberService NumberOrderPhoneNumbers {
        get { return _numberOrderPhoneNumbers.Value; }
    }

    readonly Lazy<INumberOrderService> _numberOrders;
    public INumberOrderService NumberOrders {
        get { return _numberOrders.Value; }
    }

    readonly Lazy<INumberReservationService> _numberReservations;
    public INumberReservationService NumberReservations {
        get { return _numberReservations.Value; }
    }

    readonly Lazy<INumbersFeatureService> _numbersFeatures;
    public INumbersFeatureService NumbersFeatures {
        get { return _numbersFeatures.Value; }
    }

    readonly Lazy<IOperatorConnectService> _operatorConnect;
    public IOperatorConnectService OperatorConnect {
        get { return _operatorConnect.Value; }
    }

    readonly Lazy<IOtaUpdateService> _otaUpdates;
    public IOtaUpdateService OtaUpdates { get { return _otaUpdates.Value; } }

    readonly Lazy<IOutboundVoiceProfileService> _outboundVoiceProfiles;
    public IOutboundVoiceProfileService OutboundVoiceProfiles {
        get { return _outboundVoiceProfiles.Value; }
    }

    readonly Lazy<IPaymentService> _payment;
    public IPaymentService Payment { get { return _payment.Value; } }

    readonly Lazy<IPhoneNumberBlockService> _phoneNumberBlocks;
    public IPhoneNumberBlockService PhoneNumberBlocks {
        get { return _phoneNumberBlocks.Value; }
    }

    readonly Lazy<IPhoneNumberService> _phoneNumbers;
    public IPhoneNumberService PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<IPhoneNumbersRegulatoryRequirementService> _phoneNumbersRegulatoryRequirements;
    public IPhoneNumbersRegulatoryRequirementService PhoneNumbersRegulatoryRequirements {
        get { return _phoneNumbersRegulatoryRequirements.Value; }
    }

    readonly Lazy<IPortabilityCheckService> _portabilityChecks;
    public IPortabilityCheckService PortabilityChecks {
        get { return _portabilityChecks.Value; }
    }

    readonly Lazy<IPortingService> _porting;
    public IPortingService Porting { get { return _porting.Value; } }

    readonly Lazy<IPortingOrderService> _portingOrders;
    public IPortingOrderService PortingOrders {
        get { return _portingOrders.Value; }
    }

    readonly Lazy<IPortingPhoneNumberService> _portingPhoneNumbers;
    public IPortingPhoneNumberService PortingPhoneNumbers {
        get { return _portingPhoneNumbers.Value; }
    }

    readonly Lazy<IPortoutService> _portouts;
    public IPortoutService Portouts { get { return _portouts.Value; } }

    readonly Lazy<IPrivateWirelessGatewayService> _privateWirelessGateways;
    public IPrivateWirelessGatewayService PrivateWirelessGateways {
        get { return _privateWirelessGateways.Value; }
    }

    readonly Lazy<IPublicInternetGatewayService> _publicInternetGateways;
    public IPublicInternetGatewayService PublicInternetGateways {
        get { return _publicInternetGateways.Value; }
    }

    readonly Lazy<IQueueService> _queues;
    public IQueueService Queues { get { return _queues.Value; } }

    readonly Lazy<IRcService> _rcs;
    public IRcService Rcs { get { return _rcs.Value; } }

    readonly Lazy<IRecordingTranscriptionService> _recordingTranscriptions;
    public IRecordingTranscriptionService RecordingTranscriptions {
        get { return _recordingTranscriptions.Value; }
    }

    readonly Lazy<IRecordingService> _recordings;
    public IRecordingService Recordings { get { return _recordings.Value; } }

    readonly Lazy<IRegionService> _regions;
    public IRegionService Regions { get { return _regions.Value; } }

    readonly Lazy<IRegulatoryRequirementService> _regulatoryRequirements;
    public IRegulatoryRequirementService RegulatoryRequirements {
        get { return _regulatoryRequirements.Value; }
    }

    readonly Lazy<IReportService> _reports;
    public IReportService Reports { get { return _reports.Value; } }

    readonly Lazy<ISpeechToTextService> _speechToText;
    public ISpeechToTextService SpeechToText {
        get { return _speechToText.Value; }
    }

    readonly Lazy<IRequirementGroupService> _requirementGroups;
    public IRequirementGroupService RequirementGroups {
        get { return _requirementGroups.Value; }
    }

    readonly Lazy<IRequirementTypeService> _requirementTypes;
    public IRequirementTypeService RequirementTypes {
        get { return _requirementTypes.Value; }
    }

    readonly Lazy<IRequirementService> _requirements;
    public IRequirementService Requirements {
        get { return _requirements.Value; }
    }

    readonly Lazy<IRoomCompositionService> _roomCompositions;
    public IRoomCompositionService RoomCompositions {
        get { return _roomCompositions.Value; }
    }

    readonly Lazy<IRoomParticipantService> _roomParticipants;
    public IRoomParticipantService RoomParticipants {
        get { return _roomParticipants.Value; }
    }

    readonly Lazy<IRoomRecordingService> _roomRecordings;
    public IRoomRecordingService RoomRecordings {
        get { return _roomRecordings.Value; }
    }

    readonly Lazy<IRoomService> _rooms;
    public IRoomService Rooms { get { return _rooms.Value; } }

    readonly Lazy<ISetiService> _seti;
    public ISetiService Seti { get { return _seti.Value; } }

    readonly Lazy<IShortCodeService> _shortCodes;
    public IShortCodeService ShortCodes { get { return _shortCodes.Value; } }

    readonly Lazy<ISimCardDataUsageNotificationService> _simCardDataUsageNotifications;
    public ISimCardDataUsageNotificationService SimCardDataUsageNotifications {
        get { return _simCardDataUsageNotifications.Value; }
    }

    readonly Lazy<ISimCardGroupService> _simCardGroups;
    public ISimCardGroupService SimCardGroups {
        get { return _simCardGroups.Value; }
    }

    readonly Lazy<ISimCardOrderPreviewService> _simCardOrderPreview;
    public ISimCardOrderPreviewService SimCardOrderPreview {
        get { return _simCardOrderPreview.Value; }
    }

    readonly Lazy<ISimCardOrderService> _simCardOrders;
    public ISimCardOrderService SimCardOrders {
        get { return _simCardOrders.Value; }
    }

    readonly Lazy<ISimCardService> _simCards;
    public ISimCardService SimCards { get { return _simCards.Value; } }

    readonly Lazy<ISiprecConnectorService> _siprecConnectors;
    public ISiprecConnectorService SiprecConnectors {
        get { return _siprecConnectors.Value; }
    }

    readonly Lazy<IStorageService> _storage;
    public IStorageService Storage { get { return _storage.Value; } }

    readonly Lazy<ISubNumberOrderService> _subNumberOrders;
    public ISubNumberOrderService SubNumberOrders {
        get { return _subNumberOrders.Value; }
    }

    readonly Lazy<ISubNumberOrdersReportService> _subNumberOrdersReport;
    public ISubNumberOrdersReportService SubNumberOrdersReport {
        get { return _subNumberOrdersReport.Value; }
    }

    readonly Lazy<ITelephonyCredentialService> _telephonyCredentials;
    public ITelephonyCredentialService TelephonyCredentials {
        get { return _telephonyCredentials.Value; }
    }

    readonly Lazy<ITexmlService> _texml;
    public ITexmlService Texml { get { return _texml.Value; } }

    readonly Lazy<ITexmlApplicationService> _texmlApplications;
    public ITexmlApplicationService TexmlApplications {
        get { return _texmlApplications.Value; }
    }

    readonly Lazy<ITextToSpeechService> _textToSpeech;
    public ITextToSpeechService TextToSpeech {
        get { return _textToSpeech.Value; }
    }

    readonly Lazy<IUsageReportService> _usageReports;
    public IUsageReportService UsageReports {
        get { return _usageReports.Value; }
    }

    readonly Lazy<IUserAddressService> _userAddresses;
    public IUserAddressService UserAddresses {
        get { return _userAddresses.Value; }
    }

    readonly Lazy<IUserTagService> _userTags;
    public IUserTagService UserTags { get { return _userTags.Value; } }

    readonly Lazy<IVerificationService> _verifications;
    public IVerificationService Verifications {
        get { return _verifications.Value; }
    }

    readonly Lazy<IVerifiedNumberService> _verifiedNumbers;
    public IVerifiedNumberService VerifiedNumbers {
        get { return _verifiedNumbers.Value; }
    }

    readonly Lazy<IVerifyProfileService> _verifyProfiles;
    public IVerifyProfileService VerifyProfiles {
        get { return _verifyProfiles.Value; }
    }

    readonly Lazy<IVirtualCrossConnectService> _virtualCrossConnects;
    public IVirtualCrossConnectService VirtualCrossConnects {
        get { return _virtualCrossConnects.Value; }
    }

    readonly Lazy<IVirtualCrossConnectsCoverageService> _virtualCrossConnectsCoverage;
    public IVirtualCrossConnectsCoverageService VirtualCrossConnectsCoverage {
        get { return _virtualCrossConnectsCoverage.Value; }
    }

    readonly Lazy<IWebhookDeliveryService> _webhookDeliveries;
    public IWebhookDeliveryService WebhookDeliveries {
        get { return _webhookDeliveries.Value; }
    }

    readonly Lazy<IWireguardInterfaceService> _wireguardInterfaces;
    public IWireguardInterfaceService WireguardInterfaces {
        get { return _wireguardInterfaces.Value; }
    }

    readonly Lazy<IWireguardPeerService> _wireguardPeers;
    public IWireguardPeerService WireguardPeers {
        get { return _wireguardPeers.Value; }
    }

    readonly Lazy<IWirelessService> _wireless;
    public IWirelessService Wireless { get { return _wireless.Value; } }

    readonly Lazy<IWirelessBlocklistValueService> _wirelessBlocklistValues;
    public IWirelessBlocklistValueService WirelessBlocklistValues {
        get { return _wirelessBlocklistValues.Value; }
    }

    readonly Lazy<IWirelessBlocklistService> _wirelessBlocklists;
    public IWirelessBlocklistService WirelessBlocklists {
        get { return _wirelessBlocklists.Value; }
    }

    readonly Lazy<IWellKnownService> _wellKnown;
    public IWellKnownService WellKnown { get { return _wellKnown.Value; } }

    readonly Lazy<IInexplicitNumberOrderService> _inexplicitNumberOrders;
    public IInexplicitNumberOrderService InexplicitNumberOrders {
        get { return _inexplicitNumberOrders.Value; }
    }

    readonly Lazy<IMobilePhoneNumberService> _mobilePhoneNumbers;
    public IMobilePhoneNumberService MobilePhoneNumbers {
        get { return _mobilePhoneNumbers.Value; }
    }

    readonly Lazy<IMobileVoiceConnectionService> _mobileVoiceConnections;
    public IMobileVoiceConnectionService MobileVoiceConnections {
        get { return _mobileVoiceConnections.Value; }
    }

    readonly Lazy<IMessaging10dlcService> _messaging10dlc;
    public IMessaging10dlcService Messaging10dlc {
        get { return _messaging10dlc.Value; }
    }

    readonly Lazy<IOrganizationService> _organizations;
    public IOrganizationService Organizations {
        get { return _organizations.Value; }
    }

    readonly Lazy<IAlphanumericSenderIDService> _alphanumericSenderIds;
    public IAlphanumericSenderIDService AlphanumericSenderIds {
        get { return _alphanumericSenderIds.Value; }
    }

    readonly Lazy<IMessagingProfileMetricService> _messagingProfileMetrics;
    public IMessagingProfileMetricService MessagingProfileMetrics {
        get { return _messagingProfileMetrics.Value; }
    }

    readonly Lazy<ISessionAnalysisService> _sessionAnalysis;
    public ISessionAnalysisService SessionAnalysis {
        get { return _sessionAnalysis.Value; }
    }

    readonly Lazy<IWhatsappService> _whatsapp;
    public IWhatsappService Whatsapp { get { return _whatsapp.Value; } }

    readonly Lazy<IWhatsappMessageTemplateService> _whatsappMessageTemplates;
    public IWhatsappMessageTemplateService WhatsappMessageTemplates {
        get { return _whatsappMessageTemplates.Value; }
    }

    readonly Lazy<IX402Service> _x402;
    public IX402Service X402 { get { return _x402.Value; } }

    readonly Lazy<IVoiceCloneService> _voiceClones;
    public IVoiceCloneService VoiceClones { get { return _voiceClones.Value; } }

    readonly Lazy<IVoiceDesignService> _voiceDesigns;
    public IVoiceDesignService VoiceDesigns {
        get { return _voiceDesigns.Value; }
    }

    readonly Lazy<ITrafficPolicyProfileService> _trafficPolicyProfiles;
    public ITrafficPolicyProfileService TrafficPolicyProfiles {
        get { return _trafficPolicyProfiles.Value; }
    }

    readonly Lazy<IEnterpriseService> _enterprises;
    public IEnterpriseService Enterprises { get { return _enterprises.Value; } }

    readonly Lazy<IReputationService> _reputation;
    public IReputationService Reputation { get { return _reputation.Value; } }

    readonly Lazy<ITermsOfServiceService> _termsOfService;
    public ITermsOfServiceService TermsOfService {
        get { return _termsOfService.Value; }
    }

    readonly Lazy<IPronunciationDictService> _pronunciationDicts;
    public IPronunciationDictService PronunciationDicts {
        get { return _pronunciationDicts.Value; }
    }

    readonly Lazy<IUacConnectionService> _uacConnections;
    public IUacConnectionService UacConnections {
        get { return _uacConnections.Value; }
    }

    readonly Lazy<IVoiceSdkCallReportService> _voiceSdkCallReports;
    public IVoiceSdkCallReportService VoiceSdkCallReports {
        get { return _voiceSdkCallReports.Value; }
    }

    readonly Lazy<ICallReasonService> _callReasons;
    public ICallReasonService CallReasons { get { return _callReasons.Value; } }

    readonly Lazy<IDirService> _dir;
    public IDirService Dir { get { return _dir.Value; } }

    readonly Lazy<IInfringementClaimService> _infringementClaims;
    public IInfringementClaimService InfringementClaims {
        get { return _infringementClaims.Value; }
    }

    readonly Lazy<IEmailBlockService> _emailBlocks;
    public IEmailBlockService EmailBlocks { get { return _emailBlocks.Value; } }

    readonly Lazy<IEmailDomainService> _emailDomains;
    public IEmailDomainService EmailDomains {
        get { return _emailDomains.Value; }
    }

    readonly Lazy<IEmailEventService> _emailEvents;
    public IEmailEventService EmailEvents { get { return _emailEvents.Value; } }

    readonly Lazy<IEmailInboxService> _emailInboxes;
    public IEmailInboxService EmailInboxes {
        get { return _emailInboxes.Value; }
    }

    readonly Lazy<IEmailMessageService> _emailMessages;
    public IEmailMessageService EmailMessages {
        get { return _emailMessages.Value; }
    }

    readonly Lazy<IEmailTemplateService> _emailTemplates;
    public IEmailTemplateService EmailTemplates {
        get { return _emailTemplates.Value; }
    }

    readonly Lazy<IEmailThreadService> _emailThreads;
    public IEmailThreadService EmailThreads {
        get { return _emailThreads.Value; }
    }

    readonly Lazy<IEmailUnsubscribeGroupService> _emailUnsubscribeGroups;
    public IEmailUnsubscribeGroupService EmailUnsubscribeGroups {
        get { return _emailUnsubscribeGroups.Value; }
    }

    readonly Lazy<IEmailValidationService> _emailValidations;
    public IEmailValidationService EmailValidations {
        get { return _emailValidations.Value; }
    }

    readonly Lazy<IPricingService> _pricing;
    public IPricingService Pricing { get { return _pricing.Value; } }

    readonly Lazy<IWebSearchService> _webSearch;
    public IWebSearchService WebSearch { get { return _webSearch.Value; } }

    readonly Lazy<IMeetingSessionService> _meetingSessions;
    public IMeetingSessionService MeetingSessions {
        get { return _meetingSessions.Value; }
    }

    readonly Lazy<IExternalRequirementService> _externalRequirements;
    public IExternalRequirementService ExternalRequirements {
        get { return _externalRequirements.Value; }
    }

    readonly Lazy<IComputeService> _compute;
    public IComputeService Compute { get { return _compute.Value; } }

    readonly Lazy<INoiseSuppressionEngineService> _noiseSuppressionEngines;
    public INoiseSuppressionEngineService NoiseSuppressionEngines {
        get { return _noiseSuppressionEngines.Value; }
    }

    readonly Lazy<IBotChallengeService> _botChallenge;
    public IBotChallengeService BotChallenge {
        get { return _botChallenge.Value; }
    }

    readonly Lazy<IBotSessionService> _botSessions;
    public IBotSessionService BotSessions { get { return _botSessions.Value; } }

    readonly Lazy<IBotSignupService> _botSignup;
    public IBotSignupService BotSignup { get { return _botSignup.Value; } }

    readonly Lazy<IMachinePaymentService> _machinePayments;
    public IMachinePaymentService MachinePayments {
        get { return _machinePayments.Value; }
    }

    public void Dispose()
    =>this.HttpClient.Dispose();

    public TelnyxClient ()
    {
        _options = new();

        _withRawResponse =new(
            () => new TelnyxClientWithRawResponse(this._options)
        ) ;
        _legacy =new(() => new LegacyService(this)) ;
        _oauth =new(() => new OAuthService(this)) ;
        _oauthClients =new(() => new OAuthClientService(this)) ;
        _oauthGrants =new(() => new OAuthGrantService(this)) ;
        _webhooks =new(() => new WebhookService(this)) ;
        _accessIPAddress =new(() => new AccessIPAddressService(this)) ;
        _accessIPRanges =new(() => new AccessIPRangeService(this)) ;
        _actions =new(() => new ActionService(this)) ;
        _addresses =new(() => new AddressService(this)) ;
        _advancedOrders =new(() => new AdvancedOrderService(this)) ;
        _ai =new(() => new AIService(this)) ;
        _auditEvents =new(() => new AuditEventService(this)) ;
        _authenticationProviders =new(
            () => new AuthenticationProviderService(this)
        ) ;
        _availablePhoneNumberBlocks =new(
            () => new AvailablePhoneNumberBlockService(this)
        ) ;
        _availablePhoneNumbers =new(
            () => new AvailablePhoneNumberService(this)
        ) ;
        _balance =new(() => new BalanceService(this)) ;
        _billingGroups =new(() => new BillingGroupService(this)) ;
        _bulkSimCardActions =new(() => new BulkSimCardActionService(this)) ;
        _bundlePricing =new(() => new BundlePricingService(this)) ;
        _callControlApplications =new(
            () => new CallControlApplicationService(this)
        ) ;
        _callEvents =new(() => new CallEventService(this)) ;
        _calls =new(() => new CallService(this)) ;
        _channelZones =new(() => new ChannelZoneService(this)) ;
        _chargesBreakdown =new(() => new ChargesBreakdownService(this)) ;
        _chargesSummary =new(() => new ChargesSummaryService(this)) ;
        _comments =new(() => new CommentService(this)) ;
        _conferences =new(() => new ConferenceService(this)) ;
        _connections =new(() => new ConnectionService(this)) ;
        _countryCoverage =new(() => new CountryCoverageService(this)) ;
        _credentialConnections =new(
            () => new CredentialConnectionService(this)
        ) ;
        _customStorageCredentials =new(
            () => new CustomStorageCredentialService(this)
        ) ;
        _customerServiceRecords =new(
            () => new CustomerServiceRecordService(this)
        ) ;
        _detailRecords =new(() => new DetailRecordService(this)) ;
        _dialogflowConnections =new(
            () => new DialogflowConnectionService(this)
        ) ;
        _documentLinks =new(() => new DocumentLinkService(this)) ;
        _documents =new(() => new DocumentService(this)) ;
        _dynamicEmergencyAddresses =new(
            () => new DynamicEmergencyAddressService(this)
        ) ;
        _dynamicEmergencyEndpoints =new(
            () => new DynamicEmergencyEndpointService(this)
        ) ;
        _externalConnections =new(() => new ExternalConnectionService(this)) ;
        _faxApplications =new(() => new FaxApplicationService(this)) ;
        _faxes =new(() => new FaxService(this)) ;
        _fqdnConnections =new(() => new FqdnConnectionService(this)) ;
        _fqdns =new(() => new FqdnService(this)) ;
        _globalIPAllowedPorts =new(() => new GlobalIPAllowedPortService(this)) ;
        _globalIPAssignmentHealth =new(
            () => new GlobalIPAssignmentHealthService(this)
        ) ;
        _globalIPAssignments =new(() => new GlobalIPAssignmentService(this)) ;
        _globalIPAssignmentsUsage =new(
            () => new GlobalIPAssignmentsUsageService(this)
        ) ;
        _globalIPHealthCheckTypes =new(
            () => new GlobalIPHealthCheckTypeService(this)
        ) ;
        _globalIPHealthChecks =new(() => new GlobalIPHealthCheckService(this)) ;
        _globalIPLatency =new(() => new GlobalIPLatencyService(this)) ;
        _globalIPProtocols =new(() => new GlobalIPProtocolService(this)) ;
        _globalIPUsage =new(() => new GlobalIPUsageService(this)) ;
        _globalIps =new(() => new GlobalIPService(this)) ;
        _inboundChannels =new(() => new InboundChannelService(this)) ;
        _integrationSecrets =new(() => new IntegrationSecretService(this)) ;
        _inventoryCoverage =new(() => new InventoryCoverageService(this)) ;
        _invoices =new(() => new InvoiceService(this)) ;
        _ipConnections =new(() => new IPConnectionService(this)) ;
        _ips =new(() => new IPService(this)) ;
        _ledgerBillingGroupReports =new(
            () => new LedgerBillingGroupReportService(this)
        ) ;
        _list =new(() => new ListService(this)) ;
        _managedAccounts =new(() => new ManagedAccountService(this)) ;
        _media =new(() => new MediaService(this)) ;
        _messages =new(() => new MessageService(this)) ;
        _messaging =new(() => new MessagingService(this)) ;
        _messagingHostedNumberOrders =new(
            () => new MessagingHostedNumberOrderService(this)
        ) ;
        _messagingHostedNumbers =new(
            () => new MessagingHostedNumberService(this)
        ) ;
        _messagingNumbersBulkUpdates =new(
            () => new MessagingNumbersBulkUpdateService(this)
        ) ;
        _messagingOptouts =new(() => new MessagingOptoutService(this)) ;
        _messagingProfiles =new(() => new MessagingProfileService(this)) ;
        _messagingTollfree =new(() => new MessagingTollfreeService(this)) ;
        _messagingUrlDomains =new(() => new MessagingUrlDomainService(this)) ;
        _mobileNetworkOperators =new(
            () => new MobileNetworkOperatorService(this)
        ) ;
        _mobilePushCredentials =new(
            () => new MobilePushCredentialService(this)
        ) ;
        _networkCoverage =new(() => new NetworkCoverageService(this)) ;
        _networks =new(() => new NetworkService(this)) ;
        _notificationChannels =new(() => new NotificationChannelService(this)) ;
        _notificationEventConditions =new(
            () => new NotificationEventConditionService(this)
        ) ;
        _notificationEvents =new(() => new NotificationEventService(this)) ;
        _notificationProfiles =new(() => new NotificationProfileService(this)) ;
        _notificationSettings =new(() => new NotificationSettingService(this)) ;
        _numberBlockOrders =new(() => new NumberBlockOrderService(this)) ;
        _numberLookup =new(() => new NumberLookupService(this)) ;
        _numberOrderPhoneNumbers =new(
            () => new NumberOrderPhoneNumberService(this)
        ) ;
        _numberOrders =new(() => new NumberOrderService(this)) ;
        _numberReservations =new(() => new NumberReservationService(this)) ;
        _numbersFeatures =new(() => new NumbersFeatureService(this)) ;
        _operatorConnect =new(() => new OperatorConnectService(this)) ;
        _otaUpdates =new(() => new OtaUpdateService(this)) ;
        _outboundVoiceProfiles =new(
            () => new OutboundVoiceProfileService(this)
        ) ;
        _payment =new(() => new PaymentService(this)) ;
        _phoneNumberBlocks =new(() => new PhoneNumberBlockService(this)) ;
        _phoneNumbers =new(() => new PhoneNumberService(this)) ;
        _phoneNumbersRegulatoryRequirements =new(
            () => new PhoneNumbersRegulatoryRequirementService(this)
        ) ;
        _portabilityChecks =new(() => new PortabilityCheckService(this)) ;
        _porting =new(() => new PortingService(this)) ;
        _portingOrders =new(() => new PortingOrderService(this)) ;
        _portingPhoneNumbers =new(() => new PortingPhoneNumberService(this)) ;
        _portouts =new(() => new PortoutService(this)) ;
        _privateWirelessGateways =new(
            () => new PrivateWirelessGatewayService(this)
        ) ;
        _publicInternetGateways =new(
            () => new PublicInternetGatewayService(this)
        ) ;
        _queues =new(() => new QueueService(this)) ;
        _rcs =new(() => new RcService(this)) ;
        _recordingTranscriptions =new(
            () => new RecordingTranscriptionService(this)
        ) ;
        _recordings =new(() => new RecordingService(this)) ;
        _regions =new(() => new RegionService(this)) ;
        _regulatoryRequirements =new(
            () => new RegulatoryRequirementService(this)
        ) ;
        _reports =new(() => new ReportService(this)) ;
        _speechToText =new(() => new SpeechToTextService(this)) ;
        _requirementGroups =new(() => new RequirementGroupService(this)) ;
        _requirementTypes =new(() => new RequirementTypeService(this)) ;
        _requirements =new(() => new RequirementService(this)) ;
        _roomCompositions =new(() => new RoomCompositionService(this)) ;
        _roomParticipants =new(() => new RoomParticipantService(this)) ;
        _roomRecordings =new(() => new RoomRecordingService(this)) ;
        _rooms =new(() => new RoomService(this)) ;
        _seti =new(() => new SetiService(this)) ;
        _shortCodes =new(() => new ShortCodeService(this)) ;
        _simCardDataUsageNotifications =new(
            () => new SimCardDataUsageNotificationService(this)
        ) ;
        _simCardGroups =new(() => new SimCardGroupService(this)) ;
        _simCardOrderPreview =new(() => new SimCardOrderPreviewService(this)) ;
        _simCardOrders =new(() => new SimCardOrderService(this)) ;
        _simCards =new(() => new SimCardService(this)) ;
        _siprecConnectors =new(() => new SiprecConnectorService(this)) ;
        _storage =new(() => new StorageService(this)) ;
        _subNumberOrders =new(() => new SubNumberOrderService(this)) ;
        _subNumberOrdersReport =new(
            () => new SubNumberOrdersReportService(this)
        ) ;
        _telephonyCredentials =new(() => new TelephonyCredentialService(this)) ;
        _texml =new(() => new TexmlService(this)) ;
        _texmlApplications =new(() => new TexmlApplicationService(this)) ;
        _textToSpeech =new(() => new TextToSpeechService(this)) ;
        _usageReports =new(() => new UsageReportService(this)) ;
        _userAddresses =new(() => new UserAddressService(this)) ;
        _userTags =new(() => new UserTagService(this)) ;
        _verifications =new(() => new VerificationService(this)) ;
        _verifiedNumbers =new(() => new VerifiedNumberService(this)) ;
        _verifyProfiles =new(() => new VerifyProfileService(this)) ;
        _virtualCrossConnects =new(() => new VirtualCrossConnectService(this)) ;
        _virtualCrossConnectsCoverage =new(
            () => new VirtualCrossConnectsCoverageService(this)
        ) ;
        _webhookDeliveries =new(() => new WebhookDeliveryService(this)) ;
        _wireguardInterfaces =new(() => new WireguardInterfaceService(this)) ;
        _wireguardPeers =new(() => new WireguardPeerService(this)) ;
        _wireless =new(() => new WirelessService(this)) ;
        _wirelessBlocklistValues =new(
            () => new WirelessBlocklistValueService(this)
        ) ;
        _wirelessBlocklists =new(() => new WirelessBlocklistService(this)) ;
        _wellKnown =new(() => new WellKnownService(this)) ;
        _inexplicitNumberOrders =new(
            () => new InexplicitNumberOrderService(this)
        ) ;
        _mobilePhoneNumbers =new(() => new MobilePhoneNumberService(this)) ;
        _mobileVoiceConnections =new(
            () => new MobileVoiceConnectionService(this)
        ) ;
        _messaging10dlc =new(() => new Messaging10dlcService(this)) ;
        _organizations =new(() => new OrganizationService(this)) ;
        _alphanumericSenderIds =new(
            () => new AlphanumericSenderIDService(this)
        ) ;
        _messagingProfileMetrics =new(
            () => new MessagingProfileMetricService(this)
        ) ;
        _sessionAnalysis =new(() => new SessionAnalysisService(this)) ;
        _whatsapp =new(() => new WhatsappService(this)) ;
        _whatsappMessageTemplates =new(
            () => new WhatsappMessageTemplateService(this)
        ) ;
        _x402 =new(() => new X402Service(this)) ;
        _voiceClones =new(() => new VoiceCloneService(this)) ;
        _voiceDesigns =new(() => new VoiceDesignService(this)) ;
        _trafficPolicyProfiles =new(
            () => new TrafficPolicyProfileService(this)
        ) ;
        _enterprises =new(() => new EnterpriseService(this)) ;
        _reputation =new(() => new ReputationService(this)) ;
        _termsOfService =new(() => new TermsOfServiceService(this)) ;
        _pronunciationDicts =new(() => new PronunciationDictService(this)) ;
        _uacConnections =new(() => new UacConnectionService(this)) ;
        _voiceSdkCallReports =new(() => new VoiceSdkCallReportService(this)) ;
        _callReasons =new(() => new CallReasonService(this)) ;
        _dir =new(() => new DirService(this)) ;
        _infringementClaims =new(() => new InfringementClaimService(this)) ;
        _emailBlocks =new(() => new EmailBlockService(this)) ;
        _emailDomains =new(() => new EmailDomainService(this)) ;
        _emailEvents =new(() => new EmailEventService(this)) ;
        _emailInboxes =new(() => new EmailInboxService(this)) ;
        _emailMessages =new(() => new EmailMessageService(this)) ;
        _emailTemplates =new(() => new EmailTemplateService(this)) ;
        _emailThreads =new(() => new EmailThreadService(this)) ;
        _emailUnsubscribeGroups =new(
            () => new EmailUnsubscribeGroupService(this)
        ) ;
        _emailValidations =new(() => new EmailValidationService(this)) ;
        _pricing =new(() => new PricingService(this)) ;
        _webSearch =new(() => new WebSearchService(this)) ;
        _meetingSessions =new(() => new MeetingSessionService(this)) ;
        _externalRequirements =new(() => new ExternalRequirementService(this)) ;
        _compute =new(() => new ComputeService(this)) ;
        _noiseSuppressionEngines =new(
            () => new NoiseSuppressionEngineService(this)
        ) ;
        _botChallenge =new(() => new BotChallengeService(this)) ;
        _botSessions =new(() => new BotSessionService(this)) ;
        _botSignup =new(() => new BotSignupService(this)) ;
        _machinePayments =new(() => new MachinePaymentService(this)) ;
    }

    public TelnyxClient (ClientOptions options) : this()
    { _options = options; }
}

/// <inheritdoc/>
public sealed class TelnyxClientWithRawResponse : ITelnyxClientWithRawResponse
{

    #if NET
    static readonly Random Random = Random.Shared;
    #else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random { get { return _threadLocalRandom.Value!; } }
    #endif


    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? PublicKey {
        get { return this._options.PublicKey; }
        init { this._options.PublicKey = value; }
    }

    /// <inheritdoc/>
    public string? ClientID {
        get { return this._options.ClientID; }
        init { this._options.ClientID = value; }
    }

    /// <inheritdoc/>
    public string? ClientSecret {
        get { return this._options.ClientSecret; }
        init { this._options.ClientSecret = value; }
    }

    /// <inheritdoc/>
    public string? PaymentAuthorization {
        get { return this._options.PaymentAuthorization; }
        init { this._options.PaymentAuthorization = value; }
    }

    /// <inheritdoc/>
    public ITelnyxClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TelnyxClientWithRawResponse(modifier(this._options)); }

    readonly Lazy<ILegacyServiceWithRawResponse> _legacy;
    public ILegacyServiceWithRawResponse Legacy {
        get { return _legacy.Value; }
    }

    readonly Lazy<IOAuthServiceWithRawResponse> _oauth;
    public IOAuthServiceWithRawResponse OAuth { get { return _oauth.Value; } }

    readonly Lazy<IOAuthClientServiceWithRawResponse> _oauthClients;
    public IOAuthClientServiceWithRawResponse OAuthClients {
        get { return _oauthClients.Value; }
    }

    readonly Lazy<IOAuthGrantServiceWithRawResponse> _oauthGrants;
    public IOAuthGrantServiceWithRawResponse OAuthGrants {
        get { return _oauthGrants.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks {
        get { return _webhooks.Value; }
    }

    readonly Lazy<IAccessIPAddressServiceWithRawResponse> _accessIPAddress;
    public IAccessIPAddressServiceWithRawResponse AccessIPAddress {
        get { return _accessIPAddress.Value; }
    }

    readonly Lazy<IAccessIPRangeServiceWithRawResponse> _accessIPRanges;
    public IAccessIPRangeServiceWithRawResponse AccessIPRanges {
        get { return _accessIPRanges.Value; }
    }

    readonly Lazy<IActionServiceWithRawResponse> _actions;
    public IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<IAddressServiceWithRawResponse> _addresses;
    public IAddressServiceWithRawResponse Addresses {
        get { return _addresses.Value; }
    }

    readonly Lazy<IAdvancedOrderServiceWithRawResponse> _advancedOrders;
    public IAdvancedOrderServiceWithRawResponse AdvancedOrders {
        get { return _advancedOrders.Value; }
    }

    readonly Lazy<IAIServiceWithRawResponse> _ai;
    public IAIServiceWithRawResponse AI { get { return _ai.Value; } }

    readonly Lazy<IAuditEventServiceWithRawResponse> _auditEvents;
    public IAuditEventServiceWithRawResponse AuditEvents {
        get { return _auditEvents.Value; }
    }

    readonly Lazy<IAuthenticationProviderServiceWithRawResponse> _authenticationProviders;
    public IAuthenticationProviderServiceWithRawResponse AuthenticationProviders {
        get { return _authenticationProviders.Value; }
    }

    readonly Lazy<IAvailablePhoneNumberBlockServiceWithRawResponse> _availablePhoneNumberBlocks;
    public IAvailablePhoneNumberBlockServiceWithRawResponse AvailablePhoneNumberBlocks {
        get { return _availablePhoneNumberBlocks.Value; }
    }

    readonly Lazy<IAvailablePhoneNumberServiceWithRawResponse> _availablePhoneNumbers;
    public IAvailablePhoneNumberServiceWithRawResponse AvailablePhoneNumbers {
        get { return _availablePhoneNumbers.Value; }
    }

    readonly Lazy<IBalanceServiceWithRawResponse> _balance;
    public IBalanceServiceWithRawResponse Balance {
        get { return _balance.Value; }
    }

    readonly Lazy<IBillingGroupServiceWithRawResponse> _billingGroups;
    public IBillingGroupServiceWithRawResponse BillingGroups {
        get { return _billingGroups.Value; }
    }

    readonly Lazy<IBulkSimCardActionServiceWithRawResponse> _bulkSimCardActions;
    public IBulkSimCardActionServiceWithRawResponse BulkSimCardActions {
        get { return _bulkSimCardActions.Value; }
    }

    readonly Lazy<IBundlePricingServiceWithRawResponse> _bundlePricing;
    public IBundlePricingServiceWithRawResponse BundlePricing {
        get { return _bundlePricing.Value; }
    }

    readonly Lazy<ICallControlApplicationServiceWithRawResponse> _callControlApplications;
    public ICallControlApplicationServiceWithRawResponse CallControlApplications {
        get { return _callControlApplications.Value; }
    }

    readonly Lazy<ICallEventServiceWithRawResponse> _callEvents;
    public ICallEventServiceWithRawResponse CallEvents {
        get { return _callEvents.Value; }
    }

    readonly Lazy<ICallServiceWithRawResponse> _calls;
    public ICallServiceWithRawResponse Calls { get { return _calls.Value; } }

    readonly Lazy<IChannelZoneServiceWithRawResponse> _channelZones;
    public IChannelZoneServiceWithRawResponse ChannelZones {
        get { return _channelZones.Value; }
    }

    readonly Lazy<IChargesBreakdownServiceWithRawResponse> _chargesBreakdown;
    public IChargesBreakdownServiceWithRawResponse ChargesBreakdown {
        get { return _chargesBreakdown.Value; }
    }

    readonly Lazy<IChargesSummaryServiceWithRawResponse> _chargesSummary;
    public IChargesSummaryServiceWithRawResponse ChargesSummary {
        get { return _chargesSummary.Value; }
    }

    readonly Lazy<ICommentServiceWithRawResponse> _comments;
    public ICommentServiceWithRawResponse Comments {
        get { return _comments.Value; }
    }

    readonly Lazy<IConferenceServiceWithRawResponse> _conferences;
    public IConferenceServiceWithRawResponse Conferences {
        get { return _conferences.Value; }
    }

    readonly Lazy<IConnectionServiceWithRawResponse> _connections;
    public IConnectionServiceWithRawResponse Connections {
        get { return _connections.Value; }
    }

    readonly Lazy<ICountryCoverageServiceWithRawResponse> _countryCoverage;
    public ICountryCoverageServiceWithRawResponse CountryCoverage {
        get { return _countryCoverage.Value; }
    }

    readonly Lazy<ICredentialConnectionServiceWithRawResponse> _credentialConnections;
    public ICredentialConnectionServiceWithRawResponse CredentialConnections {
        get { return _credentialConnections.Value; }
    }

    readonly Lazy<ICustomStorageCredentialServiceWithRawResponse> _customStorageCredentials;
    public ICustomStorageCredentialServiceWithRawResponse CustomStorageCredentials {
        get { return _customStorageCredentials.Value; }
    }

    readonly Lazy<ICustomerServiceRecordServiceWithRawResponse> _customerServiceRecords;
    public ICustomerServiceRecordServiceWithRawResponse CustomerServiceRecords {
        get { return _customerServiceRecords.Value; }
    }

    readonly Lazy<IDetailRecordServiceWithRawResponse> _detailRecords;
    public IDetailRecordServiceWithRawResponse DetailRecords {
        get { return _detailRecords.Value; }
    }

    readonly Lazy<IDialogflowConnectionServiceWithRawResponse> _dialogflowConnections;
    public IDialogflowConnectionServiceWithRawResponse DialogflowConnections {
        get { return _dialogflowConnections.Value; }
    }

    readonly Lazy<IDocumentLinkServiceWithRawResponse> _documentLinks;
    public IDocumentLinkServiceWithRawResponse DocumentLinks {
        get { return _documentLinks.Value; }
    }

    readonly Lazy<IDocumentServiceWithRawResponse> _documents;
    public IDocumentServiceWithRawResponse Documents {
        get { return _documents.Value; }
    }

    readonly Lazy<IDynamicEmergencyAddressServiceWithRawResponse> _dynamicEmergencyAddresses;
    public IDynamicEmergencyAddressServiceWithRawResponse DynamicEmergencyAddresses {
        get { return _dynamicEmergencyAddresses.Value; }
    }

    readonly Lazy<IDynamicEmergencyEndpointServiceWithRawResponse> _dynamicEmergencyEndpoints;
    public IDynamicEmergencyEndpointServiceWithRawResponse DynamicEmergencyEndpoints {
        get { return _dynamicEmergencyEndpoints.Value; }
    }

    readonly Lazy<IExternalConnectionServiceWithRawResponse> _externalConnections;
    public IExternalConnectionServiceWithRawResponse ExternalConnections {
        get { return _externalConnections.Value; }
    }

    readonly Lazy<IFaxApplicationServiceWithRawResponse> _faxApplications;
    public IFaxApplicationServiceWithRawResponse FaxApplications {
        get { return _faxApplications.Value; }
    }

    readonly Lazy<IFaxServiceWithRawResponse> _faxes;
    public IFaxServiceWithRawResponse Faxes { get { return _faxes.Value; } }

    readonly Lazy<IFqdnConnectionServiceWithRawResponse> _fqdnConnections;
    public IFqdnConnectionServiceWithRawResponse FqdnConnections {
        get { return _fqdnConnections.Value; }
    }

    readonly Lazy<IFqdnServiceWithRawResponse> _fqdns;
    public IFqdnServiceWithRawResponse Fqdns { get { return _fqdns.Value; } }

    readonly Lazy<IGlobalIPAllowedPortServiceWithRawResponse> _globalIPAllowedPorts;
    public IGlobalIPAllowedPortServiceWithRawResponse GlobalIPAllowedPorts {
        get { return _globalIPAllowedPorts.Value; }
    }

    readonly Lazy<IGlobalIPAssignmentHealthServiceWithRawResponse> _globalIPAssignmentHealth;
    public IGlobalIPAssignmentHealthServiceWithRawResponse GlobalIPAssignmentHealth {
        get { return _globalIPAssignmentHealth.Value; }
    }

    readonly Lazy<IGlobalIPAssignmentServiceWithRawResponse> _globalIPAssignments;
    public IGlobalIPAssignmentServiceWithRawResponse GlobalIPAssignments {
        get { return _globalIPAssignments.Value; }
    }

    readonly Lazy<IGlobalIPAssignmentsUsageServiceWithRawResponse> _globalIPAssignmentsUsage;
    public IGlobalIPAssignmentsUsageServiceWithRawResponse GlobalIPAssignmentsUsage {
        get { return _globalIPAssignmentsUsage.Value; }
    }

    readonly Lazy<IGlobalIPHealthCheckTypeServiceWithRawResponse> _globalIPHealthCheckTypes;
    public IGlobalIPHealthCheckTypeServiceWithRawResponse GlobalIPHealthCheckTypes {
        get { return _globalIPHealthCheckTypes.Value; }
    }

    readonly Lazy<IGlobalIPHealthCheckServiceWithRawResponse> _globalIPHealthChecks;
    public IGlobalIPHealthCheckServiceWithRawResponse GlobalIPHealthChecks {
        get { return _globalIPHealthChecks.Value; }
    }

    readonly Lazy<IGlobalIPLatencyServiceWithRawResponse> _globalIPLatency;
    public IGlobalIPLatencyServiceWithRawResponse GlobalIPLatency {
        get { return _globalIPLatency.Value; }
    }

    readonly Lazy<IGlobalIPProtocolServiceWithRawResponse> _globalIPProtocols;
    public IGlobalIPProtocolServiceWithRawResponse GlobalIPProtocols {
        get { return _globalIPProtocols.Value; }
    }

    readonly Lazy<IGlobalIPUsageServiceWithRawResponse> _globalIPUsage;
    public IGlobalIPUsageServiceWithRawResponse GlobalIPUsage {
        get { return _globalIPUsage.Value; }
    }

    readonly Lazy<IGlobalIPServiceWithRawResponse> _globalIps;
    public IGlobalIPServiceWithRawResponse GlobalIps {
        get { return _globalIps.Value; }
    }

    readonly Lazy<IInboundChannelServiceWithRawResponse> _inboundChannels;
    public IInboundChannelServiceWithRawResponse InboundChannels {
        get { return _inboundChannels.Value; }
    }

    readonly Lazy<IIntegrationSecretServiceWithRawResponse> _integrationSecrets;
    public IIntegrationSecretServiceWithRawResponse IntegrationSecrets {
        get { return _integrationSecrets.Value; }
    }

    readonly Lazy<IInventoryCoverageServiceWithRawResponse> _inventoryCoverage;
    public IInventoryCoverageServiceWithRawResponse InventoryCoverage {
        get { return _inventoryCoverage.Value; }
    }

    readonly Lazy<IInvoiceServiceWithRawResponse> _invoices;
    public IInvoiceServiceWithRawResponse Invoices {
        get { return _invoices.Value; }
    }

    readonly Lazy<IIPConnectionServiceWithRawResponse> _ipConnections;
    public IIPConnectionServiceWithRawResponse IPConnections {
        get { return _ipConnections.Value; }
    }

    readonly Lazy<IIPServiceWithRawResponse> _ips;
    public IIPServiceWithRawResponse Ips { get { return _ips.Value; } }

    readonly Lazy<ILedgerBillingGroupReportServiceWithRawResponse> _ledgerBillingGroupReports;
    public ILedgerBillingGroupReportServiceWithRawResponse LedgerBillingGroupReports {
        get { return _ledgerBillingGroupReports.Value; }
    }

    readonly Lazy<IListServiceWithRawResponse> _list;
    public IListServiceWithRawResponse List { get { return _list.Value; } }

    readonly Lazy<IManagedAccountServiceWithRawResponse> _managedAccounts;
    public IManagedAccountServiceWithRawResponse ManagedAccounts {
        get { return _managedAccounts.Value; }
    }

    readonly Lazy<IMediaServiceWithRawResponse> _media;
    public IMediaServiceWithRawResponse Media { get { return _media.Value; } }

    readonly Lazy<IMessageServiceWithRawResponse> _messages;
    public IMessageServiceWithRawResponse Messages {
        get { return _messages.Value; }
    }

    readonly Lazy<IMessagingServiceWithRawResponse> _messaging;
    public IMessagingServiceWithRawResponse Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<IMessagingHostedNumberOrderServiceWithRawResponse> _messagingHostedNumberOrders;
    public IMessagingHostedNumberOrderServiceWithRawResponse MessagingHostedNumberOrders {
        get { return _messagingHostedNumberOrders.Value; }
    }

    readonly Lazy<IMessagingHostedNumberServiceWithRawResponse> _messagingHostedNumbers;
    public IMessagingHostedNumberServiceWithRawResponse MessagingHostedNumbers {
        get { return _messagingHostedNumbers.Value; }
    }

    readonly Lazy<IMessagingNumbersBulkUpdateServiceWithRawResponse> _messagingNumbersBulkUpdates;
    public IMessagingNumbersBulkUpdateServiceWithRawResponse MessagingNumbersBulkUpdates {
        get { return _messagingNumbersBulkUpdates.Value; }
    }

    readonly Lazy<IMessagingOptoutServiceWithRawResponse> _messagingOptouts;
    public IMessagingOptoutServiceWithRawResponse MessagingOptouts {
        get { return _messagingOptouts.Value; }
    }

    readonly Lazy<IMessagingProfileServiceWithRawResponse> _messagingProfiles;
    public IMessagingProfileServiceWithRawResponse MessagingProfiles {
        get { return _messagingProfiles.Value; }
    }

    readonly Lazy<IMessagingTollfreeServiceWithRawResponse> _messagingTollfree;
    public IMessagingTollfreeServiceWithRawResponse MessagingTollfree {
        get { return _messagingTollfree.Value; }
    }

    readonly Lazy<IMessagingUrlDomainServiceWithRawResponse> _messagingUrlDomains;
    public IMessagingUrlDomainServiceWithRawResponse MessagingUrlDomains {
        get { return _messagingUrlDomains.Value; }
    }

    readonly Lazy<IMobileNetworkOperatorServiceWithRawResponse> _mobileNetworkOperators;
    public IMobileNetworkOperatorServiceWithRawResponse MobileNetworkOperators {
        get { return _mobileNetworkOperators.Value; }
    }

    readonly Lazy<IMobilePushCredentialServiceWithRawResponse> _mobilePushCredentials;
    public IMobilePushCredentialServiceWithRawResponse MobilePushCredentials {
        get { return _mobilePushCredentials.Value; }
    }

    readonly Lazy<INetworkCoverageServiceWithRawResponse> _networkCoverage;
    public INetworkCoverageServiceWithRawResponse NetworkCoverage {
        get { return _networkCoverage.Value; }
    }

    readonly Lazy<INetworkServiceWithRawResponse> _networks;
    public INetworkServiceWithRawResponse Networks {
        get { return _networks.Value; }
    }

    readonly Lazy<INotificationChannelServiceWithRawResponse> _notificationChannels;
    public INotificationChannelServiceWithRawResponse NotificationChannels {
        get { return _notificationChannels.Value; }
    }

    readonly Lazy<INotificationEventConditionServiceWithRawResponse> _notificationEventConditions;
    public INotificationEventConditionServiceWithRawResponse NotificationEventConditions {
        get { return _notificationEventConditions.Value; }
    }

    readonly Lazy<INotificationEventServiceWithRawResponse> _notificationEvents;
    public INotificationEventServiceWithRawResponse NotificationEvents {
        get { return _notificationEvents.Value; }
    }

    readonly Lazy<INotificationProfileServiceWithRawResponse> _notificationProfiles;
    public INotificationProfileServiceWithRawResponse NotificationProfiles {
        get { return _notificationProfiles.Value; }
    }

    readonly Lazy<INotificationSettingServiceWithRawResponse> _notificationSettings;
    public INotificationSettingServiceWithRawResponse NotificationSettings {
        get { return _notificationSettings.Value; }
    }

    readonly Lazy<INumberBlockOrderServiceWithRawResponse> _numberBlockOrders;
    public INumberBlockOrderServiceWithRawResponse NumberBlockOrders {
        get { return _numberBlockOrders.Value; }
    }

    readonly Lazy<INumberLookupServiceWithRawResponse> _numberLookup;
    public INumberLookupServiceWithRawResponse NumberLookup {
        get { return _numberLookup.Value; }
    }

    readonly Lazy<INumberOrderPhoneNumberServiceWithRawResponse> _numberOrderPhoneNumbers;
    public INumberOrderPhoneNumberServiceWithRawResponse NumberOrderPhoneNumbers {
        get { return _numberOrderPhoneNumbers.Value; }
    }

    readonly Lazy<INumberOrderServiceWithRawResponse> _numberOrders;
    public INumberOrderServiceWithRawResponse NumberOrders {
        get { return _numberOrders.Value; }
    }

    readonly Lazy<INumberReservationServiceWithRawResponse> _numberReservations;
    public INumberReservationServiceWithRawResponse NumberReservations {
        get { return _numberReservations.Value; }
    }

    readonly Lazy<INumbersFeatureServiceWithRawResponse> _numbersFeatures;
    public INumbersFeatureServiceWithRawResponse NumbersFeatures {
        get { return _numbersFeatures.Value; }
    }

    readonly Lazy<IOperatorConnectServiceWithRawResponse> _operatorConnect;
    public IOperatorConnectServiceWithRawResponse OperatorConnect {
        get { return _operatorConnect.Value; }
    }

    readonly Lazy<IOtaUpdateServiceWithRawResponse> _otaUpdates;
    public IOtaUpdateServiceWithRawResponse OtaUpdates {
        get { return _otaUpdates.Value; }
    }

    readonly Lazy<IOutboundVoiceProfileServiceWithRawResponse> _outboundVoiceProfiles;
    public IOutboundVoiceProfileServiceWithRawResponse OutboundVoiceProfiles {
        get { return _outboundVoiceProfiles.Value; }
    }

    readonly Lazy<IPaymentServiceWithRawResponse> _payment;
    public IPaymentServiceWithRawResponse Payment {
        get { return _payment.Value; }
    }

    readonly Lazy<IPhoneNumberBlockServiceWithRawResponse> _phoneNumberBlocks;
    public IPhoneNumberBlockServiceWithRawResponse PhoneNumberBlocks {
        get { return _phoneNumberBlocks.Value; }
    }

    readonly Lazy<IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public IPhoneNumberServiceWithRawResponse PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<IPhoneNumbersRegulatoryRequirementServiceWithRawResponse> _phoneNumbersRegulatoryRequirements;
    public IPhoneNumbersRegulatoryRequirementServiceWithRawResponse PhoneNumbersRegulatoryRequirements {
        get { return _phoneNumbersRegulatoryRequirements.Value; }
    }

    readonly Lazy<IPortabilityCheckServiceWithRawResponse> _portabilityChecks;
    public IPortabilityCheckServiceWithRawResponse PortabilityChecks {
        get { return _portabilityChecks.Value; }
    }

    readonly Lazy<IPortingServiceWithRawResponse> _porting;
    public IPortingServiceWithRawResponse Porting {
        get { return _porting.Value; }
    }

    readonly Lazy<IPortingOrderServiceWithRawResponse> _portingOrders;
    public IPortingOrderServiceWithRawResponse PortingOrders {
        get { return _portingOrders.Value; }
    }

    readonly Lazy<IPortingPhoneNumberServiceWithRawResponse> _portingPhoneNumbers;
    public IPortingPhoneNumberServiceWithRawResponse PortingPhoneNumbers {
        get { return _portingPhoneNumbers.Value; }
    }

    readonly Lazy<IPortoutServiceWithRawResponse> _portouts;
    public IPortoutServiceWithRawResponse Portouts {
        get { return _portouts.Value; }
    }

    readonly Lazy<IPrivateWirelessGatewayServiceWithRawResponse> _privateWirelessGateways;
    public IPrivateWirelessGatewayServiceWithRawResponse PrivateWirelessGateways {
        get { return _privateWirelessGateways.Value; }
    }

    readonly Lazy<IPublicInternetGatewayServiceWithRawResponse> _publicInternetGateways;
    public IPublicInternetGatewayServiceWithRawResponse PublicInternetGateways {
        get { return _publicInternetGateways.Value; }
    }

    readonly Lazy<IQueueServiceWithRawResponse> _queues;
    public IQueueServiceWithRawResponse Queues { get { return _queues.Value; } }

    readonly Lazy<IRcServiceWithRawResponse> _rcs;
    public IRcServiceWithRawResponse Rcs { get { return _rcs.Value; } }

    readonly Lazy<IRecordingTranscriptionServiceWithRawResponse> _recordingTranscriptions;
    public IRecordingTranscriptionServiceWithRawResponse RecordingTranscriptions {
        get { return _recordingTranscriptions.Value; }
    }

    readonly Lazy<IRecordingServiceWithRawResponse> _recordings;
    public IRecordingServiceWithRawResponse Recordings {
        get { return _recordings.Value; }
    }

    readonly Lazy<IRegionServiceWithRawResponse> _regions;
    public IRegionServiceWithRawResponse Regions {
        get { return _regions.Value; }
    }

    readonly Lazy<IRegulatoryRequirementServiceWithRawResponse> _regulatoryRequirements;
    public IRegulatoryRequirementServiceWithRawResponse RegulatoryRequirements {
        get { return _regulatoryRequirements.Value; }
    }

    readonly Lazy<IReportServiceWithRawResponse> _reports;
    public IReportServiceWithRawResponse Reports {
        get { return _reports.Value; }
    }

    readonly Lazy<ISpeechToTextServiceWithRawResponse> _speechToText;
    public ISpeechToTextServiceWithRawResponse SpeechToText {
        get { return _speechToText.Value; }
    }

    readonly Lazy<IRequirementGroupServiceWithRawResponse> _requirementGroups;
    public IRequirementGroupServiceWithRawResponse RequirementGroups {
        get { return _requirementGroups.Value; }
    }

    readonly Lazy<IRequirementTypeServiceWithRawResponse> _requirementTypes;
    public IRequirementTypeServiceWithRawResponse RequirementTypes {
        get { return _requirementTypes.Value; }
    }

    readonly Lazy<IRequirementServiceWithRawResponse> _requirements;
    public IRequirementServiceWithRawResponse Requirements {
        get { return _requirements.Value; }
    }

    readonly Lazy<IRoomCompositionServiceWithRawResponse> _roomCompositions;
    public IRoomCompositionServiceWithRawResponse RoomCompositions {
        get { return _roomCompositions.Value; }
    }

    readonly Lazy<IRoomParticipantServiceWithRawResponse> _roomParticipants;
    public IRoomParticipantServiceWithRawResponse RoomParticipants {
        get { return _roomParticipants.Value; }
    }

    readonly Lazy<IRoomRecordingServiceWithRawResponse> _roomRecordings;
    public IRoomRecordingServiceWithRawResponse RoomRecordings {
        get { return _roomRecordings.Value; }
    }

    readonly Lazy<IRoomServiceWithRawResponse> _rooms;
    public IRoomServiceWithRawResponse Rooms { get { return _rooms.Value; } }

    readonly Lazy<ISetiServiceWithRawResponse> _seti;
    public ISetiServiceWithRawResponse Seti { get { return _seti.Value; } }

    readonly Lazy<IShortCodeServiceWithRawResponse> _shortCodes;
    public IShortCodeServiceWithRawResponse ShortCodes {
        get { return _shortCodes.Value; }
    }

    readonly Lazy<ISimCardDataUsageNotificationServiceWithRawResponse> _simCardDataUsageNotifications;
    public ISimCardDataUsageNotificationServiceWithRawResponse SimCardDataUsageNotifications {
        get { return _simCardDataUsageNotifications.Value; }
    }

    readonly Lazy<ISimCardGroupServiceWithRawResponse> _simCardGroups;
    public ISimCardGroupServiceWithRawResponse SimCardGroups {
        get { return _simCardGroups.Value; }
    }

    readonly Lazy<ISimCardOrderPreviewServiceWithRawResponse> _simCardOrderPreview;
    public ISimCardOrderPreviewServiceWithRawResponse SimCardOrderPreview {
        get { return _simCardOrderPreview.Value; }
    }

    readonly Lazy<ISimCardOrderServiceWithRawResponse> _simCardOrders;
    public ISimCardOrderServiceWithRawResponse SimCardOrders {
        get { return _simCardOrders.Value; }
    }

    readonly Lazy<ISimCardServiceWithRawResponse> _simCards;
    public ISimCardServiceWithRawResponse SimCards {
        get { return _simCards.Value; }
    }

    readonly Lazy<ISiprecConnectorServiceWithRawResponse> _siprecConnectors;
    public ISiprecConnectorServiceWithRawResponse SiprecConnectors {
        get { return _siprecConnectors.Value; }
    }

    readonly Lazy<IStorageServiceWithRawResponse> _storage;
    public IStorageServiceWithRawResponse Storage {
        get { return _storage.Value; }
    }

    readonly Lazy<ISubNumberOrderServiceWithRawResponse> _subNumberOrders;
    public ISubNumberOrderServiceWithRawResponse SubNumberOrders {
        get { return _subNumberOrders.Value; }
    }

    readonly Lazy<ISubNumberOrdersReportServiceWithRawResponse> _subNumberOrdersReport;
    public ISubNumberOrdersReportServiceWithRawResponse SubNumberOrdersReport {
        get { return _subNumberOrdersReport.Value; }
    }

    readonly Lazy<ITelephonyCredentialServiceWithRawResponse> _telephonyCredentials;
    public ITelephonyCredentialServiceWithRawResponse TelephonyCredentials {
        get { return _telephonyCredentials.Value; }
    }

    readonly Lazy<ITexmlServiceWithRawResponse> _texml;
    public ITexmlServiceWithRawResponse Texml { get { return _texml.Value; } }

    readonly Lazy<ITexmlApplicationServiceWithRawResponse> _texmlApplications;
    public ITexmlApplicationServiceWithRawResponse TexmlApplications {
        get { return _texmlApplications.Value; }
    }

    readonly Lazy<ITextToSpeechServiceWithRawResponse> _textToSpeech;
    public ITextToSpeechServiceWithRawResponse TextToSpeech {
        get { return _textToSpeech.Value; }
    }

    readonly Lazy<IUsageReportServiceWithRawResponse> _usageReports;
    public IUsageReportServiceWithRawResponse UsageReports {
        get { return _usageReports.Value; }
    }

    readonly Lazy<IUserAddressServiceWithRawResponse> _userAddresses;
    public IUserAddressServiceWithRawResponse UserAddresses {
        get { return _userAddresses.Value; }
    }

    readonly Lazy<IUserTagServiceWithRawResponse> _userTags;
    public IUserTagServiceWithRawResponse UserTags {
        get { return _userTags.Value; }
    }

    readonly Lazy<IVerificationServiceWithRawResponse> _verifications;
    public IVerificationServiceWithRawResponse Verifications {
        get { return _verifications.Value; }
    }

    readonly Lazy<IVerifiedNumberServiceWithRawResponse> _verifiedNumbers;
    public IVerifiedNumberServiceWithRawResponse VerifiedNumbers {
        get { return _verifiedNumbers.Value; }
    }

    readonly Lazy<IVerifyProfileServiceWithRawResponse> _verifyProfiles;
    public IVerifyProfileServiceWithRawResponse VerifyProfiles {
        get { return _verifyProfiles.Value; }
    }

    readonly Lazy<IVirtualCrossConnectServiceWithRawResponse> _virtualCrossConnects;
    public IVirtualCrossConnectServiceWithRawResponse VirtualCrossConnects {
        get { return _virtualCrossConnects.Value; }
    }

    readonly Lazy<IVirtualCrossConnectsCoverageServiceWithRawResponse> _virtualCrossConnectsCoverage;
    public IVirtualCrossConnectsCoverageServiceWithRawResponse VirtualCrossConnectsCoverage {
        get { return _virtualCrossConnectsCoverage.Value; }
    }

    readonly Lazy<IWebhookDeliveryServiceWithRawResponse> _webhookDeliveries;
    public IWebhookDeliveryServiceWithRawResponse WebhookDeliveries {
        get { return _webhookDeliveries.Value; }
    }

    readonly Lazy<IWireguardInterfaceServiceWithRawResponse> _wireguardInterfaces;
    public IWireguardInterfaceServiceWithRawResponse WireguardInterfaces {
        get { return _wireguardInterfaces.Value; }
    }

    readonly Lazy<IWireguardPeerServiceWithRawResponse> _wireguardPeers;
    public IWireguardPeerServiceWithRawResponse WireguardPeers {
        get { return _wireguardPeers.Value; }
    }

    readonly Lazy<IWirelessServiceWithRawResponse> _wireless;
    public IWirelessServiceWithRawResponse Wireless {
        get { return _wireless.Value; }
    }

    readonly Lazy<IWirelessBlocklistValueServiceWithRawResponse> _wirelessBlocklistValues;
    public IWirelessBlocklistValueServiceWithRawResponse WirelessBlocklistValues {
        get { return _wirelessBlocklistValues.Value; }
    }

    readonly Lazy<IWirelessBlocklistServiceWithRawResponse> _wirelessBlocklists;
    public IWirelessBlocklistServiceWithRawResponse WirelessBlocklists {
        get { return _wirelessBlocklists.Value; }
    }

    readonly Lazy<IWellKnownServiceWithRawResponse> _wellKnown;
    public IWellKnownServiceWithRawResponse WellKnown {
        get { return _wellKnown.Value; }
    }

    readonly Lazy<IInexplicitNumberOrderServiceWithRawResponse> _inexplicitNumberOrders;
    public IInexplicitNumberOrderServiceWithRawResponse InexplicitNumberOrders {
        get { return _inexplicitNumberOrders.Value; }
    }

    readonly Lazy<IMobilePhoneNumberServiceWithRawResponse> _mobilePhoneNumbers;
    public IMobilePhoneNumberServiceWithRawResponse MobilePhoneNumbers {
        get { return _mobilePhoneNumbers.Value; }
    }

    readonly Lazy<IMobileVoiceConnectionServiceWithRawResponse> _mobileVoiceConnections;
    public IMobileVoiceConnectionServiceWithRawResponse MobileVoiceConnections {
        get { return _mobileVoiceConnections.Value; }
    }

    readonly Lazy<IMessaging10dlcServiceWithRawResponse> _messaging10dlc;
    public IMessaging10dlcServiceWithRawResponse Messaging10dlc {
        get { return _messaging10dlc.Value; }
    }

    readonly Lazy<IOrganizationServiceWithRawResponse> _organizations;
    public IOrganizationServiceWithRawResponse Organizations {
        get { return _organizations.Value; }
    }

    readonly Lazy<IAlphanumericSenderIDServiceWithRawResponse> _alphanumericSenderIds;
    public IAlphanumericSenderIDServiceWithRawResponse AlphanumericSenderIds {
        get { return _alphanumericSenderIds.Value; }
    }

    readonly Lazy<IMessagingProfileMetricServiceWithRawResponse> _messagingProfileMetrics;
    public IMessagingProfileMetricServiceWithRawResponse MessagingProfileMetrics {
        get { return _messagingProfileMetrics.Value; }
    }

    readonly Lazy<ISessionAnalysisServiceWithRawResponse> _sessionAnalysis;
    public ISessionAnalysisServiceWithRawResponse SessionAnalysis {
        get { return _sessionAnalysis.Value; }
    }

    readonly Lazy<IWhatsappServiceWithRawResponse> _whatsapp;
    public IWhatsappServiceWithRawResponse Whatsapp {
        get { return _whatsapp.Value; }
    }

    readonly Lazy<IWhatsappMessageTemplateServiceWithRawResponse> _whatsappMessageTemplates;
    public IWhatsappMessageTemplateServiceWithRawResponse WhatsappMessageTemplates {
        get { return _whatsappMessageTemplates.Value; }
    }

    readonly Lazy<IX402ServiceWithRawResponse> _x402;
    public IX402ServiceWithRawResponse X402 { get { return _x402.Value; } }

    readonly Lazy<IVoiceCloneServiceWithRawResponse> _voiceClones;
    public IVoiceCloneServiceWithRawResponse VoiceClones {
        get { return _voiceClones.Value; }
    }

    readonly Lazy<IVoiceDesignServiceWithRawResponse> _voiceDesigns;
    public IVoiceDesignServiceWithRawResponse VoiceDesigns {
        get { return _voiceDesigns.Value; }
    }

    readonly Lazy<ITrafficPolicyProfileServiceWithRawResponse> _trafficPolicyProfiles;
    public ITrafficPolicyProfileServiceWithRawResponse TrafficPolicyProfiles {
        get { return _trafficPolicyProfiles.Value; }
    }

    readonly Lazy<IEnterpriseServiceWithRawResponse> _enterprises;
    public IEnterpriseServiceWithRawResponse Enterprises {
        get { return _enterprises.Value; }
    }

    readonly Lazy<IReputationServiceWithRawResponse> _reputation;
    public IReputationServiceWithRawResponse Reputation {
        get { return _reputation.Value; }
    }

    readonly Lazy<ITermsOfServiceServiceWithRawResponse> _termsOfService;
    public ITermsOfServiceServiceWithRawResponse TermsOfService {
        get { return _termsOfService.Value; }
    }

    readonly Lazy<IPronunciationDictServiceWithRawResponse> _pronunciationDicts;
    public IPronunciationDictServiceWithRawResponse PronunciationDicts {
        get { return _pronunciationDicts.Value; }
    }

    readonly Lazy<IUacConnectionServiceWithRawResponse> _uacConnections;
    public IUacConnectionServiceWithRawResponse UacConnections {
        get { return _uacConnections.Value; }
    }

    readonly Lazy<IVoiceSdkCallReportServiceWithRawResponse> _voiceSdkCallReports;
    public IVoiceSdkCallReportServiceWithRawResponse VoiceSdkCallReports {
        get { return _voiceSdkCallReports.Value; }
    }

    readonly Lazy<ICallReasonServiceWithRawResponse> _callReasons;
    public ICallReasonServiceWithRawResponse CallReasons {
        get { return _callReasons.Value; }
    }

    readonly Lazy<IDirServiceWithRawResponse> _dir;
    public IDirServiceWithRawResponse Dir { get { return _dir.Value; } }

    readonly Lazy<IInfringementClaimServiceWithRawResponse> _infringementClaims;
    public IInfringementClaimServiceWithRawResponse InfringementClaims {
        get { return _infringementClaims.Value; }
    }

    readonly Lazy<IEmailBlockServiceWithRawResponse> _emailBlocks;
    public IEmailBlockServiceWithRawResponse EmailBlocks {
        get { return _emailBlocks.Value; }
    }

    readonly Lazy<IEmailDomainServiceWithRawResponse> _emailDomains;
    public IEmailDomainServiceWithRawResponse EmailDomains {
        get { return _emailDomains.Value; }
    }

    readonly Lazy<IEmailEventServiceWithRawResponse> _emailEvents;
    public IEmailEventServiceWithRawResponse EmailEvents {
        get { return _emailEvents.Value; }
    }

    readonly Lazy<IEmailInboxServiceWithRawResponse> _emailInboxes;
    public IEmailInboxServiceWithRawResponse EmailInboxes {
        get { return _emailInboxes.Value; }
    }

    readonly Lazy<IEmailMessageServiceWithRawResponse> _emailMessages;
    public IEmailMessageServiceWithRawResponse EmailMessages {
        get { return _emailMessages.Value; }
    }

    readonly Lazy<IEmailTemplateServiceWithRawResponse> _emailTemplates;
    public IEmailTemplateServiceWithRawResponse EmailTemplates {
        get { return _emailTemplates.Value; }
    }

    readonly Lazy<IEmailThreadServiceWithRawResponse> _emailThreads;
    public IEmailThreadServiceWithRawResponse EmailThreads {
        get { return _emailThreads.Value; }
    }

    readonly Lazy<IEmailUnsubscribeGroupServiceWithRawResponse> _emailUnsubscribeGroups;
    public IEmailUnsubscribeGroupServiceWithRawResponse EmailUnsubscribeGroups {
        get { return _emailUnsubscribeGroups.Value; }
    }

    readonly Lazy<IEmailValidationServiceWithRawResponse> _emailValidations;
    public IEmailValidationServiceWithRawResponse EmailValidations {
        get { return _emailValidations.Value; }
    }

    readonly Lazy<IPricingServiceWithRawResponse> _pricing;
    public IPricingServiceWithRawResponse Pricing {
        get { return _pricing.Value; }
    }

    readonly Lazy<IWebSearchServiceWithRawResponse> _webSearch;
    public IWebSearchServiceWithRawResponse WebSearch {
        get { return _webSearch.Value; }
    }

    readonly Lazy<IMeetingSessionServiceWithRawResponse> _meetingSessions;
    public IMeetingSessionServiceWithRawResponse MeetingSessions {
        get { return _meetingSessions.Value; }
    }

    readonly Lazy<IExternalRequirementServiceWithRawResponse> _externalRequirements;
    public IExternalRequirementServiceWithRawResponse ExternalRequirements {
        get { return _externalRequirements.Value; }
    }

    readonly Lazy<IComputeServiceWithRawResponse> _compute;
    public IComputeServiceWithRawResponse Compute {
        get { return _compute.Value; }
    }

    readonly Lazy<INoiseSuppressionEngineServiceWithRawResponse> _noiseSuppressionEngines;
    public INoiseSuppressionEngineServiceWithRawResponse NoiseSuppressionEngines {
        get { return _noiseSuppressionEngines.Value; }
    }

    readonly Lazy<IBotChallengeServiceWithRawResponse> _botChallenge;
    public IBotChallengeServiceWithRawResponse BotChallenge {
        get { return _botChallenge.Value; }
    }

    readonly Lazy<IBotSessionServiceWithRawResponse> _botSessions;
    public IBotSessionServiceWithRawResponse BotSessions {
        get { return _botSessions.Value; }
    }

    readonly Lazy<IBotSignupServiceWithRawResponse> _botSignup;
    public IBotSignupServiceWithRawResponse BotSignup {
        get { return _botSignup.Value; }
    }

    readonly Lazy<IMachinePaymentServiceWithRawResponse> _machinePayments;
    public IMachinePaymentServiceWithRawResponse MachinePayments {
        get { return _machinePayments.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>
    (
        HttpRequest<T> request, CancellationToken cancellationToken = default
    ) where T: ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        using var bodyContent = request.Params.BodyContent();
        bool canReplay = ReplayableStreamContent.CanReplay(bodyContent);
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request,
                retries,
                bodyContent,
                cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !canReplay || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !canReplay || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode) {
                    return response;
                }

                try
                {
                    var apiException = TelnyxExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                    var responseHeaders = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IReadOnlyList<string>>(System.StringComparer.OrdinalIgnoreCase);
                    foreach (var header in response.RawMessage.Headers)
                        responseHeaders[header.Key] = new System.Collections.Generic.List<string>(header.Value).AsReadOnly();
                    if (response.RawMessage.Content != null)
                        foreach (var header in response.RawMessage.Content.Headers)
                            responseHeaders[header.Key] = new System.Collections.Generic.List<string>(header.Value).AsReadOnly();
                    apiException.ResponseHeaders = new System.Collections.ObjectModel.ReadOnlyDictionary<string, System.Collections.Generic.IReadOnlyList<string>>(responseHeaders);
                    throw apiException;
                }
                catch (HttpRequestException e)
                {
                    throw new TelnyxIOException("I/O Exception", e);
                }finally
                { response.Dispose(); }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>
    (
        HttpRequest<T> request,
        int retryCount,
        System.Net.Http.HttpContent? bodyContent,
        CancellationToken cancellationToken = default
    ) where T: ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method, request.Params.Url(this._options)
        )
        {
            Content = bodyContent
        };request.Params.AddHeadersToRequest(requestMessage, this._options);if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }var timeoutCts = new ResponseLifetime(this.Timeout ?? ClientOptions.DefaultTimeout, cancellationToken);var cts = timeoutCts;HttpResponseMessage responseMessage;try
        {
            responseMessage =await this.HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cts.Token).ConfigureAwait(false) ;
        }
        catch (HttpRequestException e)
        {
            timeoutCts.Dispose(); throw new TelnyxIOException("I/O exception", e);
        }
        catch (Exception e)
        {
            _ = e; timeoutCts.Dispose(); throw;
        }finally
        {
            requestMessage.Content = null;
        }timeoutCts.Attach(responseMessage); return new()
        {
            RawMessage = responseMessage,
            Lifetime = timeoutCts,
            CancellationToken = cts.Token,
        };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff > TimeSpan.Zero && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(
            0.5 * Math.Pow(2.0, retries - 1), 8.0
        );
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry))
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    { return e is IOException || e is TelnyxIOException; }

    public void Dispose()
    =>this.HttpClient.Dispose();

    public TelnyxClientWithRawResponse ()
    {
        _options = new();

        _legacy =new(() => new LegacyServiceWithRawResponse(this)) ;
        _oauth =new(() => new OAuthServiceWithRawResponse(this)) ;
        _oauthClients =new(() => new OAuthClientServiceWithRawResponse(this)) ;
        _oauthGrants =new(() => new OAuthGrantServiceWithRawResponse(this)) ;
        _webhooks =new(() => new WebhookServiceWithRawResponse(this)) ;
        _accessIPAddress =new(
            () => new AccessIPAddressServiceWithRawResponse(this)
        ) ;
        _accessIPRanges =new(
            () => new AccessIPRangeServiceWithRawResponse(this)
        ) ;
        _actions =new(() => new ActionServiceWithRawResponse(this)) ;
        _addresses =new(() => new AddressServiceWithRawResponse(this)) ;
        _advancedOrders =new(
            () => new AdvancedOrderServiceWithRawResponse(this)
        ) ;
        _ai =new(() => new AIServiceWithRawResponse(this)) ;
        _auditEvents =new(() => new AuditEventServiceWithRawResponse(this)) ;
        _authenticationProviders =new(
            () => new AuthenticationProviderServiceWithRawResponse(this)
        ) ;
        _availablePhoneNumberBlocks =new(
            () => new AvailablePhoneNumberBlockServiceWithRawResponse(this)
        ) ;
        _availablePhoneNumbers =new(
            () => new AvailablePhoneNumberServiceWithRawResponse(this)
        ) ;
        _balance =new(() => new BalanceServiceWithRawResponse(this)) ;
        _billingGroups =new(
            () => new BillingGroupServiceWithRawResponse(this)
        ) ;
        _bulkSimCardActions =new(
            () => new BulkSimCardActionServiceWithRawResponse(this)
        ) ;
        _bundlePricing =new(
            () => new BundlePricingServiceWithRawResponse(this)
        ) ;
        _callControlApplications =new(
            () => new CallControlApplicationServiceWithRawResponse(this)
        ) ;
        _callEvents =new(() => new CallEventServiceWithRawResponse(this)) ;
        _calls =new(() => new CallServiceWithRawResponse(this)) ;
        _channelZones =new(() => new ChannelZoneServiceWithRawResponse(this)) ;
        _chargesBreakdown =new(
            () => new ChargesBreakdownServiceWithRawResponse(this)
        ) ;
        _chargesSummary =new(
            () => new ChargesSummaryServiceWithRawResponse(this)
        ) ;
        _comments =new(() => new CommentServiceWithRawResponse(this)) ;
        _conferences =new(() => new ConferenceServiceWithRawResponse(this)) ;
        _connections =new(() => new ConnectionServiceWithRawResponse(this)) ;
        _countryCoverage =new(
            () => new CountryCoverageServiceWithRawResponse(this)
        ) ;
        _credentialConnections =new(
            () => new CredentialConnectionServiceWithRawResponse(this)
        ) ;
        _customStorageCredentials =new(
            () => new CustomStorageCredentialServiceWithRawResponse(this)
        ) ;
        _customerServiceRecords =new(
            () => new CustomerServiceRecordServiceWithRawResponse(this)
        ) ;
        _detailRecords =new(
            () => new DetailRecordServiceWithRawResponse(this)
        ) ;
        _dialogflowConnections =new(
            () => new DialogflowConnectionServiceWithRawResponse(this)
        ) ;
        _documentLinks =new(
            () => new DocumentLinkServiceWithRawResponse(this)
        ) ;
        _documents =new(() => new DocumentServiceWithRawResponse(this)) ;
        _dynamicEmergencyAddresses =new(
            () => new DynamicEmergencyAddressServiceWithRawResponse(this)
        ) ;
        _dynamicEmergencyEndpoints =new(
            () => new DynamicEmergencyEndpointServiceWithRawResponse(this)
        ) ;
        _externalConnections =new(
            () => new ExternalConnectionServiceWithRawResponse(this)
        ) ;
        _faxApplications =new(
            () => new FaxApplicationServiceWithRawResponse(this)
        ) ;
        _faxes =new(() => new FaxServiceWithRawResponse(this)) ;
        _fqdnConnections =new(
            () => new FqdnConnectionServiceWithRawResponse(this)
        ) ;
        _fqdns =new(() => new FqdnServiceWithRawResponse(this)) ;
        _globalIPAllowedPorts =new(
            () => new GlobalIPAllowedPortServiceWithRawResponse(this)
        ) ;
        _globalIPAssignmentHealth =new(
            () => new GlobalIPAssignmentHealthServiceWithRawResponse(this)
        ) ;
        _globalIPAssignments =new(
            () => new GlobalIPAssignmentServiceWithRawResponse(this)
        ) ;
        _globalIPAssignmentsUsage =new(
            () => new GlobalIPAssignmentsUsageServiceWithRawResponse(this)
        ) ;
        _globalIPHealthCheckTypes =new(
            () => new GlobalIPHealthCheckTypeServiceWithRawResponse(this)
        ) ;
        _globalIPHealthChecks =new(
            () => new GlobalIPHealthCheckServiceWithRawResponse(this)
        ) ;
        _globalIPLatency =new(
            () => new GlobalIPLatencyServiceWithRawResponse(this)
        ) ;
        _globalIPProtocols =new(
            () => new GlobalIPProtocolServiceWithRawResponse(this)
        ) ;
        _globalIPUsage =new(
            () => new GlobalIPUsageServiceWithRawResponse(this)
        ) ;
        _globalIps =new(() => new GlobalIPServiceWithRawResponse(this)) ;
        _inboundChannels =new(
            () => new InboundChannelServiceWithRawResponse(this)
        ) ;
        _integrationSecrets =new(
            () => new IntegrationSecretServiceWithRawResponse(this)
        ) ;
        _inventoryCoverage =new(
            () => new InventoryCoverageServiceWithRawResponse(this)
        ) ;
        _invoices =new(() => new InvoiceServiceWithRawResponse(this)) ;
        _ipConnections =new(
            () => new IPConnectionServiceWithRawResponse(this)
        ) ;
        _ips =new(() => new IPServiceWithRawResponse(this)) ;
        _ledgerBillingGroupReports =new(
            () => new LedgerBillingGroupReportServiceWithRawResponse(this)
        ) ;
        _list =new(() => new ListServiceWithRawResponse(this)) ;
        _managedAccounts =new(
            () => new ManagedAccountServiceWithRawResponse(this)
        ) ;
        _media =new(() => new MediaServiceWithRawResponse(this)) ;
        _messages =new(() => new MessageServiceWithRawResponse(this)) ;
        _messaging =new(() => new MessagingServiceWithRawResponse(this)) ;
        _messagingHostedNumberOrders =new(
            () => new MessagingHostedNumberOrderServiceWithRawResponse(this)
        ) ;
        _messagingHostedNumbers =new(
            () => new MessagingHostedNumberServiceWithRawResponse(this)
        ) ;
        _messagingNumbersBulkUpdates =new(
            () => new MessagingNumbersBulkUpdateServiceWithRawResponse(this)
        ) ;
        _messagingOptouts =new(
            () => new MessagingOptoutServiceWithRawResponse(this)
        ) ;
        _messagingProfiles =new(
            () => new MessagingProfileServiceWithRawResponse(this)
        ) ;
        _messagingTollfree =new(
            () => new MessagingTollfreeServiceWithRawResponse(this)
        ) ;
        _messagingUrlDomains =new(
            () => new MessagingUrlDomainServiceWithRawResponse(this)
        ) ;
        _mobileNetworkOperators =new(
            () => new MobileNetworkOperatorServiceWithRawResponse(this)
        ) ;
        _mobilePushCredentials =new(
            () => new MobilePushCredentialServiceWithRawResponse(this)
        ) ;
        _networkCoverage =new(
            () => new NetworkCoverageServiceWithRawResponse(this)
        ) ;
        _networks =new(() => new NetworkServiceWithRawResponse(this)) ;
        _notificationChannels =new(
            () => new NotificationChannelServiceWithRawResponse(this)
        ) ;
        _notificationEventConditions =new(
            () => new NotificationEventConditionServiceWithRawResponse(this)
        ) ;
        _notificationEvents =new(
            () => new NotificationEventServiceWithRawResponse(this)
        ) ;
        _notificationProfiles =new(
            () => new NotificationProfileServiceWithRawResponse(this)
        ) ;
        _notificationSettings =new(
            () => new NotificationSettingServiceWithRawResponse(this)
        ) ;
        _numberBlockOrders =new(
            () => new NumberBlockOrderServiceWithRawResponse(this)
        ) ;
        _numberLookup =new(() => new NumberLookupServiceWithRawResponse(this)) ;
        _numberOrderPhoneNumbers =new(
            () => new NumberOrderPhoneNumberServiceWithRawResponse(this)
        ) ;
        _numberOrders =new(() => new NumberOrderServiceWithRawResponse(this)) ;
        _numberReservations =new(
            () => new NumberReservationServiceWithRawResponse(this)
        ) ;
        _numbersFeatures =new(
            () => new NumbersFeatureServiceWithRawResponse(this)
        ) ;
        _operatorConnect =new(
            () => new OperatorConnectServiceWithRawResponse(this)
        ) ;
        _otaUpdates =new(() => new OtaUpdateServiceWithRawResponse(this)) ;
        _outboundVoiceProfiles =new(
            () => new OutboundVoiceProfileServiceWithRawResponse(this)
        ) ;
        _payment =new(() => new PaymentServiceWithRawResponse(this)) ;
        _phoneNumberBlocks =new(
            () => new PhoneNumberBlockServiceWithRawResponse(this)
        ) ;
        _phoneNumbers =new(() => new PhoneNumberServiceWithRawResponse(this)) ;
        _phoneNumbersRegulatoryRequirements =new(
            () => new PhoneNumbersRegulatoryRequirementServiceWithRawResponse(
                this
            )
        ) ;
        _portabilityChecks =new(
            () => new PortabilityCheckServiceWithRawResponse(this)
        ) ;
        _porting =new(() => new PortingServiceWithRawResponse(this)) ;
        _portingOrders =new(
            () => new PortingOrderServiceWithRawResponse(this)
        ) ;
        _portingPhoneNumbers =new(
            () => new PortingPhoneNumberServiceWithRawResponse(this)
        ) ;
        _portouts =new(() => new PortoutServiceWithRawResponse(this)) ;
        _privateWirelessGateways =new(
            () => new PrivateWirelessGatewayServiceWithRawResponse(this)
        ) ;
        _publicInternetGateways =new(
            () => new PublicInternetGatewayServiceWithRawResponse(this)
        ) ;
        _queues =new(() => new QueueServiceWithRawResponse(this)) ;
        _rcs =new(() => new RcServiceWithRawResponse(this)) ;
        _recordingTranscriptions =new(
            () => new RecordingTranscriptionServiceWithRawResponse(this)
        ) ;
        _recordings =new(() => new RecordingServiceWithRawResponse(this)) ;
        _regions =new(() => new RegionServiceWithRawResponse(this)) ;
        _regulatoryRequirements =new(
            () => new RegulatoryRequirementServiceWithRawResponse(this)
        ) ;
        _reports =new(() => new ReportServiceWithRawResponse(this)) ;
        _speechToText =new(() => new SpeechToTextServiceWithRawResponse(this)) ;
        _requirementGroups =new(
            () => new RequirementGroupServiceWithRawResponse(this)
        ) ;
        _requirementTypes =new(
            () => new RequirementTypeServiceWithRawResponse(this)
        ) ;
        _requirements =new(() => new RequirementServiceWithRawResponse(this)) ;
        _roomCompositions =new(
            () => new RoomCompositionServiceWithRawResponse(this)
        ) ;
        _roomParticipants =new(
            () => new RoomParticipantServiceWithRawResponse(this)
        ) ;
        _roomRecordings =new(
            () => new RoomRecordingServiceWithRawResponse(this)
        ) ;
        _rooms =new(() => new RoomServiceWithRawResponse(this)) ;
        _seti =new(() => new SetiServiceWithRawResponse(this)) ;
        _shortCodes =new(() => new ShortCodeServiceWithRawResponse(this)) ;
        _simCardDataUsageNotifications =new(
            () => new SimCardDataUsageNotificationServiceWithRawResponse(this)
        ) ;
        _simCardGroups =new(
            () => new SimCardGroupServiceWithRawResponse(this)
        ) ;
        _simCardOrderPreview =new(
            () => new SimCardOrderPreviewServiceWithRawResponse(this)
        ) ;
        _simCardOrders =new(
            () => new SimCardOrderServiceWithRawResponse(this)
        ) ;
        _simCards =new(() => new SimCardServiceWithRawResponse(this)) ;
        _siprecConnectors =new(
            () => new SiprecConnectorServiceWithRawResponse(this)
        ) ;
        _storage =new(() => new StorageServiceWithRawResponse(this)) ;
        _subNumberOrders =new(
            () => new SubNumberOrderServiceWithRawResponse(this)
        ) ;
        _subNumberOrdersReport =new(
            () => new SubNumberOrdersReportServiceWithRawResponse(this)
        ) ;
        _telephonyCredentials =new(
            () => new TelephonyCredentialServiceWithRawResponse(this)
        ) ;
        _texml =new(() => new TexmlServiceWithRawResponse(this)) ;
        _texmlApplications =new(
            () => new TexmlApplicationServiceWithRawResponse(this)
        ) ;
        _textToSpeech =new(() => new TextToSpeechServiceWithRawResponse(this)) ;
        _usageReports =new(() => new UsageReportServiceWithRawResponse(this)) ;
        _userAddresses =new(() => new UserAddressServiceWithRawResponse(this)) ;
        _userTags =new(() => new UserTagServiceWithRawResponse(this)) ;
        _verifications =new(
            () => new VerificationServiceWithRawResponse(this)
        ) ;
        _verifiedNumbers =new(
            () => new VerifiedNumberServiceWithRawResponse(this)
        ) ;
        _verifyProfiles =new(
            () => new VerifyProfileServiceWithRawResponse(this)
        ) ;
        _virtualCrossConnects =new(
            () => new VirtualCrossConnectServiceWithRawResponse(this)
        ) ;
        _virtualCrossConnectsCoverage =new(
            () => new VirtualCrossConnectsCoverageServiceWithRawResponse(this)
        ) ;
        _webhookDeliveries =new(
            () => new WebhookDeliveryServiceWithRawResponse(this)
        ) ;
        _wireguardInterfaces =new(
            () => new WireguardInterfaceServiceWithRawResponse(this)
        ) ;
        _wireguardPeers =new(
            () => new WireguardPeerServiceWithRawResponse(this)
        ) ;
        _wireless =new(() => new WirelessServiceWithRawResponse(this)) ;
        _wirelessBlocklistValues =new(
            () => new WirelessBlocklistValueServiceWithRawResponse(this)
        ) ;
        _wirelessBlocklists =new(
            () => new WirelessBlocklistServiceWithRawResponse(this)
        ) ;
        _wellKnown =new(() => new WellKnownServiceWithRawResponse(this)) ;
        _inexplicitNumberOrders =new(
            () => new InexplicitNumberOrderServiceWithRawResponse(this)
        ) ;
        _mobilePhoneNumbers =new(
            () => new MobilePhoneNumberServiceWithRawResponse(this)
        ) ;
        _mobileVoiceConnections =new(
            () => new MobileVoiceConnectionServiceWithRawResponse(this)
        ) ;
        _messaging10dlc =new(
            () => new Messaging10dlcServiceWithRawResponse(this)
        ) ;
        _organizations =new(
            () => new OrganizationServiceWithRawResponse(this)
        ) ;
        _alphanumericSenderIds =new(
            () => new AlphanumericSenderIDServiceWithRawResponse(this)
        ) ;
        _messagingProfileMetrics =new(
            () => new MessagingProfileMetricServiceWithRawResponse(this)
        ) ;
        _sessionAnalysis =new(
            () => new SessionAnalysisServiceWithRawResponse(this)
        ) ;
        _whatsapp =new(() => new WhatsappServiceWithRawResponse(this)) ;
        _whatsappMessageTemplates =new(
            () => new WhatsappMessageTemplateServiceWithRawResponse(this)
        ) ;
        _x402 =new(() => new X402ServiceWithRawResponse(this)) ;
        _voiceClones =new(() => new VoiceCloneServiceWithRawResponse(this)) ;
        _voiceDesigns =new(() => new VoiceDesignServiceWithRawResponse(this)) ;
        _trafficPolicyProfiles =new(
            () => new TrafficPolicyProfileServiceWithRawResponse(this)
        ) ;
        _enterprises =new(() => new EnterpriseServiceWithRawResponse(this)) ;
        _reputation =new(() => new ReputationServiceWithRawResponse(this)) ;
        _termsOfService =new(
            () => new TermsOfServiceServiceWithRawResponse(this)
        ) ;
        _pronunciationDicts =new(
            () => new PronunciationDictServiceWithRawResponse(this)
        ) ;
        _uacConnections =new(
            () => new UacConnectionServiceWithRawResponse(this)
        ) ;
        _voiceSdkCallReports =new(
            () => new VoiceSdkCallReportServiceWithRawResponse(this)
        ) ;
        _callReasons =new(() => new CallReasonServiceWithRawResponse(this)) ;
        _dir =new(() => new DirServiceWithRawResponse(this)) ;
        _infringementClaims =new(
            () => new InfringementClaimServiceWithRawResponse(this)
        ) ;
        _emailBlocks =new(() => new EmailBlockServiceWithRawResponse(this)) ;
        _emailDomains =new(() => new EmailDomainServiceWithRawResponse(this)) ;
        _emailEvents =new(() => new EmailEventServiceWithRawResponse(this)) ;
        _emailInboxes =new(() => new EmailInboxServiceWithRawResponse(this)) ;
        _emailMessages =new(
            () => new EmailMessageServiceWithRawResponse(this)
        ) ;
        _emailTemplates =new(
            () => new EmailTemplateServiceWithRawResponse(this)
        ) ;
        _emailThreads =new(() => new EmailThreadServiceWithRawResponse(this)) ;
        _emailUnsubscribeGroups =new(
            () => new EmailUnsubscribeGroupServiceWithRawResponse(this)
        ) ;
        _emailValidations =new(
            () => new EmailValidationServiceWithRawResponse(this)
        ) ;
        _pricing =new(() => new PricingServiceWithRawResponse(this)) ;
        _webSearch =new(() => new WebSearchServiceWithRawResponse(this)) ;
        _meetingSessions =new(
            () => new MeetingSessionServiceWithRawResponse(this)
        ) ;
        _externalRequirements =new(
            () => new ExternalRequirementServiceWithRawResponse(this)
        ) ;
        _compute =new(() => new ComputeServiceWithRawResponse(this)) ;
        _noiseSuppressionEngines =new(
            () => new NoiseSuppressionEngineServiceWithRawResponse(this)
        ) ;
        _botChallenge =new(() => new BotChallengeServiceWithRawResponse(this)) ;
        _botSessions =new(() => new BotSessionServiceWithRawResponse(this)) ;
        _botSignup =new(() => new BotSignupServiceWithRawResponse(this)) ;
        _machinePayments =new(
            () => new MachinePaymentServiceWithRawResponse(this)
        ) ;
    }

    public TelnyxClientWithRawResponse (ClientOptions options) : this()
    { _options = options; }
}