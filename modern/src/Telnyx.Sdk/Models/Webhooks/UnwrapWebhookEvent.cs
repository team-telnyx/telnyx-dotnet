using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public record class UnwrapWebhookEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? ID {
        get {
            return Match<string?>(callAIGatherEnded: ( _ )=>null,
            callAIGatherMessageHistoryUpdated: ( _ )=>null,
            callAIGatherPartialResults: ( _ )=>null,
            artifactCompleted: ( x )=>x.ID,
            artifactFailed: ( x )=>x.ID,
            callAnswered: ( _ )=>null,
            callBridged: ( _ )=>null,
            callConversationEnded: ( _ )=>null,
            callConversationInsightsGenerated: ( _ )=>null,
            callCost: ( _ )=>null,
            callDeepfakeDetectionError: ( _ )=>null,
            callDeepfakeDetectionResult: ( _ )=>null,
            callDtmfReceived: ( _ )=>null,
            callEnqueued: ( _ )=>null,
            callForkStarted: ( _ )=>null,
            callForkStopped: ( _ )=>null,
            callGatherEnded: ( _ )=>null,
            callHangup: ( _ )=>null,
            callHold: ( _ )=>null,
            callInitiated: ( _ )=>null,
            callLeftQueue: ( _ )=>null,
            callMachineDetectionEnded: ( _ )=>null,
            callMachineGreetingEnded: ( _ )=>null,
            callMachinePremiumDetectionEnded: ( _ )=>null,
            callMachinePremiumGreetingEnded: ( _ )=>null,
            callPaymentCompleted: ( _ )=>null,
            callPaymentProgress: ( _ )=>null,
            callPlaybackEnded: ( _ )=>null,
            callPlaybackStarted: ( _ )=>null,
            callRecordingError: ( _ )=>null,
            callRecordingSaved: ( _ )=>null,
            callRecordingTranscriptionSaved: ( _ )=>null,
            callReferCompleted: ( _ )=>null,
            callReferFailed: ( _ )=>null,
            callReferStarted: ( _ )=>null,
            callSiprecFailed: ( _ )=>null,
            callSiprecStarted: ( _ )=>null,
            callSiprecStopped: ( _ )=>null,
            callSpeakEnded: ( _ )=>null,
            callSpeakStarted: ( _ )=>null,
            callStreamingFailed: ( _ )=>null,
            callStreamingStarted: ( _ )=>null,
            callStreamingStopped: ( _ )=>null,
            callUnhold: ( _ )=>null,
            campaignStatusUpdate: ( _ )=>null,
            conferenceCreated: ( _ )=>null,
            conferenceEnded: ( _ )=>null,
            conferenceFloorChanged: ( x )=>x.ID,
            conferenceParticipantJoined: ( _ )=>null,
            conferenceParticipantLeft: ( _ )=>null,
            conferenceParticipantPlaybackEnded: ( _ )=>null,
            conferenceParticipantPlaybackStarted: ( _ )=>null,
            conferenceParticipantSpeakEnded: ( _ )=>null,
            conferenceParticipantSpeakStarted: ( _ )=>null,
            conferencePlaybackEnded: ( _ )=>null,
            conferencePlaybackStarted: ( _ )=>null,
            conferenceRecordingSaved: ( _ )=>null,
            conferenceSpeakEnded: ( _ )=>null,
            conferenceSpeakStarted: ( _ )=>null,
            deliveryUpdate: ( _ )=>null,
            faxDelivered: ( _ )=>null,
            faxFailed: ( _ )=>null,
            faxMediaProcessed: ( _ )=>null,
            faxQueued: ( _ )=>null,
            faxSendingStarted: ( _ )=>null,
            hostedNumberOrderEvent: ( _ )=>null,
            inboundMessage: ( _ )=>null,
            numberOrderStatusUpdate: ( _ )=>null,
            recordingAvailable: ( x )=>x.ID,
            replacedLinkClick: ( _ )=>null,
            sessionStatusChanged: ( x )=>x.ID,
            transcriptCompleted: ( x )=>x.ID,
            transcription: ( _ )=>null,
            whatsappAccountUpdate: ( _ )=>null,
            whatsappMessageEcho: ( _ )=>null);
        }
    }

    public System::DateTimeOffset? OccurredAt {
        get {
            return Match<System::DateTimeOffset?>(callAIGatherEnded: ( _ )=>null,
            callAIGatherMessageHistoryUpdated: ( _ )=>null,
            callAIGatherPartialResults: ( _ )=>null,
            artifactCompleted: ( x )=>x.OccurredAt,
            artifactFailed: ( x )=>x.OccurredAt,
            callAnswered: ( _ )=>null,
            callBridged: ( _ )=>null,
            callConversationEnded: ( _ )=>null,
            callConversationInsightsGenerated: ( _ )=>null,
            callCost: ( _ )=>null,
            callDeepfakeDetectionError: ( _ )=>null,
            callDeepfakeDetectionResult: ( _ )=>null,
            callDtmfReceived: ( _ )=>null,
            callEnqueued: ( _ )=>null,
            callForkStarted: ( _ )=>null,
            callForkStopped: ( _ )=>null,
            callGatherEnded: ( _ )=>null,
            callHangup: ( _ )=>null,
            callHold: ( _ )=>null,
            callInitiated: ( _ )=>null,
            callLeftQueue: ( _ )=>null,
            callMachineDetectionEnded: ( _ )=>null,
            callMachineGreetingEnded: ( _ )=>null,
            callMachinePremiumDetectionEnded: ( _ )=>null,
            callMachinePremiumGreetingEnded: ( _ )=>null,
            callPaymentCompleted: ( _ )=>null,
            callPaymentProgress: ( _ )=>null,
            callPlaybackEnded: ( _ )=>null,
            callPlaybackStarted: ( _ )=>null,
            callRecordingError: ( _ )=>null,
            callRecordingSaved: ( _ )=>null,
            callRecordingTranscriptionSaved: ( _ )=>null,
            callReferCompleted: ( _ )=>null,
            callReferFailed: ( _ )=>null,
            callReferStarted: ( _ )=>null,
            callSiprecFailed: ( _ )=>null,
            callSiprecStarted: ( _ )=>null,
            callSiprecStopped: ( _ )=>null,
            callSpeakEnded: ( _ )=>null,
            callSpeakStarted: ( _ )=>null,
            callStreamingFailed: ( _ )=>null,
            callStreamingStarted: ( _ )=>null,
            callStreamingStopped: ( _ )=>null,
            callUnhold: ( _ )=>null,
            campaignStatusUpdate: ( _ )=>null,
            conferenceCreated: ( _ )=>null,
            conferenceEnded: ( _ )=>null,
            conferenceFloorChanged: ( _ )=>null,
            conferenceParticipantJoined: ( _ )=>null,
            conferenceParticipantLeft: ( _ )=>null,
            conferenceParticipantPlaybackEnded: ( _ )=>null,
            conferenceParticipantPlaybackStarted: ( _ )=>null,
            conferenceParticipantSpeakEnded: ( _ )=>null,
            conferenceParticipantSpeakStarted: ( _ )=>null,
            conferencePlaybackEnded: ( _ )=>null,
            conferencePlaybackStarted: ( _ )=>null,
            conferenceRecordingSaved: ( _ )=>null,
            conferenceSpeakEnded: ( _ )=>null,
            conferenceSpeakStarted: ( _ )=>null,
            deliveryUpdate: ( _ )=>null,
            faxDelivered: ( _ )=>null,
            faxFailed: ( _ )=>null,
            faxMediaProcessed: ( _ )=>null,
            faxQueued: ( _ )=>null,
            faxSendingStarted: ( _ )=>null,
            hostedNumberOrderEvent: ( _ )=>null,
            inboundMessage: ( _ )=>null,
            numberOrderStatusUpdate: ( _ )=>null,
            recordingAvailable: ( x )=>x.OccurredAt,
            replacedLinkClick: ( _ )=>null,
            sessionStatusChanged: ( x )=>x.OccurredAt,
            transcriptCompleted: ( x )=>x.OccurredAt,
            transcription: ( _ )=>null,
            whatsappAccountUpdate: ( _ )=>null,
            whatsappMessageEcho: ( _ )=>null);
        }
    }

    public string? Version {
        get {
            return Match<string?>(callAIGatherEnded: ( _ )=>null,
            callAIGatherMessageHistoryUpdated: ( _ )=>null,
            callAIGatherPartialResults: ( _ )=>null,
            artifactCompleted: ( x )=>x.Version,
            artifactFailed: ( x )=>x.Version,
            callAnswered: ( _ )=>null,
            callBridged: ( _ )=>null,
            callConversationEnded: ( _ )=>null,
            callConversationInsightsGenerated: ( _ )=>null,
            callCost: ( _ )=>null,
            callDeepfakeDetectionError: ( _ )=>null,
            callDeepfakeDetectionResult: ( _ )=>null,
            callDtmfReceived: ( _ )=>null,
            callEnqueued: ( _ )=>null,
            callForkStarted: ( _ )=>null,
            callForkStopped: ( _ )=>null,
            callGatherEnded: ( _ )=>null,
            callHangup: ( _ )=>null,
            callHold: ( _ )=>null,
            callInitiated: ( _ )=>null,
            callLeftQueue: ( _ )=>null,
            callMachineDetectionEnded: ( _ )=>null,
            callMachineGreetingEnded: ( _ )=>null,
            callMachinePremiumDetectionEnded: ( _ )=>null,
            callMachinePremiumGreetingEnded: ( _ )=>null,
            callPaymentCompleted: ( _ )=>null,
            callPaymentProgress: ( _ )=>null,
            callPlaybackEnded: ( _ )=>null,
            callPlaybackStarted: ( _ )=>null,
            callRecordingError: ( _ )=>null,
            callRecordingSaved: ( _ )=>null,
            callRecordingTranscriptionSaved: ( _ )=>null,
            callReferCompleted: ( _ )=>null,
            callReferFailed: ( _ )=>null,
            callReferStarted: ( _ )=>null,
            callSiprecFailed: ( _ )=>null,
            callSiprecStarted: ( _ )=>null,
            callSiprecStopped: ( _ )=>null,
            callSpeakEnded: ( _ )=>null,
            callSpeakStarted: ( _ )=>null,
            callStreamingFailed: ( _ )=>null,
            callStreamingStarted: ( _ )=>null,
            callStreamingStopped: ( _ )=>null,
            callUnhold: ( _ )=>null,
            campaignStatusUpdate: ( _ )=>null,
            conferenceCreated: ( _ )=>null,
            conferenceEnded: ( _ )=>null,
            conferenceFloorChanged: ( _ )=>null,
            conferenceParticipantJoined: ( _ )=>null,
            conferenceParticipantLeft: ( _ )=>null,
            conferenceParticipantPlaybackEnded: ( _ )=>null,
            conferenceParticipantPlaybackStarted: ( _ )=>null,
            conferenceParticipantSpeakEnded: ( _ )=>null,
            conferenceParticipantSpeakStarted: ( _ )=>null,
            conferencePlaybackEnded: ( _ )=>null,
            conferencePlaybackStarted: ( _ )=>null,
            conferenceRecordingSaved: ( _ )=>null,
            conferenceSpeakEnded: ( _ )=>null,
            conferenceSpeakStarted: ( _ )=>null,
            deliveryUpdate: ( _ )=>null,
            faxDelivered: ( _ )=>null,
            faxFailed: ( _ )=>null,
            faxMediaProcessed: ( _ )=>null,
            faxQueued: ( _ )=>null,
            faxSendingStarted: ( _ )=>null,
            hostedNumberOrderEvent: ( _ )=>null,
            inboundMessage: ( _ )=>null,
            numberOrderStatusUpdate: ( _ )=>null,
            recordingAvailable: ( x )=>x.Version,
            replacedLinkClick: ( _ )=>null,
            sessionStatusChanged: ( x )=>x.Version,
            transcriptCompleted: ( x )=>x.Version,
            transcription: ( _ )=>null,
            whatsappAccountUpdate: ( _ )=>null,
            whatsappMessageEcho: ( _ )=>null);
        }
    }

    public UnwrapWebhookEvent (
        CallAIGatherEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallAIGatherMessageHistoryUpdatedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallAIGatherPartialResultsWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ArtifactCompletedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ArtifactFailedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallAnsweredWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallBridgedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallConversationEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallConversationInsightsGeneratedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallCostWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallDeepfakeDetectionErrorWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallDeepfakeDetectionResultWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallDtmfReceivedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallEnqueuedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallForkStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallForkStoppedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallGatherEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallHangupWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallHoldWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallInitiatedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallLeftQueueWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallMachineDetectionEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallMachineGreetingEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallMachinePremiumDetectionEndedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallMachinePremiumGreetingEndedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallPaymentCompletedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallPaymentProgressWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallPlaybackEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallPlaybackStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallRecordingErrorWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallRecordingSavedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallRecordingTranscriptionSavedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallReferCompletedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallReferFailedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallReferStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallSiprecFailedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallSiprecStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallSiprecStoppedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallSpeakEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallSpeakStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallStreamingFailedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallStreamingStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallStreamingStoppedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CallUnholdWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        CampaignStatusUpdate value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceCreatedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceFloorChanged value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceParticipantJoinedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceParticipantLeftWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceParticipantPlaybackEndedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceParticipantPlaybackStartedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceParticipantSpeakEndedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceParticipantSpeakStartedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferencePlaybackEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferencePlaybackStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceRecordingSavedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceSpeakEndedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ConferenceSpeakStartedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        DeliveryUpdateWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (FaxDelivered value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (FaxFailed value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        FaxMediaProcessed value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (FaxQueued value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        FaxSendingStarted value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        HostedNumberOrderEventWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        InboundMessageWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        NumberOrderStatusUpdateWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        RecordingAvailableWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        ReplacedLinkClickWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        SessionStatusChangedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        TranscriptCompletedWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        TranscriptionWebhookEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        WhatsappAccountUpdate value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (
        WhatsappMessageEcho value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallAIGatherEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallAIGatherEnded(out var value)) {
///     // `value` is of type `CallAIGatherEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallAIGatherEnded(
        [NotNullWhen(true)] out CallAIGatherEndedWebhookEvent? value
    )
    {
        value =this.Value as CallAIGatherEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallAIGatherMessageHistoryUpdatedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallAIGatherMessageHistoryUpdated(out var value)) {
///     // `value` is of type `CallAIGatherMessageHistoryUpdatedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallAIGatherMessageHistoryUpdated(
        [NotNullWhen(true)] out CallAIGatherMessageHistoryUpdatedWebhookEvent? value
    )
    {
        value =this.Value as CallAIGatherMessageHistoryUpdatedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallAIGatherPartialResultsWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallAIGatherPartialResults(out var value)) {
///     // `value` is of type `CallAIGatherPartialResultsWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallAIGatherPartialResults(
        [NotNullWhen(true)] out CallAIGatherPartialResultsWebhookEvent? value
    )
    {
        value =this.Value as CallAIGatherPartialResultsWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ArtifactCompletedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickArtifactCompleted(out var value)) {
///     // `value` is of type `ArtifactCompletedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickArtifactCompleted(
        [NotNullWhen(true)] out ArtifactCompletedWebhookEvent? value
    )
    {
        value =this.Value as ArtifactCompletedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ArtifactFailedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickArtifactFailed(out var value)) {
///     // `value` is of type `ArtifactFailedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickArtifactFailed(
        [NotNullWhen(true)] out ArtifactFailedWebhookEvent? value
    )
    {
        value =this.Value as ArtifactFailedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallAnsweredWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallAnswered(out var value)) {
///     // `value` is of type `CallAnsweredWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallAnswered(
        [NotNullWhen(true)] out CallAnsweredWebhookEvent? value
    )
    {
        value =this.Value as CallAnsweredWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallBridgedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallBridged(out var value)) {
///     // `value` is of type `CallBridgedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallBridged(
        [NotNullWhen(true)] out CallBridgedWebhookEvent? value
    )
    {
        value =this.Value as CallBridgedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallConversationEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallConversationEnded(out var value)) {
///     // `value` is of type `CallConversationEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallConversationEnded(
        [NotNullWhen(true)] out CallConversationEndedWebhookEvent? value
    )
    {
        value =this.Value as CallConversationEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallConversationInsightsGeneratedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallConversationInsightsGenerated(out var value)) {
///     // `value` is of type `CallConversationInsightsGeneratedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallConversationInsightsGenerated(
        [NotNullWhen(true)] out CallConversationInsightsGeneratedWebhookEvent? value
    )
    {
        value =this.Value as CallConversationInsightsGeneratedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallCostWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallCost(out var value)) {
///     // `value` is of type `CallCostWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallCost(
        [NotNullWhen(true)] out CallCostWebhookEvent? value
    )
    {
        value =this.Value as CallCostWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallDeepfakeDetectionErrorWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallDeepfakeDetectionError(out var value)) {
///     // `value` is of type `CallDeepfakeDetectionErrorWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallDeepfakeDetectionError(
        [NotNullWhen(true)] out CallDeepfakeDetectionErrorWebhookEvent? value
    )
    {
        value =this.Value as CallDeepfakeDetectionErrorWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallDeepfakeDetectionResultWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallDeepfakeDetectionResult(out var value)) {
///     // `value` is of type `CallDeepfakeDetectionResultWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallDeepfakeDetectionResult(
        [NotNullWhen(true)] out CallDeepfakeDetectionResultWebhookEvent? value
    )
    {
        value =this.Value as CallDeepfakeDetectionResultWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallDtmfReceivedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallDtmfReceived(out var value)) {
///     // `value` is of type `CallDtmfReceivedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallDtmfReceived(
        [NotNullWhen(true)] out CallDtmfReceivedWebhookEvent? value
    )
    {
        value =this.Value as CallDtmfReceivedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallEnqueuedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallEnqueued(out var value)) {
///     // `value` is of type `CallEnqueuedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallEnqueued(
        [NotNullWhen(true)] out CallEnqueuedWebhookEvent? value
    )
    {
        value =this.Value as CallEnqueuedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallForkStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallForkStarted(out var value)) {
///     // `value` is of type `CallForkStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallForkStarted(
        [NotNullWhen(true)] out CallForkStartedWebhookEvent? value
    )
    {
        value =this.Value as CallForkStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallForkStoppedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallForkStopped(out var value)) {
///     // `value` is of type `CallForkStoppedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallForkStopped(
        [NotNullWhen(true)] out CallForkStoppedWebhookEvent? value
    )
    {
        value =this.Value as CallForkStoppedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallGatherEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallGatherEnded(out var value)) {
///     // `value` is of type `CallGatherEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallGatherEnded(
        [NotNullWhen(true)] out CallGatherEndedWebhookEvent? value
    )
    {
        value =this.Value as CallGatherEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallHangupWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallHangup(out var value)) {
///     // `value` is of type `CallHangupWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallHangup(
        [NotNullWhen(true)] out CallHangupWebhookEvent? value
    )
    {
        value =this.Value as CallHangupWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallHoldWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallHold(out var value)) {
///     // `value` is of type `CallHoldWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallHold(
        [NotNullWhen(true)] out CallHoldWebhookEvent? value
    )
    {
        value =this.Value as CallHoldWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallInitiatedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallInitiated(out var value)) {
///     // `value` is of type `CallInitiatedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallInitiated(
        [NotNullWhen(true)] out CallInitiatedWebhookEvent? value
    )
    {
        value =this.Value as CallInitiatedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallLeftQueueWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallLeftQueue(out var value)) {
///     // `value` is of type `CallLeftQueueWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallLeftQueue(
        [NotNullWhen(true)] out CallLeftQueueWebhookEvent? value
    )
    {
        value =this.Value as CallLeftQueueWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallMachineDetectionEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallMachineDetectionEnded(out var value)) {
///     // `value` is of type `CallMachineDetectionEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallMachineDetectionEnded(
        [NotNullWhen(true)] out CallMachineDetectionEndedWebhookEvent? value
    )
    {
        value =this.Value as CallMachineDetectionEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallMachineGreetingEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallMachineGreetingEnded(out var value)) {
///     // `value` is of type `CallMachineGreetingEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallMachineGreetingEnded(
        [NotNullWhen(true)] out CallMachineGreetingEndedWebhookEvent? value
    )
    {
        value =this.Value as CallMachineGreetingEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallMachinePremiumDetectionEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallMachinePremiumDetectionEnded(out var value)) {
///     // `value` is of type `CallMachinePremiumDetectionEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallMachinePremiumDetectionEnded(
        [NotNullWhen(true)] out CallMachinePremiumDetectionEndedWebhookEvent? value
    )
    {
        value =this.Value as CallMachinePremiumDetectionEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallMachinePremiumGreetingEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallMachinePremiumGreetingEnded(out var value)) {
///     // `value` is of type `CallMachinePremiumGreetingEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallMachinePremiumGreetingEnded(
        [NotNullWhen(true)] out CallMachinePremiumGreetingEndedWebhookEvent? value
    )
    {
        value =this.Value as CallMachinePremiumGreetingEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallPaymentCompletedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallPaymentCompleted(out var value)) {
///     // `value` is of type `CallPaymentCompletedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallPaymentCompleted(
        [NotNullWhen(true)] out CallPaymentCompletedWebhookEvent? value
    )
    {
        value =this.Value as CallPaymentCompletedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallPaymentProgressWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallPaymentProgress(out var value)) {
///     // `value` is of type `CallPaymentProgressWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallPaymentProgress(
        [NotNullWhen(true)] out CallPaymentProgressWebhookEvent? value
    )
    {
        value =this.Value as CallPaymentProgressWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallPlaybackEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallPlaybackEnded(out var value)) {
///     // `value` is of type `CallPlaybackEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallPlaybackEnded(
        [NotNullWhen(true)] out CallPlaybackEndedWebhookEvent? value
    )
    {
        value =this.Value as CallPlaybackEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallPlaybackStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallPlaybackStarted(out var value)) {
///     // `value` is of type `CallPlaybackStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallPlaybackStarted(
        [NotNullWhen(true)] out CallPlaybackStartedWebhookEvent? value
    )
    {
        value =this.Value as CallPlaybackStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallRecordingErrorWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallRecordingError(out var value)) {
///     // `value` is of type `CallRecordingErrorWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallRecordingError(
        [NotNullWhen(true)] out CallRecordingErrorWebhookEvent? value
    )
    {
        value =this.Value as CallRecordingErrorWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallRecordingSavedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallRecordingSaved(out var value)) {
///     // `value` is of type `CallRecordingSavedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallRecordingSaved(
        [NotNullWhen(true)] out CallRecordingSavedWebhookEvent? value
    )
    {
        value =this.Value as CallRecordingSavedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallRecordingTranscriptionSavedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallRecordingTranscriptionSaved(out var value)) {
///     // `value` is of type `CallRecordingTranscriptionSavedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallRecordingTranscriptionSaved(
        [NotNullWhen(true)] out CallRecordingTranscriptionSavedWebhookEvent? value
    )
    {
        value =this.Value as CallRecordingTranscriptionSavedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallReferCompletedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallReferCompleted(out var value)) {
///     // `value` is of type `CallReferCompletedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallReferCompleted(
        [NotNullWhen(true)] out CallReferCompletedWebhookEvent? value
    )
    {
        value =this.Value as CallReferCompletedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallReferFailedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallReferFailed(out var value)) {
///     // `value` is of type `CallReferFailedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallReferFailed(
        [NotNullWhen(true)] out CallReferFailedWebhookEvent? value
    )
    {
        value =this.Value as CallReferFailedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallReferStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallReferStarted(out var value)) {
///     // `value` is of type `CallReferStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallReferStarted(
        [NotNullWhen(true)] out CallReferStartedWebhookEvent? value
    )
    {
        value =this.Value as CallReferStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallSiprecFailedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallSiprecFailed(out var value)) {
///     // `value` is of type `CallSiprecFailedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallSiprecFailed(
        [NotNullWhen(true)] out CallSiprecFailedWebhookEvent? value
    )
    {
        value =this.Value as CallSiprecFailedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallSiprecStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallSiprecStarted(out var value)) {
///     // `value` is of type `CallSiprecStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallSiprecStarted(
        [NotNullWhen(true)] out CallSiprecStartedWebhookEvent? value
    )
    {
        value =this.Value as CallSiprecStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallSiprecStoppedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallSiprecStopped(out var value)) {
///     // `value` is of type `CallSiprecStoppedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallSiprecStopped(
        [NotNullWhen(true)] out CallSiprecStoppedWebhookEvent? value
    )
    {
        value =this.Value as CallSiprecStoppedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallSpeakEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallSpeakEnded(out var value)) {
///     // `value` is of type `CallSpeakEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallSpeakEnded(
        [NotNullWhen(true)] out CallSpeakEndedWebhookEvent? value
    )
    {
        value =this.Value as CallSpeakEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallSpeakStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallSpeakStarted(out var value)) {
///     // `value` is of type `CallSpeakStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallSpeakStarted(
        [NotNullWhen(true)] out CallSpeakStartedWebhookEvent? value
    )
    {
        value =this.Value as CallSpeakStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallStreamingFailedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallStreamingFailed(out var value)) {
///     // `value` is of type `CallStreamingFailedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallStreamingFailed(
        [NotNullWhen(true)] out CallStreamingFailedWebhookEvent? value
    )
    {
        value =this.Value as CallStreamingFailedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallStreamingStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallStreamingStarted(out var value)) {
///     // `value` is of type `CallStreamingStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallStreamingStarted(
        [NotNullWhen(true)] out CallStreamingStartedWebhookEvent? value
    )
    {
        value =this.Value as CallStreamingStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallStreamingStoppedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallStreamingStopped(out var value)) {
///     // `value` is of type `CallStreamingStoppedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallStreamingStopped(
        [NotNullWhen(true)] out CallStreamingStoppedWebhookEvent? value
    )
    {
        value =this.Value as CallStreamingStoppedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallUnholdWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallUnhold(out var value)) {
///     // `value` is of type `CallUnholdWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallUnhold(
        [NotNullWhen(true)] out CallUnholdWebhookEvent? value
    )
    {
        value =this.Value as CallUnholdWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CampaignStatusUpdate"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCampaignStatusUpdate(out var value)) {
///     // `value` is of type `CampaignStatusUpdate`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCampaignStatusUpdate(
        [NotNullWhen(true)] out CampaignStatusUpdate? value
    )
    {
        value =this.Value as CampaignStatusUpdate ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceCreatedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceCreated(out var value)) {
///     // `value` is of type `ConferenceCreatedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceCreated(
        [NotNullWhen(true)] out ConferenceCreatedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceCreatedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceEnded(out var value)) {
///     // `value` is of type `ConferenceEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceEnded(
        [NotNullWhen(true)] out ConferenceEndedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceFloorChanged"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceFloorChanged(out var value)) {
///     // `value` is of type `ConferenceFloorChanged`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceFloorChanged(
        [NotNullWhen(true)] out ConferenceFloorChanged? value
    )
    {
        value =this.Value as ConferenceFloorChanged ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantJoinedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantJoined(out var value)) {
///     // `value` is of type `ConferenceParticipantJoinedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantJoined(
        [NotNullWhen(true)] out ConferenceParticipantJoinedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceParticipantJoinedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantLeftWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantLeft(out var value)) {
///     // `value` is of type `ConferenceParticipantLeftWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantLeft(
        [NotNullWhen(true)] out ConferenceParticipantLeftWebhookEvent? value
    )
    {
        value =this.Value as ConferenceParticipantLeftWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantPlaybackEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantPlaybackEnded(out var value)) {
///     // `value` is of type `ConferenceParticipantPlaybackEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantPlaybackEnded(
        [NotNullWhen(true)] out ConferenceParticipantPlaybackEndedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceParticipantPlaybackEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantPlaybackStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantPlaybackStarted(out var value)) {
///     // `value` is of type `ConferenceParticipantPlaybackStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantPlaybackStarted(
        [NotNullWhen(true)] out ConferenceParticipantPlaybackStartedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceParticipantPlaybackStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantSpeakEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantSpeakEnded(out var value)) {
///     // `value` is of type `ConferenceParticipantSpeakEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantSpeakEnded(
        [NotNullWhen(true)] out ConferenceParticipantSpeakEndedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceParticipantSpeakEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantSpeakStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantSpeakStarted(out var value)) {
///     // `value` is of type `ConferenceParticipantSpeakStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantSpeakStarted(
        [NotNullWhen(true)] out ConferenceParticipantSpeakStartedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceParticipantSpeakStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferencePlaybackEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferencePlaybackEnded(out var value)) {
///     // `value` is of type `ConferencePlaybackEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferencePlaybackEnded(
        [NotNullWhen(true)] out ConferencePlaybackEndedWebhookEvent? value
    )
    {
        value =this.Value as ConferencePlaybackEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferencePlaybackStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferencePlaybackStarted(out var value)) {
///     // `value` is of type `ConferencePlaybackStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferencePlaybackStarted(
        [NotNullWhen(true)] out ConferencePlaybackStartedWebhookEvent? value
    )
    {
        value =this.Value as ConferencePlaybackStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceRecordingSavedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceRecordingSaved(out var value)) {
///     // `value` is of type `ConferenceRecordingSavedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceRecordingSaved(
        [NotNullWhen(true)] out ConferenceRecordingSavedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceRecordingSavedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceSpeakEndedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceSpeakEnded(out var value)) {
///     // `value` is of type `ConferenceSpeakEndedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceSpeakEnded(
        [NotNullWhen(true)] out ConferenceSpeakEndedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceSpeakEndedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceSpeakStartedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceSpeakStarted(out var value)) {
///     // `value` is of type `ConferenceSpeakStartedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceSpeakStarted(
        [NotNullWhen(true)] out ConferenceSpeakStartedWebhookEvent? value
    )
    {
        value =this.Value as ConferenceSpeakStartedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="DeliveryUpdateWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDeliveryUpdate(out var value)) {
///     // `value` is of type `DeliveryUpdateWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDeliveryUpdate(
        [NotNullWhen(true)] out DeliveryUpdateWebhookEvent? value
    )
    {
        value =this.Value as DeliveryUpdateWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FaxDelivered"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFaxDelivered(out var value)) {
///     // `value` is of type `FaxDelivered`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFaxDelivered([NotNullWhen(true)] out FaxDelivered? value)
    {
        value =this.Value as FaxDelivered ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FaxFailed"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFaxFailed(out var value)) {
///     // `value` is of type `FaxFailed`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFaxFailed([NotNullWhen(true)] out FaxFailed? value)
    {
        value =this.Value as FaxFailed ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FaxMediaProcessed"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFaxMediaProcessed(out var value)) {
///     // `value` is of type `FaxMediaProcessed`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFaxMediaProcessed(
        [NotNullWhen(true)] out FaxMediaProcessed? value
    )
    {
        value =this.Value as FaxMediaProcessed ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FaxQueued"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFaxQueued(out var value)) {
///     // `value` is of type `FaxQueued`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFaxQueued([NotNullWhen(true)] out FaxQueued? value)
    {
        value =this.Value as FaxQueued ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FaxSendingStarted"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFaxSendingStarted(out var value)) {
///     // `value` is of type `FaxSendingStarted`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFaxSendingStarted(
        [NotNullWhen(true)] out FaxSendingStarted? value
    )
    {
        value =this.Value as FaxSendingStarted ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="HostedNumberOrderEventWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickHostedNumberOrderEvent(out var value)) {
///     // `value` is of type `HostedNumberOrderEventWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickHostedNumberOrderEvent(
        [NotNullWhen(true)] out HostedNumberOrderEventWebhookEvent? value
    )
    {
        value =this.Value as HostedNumberOrderEventWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="InboundMessageWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInboundMessage(out var value)) {
///     // `value` is of type `InboundMessageWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInboundMessage(
        [NotNullWhen(true)] out InboundMessageWebhookEvent? value
    )
    {
        value =this.Value as InboundMessageWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="NumberOrderStatusUpdateWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNumberOrderStatusUpdate(out var value)) {
///     // `value` is of type `NumberOrderStatusUpdateWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNumberOrderStatusUpdate(
        [NotNullWhen(true)] out NumberOrderStatusUpdateWebhookEvent? value
    )
    {
        value =this.Value as NumberOrderStatusUpdateWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="RecordingAvailableWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRecordingAvailable(out var value)) {
///     // `value` is of type `RecordingAvailableWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRecordingAvailable(
        [NotNullWhen(true)] out RecordingAvailableWebhookEvent? value
    )
    {
        value =this.Value as RecordingAvailableWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ReplacedLinkClickWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickReplacedLinkClick(out var value)) {
///     // `value` is of type `ReplacedLinkClickWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickReplacedLinkClick(
        [NotNullWhen(true)] out ReplacedLinkClickWebhookEvent? value
    )
    {
        value =this.Value as ReplacedLinkClickWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SessionStatusChangedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSessionStatusChanged(out var value)) {
///     // `value` is of type `SessionStatusChangedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSessionStatusChanged(
        [NotNullWhen(true)] out SessionStatusChangedWebhookEvent? value
    )
    {
        value =this.Value as SessionStatusChangedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptCompletedWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTranscriptCompleted(out var value)) {
///     // `value` is of type `TranscriptCompletedWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTranscriptCompleted(
        [NotNullWhen(true)] out TranscriptCompletedWebhookEvent? value
    )
    {
        value =this.Value as TranscriptCompletedWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionWebhookEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTranscription(out var value)) {
///     // `value` is of type `TranscriptionWebhookEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTranscription(
        [NotNullWhen(true)] out TranscriptionWebhookEvent? value
    )
    {
        value =this.Value as TranscriptionWebhookEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappAccountUpdate"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappAccountUpdate(out var value)) {
///     // `value` is of type `WhatsappAccountUpdate`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappAccountUpdate(
        [NotNullWhen(true)] out WhatsappAccountUpdate? value
    )
    {
        value =this.Value as WhatsappAccountUpdate ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappMessageEcho"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappMessageEcho(out var value)) {
///     // `value` is of type `WhatsappMessageEcho`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappMessageEcho(
        [NotNullWhen(true)] out WhatsappMessageEcho? value
    )
    {
        value =this.Value as WhatsappMessageEcho ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (CallAIGatherEndedWebhookEvent value) =&gt; {...},
///     (CallAIGatherMessageHistoryUpdatedWebhookEvent value) =&gt; {...},
///     (CallAIGatherPartialResultsWebhookEvent value) =&gt; {...},
///     (ArtifactCompletedWebhookEvent value) =&gt; {...},
///     (ArtifactFailedWebhookEvent value) =&gt; {...},
///     (CallAnsweredWebhookEvent value) =&gt; {...},
///     (CallBridgedWebhookEvent value) =&gt; {...},
///     (CallConversationEndedWebhookEvent value) =&gt; {...},
///     (CallConversationInsightsGeneratedWebhookEvent value) =&gt; {...},
///     (CallCostWebhookEvent value) =&gt; {...},
///     (CallDeepfakeDetectionErrorWebhookEvent value) =&gt; {...},
///     (CallDeepfakeDetectionResultWebhookEvent value) =&gt; {...},
///     (CallDtmfReceivedWebhookEvent value) =&gt; {...},
///     (CallEnqueuedWebhookEvent value) =&gt; {...},
///     (CallForkStartedWebhookEvent value) =&gt; {...},
///     (CallForkStoppedWebhookEvent value) =&gt; {...},
///     (CallGatherEndedWebhookEvent value) =&gt; {...},
///     (CallHangupWebhookEvent value) =&gt; {...},
///     (CallHoldWebhookEvent value) =&gt; {...},
///     (CallInitiatedWebhookEvent value) =&gt; {...},
///     (CallLeftQueueWebhookEvent value) =&gt; {...},
///     (CallMachineDetectionEndedWebhookEvent value) =&gt; {...},
///     (CallMachineGreetingEndedWebhookEvent value) =&gt; {...},
///     (CallMachinePremiumDetectionEndedWebhookEvent value) =&gt; {...},
///     (CallMachinePremiumGreetingEndedWebhookEvent value) =&gt; {...},
///     (CallPaymentCompletedWebhookEvent value) =&gt; {...},
///     (CallPaymentProgressWebhookEvent value) =&gt; {...},
///     (CallPlaybackEndedWebhookEvent value) =&gt; {...},
///     (CallPlaybackStartedWebhookEvent value) =&gt; {...},
///     (CallRecordingErrorWebhookEvent value) =&gt; {...},
///     (CallRecordingSavedWebhookEvent value) =&gt; {...},
///     (CallRecordingTranscriptionSavedWebhookEvent value) =&gt; {...},
///     (CallReferCompletedWebhookEvent value) =&gt; {...},
///     (CallReferFailedWebhookEvent value) =&gt; {...},
///     (CallReferStartedWebhookEvent value) =&gt; {...},
///     (CallSiprecFailedWebhookEvent value) =&gt; {...},
///     (CallSiprecStartedWebhookEvent value) =&gt; {...},
///     (CallSiprecStoppedWebhookEvent value) =&gt; {...},
///     (CallSpeakEndedWebhookEvent value) =&gt; {...},
///     (CallSpeakStartedWebhookEvent value) =&gt; {...},
///     (CallStreamingFailedWebhookEvent value) =&gt; {...},
///     (CallStreamingStartedWebhookEvent value) =&gt; {...},
///     (CallStreamingStoppedWebhookEvent value) =&gt; {...},
///     (CallUnholdWebhookEvent value) =&gt; {...},
///     (CampaignStatusUpdate value) =&gt; {...},
///     (ConferenceCreatedWebhookEvent value) =&gt; {...},
///     (ConferenceEndedWebhookEvent value) =&gt; {...},
///     (ConferenceFloorChanged value) =&gt; {...},
///     (ConferenceParticipantJoinedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantLeftWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantPlaybackEndedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantPlaybackStartedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantSpeakEndedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantSpeakStartedWebhookEvent value) =&gt; {...},
///     (ConferencePlaybackEndedWebhookEvent value) =&gt; {...},
///     (ConferencePlaybackStartedWebhookEvent value) =&gt; {...},
///     (ConferenceRecordingSavedWebhookEvent value) =&gt; {...},
///     (ConferenceSpeakEndedWebhookEvent value) =&gt; {...},
///     (ConferenceSpeakStartedWebhookEvent value) =&gt; {...},
///     (DeliveryUpdateWebhookEvent value) =&gt; {...},
///     (FaxDelivered value) =&gt; {...},
///     (FaxFailed value) =&gt; {...},
///     (FaxMediaProcessed value) =&gt; {...},
///     (FaxQueued value) =&gt; {...},
///     (FaxSendingStarted value) =&gt; {...},
///     (HostedNumberOrderEventWebhookEvent value) =&gt; {...},
///     (InboundMessageWebhookEvent value) =&gt; {...},
///     (NumberOrderStatusUpdateWebhookEvent value) =&gt; {...},
///     (RecordingAvailableWebhookEvent value) =&gt; {...},
///     (ReplacedLinkClickWebhookEvent value) =&gt; {...},
///     (SessionStatusChangedWebhookEvent value) =&gt; {...},
///     (TranscriptCompletedWebhookEvent value) =&gt; {...},
///     (TranscriptionWebhookEvent value) =&gt; {...},
///     (WhatsappAccountUpdate value) =&gt; {...},
///     (WhatsappMessageEcho value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<CallAIGatherEndedWebhookEvent> callAIGatherEnded,
        System::Action<CallAIGatherMessageHistoryUpdatedWebhookEvent> callAIGatherMessageHistoryUpdated,
        System::Action<CallAIGatherPartialResultsWebhookEvent> callAIGatherPartialResults,
        System::Action<ArtifactCompletedWebhookEvent> artifactCompleted,
        System::Action<ArtifactFailedWebhookEvent> artifactFailed,
        System::Action<CallAnsweredWebhookEvent> callAnswered,
        System::Action<CallBridgedWebhookEvent> callBridged,
        System::Action<CallConversationEndedWebhookEvent> callConversationEnded,
        System::Action<CallConversationInsightsGeneratedWebhookEvent> callConversationInsightsGenerated,
        System::Action<CallCostWebhookEvent> callCost,
        System::Action<CallDeepfakeDetectionErrorWebhookEvent> callDeepfakeDetectionError,
        System::Action<CallDeepfakeDetectionResultWebhookEvent> callDeepfakeDetectionResult,
        System::Action<CallDtmfReceivedWebhookEvent> callDtmfReceived,
        System::Action<CallEnqueuedWebhookEvent> callEnqueued,
        System::Action<CallForkStartedWebhookEvent> callForkStarted,
        System::Action<CallForkStoppedWebhookEvent> callForkStopped,
        System::Action<CallGatherEndedWebhookEvent> callGatherEnded,
        System::Action<CallHangupWebhookEvent> callHangup,
        System::Action<CallHoldWebhookEvent> callHold,
        System::Action<CallInitiatedWebhookEvent> callInitiated,
        System::Action<CallLeftQueueWebhookEvent> callLeftQueue,
        System::Action<CallMachineDetectionEndedWebhookEvent> callMachineDetectionEnded,
        System::Action<CallMachineGreetingEndedWebhookEvent> callMachineGreetingEnded,
        System::Action<CallMachinePremiumDetectionEndedWebhookEvent> callMachinePremiumDetectionEnded,
        System::Action<CallMachinePremiumGreetingEndedWebhookEvent> callMachinePremiumGreetingEnded,
        System::Action<CallPaymentCompletedWebhookEvent> callPaymentCompleted,
        System::Action<CallPaymentProgressWebhookEvent> callPaymentProgress,
        System::Action<CallPlaybackEndedWebhookEvent> callPlaybackEnded,
        System::Action<CallPlaybackStartedWebhookEvent> callPlaybackStarted,
        System::Action<CallRecordingErrorWebhookEvent> callRecordingError,
        System::Action<CallRecordingSavedWebhookEvent> callRecordingSaved,
        System::Action<CallRecordingTranscriptionSavedWebhookEvent> callRecordingTranscriptionSaved,
        System::Action<CallReferCompletedWebhookEvent> callReferCompleted,
        System::Action<CallReferFailedWebhookEvent> callReferFailed,
        System::Action<CallReferStartedWebhookEvent> callReferStarted,
        System::Action<CallSiprecFailedWebhookEvent> callSiprecFailed,
        System::Action<CallSiprecStartedWebhookEvent> callSiprecStarted,
        System::Action<CallSiprecStoppedWebhookEvent> callSiprecStopped,
        System::Action<CallSpeakEndedWebhookEvent> callSpeakEnded,
        System::Action<CallSpeakStartedWebhookEvent> callSpeakStarted,
        System::Action<CallStreamingFailedWebhookEvent> callStreamingFailed,
        System::Action<CallStreamingStartedWebhookEvent> callStreamingStarted,
        System::Action<CallStreamingStoppedWebhookEvent> callStreamingStopped,
        System::Action<CallUnholdWebhookEvent> callUnhold,
        System::Action<CampaignStatusUpdate> campaignStatusUpdate,
        System::Action<ConferenceCreatedWebhookEvent> conferenceCreated,
        System::Action<ConferenceEndedWebhookEvent> conferenceEnded,
        System::Action<ConferenceFloorChanged> conferenceFloorChanged,
        System::Action<ConferenceParticipantJoinedWebhookEvent> conferenceParticipantJoined,
        System::Action<ConferenceParticipantLeftWebhookEvent> conferenceParticipantLeft,
        System::Action<ConferenceParticipantPlaybackEndedWebhookEvent> conferenceParticipantPlaybackEnded,
        System::Action<ConferenceParticipantPlaybackStartedWebhookEvent> conferenceParticipantPlaybackStarted,
        System::Action<ConferenceParticipantSpeakEndedWebhookEvent> conferenceParticipantSpeakEnded,
        System::Action<ConferenceParticipantSpeakStartedWebhookEvent> conferenceParticipantSpeakStarted,
        System::Action<ConferencePlaybackEndedWebhookEvent> conferencePlaybackEnded,
        System::Action<ConferencePlaybackStartedWebhookEvent> conferencePlaybackStarted,
        System::Action<ConferenceRecordingSavedWebhookEvent> conferenceRecordingSaved,
        System::Action<ConferenceSpeakEndedWebhookEvent> conferenceSpeakEnded,
        System::Action<ConferenceSpeakStartedWebhookEvent> conferenceSpeakStarted,
        System::Action<DeliveryUpdateWebhookEvent> deliveryUpdate,
        System::Action<FaxDelivered> faxDelivered,
        System::Action<FaxFailed> faxFailed,
        System::Action<FaxMediaProcessed> faxMediaProcessed,
        System::Action<FaxQueued> faxQueued,
        System::Action<FaxSendingStarted> faxSendingStarted,
        System::Action<HostedNumberOrderEventWebhookEvent> hostedNumberOrderEvent,
        System::Action<InboundMessageWebhookEvent> inboundMessage,
        System::Action<NumberOrderStatusUpdateWebhookEvent> numberOrderStatusUpdate,
        System::Action<RecordingAvailableWebhookEvent> recordingAvailable,
        System::Action<ReplacedLinkClickWebhookEvent> replacedLinkClick,
        System::Action<SessionStatusChangedWebhookEvent> sessionStatusChanged,
        System::Action<TranscriptCompletedWebhookEvent> transcriptCompleted,
        System::Action<TranscriptionWebhookEvent> transcription,
        System::Action<WhatsappAccountUpdate> whatsappAccountUpdate,
        System::Action<WhatsappMessageEcho> whatsappMessageEcho
    )
    {
        switch (this.Value)
        {
            case CallAIGatherEndedWebhookEvent value:
                callAIGatherEnded(value);
                break;
            case CallAIGatherMessageHistoryUpdatedWebhookEvent value:
                callAIGatherMessageHistoryUpdated(value);
                break;
            case CallAIGatherPartialResultsWebhookEvent value:
                callAIGatherPartialResults(value);
                break;
            case ArtifactCompletedWebhookEvent value:
                artifactCompleted(value);
                break;
            case ArtifactFailedWebhookEvent value:
                artifactFailed(value);
                break;
            case CallAnsweredWebhookEvent value:
                callAnswered(value);
                break;
            case CallBridgedWebhookEvent value:
                callBridged(value);
                break;
            case CallConversationEndedWebhookEvent value:
                callConversationEnded(value);
                break;
            case CallConversationInsightsGeneratedWebhookEvent value:
                callConversationInsightsGenerated(value);
                break;
            case CallCostWebhookEvent value:
                callCost(value);
                break;
            case CallDeepfakeDetectionErrorWebhookEvent value:
                callDeepfakeDetectionError(value);
                break;
            case CallDeepfakeDetectionResultWebhookEvent value:
                callDeepfakeDetectionResult(value);
                break;
            case CallDtmfReceivedWebhookEvent value:
                callDtmfReceived(value);
                break;
            case CallEnqueuedWebhookEvent value:
                callEnqueued(value);
                break;
            case CallForkStartedWebhookEvent value:
                callForkStarted(value);
                break;
            case CallForkStoppedWebhookEvent value:
                callForkStopped(value);
                break;
            case CallGatherEndedWebhookEvent value:
                callGatherEnded(value);
                break;
            case CallHangupWebhookEvent value:
                callHangup(value);
                break;
            case CallHoldWebhookEvent value:
                callHold(value);
                break;
            case CallInitiatedWebhookEvent value:
                callInitiated(value);
                break;
            case CallLeftQueueWebhookEvent value:
                callLeftQueue(value);
                break;
            case CallMachineDetectionEndedWebhookEvent value:
                callMachineDetectionEnded(value);
                break;
            case CallMachineGreetingEndedWebhookEvent value:
                callMachineGreetingEnded(value);
                break;
            case CallMachinePremiumDetectionEndedWebhookEvent value:
                callMachinePremiumDetectionEnded(value);
                break;
            case CallMachinePremiumGreetingEndedWebhookEvent value:
                callMachinePremiumGreetingEnded(value);
                break;
            case CallPaymentCompletedWebhookEvent value:
                callPaymentCompleted(value);
                break;
            case CallPaymentProgressWebhookEvent value:
                callPaymentProgress(value);
                break;
            case CallPlaybackEndedWebhookEvent value:
                callPlaybackEnded(value);
                break;
            case CallPlaybackStartedWebhookEvent value:
                callPlaybackStarted(value);
                break;
            case CallRecordingErrorWebhookEvent value:
                callRecordingError(value);
                break;
            case CallRecordingSavedWebhookEvent value:
                callRecordingSaved(value);
                break;
            case CallRecordingTranscriptionSavedWebhookEvent value:
                callRecordingTranscriptionSaved(value);
                break;
            case CallReferCompletedWebhookEvent value:
                callReferCompleted(value);
                break;
            case CallReferFailedWebhookEvent value:
                callReferFailed(value);
                break;
            case CallReferStartedWebhookEvent value:
                callReferStarted(value);
                break;
            case CallSiprecFailedWebhookEvent value:
                callSiprecFailed(value);
                break;
            case CallSiprecStartedWebhookEvent value:
                callSiprecStarted(value);
                break;
            case CallSiprecStoppedWebhookEvent value:
                callSiprecStopped(value);
                break;
            case CallSpeakEndedWebhookEvent value:
                callSpeakEnded(value);
                break;
            case CallSpeakStartedWebhookEvent value:
                callSpeakStarted(value);
                break;
            case CallStreamingFailedWebhookEvent value:
                callStreamingFailed(value);
                break;
            case CallStreamingStartedWebhookEvent value:
                callStreamingStarted(value);
                break;
            case CallStreamingStoppedWebhookEvent value:
                callStreamingStopped(value);
                break;
            case CallUnholdWebhookEvent value:
                callUnhold(value);
                break;
            case CampaignStatusUpdate value:
                campaignStatusUpdate(value);
                break;
            case ConferenceCreatedWebhookEvent value:
                conferenceCreated(value);
                break;
            case ConferenceEndedWebhookEvent value:
                conferenceEnded(value);
                break;
            case ConferenceFloorChanged value:
                conferenceFloorChanged(value);
                break;
            case ConferenceParticipantJoinedWebhookEvent value:
                conferenceParticipantJoined(value);
                break;
            case ConferenceParticipantLeftWebhookEvent value:
                conferenceParticipantLeft(value);
                break;
            case ConferenceParticipantPlaybackEndedWebhookEvent value:
                conferenceParticipantPlaybackEnded(value);
                break;
            case ConferenceParticipantPlaybackStartedWebhookEvent value:
                conferenceParticipantPlaybackStarted(value);
                break;
            case ConferenceParticipantSpeakEndedWebhookEvent value:
                conferenceParticipantSpeakEnded(value);
                break;
            case ConferenceParticipantSpeakStartedWebhookEvent value:
                conferenceParticipantSpeakStarted(value);
                break;
            case ConferencePlaybackEndedWebhookEvent value:
                conferencePlaybackEnded(value);
                break;
            case ConferencePlaybackStartedWebhookEvent value:
                conferencePlaybackStarted(value);
                break;
            case ConferenceRecordingSavedWebhookEvent value:
                conferenceRecordingSaved(value);
                break;
            case ConferenceSpeakEndedWebhookEvent value:
                conferenceSpeakEnded(value);
                break;
            case ConferenceSpeakStartedWebhookEvent value:
                conferenceSpeakStarted(value);
                break;
            case DeliveryUpdateWebhookEvent value:
                deliveryUpdate(value);
                break;
            case FaxDelivered value:
                faxDelivered(value);
                break;
            case FaxFailed value:
                faxFailed(value);
                break;
            case FaxMediaProcessed value:
                faxMediaProcessed(value);
                break;
            case FaxQueued value:
                faxQueued(value);
                break;
            case FaxSendingStarted value:
                faxSendingStarted(value);
                break;
            case HostedNumberOrderEventWebhookEvent value:
                hostedNumberOrderEvent(value);
                break;
            case InboundMessageWebhookEvent value:
                inboundMessage(value);
                break;
            case NumberOrderStatusUpdateWebhookEvent value:
                numberOrderStatusUpdate(value);
                break;
            case RecordingAvailableWebhookEvent value:
                recordingAvailable(value);
                break;
            case ReplacedLinkClickWebhookEvent value:
                replacedLinkClick(value);
                break;
            case SessionStatusChangedWebhookEvent value:
                sessionStatusChanged(value);
                break;
            case TranscriptCompletedWebhookEvent value:
                transcriptCompleted(value);
                break;
            case TranscriptionWebhookEvent value:
                transcription(value);
                break;
            case WhatsappAccountUpdate value:
                whatsappAccountUpdate(value);
                break;
            case WhatsappMessageEcho value:
                whatsappMessageEcho(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of UnwrapWebhookEvent");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (CallAIGatherEndedWebhookEvent value) =&gt; {...},
///     (CallAIGatherMessageHistoryUpdatedWebhookEvent value) =&gt; {...},
///     (CallAIGatherPartialResultsWebhookEvent value) =&gt; {...},
///     (ArtifactCompletedWebhookEvent value) =&gt; {...},
///     (ArtifactFailedWebhookEvent value) =&gt; {...},
///     (CallAnsweredWebhookEvent value) =&gt; {...},
///     (CallBridgedWebhookEvent value) =&gt; {...},
///     (CallConversationEndedWebhookEvent value) =&gt; {...},
///     (CallConversationInsightsGeneratedWebhookEvent value) =&gt; {...},
///     (CallCostWebhookEvent value) =&gt; {...},
///     (CallDeepfakeDetectionErrorWebhookEvent value) =&gt; {...},
///     (CallDeepfakeDetectionResultWebhookEvent value) =&gt; {...},
///     (CallDtmfReceivedWebhookEvent value) =&gt; {...},
///     (CallEnqueuedWebhookEvent value) =&gt; {...},
///     (CallForkStartedWebhookEvent value) =&gt; {...},
///     (CallForkStoppedWebhookEvent value) =&gt; {...},
///     (CallGatherEndedWebhookEvent value) =&gt; {...},
///     (CallHangupWebhookEvent value) =&gt; {...},
///     (CallHoldWebhookEvent value) =&gt; {...},
///     (CallInitiatedWebhookEvent value) =&gt; {...},
///     (CallLeftQueueWebhookEvent value) =&gt; {...},
///     (CallMachineDetectionEndedWebhookEvent value) =&gt; {...},
///     (CallMachineGreetingEndedWebhookEvent value) =&gt; {...},
///     (CallMachinePremiumDetectionEndedWebhookEvent value) =&gt; {...},
///     (CallMachinePremiumGreetingEndedWebhookEvent value) =&gt; {...},
///     (CallPaymentCompletedWebhookEvent value) =&gt; {...},
///     (CallPaymentProgressWebhookEvent value) =&gt; {...},
///     (CallPlaybackEndedWebhookEvent value) =&gt; {...},
///     (CallPlaybackStartedWebhookEvent value) =&gt; {...},
///     (CallRecordingErrorWebhookEvent value) =&gt; {...},
///     (CallRecordingSavedWebhookEvent value) =&gt; {...},
///     (CallRecordingTranscriptionSavedWebhookEvent value) =&gt; {...},
///     (CallReferCompletedWebhookEvent value) =&gt; {...},
///     (CallReferFailedWebhookEvent value) =&gt; {...},
///     (CallReferStartedWebhookEvent value) =&gt; {...},
///     (CallSiprecFailedWebhookEvent value) =&gt; {...},
///     (CallSiprecStartedWebhookEvent value) =&gt; {...},
///     (CallSiprecStoppedWebhookEvent value) =&gt; {...},
///     (CallSpeakEndedWebhookEvent value) =&gt; {...},
///     (CallSpeakStartedWebhookEvent value) =&gt; {...},
///     (CallStreamingFailedWebhookEvent value) =&gt; {...},
///     (CallStreamingStartedWebhookEvent value) =&gt; {...},
///     (CallStreamingStoppedWebhookEvent value) =&gt; {...},
///     (CallUnholdWebhookEvent value) =&gt; {...},
///     (CampaignStatusUpdate value) =&gt; {...},
///     (ConferenceCreatedWebhookEvent value) =&gt; {...},
///     (ConferenceEndedWebhookEvent value) =&gt; {...},
///     (ConferenceFloorChanged value) =&gt; {...},
///     (ConferenceParticipantJoinedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantLeftWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantPlaybackEndedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantPlaybackStartedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantSpeakEndedWebhookEvent value) =&gt; {...},
///     (ConferenceParticipantSpeakStartedWebhookEvent value) =&gt; {...},
///     (ConferencePlaybackEndedWebhookEvent value) =&gt; {...},
///     (ConferencePlaybackStartedWebhookEvent value) =&gt; {...},
///     (ConferenceRecordingSavedWebhookEvent value) =&gt; {...},
///     (ConferenceSpeakEndedWebhookEvent value) =&gt; {...},
///     (ConferenceSpeakStartedWebhookEvent value) =&gt; {...},
///     (DeliveryUpdateWebhookEvent value) =&gt; {...},
///     (FaxDelivered value) =&gt; {...},
///     (FaxFailed value) =&gt; {...},
///     (FaxMediaProcessed value) =&gt; {...},
///     (FaxQueued value) =&gt; {...},
///     (FaxSendingStarted value) =&gt; {...},
///     (HostedNumberOrderEventWebhookEvent value) =&gt; {...},
///     (InboundMessageWebhookEvent value) =&gt; {...},
///     (NumberOrderStatusUpdateWebhookEvent value) =&gt; {...},
///     (RecordingAvailableWebhookEvent value) =&gt; {...},
///     (ReplacedLinkClickWebhookEvent value) =&gt; {...},
///     (SessionStatusChangedWebhookEvent value) =&gt; {...},
///     (TranscriptCompletedWebhookEvent value) =&gt; {...},
///     (TranscriptionWebhookEvent value) =&gt; {...},
///     (WhatsappAccountUpdate value) =&gt; {...},
///     (WhatsappMessageEcho value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<CallAIGatherEndedWebhookEvent, T> callAIGatherEnded,
        System::Func<CallAIGatherMessageHistoryUpdatedWebhookEvent, T> callAIGatherMessageHistoryUpdated,
        System::Func<CallAIGatherPartialResultsWebhookEvent, T> callAIGatherPartialResults,
        System::Func<ArtifactCompletedWebhookEvent, T> artifactCompleted,
        System::Func<ArtifactFailedWebhookEvent, T> artifactFailed,
        System::Func<CallAnsweredWebhookEvent, T> callAnswered,
        System::Func<CallBridgedWebhookEvent, T> callBridged,
        System::Func<CallConversationEndedWebhookEvent, T> callConversationEnded,
        System::Func<CallConversationInsightsGeneratedWebhookEvent, T> callConversationInsightsGenerated,
        System::Func<CallCostWebhookEvent, T> callCost,
        System::Func<CallDeepfakeDetectionErrorWebhookEvent, T> callDeepfakeDetectionError,
        System::Func<CallDeepfakeDetectionResultWebhookEvent, T> callDeepfakeDetectionResult,
        System::Func<CallDtmfReceivedWebhookEvent, T> callDtmfReceived,
        System::Func<CallEnqueuedWebhookEvent, T> callEnqueued,
        System::Func<CallForkStartedWebhookEvent, T> callForkStarted,
        System::Func<CallForkStoppedWebhookEvent, T> callForkStopped,
        System::Func<CallGatherEndedWebhookEvent, T> callGatherEnded,
        System::Func<CallHangupWebhookEvent, T> callHangup,
        System::Func<CallHoldWebhookEvent, T> callHold,
        System::Func<CallInitiatedWebhookEvent, T> callInitiated,
        System::Func<CallLeftQueueWebhookEvent, T> callLeftQueue,
        System::Func<CallMachineDetectionEndedWebhookEvent, T> callMachineDetectionEnded,
        System::Func<CallMachineGreetingEndedWebhookEvent, T> callMachineGreetingEnded,
        System::Func<CallMachinePremiumDetectionEndedWebhookEvent, T> callMachinePremiumDetectionEnded,
        System::Func<CallMachinePremiumGreetingEndedWebhookEvent, T> callMachinePremiumGreetingEnded,
        System::Func<CallPaymentCompletedWebhookEvent, T> callPaymentCompleted,
        System::Func<CallPaymentProgressWebhookEvent, T> callPaymentProgress,
        System::Func<CallPlaybackEndedWebhookEvent, T> callPlaybackEnded,
        System::Func<CallPlaybackStartedWebhookEvent, T> callPlaybackStarted,
        System::Func<CallRecordingErrorWebhookEvent, T> callRecordingError,
        System::Func<CallRecordingSavedWebhookEvent, T> callRecordingSaved,
        System::Func<CallRecordingTranscriptionSavedWebhookEvent, T> callRecordingTranscriptionSaved,
        System::Func<CallReferCompletedWebhookEvent, T> callReferCompleted,
        System::Func<CallReferFailedWebhookEvent, T> callReferFailed,
        System::Func<CallReferStartedWebhookEvent, T> callReferStarted,
        System::Func<CallSiprecFailedWebhookEvent, T> callSiprecFailed,
        System::Func<CallSiprecStartedWebhookEvent, T> callSiprecStarted,
        System::Func<CallSiprecStoppedWebhookEvent, T> callSiprecStopped,
        System::Func<CallSpeakEndedWebhookEvent, T> callSpeakEnded,
        System::Func<CallSpeakStartedWebhookEvent, T> callSpeakStarted,
        System::Func<CallStreamingFailedWebhookEvent, T> callStreamingFailed,
        System::Func<CallStreamingStartedWebhookEvent, T> callStreamingStarted,
        System::Func<CallStreamingStoppedWebhookEvent, T> callStreamingStopped,
        System::Func<CallUnholdWebhookEvent, T> callUnhold,
        System::Func<CampaignStatusUpdate, T> campaignStatusUpdate,
        System::Func<ConferenceCreatedWebhookEvent, T> conferenceCreated,
        System::Func<ConferenceEndedWebhookEvent, T> conferenceEnded,
        System::Func<ConferenceFloorChanged, T> conferenceFloorChanged,
        System::Func<ConferenceParticipantJoinedWebhookEvent, T> conferenceParticipantJoined,
        System::Func<ConferenceParticipantLeftWebhookEvent, T> conferenceParticipantLeft,
        System::Func<ConferenceParticipantPlaybackEndedWebhookEvent, T> conferenceParticipantPlaybackEnded,
        System::Func<ConferenceParticipantPlaybackStartedWebhookEvent, T> conferenceParticipantPlaybackStarted,
        System::Func<ConferenceParticipantSpeakEndedWebhookEvent, T> conferenceParticipantSpeakEnded,
        System::Func<ConferenceParticipantSpeakStartedWebhookEvent, T> conferenceParticipantSpeakStarted,
        System::Func<ConferencePlaybackEndedWebhookEvent, T> conferencePlaybackEnded,
        System::Func<ConferencePlaybackStartedWebhookEvent, T> conferencePlaybackStarted,
        System::Func<ConferenceRecordingSavedWebhookEvent, T> conferenceRecordingSaved,
        System::Func<ConferenceSpeakEndedWebhookEvent, T> conferenceSpeakEnded,
        System::Func<ConferenceSpeakStartedWebhookEvent, T> conferenceSpeakStarted,
        System::Func<DeliveryUpdateWebhookEvent, T> deliveryUpdate,
        System::Func<FaxDelivered, T> faxDelivered,
        System::Func<FaxFailed, T> faxFailed,
        System::Func<FaxMediaProcessed, T> faxMediaProcessed,
        System::Func<FaxQueued, T> faxQueued,
        System::Func<FaxSendingStarted, T> faxSendingStarted,
        System::Func<HostedNumberOrderEventWebhookEvent, T> hostedNumberOrderEvent,
        System::Func<InboundMessageWebhookEvent, T> inboundMessage,
        System::Func<NumberOrderStatusUpdateWebhookEvent, T> numberOrderStatusUpdate,
        System::Func<RecordingAvailableWebhookEvent, T> recordingAvailable,
        System::Func<ReplacedLinkClickWebhookEvent, T> replacedLinkClick,
        System::Func<SessionStatusChangedWebhookEvent, T> sessionStatusChanged,
        System::Func<TranscriptCompletedWebhookEvent, T> transcriptCompleted,
        System::Func<TranscriptionWebhookEvent, T> transcription,
        System::Func<WhatsappAccountUpdate, T> whatsappAccountUpdate,
        System::Func<WhatsappMessageEcho, T> whatsappMessageEcho
    )
    {
        return this.Value switch
        {
            CallAIGatherEndedWebhookEvent value=>callAIGatherEnded(value),
            CallAIGatherMessageHistoryUpdatedWebhookEvent value=>callAIGatherMessageHistoryUpdated(value),
            CallAIGatherPartialResultsWebhookEvent value=>callAIGatherPartialResults(value),
            ArtifactCompletedWebhookEvent value=>artifactCompleted(value),
            ArtifactFailedWebhookEvent value=>artifactFailed(value),
            CallAnsweredWebhookEvent value=>callAnswered(value),
            CallBridgedWebhookEvent value=>callBridged(value),
            CallConversationEndedWebhookEvent value=>callConversationEnded(value),
            CallConversationInsightsGeneratedWebhookEvent value=>callConversationInsightsGenerated(value),
            CallCostWebhookEvent value=>callCost(value),
            CallDeepfakeDetectionErrorWebhookEvent value=>callDeepfakeDetectionError(value),
            CallDeepfakeDetectionResultWebhookEvent value=>callDeepfakeDetectionResult(value),
            CallDtmfReceivedWebhookEvent value=>callDtmfReceived(value),
            CallEnqueuedWebhookEvent value=>callEnqueued(value),
            CallForkStartedWebhookEvent value=>callForkStarted(value),
            CallForkStoppedWebhookEvent value=>callForkStopped(value),
            CallGatherEndedWebhookEvent value=>callGatherEnded(value),
            CallHangupWebhookEvent value=>callHangup(value),
            CallHoldWebhookEvent value=>callHold(value),
            CallInitiatedWebhookEvent value=>callInitiated(value),
            CallLeftQueueWebhookEvent value=>callLeftQueue(value),
            CallMachineDetectionEndedWebhookEvent value=>callMachineDetectionEnded(value),
            CallMachineGreetingEndedWebhookEvent value=>callMachineGreetingEnded(value),
            CallMachinePremiumDetectionEndedWebhookEvent value=>callMachinePremiumDetectionEnded(value),
            CallMachinePremiumGreetingEndedWebhookEvent value=>callMachinePremiumGreetingEnded(value),
            CallPaymentCompletedWebhookEvent value=>callPaymentCompleted(value),
            CallPaymentProgressWebhookEvent value=>callPaymentProgress(value),
            CallPlaybackEndedWebhookEvent value=>callPlaybackEnded(value),
            CallPlaybackStartedWebhookEvent value=>callPlaybackStarted(value),
            CallRecordingErrorWebhookEvent value=>callRecordingError(value),
            CallRecordingSavedWebhookEvent value=>callRecordingSaved(value),
            CallRecordingTranscriptionSavedWebhookEvent value=>callRecordingTranscriptionSaved(value),
            CallReferCompletedWebhookEvent value=>callReferCompleted(value),
            CallReferFailedWebhookEvent value=>callReferFailed(value),
            CallReferStartedWebhookEvent value=>callReferStarted(value),
            CallSiprecFailedWebhookEvent value=>callSiprecFailed(value),
            CallSiprecStartedWebhookEvent value=>callSiprecStarted(value),
            CallSiprecStoppedWebhookEvent value=>callSiprecStopped(value),
            CallSpeakEndedWebhookEvent value=>callSpeakEnded(value),
            CallSpeakStartedWebhookEvent value=>callSpeakStarted(value),
            CallStreamingFailedWebhookEvent value=>callStreamingFailed(value),
            CallStreamingStartedWebhookEvent value=>callStreamingStarted(value),
            CallStreamingStoppedWebhookEvent value=>callStreamingStopped(value),
            CallUnholdWebhookEvent value=>callUnhold(value),
            CampaignStatusUpdate value=>campaignStatusUpdate(value),
            ConferenceCreatedWebhookEvent value=>conferenceCreated(value),
            ConferenceEndedWebhookEvent value=>conferenceEnded(value),
            ConferenceFloorChanged value=>conferenceFloorChanged(value),
            ConferenceParticipantJoinedWebhookEvent value=>conferenceParticipantJoined(value),
            ConferenceParticipantLeftWebhookEvent value=>conferenceParticipantLeft(value),
            ConferenceParticipantPlaybackEndedWebhookEvent value=>conferenceParticipantPlaybackEnded(value),
            ConferenceParticipantPlaybackStartedWebhookEvent value=>conferenceParticipantPlaybackStarted(value),
            ConferenceParticipantSpeakEndedWebhookEvent value=>conferenceParticipantSpeakEnded(value),
            ConferenceParticipantSpeakStartedWebhookEvent value=>conferenceParticipantSpeakStarted(value),
            ConferencePlaybackEndedWebhookEvent value=>conferencePlaybackEnded(value),
            ConferencePlaybackStartedWebhookEvent value=>conferencePlaybackStarted(value),
            ConferenceRecordingSavedWebhookEvent value=>conferenceRecordingSaved(value),
            ConferenceSpeakEndedWebhookEvent value=>conferenceSpeakEnded(value),
            ConferenceSpeakStartedWebhookEvent value=>conferenceSpeakStarted(value),
            DeliveryUpdateWebhookEvent value=>deliveryUpdate(value),
            FaxDelivered value=>faxDelivered(value),
            FaxFailed value=>faxFailed(value),
            FaxMediaProcessed value=>faxMediaProcessed(value),
            FaxQueued value=>faxQueued(value),
            FaxSendingStarted value=>faxSendingStarted(value),
            HostedNumberOrderEventWebhookEvent value=>hostedNumberOrderEvent(value),
            InboundMessageWebhookEvent value=>inboundMessage(value),
            NumberOrderStatusUpdateWebhookEvent value=>numberOrderStatusUpdate(value),
            RecordingAvailableWebhookEvent value=>recordingAvailable(value),
            ReplacedLinkClickWebhookEvent value=>replacedLinkClick(value),
            SessionStatusChangedWebhookEvent value=>sessionStatusChanged(value),
            TranscriptCompletedWebhookEvent value=>transcriptCompleted(value),
            TranscriptionWebhookEvent value=>transcription(value),
            WhatsappAccountUpdate value=>whatsappAccountUpdate(value),
            WhatsappMessageEcho value=>whatsappMessageEcho(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of UnwrapWebhookEvent")
        } ;
    }

    public static implicit operator UnwrapWebhookEvent (
        CallAIGatherEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallAIGatherMessageHistoryUpdatedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallAIGatherPartialResultsWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ArtifactCompletedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ArtifactFailedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallAnsweredWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallBridgedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallConversationEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallConversationInsightsGeneratedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallCostWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallDeepfakeDetectionErrorWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallDeepfakeDetectionResultWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallDtmfReceivedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallEnqueuedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallForkStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallForkStoppedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallGatherEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallHangupWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallHoldWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallInitiatedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallLeftQueueWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallMachineDetectionEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallMachineGreetingEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallMachinePremiumDetectionEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallMachinePremiumGreetingEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallPaymentCompletedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallPaymentProgressWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallPlaybackEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallPlaybackStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallRecordingErrorWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallRecordingSavedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallRecordingTranscriptionSavedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallReferCompletedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallReferFailedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallReferStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallSiprecFailedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallSiprecStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallSiprecStoppedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallSpeakEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallSpeakStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallStreamingFailedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallStreamingStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallStreamingStoppedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CallUnholdWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        CampaignStatusUpdate value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceCreatedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceFloorChanged value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceParticipantJoinedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceParticipantLeftWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceParticipantPlaybackEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceParticipantPlaybackStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceParticipantSpeakEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceParticipantSpeakStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferencePlaybackEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferencePlaybackStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceRecordingSavedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceSpeakEndedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ConferenceSpeakStartedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        DeliveryUpdateWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        FaxDelivered value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        FaxFailed value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        FaxMediaProcessed value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        FaxQueued value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        FaxSendingStarted value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        HostedNumberOrderEventWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        InboundMessageWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        NumberOrderStatusUpdateWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        RecordingAvailableWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        ReplacedLinkClickWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        SessionStatusChangedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        TranscriptCompletedWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        TranscriptionWebhookEvent value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        WhatsappAccountUpdate value
    )=> new(value) ;

    public static implicit operator UnwrapWebhookEvent (
        WhatsappMessageEcho value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of UnwrapWebhookEvent");
        }
        this.Switch((callAIGatherEnded) => callAIGatherEnded.Validate(),
        (callAIGatherMessageHistoryUpdated) => callAIGatherMessageHistoryUpdated.Validate(),
        (callAIGatherPartialResults) => callAIGatherPartialResults.Validate(),
        (artifactCompleted) => artifactCompleted.Validate(),
        (artifactFailed) => artifactFailed.Validate(),
        (callAnswered) => callAnswered.Validate(),
        (callBridged) => callBridged.Validate(),
        (callConversationEnded) => callConversationEnded.Validate(),
        (callConversationInsightsGenerated) => callConversationInsightsGenerated.Validate(),
        (callCost) => callCost.Validate(),
        (callDeepfakeDetectionError) => callDeepfakeDetectionError.Validate(),
        (callDeepfakeDetectionResult) => callDeepfakeDetectionResult.Validate(),
        (callDtmfReceived) => callDtmfReceived.Validate(),
        (callEnqueued) => callEnqueued.Validate(),
        (callForkStarted) => callForkStarted.Validate(),
        (callForkStopped) => callForkStopped.Validate(),
        (callGatherEnded) => callGatherEnded.Validate(),
        (callHangup) => callHangup.Validate(),
        (callHold) => callHold.Validate(),
        (callInitiated) => callInitiated.Validate(),
        (callLeftQueue) => callLeftQueue.Validate(),
        (callMachineDetectionEnded) => callMachineDetectionEnded.Validate(),
        (callMachineGreetingEnded) => callMachineGreetingEnded.Validate(),
        (callMachinePremiumDetectionEnded) => callMachinePremiumDetectionEnded.Validate(),
        (callMachinePremiumGreetingEnded) => callMachinePremiumGreetingEnded.Validate(),
        (callPaymentCompleted) => callPaymentCompleted.Validate(),
        (callPaymentProgress) => callPaymentProgress.Validate(),
        (callPlaybackEnded) => callPlaybackEnded.Validate(),
        (callPlaybackStarted) => callPlaybackStarted.Validate(),
        (callRecordingError) => callRecordingError.Validate(),
        (callRecordingSaved) => callRecordingSaved.Validate(),
        (callRecordingTranscriptionSaved) => callRecordingTranscriptionSaved.Validate(),
        (callReferCompleted) => callReferCompleted.Validate(),
        (callReferFailed) => callReferFailed.Validate(),
        (callReferStarted) => callReferStarted.Validate(),
        (callSiprecFailed) => callSiprecFailed.Validate(),
        (callSiprecStarted) => callSiprecStarted.Validate(),
        (callSiprecStopped) => callSiprecStopped.Validate(),
        (callSpeakEnded) => callSpeakEnded.Validate(),
        (callSpeakStarted) => callSpeakStarted.Validate(),
        (callStreamingFailed) => callStreamingFailed.Validate(),
        (callStreamingStarted) => callStreamingStarted.Validate(),
        (callStreamingStopped) => callStreamingStopped.Validate(),
        (callUnhold) => callUnhold.Validate(),
        (campaignStatusUpdate) => campaignStatusUpdate.Validate(),
        (conferenceCreated) => conferenceCreated.Validate(),
        (conferenceEnded) => conferenceEnded.Validate(),
        (conferenceFloorChanged) => conferenceFloorChanged.Validate(),
        (conferenceParticipantJoined) => conferenceParticipantJoined.Validate(),
        (conferenceParticipantLeft) => conferenceParticipantLeft.Validate(),
        (conferenceParticipantPlaybackEnded) => conferenceParticipantPlaybackEnded.Validate(),
        (conferenceParticipantPlaybackStarted) => conferenceParticipantPlaybackStarted.Validate(),
        (conferenceParticipantSpeakEnded) => conferenceParticipantSpeakEnded.Validate(),
        (conferenceParticipantSpeakStarted) => conferenceParticipantSpeakStarted.Validate(),
        (conferencePlaybackEnded) => conferencePlaybackEnded.Validate(),
        (conferencePlaybackStarted) => conferencePlaybackStarted.Validate(),
        (conferenceRecordingSaved) => conferenceRecordingSaved.Validate(),
        (conferenceSpeakEnded) => conferenceSpeakEnded.Validate(),
        (conferenceSpeakStarted) => conferenceSpeakStarted.Validate(),
        (deliveryUpdate) => deliveryUpdate.Validate(),
        (faxDelivered) => faxDelivered.Validate(),
        (faxFailed) => faxFailed.Validate(),
        (faxMediaProcessed) => faxMediaProcessed.Validate(),
        (faxQueued) => faxQueued.Validate(),
        (faxSendingStarted) => faxSendingStarted.Validate(),
        (hostedNumberOrderEvent) => hostedNumberOrderEvent.Validate(),
        (inboundMessage) => inboundMessage.Validate(),
        (numberOrderStatusUpdate) => numberOrderStatusUpdate.Validate(),
        (recordingAvailable) => recordingAvailable.Validate(),
        (replacedLinkClick) => replacedLinkClick.Validate(),
        (sessionStatusChanged) => sessionStatusChanged.Validate(),
        (transcriptCompleted) => transcriptCompleted.Validate(),
        (transcription) => transcription.Validate(),
        (whatsappAccountUpdate) => whatsappAccountUpdate.Validate(),
        (whatsappMessageEcho) => whatsappMessageEcho.Validate());
    }

    public virtual bool Equals(UnwrapWebhookEvent? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            CallAIGatherEndedWebhookEvent _=>0,
            CallAIGatherMessageHistoryUpdatedWebhookEvent _=>1,
            CallAIGatherPartialResultsWebhookEvent _=>2,
            ArtifactCompletedWebhookEvent _=>3,
            ArtifactFailedWebhookEvent _=>4,
            CallAnsweredWebhookEvent _=>5,
            CallBridgedWebhookEvent _=>6,
            CallConversationEndedWebhookEvent _=>7,
            CallConversationInsightsGeneratedWebhookEvent _=>8,
            CallCostWebhookEvent _=>9,
            CallDeepfakeDetectionErrorWebhookEvent _=>10,
            CallDeepfakeDetectionResultWebhookEvent _=>11,
            CallDtmfReceivedWebhookEvent _=>12,
            CallEnqueuedWebhookEvent _=>13,
            CallForkStartedWebhookEvent _=>14,
            CallForkStoppedWebhookEvent _=>15,
            CallGatherEndedWebhookEvent _=>16,
            CallHangupWebhookEvent _=>17,
            CallHoldWebhookEvent _=>18,
            CallInitiatedWebhookEvent _=>19,
            CallLeftQueueWebhookEvent _=>20,
            CallMachineDetectionEndedWebhookEvent _=>21,
            CallMachineGreetingEndedWebhookEvent _=>22,
            CallMachinePremiumDetectionEndedWebhookEvent _=>23,
            CallMachinePremiumGreetingEndedWebhookEvent _=>24,
            CallPaymentCompletedWebhookEvent _=>25,
            CallPaymentProgressWebhookEvent _=>26,
            CallPlaybackEndedWebhookEvent _=>27,
            CallPlaybackStartedWebhookEvent _=>28,
            CallRecordingErrorWebhookEvent _=>29,
            CallRecordingSavedWebhookEvent _=>30,
            CallRecordingTranscriptionSavedWebhookEvent _=>31,
            CallReferCompletedWebhookEvent _=>32,
            CallReferFailedWebhookEvent _=>33,
            CallReferStartedWebhookEvent _=>34,
            CallSiprecFailedWebhookEvent _=>35,
            CallSiprecStartedWebhookEvent _=>36,
            CallSiprecStoppedWebhookEvent _=>37,
            CallSpeakEndedWebhookEvent _=>38,
            CallSpeakStartedWebhookEvent _=>39,
            CallStreamingFailedWebhookEvent _=>40,
            CallStreamingStartedWebhookEvent _=>41,
            CallStreamingStoppedWebhookEvent _=>42,
            CallUnholdWebhookEvent _=>43,
            CampaignStatusUpdate _=>44,
            ConferenceCreatedWebhookEvent _=>45,
            ConferenceEndedWebhookEvent _=>46,
            ConferenceFloorChanged _=>47,
            ConferenceParticipantJoinedWebhookEvent _=>48,
            ConferenceParticipantLeftWebhookEvent _=>49,
            ConferenceParticipantPlaybackEndedWebhookEvent _=>50,
            ConferenceParticipantPlaybackStartedWebhookEvent _=>51,
            ConferenceParticipantSpeakEndedWebhookEvent _=>52,
            ConferenceParticipantSpeakStartedWebhookEvent _=>53,
            ConferencePlaybackEndedWebhookEvent _=>54,
            ConferencePlaybackStartedWebhookEvent _=>55,
            ConferenceRecordingSavedWebhookEvent _=>56,
            ConferenceSpeakEndedWebhookEvent _=>57,
            ConferenceSpeakStartedWebhookEvent _=>58,
            DeliveryUpdateWebhookEvent _=>59,
            FaxDelivered _=>60,
            FaxFailed _=>61,
            FaxMediaProcessed _=>62,
            FaxQueued _=>63,
            FaxSendingStarted _=>64,
            HostedNumberOrderEventWebhookEvent _=>65,
            InboundMessageWebhookEvent _=>66,
            NumberOrderStatusUpdateWebhookEvent _=>67,
            RecordingAvailableWebhookEvent _=>68,
            ReplacedLinkClickWebhookEvent _=>69,
            SessionStatusChangedWebhookEvent _=>70,
            TranscriptCompletedWebhookEvent _=>71,
            TranscriptionWebhookEvent _=>72,
            WhatsappAccountUpdate _=>73,
            WhatsappMessageEcho _=>74,
            _ =>-1
        } ;
    }
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<WhatsappMessageEcho>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ArtifactCompletedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NumberOrderStatusUpdateWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SessionStatusChangedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<TranscriptCompletedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WhatsappAccountUpdate>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ArtifactFailedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RecordingAvailableWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallAIGatherEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallAIGatherMessageHistoryUpdatedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallAIGatherPartialResultsWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallAnsweredWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallBridgedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallConversationEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallConversationInsightsGeneratedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallCostWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallDeepfakeDetectionErrorWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallDeepfakeDetectionResultWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallDtmfReceivedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallEnqueuedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallForkStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallForkStoppedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallGatherEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallHangupWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallHoldWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallInitiatedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallLeftQueueWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallMachineDetectionEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallMachineGreetingEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallMachinePremiumDetectionEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallMachinePremiumGreetingEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallPaymentCompletedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallPaymentProgressWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallPlaybackEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallPlaybackStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallRecordingErrorWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallRecordingSavedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallRecordingTranscriptionSavedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallReferCompletedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallReferFailedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallReferStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallSiprecFailedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallSiprecStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallSiprecStoppedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallSpeakEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallSpeakStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallStreamingFailedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallStreamingStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallStreamingStoppedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CallUnholdWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CampaignStatusUpdate>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceCreatedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceFloorChanged>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceParticipantJoinedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceParticipantLeftWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceParticipantPlaybackEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceParticipantPlaybackStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceParticipantSpeakEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceParticipantSpeakStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferencePlaybackEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferencePlaybackStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceRecordingSavedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceSpeakEndedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ConferenceSpeakStartedWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DeliveryUpdateWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FaxDelivered>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FaxFailed>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FaxMediaProcessed>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FaxQueued>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FaxSendingStarted>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<HostedNumberOrderEventWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<InboundMessageWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ReplacedLinkClickWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<TranscriptionWebhookEvent>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}