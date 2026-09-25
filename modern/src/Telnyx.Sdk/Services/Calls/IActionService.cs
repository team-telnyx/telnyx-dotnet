using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Services.Calls;

/// <summary>
/// Call Control command operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Add messages to the conversation started by an AI assistant on the call.
/// </summary>
    Task<ActionAddAIAssistantMessagesResponse> AddAIAssistantMessages(
        ActionAddAIAssistantMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AddAIAssistantMessages(ActionAddAIAssistantMessagesParams, CancellationToken)"/>
    Task<ActionAddAIAssistantMessagesResponse> AddAIAssistantMessages(
        string callControlID,
        ActionAddAIAssistantMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Answer an incoming call. You must issue this command before executing subsequent
/// commands on an incoming call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.answered` - `call.hold` and `call.unhold` if the call is
/// held/unheld - `call.deepfake_detection.result` if `deepfake_detection` was
/// enabled - `call.deepfake_detection.error` if `deepfake_detection` was enabled
/// and an error occurred - `streaming.started`, `streaming.stopped` or
/// `streaming.failed` if `stream_url` was set</para>
/// 
/// <para>When the `record` parameter is set to `record-from-answer`, the response
/// will include a `recording_id` field. </para>
/// </summary>
    Task<ActionAnswerResponse> Answer(
        ActionAnswerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Answer(ActionAnswerParams, CancellationToken)"/>
    Task<ActionAnswerResponse> Answer(
        string callControlID,
        ActionAnswerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Bridge two call control calls.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.bridged` for Leg A - `call.bridged` for Leg B </para>
/// </summary>
    Task<ActionBridgeResponse> Bridge(
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Bridge(ActionBridgeParams, CancellationToken)"/>
    Task<ActionBridgeResponse> Bridge(
        string callControlIDToBridge,
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Places the call into a queue, where it waits until it is removed or bridged to
/// another leg. Queue behavior is configured through the request body.
/// </summary>
    Task<ActionEnqueueResponse> Enqueue(
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enqueue(ActionEnqueueParams, CancellationToken)"/>
    Task<ActionEnqueueResponse> Enqueue(
        string callControlID,
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Gather DTMF signals to build interactive menus.
/// 
/// <para>You can pass a list of valid digits. The `Answer` command must be issued
/// before the `gather` command.</para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.dtmf.received` (you may receive many of these webhooks) -
/// `call.gather.ended` </para>
/// </summary>
    Task<ActionGatherResponse> Gather(
        ActionGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Gather(ActionGatherParams, CancellationToken)"/>
    Task<ActionGatherResponse> Gather(
        string callControlID,
        ActionGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Gather parameters defined in the request payload using a voice assistant.
/// 
/// <para> You can pass parameters described as a JSON Schema object and the voice assistant
/// will attempt to gather these informations. </para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.ai_gather.ended` - `call.conversation.ended` -
/// `call.ai_gather.partial_results` (if `send_partial_results` is set to `true`) -
/// `call.ai_gather.message_history_updated` (if `send_message_history_updates` is
/// set to `true`) </para>
/// </summary>
    Task<ActionGatherUsingAIResponse> GatherUsingAI(
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherUsingAI(ActionGatherUsingAIParams, CancellationToken)"/>
    Task<ActionGatherUsingAIResponse> GatherUsingAI(
        string callControlID,
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Play an audio file on the call until the required DTMF signals are gathered to
/// build interactive menus.
/// 
/// <para>You can pass a list of valid digits along with an 'invalid_audio_url',
/// which will be played back at the beginning of each prompt. Playback will be
/// interrupted when a DTMF signal is received. The `Answer command must be issued
/// before the `gather_using_audio` command.</para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.playback.started` - `call.playback.ended` - `call.dtmf.received`
/// (you may receive many of these webhooks) - `call.gather.ended` </para>
/// </summary>
    Task<ActionGatherUsingAudioResponse> GatherUsingAudio(
        ActionGatherUsingAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherUsingAudio(ActionGatherUsingAudioParams, CancellationToken)"/>
    Task<ActionGatherUsingAudioResponse> GatherUsingAudio(
        string callControlID,
        ActionGatherUsingAudioParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Convert text to speech and play it on the call until the required DTMF signals
/// are gathered to build interactive menus.
/// 
/// <para>You can pass a list of valid digits along with an 'invalid_payload', which
/// will be played back at the beginning of each prompt. Speech will be interrupted
/// when a DTMF signal is received. The `Answer` command must be issued before the
/// `gather_using_speak` command.</para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.dtmf.received` (you may receive many of these webhooks) -
/// `call.gather.ended` </para>
/// </summary>
    Task<ActionGatherUsingSpeakResponse> GatherUsingSpeak(
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherUsingSpeak(ActionGatherUsingSpeakParams, CancellationToken)"/>
    Task<ActionGatherUsingSpeakResponse> GatherUsingSpeak(
        string callControlID,
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Hang up the call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.hangup` - `call.recording.saved` </para>
/// </summary>
    Task<ActionHangupResponse> Hangup(
        ActionHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Hangup(ActionHangupParams, CancellationToken)"/>
    Task<ActionHangupResponse> Hangup(
        string callControlID,
        ActionHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Add a participant to an existing AI assistant conversation. Use this command to
/// bring an additional call leg into a running AI conversation.
/// </summary>
    Task<ActionJoinAIAssistantResponse> JoinAIAssistant(
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="JoinAIAssistant(ActionJoinAIAssistantParams, CancellationToken)"/>
    Task<ActionJoinAIAssistantResponse> JoinAIAssistant(
        string callControlID,
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the call from the queue it is currently waiting in. The call remains
/// active and can be directed with further call commands.
/// </summary>
    Task<ActionLeaveQueueResponse> LeaveQueue(
        ActionLeaveQueueParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="LeaveQueue(ActionLeaveQueueParams, CancellationToken)"/>
    Task<ActionLeaveQueueResponse> LeaveQueue(
        string callControlID,
        ActionLeaveQueueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Pause recording the call. Recording can be resumed via Resume recording command.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>There are no webhooks associated with this command. </para>
/// </summary>
    Task<ActionPauseRecordingResponse> PauseRecording(
        ActionPauseRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PauseRecording(ActionPauseRecordingParams, CancellationToken)"/>
    Task<ActionPauseRecordingResponse> PauseRecording(
        string callControlID,
        ActionPauseRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Collect payment details from the caller using DTMF and either charge or tokenize
/// the payment method through a configured Pay connector. Pay pauses active call
/// recordings while sensitive payment details are collected.
/// 
/// <para>When `payment_token` is supplied, the DTMF collection steps are skipped
/// and the existing token is sent to the connector.</para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.payment.progress` - `call.payment.completed`</para>
/// 
/// <para>**Test mode card numbers:** `4111111111111111` (Visa), `5555555555554444`
/// (Mastercard), `378282246310005` (American Express), `6011111111111117`
/// (Discover), `3065930009020004` (Diners Club), `3566002020360505` (JCB),
/// `6200000000000005` (UnionPay), and `6771798021000008` (Maestro). Test-mode
/// connectors reject other card numbers before contacting the configured processor.
/// The UnionPay and Maestro numbers are accepted for processor testing, but Pay
/// currently does not emit a card type for them.</para>
/// </summary>
    Task<ActionPayResponse> Pay(
        ActionPayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Pay(ActionPayParams, CancellationToken)"/>
    Task<ActionPayResponse> Pay(
        string callControlID,
        ActionPayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Initiate a SIP Refer on a Call Control call. You can initiate a SIP Refer at any
/// point in the duration of a call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.refer.started` - `call.refer.completed` - `call.refer.failed` </para>
/// </summary>
    Task<ActionReferResponse> Refer(
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Refer(ActionReferParams, CancellationToken)"/>
    Task<ActionReferResponse> Refer(
        string callControlID,
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Reject an incoming call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.hangup` </para>
/// </summary>
    Task<ActionRejectResponse> Reject(
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Reject(ActionRejectParams, CancellationToken)"/>
    Task<ActionRejectResponse> Reject(
        string callControlID,
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Resume recording the call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>There are no webhooks associated with this command. </para>
/// </summary>
    Task<ActionResumeRecordingResponse> ResumeRecording(
        ActionResumeRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ResumeRecording(ActionResumeRecordingParams, CancellationToken)"/>
    Task<ActionResumeRecordingResponse> ResumeRecording(
        string callControlID,
        ActionResumeRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends DTMF tones from this leg. DTMF tones will be heard by the other end of the
/// call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>There are no webhooks associated with this command. </para>
/// </summary>
    Task<ActionSendDtmfResponse> SendDtmf(
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendDtmf(ActionSendDtmfParams, CancellationToken)"/>
    Task<ActionSendDtmfResponse> SendDtmf(
        string callControlID,
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends SIP info from this leg.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.sip_info.received` (to be received on the target call leg) </para>
/// </summary>
    Task<ActionSendSipInfoResponse> SendSipInfo(
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendSipInfo(ActionSendSipInfoParams, CancellationToken)"/>
    Task<ActionSendSipInfoResponse> SendSipInfo(
        string callControlID,
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Convert text to speech and play it back on the call. If multiple speak text
/// commands are issued consecutively, the audio files will be placed in a queue
/// awaiting playback.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.speak.started` - `call.speak.ended` </para>
/// </summary>
    Task<ActionSpeakResponse> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Speak(ActionSpeakParams, CancellationToken)"/>
    Task<ActionSpeakResponse> Speak(
        string callControlID,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start an AI assistant on the call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.conversation.ended` - `call.conversation_insights.generated` </para>
/// </summary>
    Task<ActionStartAIAssistantResponse> StartAIAssistant(
        ActionStartAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartAIAssistant(ActionStartAIAssistantParams, CancellationToken)"/>
    Task<ActionStartAIAssistantResponse> StartAIAssistant(
        string callControlID,
        ActionStartAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start a Conversation Relay session on an active call. Conversation Relay
/// connects the call audio to your WebSocket so your application can exchange
/// realtime messages with the caller while Telnyx handles speech recognition and
/// text-to-speech. Only one AI Assistant or Conversation Relay session can be
/// active on a call at a time.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.conversation.ended` - Sent when the Conversation Relay session
/// ends. If the customer WebSocket disconnects, the webhook payload `reason` is
/// `customer_disconnect`. </para>
/// </summary>
    Task<ActionStartConversationRelayResponse> StartConversationRelay(
        ActionStartConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartConversationRelay(ActionStartConversationRelayParams, CancellationToken)"/>
    Task<ActionStartConversationRelayResponse> StartConversationRelay(
        string callControlID,
        ActionStartConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Call forking allows you to stream the media from a call to a specific target in
/// realtime.  This stream can be used to enable realtime audio analysis to support a
/// 
/// variety of use cases, including fraud detection, or the creation of AI-generated
/// audio responses.  Requests must specify either the `target` attribute or the `rx`
/// and `tx` attributes.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.fork.started` - `call.fork.stopped`</para>
/// 
/// <para></para>
/// </summary>
    Task<ActionStartForkingResponse> StartForking(
        ActionStartForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartForking(ActionStartForkingParams, CancellationToken)"/>
    Task<ActionStartForkingResponse> StartForking(
        string callControlID,
        ActionStartForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start noise suppression on an active call to reduce background noise. This
/// feature is currently in beta.
/// </summary>
    Task<ActionStartNoiseSuppressionResponse> StartNoiseSuppression(
        ActionStartNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartNoiseSuppression(ActionStartNoiseSuppressionParams, CancellationToken)"/>
    Task<ActionStartNoiseSuppressionResponse> StartNoiseSuppression(
        string callControlID,
        ActionStartNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Play an audio file on the call. If multiple play audio commands are issued
/// consecutively, the audio files will be placed in a queue awaiting playback.
/// 
/// <para>*Notes:*</para>
/// 
/// <para>- When `overlay` is enabled, `target_legs` is limited to `self`. - A
/// customer cannot Play Audio with `overlay=true` unless there is a Play Audio with
/// `overlay=false` actively playing.</para>
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.playback.started` - `call.playback.ended` </para>
/// </summary>
    Task<ActionStartPlaybackResponse> StartPlayback(
        ActionStartPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartPlayback(ActionStartPlaybackParams, CancellationToken)"/>
    Task<ActionStartPlaybackResponse> StartPlayback(
        string callControlID,
        ActionStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start recording the call. Recording will stop on call hang-up, or can be
/// initiated via the Stop Recording command.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.recording.saved` - `call.recording.transcription.saved` -
/// `call.recording.error` </para>
/// </summary>
    Task<ActionStartRecordingResponse> StartRecording(
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartRecording(ActionStartRecordingParams, CancellationToken)"/>
    Task<ActionStartRecordingResponse> StartRecording(
        string callControlID,
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start siprec session to configured in SIPREC connector SRS.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `siprec.started` - `siprec.stopped` - `siprec.failed` </para>
/// </summary>
    Task<ActionStartSiprecResponse> StartSiprec(
        ActionStartSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartSiprec(ActionStartSiprecParams, CancellationToken)"/>
    Task<ActionStartSiprecResponse> StartSiprec(
        string callControlID,
        ActionStartSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start streaming the media from a call to a specific WebSocket address or
/// Dialogflow connection in near-realtime. Audio will be delivered as
/// base64-encoded RTP payload (raw audio), wrapped in JSON payloads.
/// 
/// <para>Please find more details about media streaming messages specification
/// under the
/// [link](https://developers.telnyx.com/docs/voice/programmable-voice/media-streaming).</para>
/// </summary>
    Task<ActionStartStreamingResponse> StartStreaming(
        ActionStartStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartStreaming(ActionStartStreamingParams, CancellationToken)"/>
    Task<ActionStartStreamingResponse> StartStreaming(
        string callControlID,
        ActionStartStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start real-time transcription. Transcription will stop on call hang-up, or can
/// be initiated via the Transcription stop command.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.transcription` </para>
/// </summary>
    Task<ActionStartTranscriptionResponse> StartTranscription(
        ActionStartTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartTranscription(ActionStartTranscriptionParams, CancellationToken)"/>
    Task<ActionStartTranscriptionResponse> StartTranscription(
        string callControlID,
        ActionStartTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stops the AI assistant currently engaged on the call. The call remains active
/// and can continue with other call control commands.
/// </summary>
    Task<ActionStopAIAssistantResponse> StopAIAssistant(
        ActionStopAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopAIAssistant(ActionStopAIAssistantParams, CancellationToken)"/>
    Task<ActionStopAIAssistantResponse> StopAIAssistant(
        string callControlID,
        ActionStopAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop the active Conversation Relay session on a call.
/// </summary>
    Task<ActionStopConversationRelayResponse> StopConversationRelay(
        ActionStopConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopConversationRelay(ActionStopConversationRelayParams, CancellationToken)"/>
    Task<ActionStopConversationRelayResponse> StopConversationRelay(
        string callControlID,
        ActionStopConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop forking a call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.fork.stopped` </para>
/// </summary>
    Task<ActionStopForkingResponse> StopForking(
        ActionStopForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopForking(ActionStopForkingParams, CancellationToken)"/>
    Task<ActionStopForkingResponse> StopForking(
        string callControlID,
        ActionStopForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop current gather.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.gather.ended` </para>
/// </summary>
    Task<ActionStopGatherResponse> StopGather(
        ActionStopGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopGather(ActionStopGatherParams, CancellationToken)"/>
    Task<ActionStopGatherResponse> StopGather(
        string callControlID,
        ActionStopGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop noise suppression previously started on an active call. This feature is
/// currently in beta.
/// </summary>
    Task<ActionStopNoiseSuppressionResponse> StopNoiseSuppression(
        ActionStopNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopNoiseSuppression(ActionStopNoiseSuppressionParams, CancellationToken)"/>
    Task<ActionStopNoiseSuppressionResponse> StopNoiseSuppression(
        string callControlID,
        ActionStopNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop audio being played on the call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.playback.ended` or `call.speak.ended` </para>
/// </summary>
    Task<ActionStopPlaybackResponse> StopPlayback(
        ActionStopPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopPlayback(ActionStopPlaybackParams, CancellationToken)"/>
    Task<ActionStopPlaybackResponse> StopPlayback(
        string callControlID,
        ActionStopPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop recording the call.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.recording.saved` </para>
/// </summary>
    Task<ActionStopRecordingResponse> StopRecording(
        ActionStopRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopRecording(ActionStopRecordingParams, CancellationToken)"/>
    Task<ActionStopRecordingResponse> StopRecording(
        string callControlID,
        ActionStopRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop SIPREC session.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `siprec.stopped` </para>
/// </summary>
    Task<ActionStopSiprecResponse> StopSiprec(
        ActionStopSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopSiprec(ActionStopSiprecParams, CancellationToken)"/>
    Task<ActionStopSiprecResponse> StopSiprec(
        string callControlID,
        ActionStopSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop streaming a call to a WebSocket.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `streaming.stopped` </para>
/// </summary>
    Task<ActionStopStreamingResponse> StopStreaming(
        ActionStopStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopStreaming(ActionStopStreamingParams, CancellationToken)"/>
    Task<ActionStopStreamingResponse> StopStreaming(
        string callControlID,
        ActionStopStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stops real-time transcription on the call. Transcription webhooks cease once the
/// command takes effect; the call itself is unaffected.
/// </summary>
    Task<ActionStopTranscriptionResponse> StopTranscription(
        ActionStopTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopTranscription(ActionStopTranscriptionParams, CancellationToken)"/>
    Task<ActionStopTranscriptionResponse> StopTranscription(
        string callControlID,
        ActionStopTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Switch the supervisor role for a bridged call. This allows switching between
/// different supervisor modes during an active call
/// </summary>
    Task<ActionSwitchSupervisorRoleResponse> SwitchSupervisorRole(
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SwitchSupervisorRole(ActionSwitchSupervisorRoleParams, CancellationToken)"/>
    Task<ActionSwitchSupervisorRoleResponse> SwitchSupervisorRole(
        string callControlID,
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Transfer a call to a new destination. If the transfer is unsuccessful, a
/// `call.hangup` webhook for the other call (Leg B) will be sent indicating that
/// the transfer could not be completed. The original call will remain active and
/// may be issued additional commands, potentially transfering the call to an
/// alternate destination.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.initiated` - `call.bridged` to Leg B - `call.answered` or
/// `call.hangup` - `call.machine.detection.ended` if `answering_machine_detection`
/// was requested - `call.machine.greeting.ended` if `answering_machine_detection`
/// was requested to detect the end of machine greeting -
/// `call.machine.premium.detection.ended` if `answering_machine_detection=premium`
/// was requested - `call.machine.premium.greeting.ended` if
/// `answering_machine_detection=premium` was requested and a beep was detected </para>
/// </summary>
    Task<ActionTransferResponse> Transfer(
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Transfer(ActionTransferParams, CancellationToken)"/>
    Task<ActionTransferResponse> Transfer(
        string callControlID,
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the client state associated with the call. Client state is an opaque
/// value echoed back in subsequent webhooks for the call, letting you correlate
/// events with your application's state.
/// </summary>
    Task<ActionUpdateClientStateResponse> UpdateClientState(
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateClientState(ActionUpdateClientStateParams, CancellationToken)"/>
    Task<ActionUpdateClientStateResponse> UpdateClientState(
        string callControlID,
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/ai_assistant_add_messages</c>, but is otherwise the
/// same as <see cref="IActionService.AddAIAssistantMessages(ActionAddAIAssistantMessagesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionAddAIAssistantMessagesResponse>> AddAIAssistantMessages(
        ActionAddAIAssistantMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AddAIAssistantMessages(ActionAddAIAssistantMessagesParams, CancellationToken)"/>
    Task<HttpResponse<ActionAddAIAssistantMessagesResponse>> AddAIAssistantMessages(
        string callControlID,
        ActionAddAIAssistantMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/answer</c>, but is otherwise the
/// same as <see cref="IActionService.Answer(ActionAnswerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionAnswerResponse>> Answer(
        ActionAnswerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Answer(ActionAnswerParams, CancellationToken)"/>
    Task<HttpResponse<ActionAnswerResponse>> Answer(
        string callControlID,
        ActionAnswerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/bridge</c>, but is otherwise the
/// same as <see cref="IActionService.Bridge(ActionBridgeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionBridgeResponse>> Bridge(
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Bridge(ActionBridgeParams, CancellationToken)"/>
    Task<HttpResponse<ActionBridgeResponse>> Bridge(
        string callControlIDToBridge,
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/enqueue</c>, but is otherwise the
/// same as <see cref="IActionService.Enqueue(ActionEnqueueParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEnqueueResponse>> Enqueue(
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enqueue(ActionEnqueueParams, CancellationToken)"/>
    Task<HttpResponse<ActionEnqueueResponse>> Enqueue(
        string callControlID,
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/gather</c>, but is otherwise the
/// same as <see cref="IActionService.Gather(ActionGatherParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionGatherResponse>> Gather(
        ActionGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Gather(ActionGatherParams, CancellationToken)"/>
    Task<HttpResponse<ActionGatherResponse>> Gather(
        string callControlID,
        ActionGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/gather_using_ai</c>, but is otherwise the
/// same as <see cref="IActionService.GatherUsingAI(ActionGatherUsingAIParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionGatherUsingAIResponse>> GatherUsingAI(
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherUsingAI(ActionGatherUsingAIParams, CancellationToken)"/>
    Task<HttpResponse<ActionGatherUsingAIResponse>> GatherUsingAI(
        string callControlID,
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/gather_using_audio</c>, but is otherwise the
/// same as <see cref="IActionService.GatherUsingAudio(ActionGatherUsingAudioParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionGatherUsingAudioResponse>> GatherUsingAudio(
        ActionGatherUsingAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherUsingAudio(ActionGatherUsingAudioParams, CancellationToken)"/>
    Task<HttpResponse<ActionGatherUsingAudioResponse>> GatherUsingAudio(
        string callControlID,
        ActionGatherUsingAudioParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/gather_using_speak</c>, but is otherwise the
/// same as <see cref="IActionService.GatherUsingSpeak(ActionGatherUsingSpeakParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionGatherUsingSpeakResponse>> GatherUsingSpeak(
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherUsingSpeak(ActionGatherUsingSpeakParams, CancellationToken)"/>
    Task<HttpResponse<ActionGatherUsingSpeakResponse>> GatherUsingSpeak(
        string callControlID,
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/hangup</c>, but is otherwise the
/// same as <see cref="IActionService.Hangup(ActionHangupParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionHangupResponse>> Hangup(
        ActionHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Hangup(ActionHangupParams, CancellationToken)"/>
    Task<HttpResponse<ActionHangupResponse>> Hangup(
        string callControlID,
        ActionHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/ai_assistant_join</c>, but is otherwise the
/// same as <see cref="IActionService.JoinAIAssistant(ActionJoinAIAssistantParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionJoinAIAssistantResponse>> JoinAIAssistant(
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="JoinAIAssistant(ActionJoinAIAssistantParams, CancellationToken)"/>
    Task<HttpResponse<ActionJoinAIAssistantResponse>> JoinAIAssistant(
        string callControlID,
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/leave_queue</c>, but is otherwise the
/// same as <see cref="IActionService.LeaveQueue(ActionLeaveQueueParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionLeaveQueueResponse>> LeaveQueue(
        ActionLeaveQueueParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="LeaveQueue(ActionLeaveQueueParams, CancellationToken)"/>
    Task<HttpResponse<ActionLeaveQueueResponse>> LeaveQueue(
        string callControlID,
        ActionLeaveQueueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/record_pause</c>, but is otherwise the
/// same as <see cref="IActionService.PauseRecording(ActionPauseRecordingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionPauseRecordingResponse>> PauseRecording(
        ActionPauseRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PauseRecording(ActionPauseRecordingParams, CancellationToken)"/>
    Task<HttpResponse<ActionPauseRecordingResponse>> PauseRecording(
        string callControlID,
        ActionPauseRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/pay</c>, but is otherwise the
/// same as <see cref="IActionService.Pay(ActionPayParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionPayResponse>> Pay(
        ActionPayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Pay(ActionPayParams, CancellationToken)"/>
    Task<HttpResponse<ActionPayResponse>> Pay(
        string callControlID,
        ActionPayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/refer</c>, but is otherwise the
/// same as <see cref="IActionService.Refer(ActionReferParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionReferResponse>> Refer(
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Refer(ActionReferParams, CancellationToken)"/>
    Task<HttpResponse<ActionReferResponse>> Refer(
        string callControlID,
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/reject</c>, but is otherwise the
/// same as <see cref="IActionService.Reject(ActionRejectParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRejectResponse>> Reject(
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Reject(ActionRejectParams, CancellationToken)"/>
    Task<HttpResponse<ActionRejectResponse>> Reject(
        string callControlID,
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/record_resume</c>, but is otherwise the
/// same as <see cref="IActionService.ResumeRecording(ActionResumeRecordingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionResumeRecordingResponse>> ResumeRecording(
        ActionResumeRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ResumeRecording(ActionResumeRecordingParams, CancellationToken)"/>
    Task<HttpResponse<ActionResumeRecordingResponse>> ResumeRecording(
        string callControlID,
        ActionResumeRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/send_dtmf</c>, but is otherwise the
/// same as <see cref="IActionService.SendDtmf(ActionSendDtmfParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSendDtmfResponse>> SendDtmf(
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendDtmf(ActionSendDtmfParams, CancellationToken)"/>
    Task<HttpResponse<ActionSendDtmfResponse>> SendDtmf(
        string callControlID,
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/send_sip_info</c>, but is otherwise the
/// same as <see cref="IActionService.SendSipInfo(ActionSendSipInfoParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSendSipInfoResponse>> SendSipInfo(
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendSipInfo(ActionSendSipInfoParams, CancellationToken)"/>
    Task<HttpResponse<ActionSendSipInfoResponse>> SendSipInfo(
        string callControlID,
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/speak</c>, but is otherwise the
/// same as <see cref="IActionService.Speak(ActionSpeakParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSpeakResponse>> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Speak(ActionSpeakParams, CancellationToken)"/>
    Task<HttpResponse<ActionSpeakResponse>> Speak(
        string callControlID,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/ai_assistant_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartAIAssistant(ActionStartAIAssistantParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartAIAssistantResponse>> StartAIAssistant(
        ActionStartAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartAIAssistant(ActionStartAIAssistantParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartAIAssistantResponse>> StartAIAssistant(
        string callControlID,
        ActionStartAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/conversation_relay_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartConversationRelay(ActionStartConversationRelayParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartConversationRelayResponse>> StartConversationRelay(
        ActionStartConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartConversationRelay(ActionStartConversationRelayParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartConversationRelayResponse>> StartConversationRelay(
        string callControlID,
        ActionStartConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/fork_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartForking(ActionStartForkingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartForkingResponse>> StartForking(
        ActionStartForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartForking(ActionStartForkingParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartForkingResponse>> StartForking(
        string callControlID,
        ActionStartForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/suppression_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartNoiseSuppression(ActionStartNoiseSuppressionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartNoiseSuppressionResponse>> StartNoiseSuppression(
        ActionStartNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartNoiseSuppression(ActionStartNoiseSuppressionParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartNoiseSuppressionResponse>> StartNoiseSuppression(
        string callControlID,
        ActionStartNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/playback_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartPlayback(ActionStartPlaybackParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartPlaybackResponse>> StartPlayback(
        ActionStartPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartPlayback(ActionStartPlaybackParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartPlaybackResponse>> StartPlayback(
        string callControlID,
        ActionStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/record_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartRecording(ActionStartRecordingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartRecordingResponse>> StartRecording(
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartRecording(ActionStartRecordingParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartRecordingResponse>> StartRecording(
        string callControlID,
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/siprec_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartSiprec(ActionStartSiprecParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartSiprecResponse>> StartSiprec(
        ActionStartSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartSiprec(ActionStartSiprecParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartSiprecResponse>> StartSiprec(
        string callControlID,
        ActionStartSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/streaming_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartStreaming(ActionStartStreamingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartStreamingResponse>> StartStreaming(
        ActionStartStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartStreaming(ActionStartStreamingParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartStreamingResponse>> StartStreaming(
        string callControlID,
        ActionStartStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/transcription_start</c>, but is otherwise the
/// same as <see cref="IActionService.StartTranscription(ActionStartTranscriptionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStartTranscriptionResponse>> StartTranscription(
        ActionStartTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StartTranscription(ActionStartTranscriptionParams, CancellationToken)"/>
    Task<HttpResponse<ActionStartTranscriptionResponse>> StartTranscription(
        string callControlID,
        ActionStartTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/ai_assistant_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopAIAssistant(ActionStopAIAssistantParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopAIAssistantResponse>> StopAIAssistant(
        ActionStopAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopAIAssistant(ActionStopAIAssistantParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopAIAssistantResponse>> StopAIAssistant(
        string callControlID,
        ActionStopAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/conversation_relay_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopConversationRelay(ActionStopConversationRelayParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopConversationRelayResponse>> StopConversationRelay(
        ActionStopConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopConversationRelay(ActionStopConversationRelayParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopConversationRelayResponse>> StopConversationRelay(
        string callControlID,
        ActionStopConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/fork_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopForking(ActionStopForkingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopForkingResponse>> StopForking(
        ActionStopForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopForking(ActionStopForkingParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopForkingResponse>> StopForking(
        string callControlID,
        ActionStopForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/gather_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopGather(ActionStopGatherParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopGatherResponse>> StopGather(
        ActionStopGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopGather(ActionStopGatherParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopGatherResponse>> StopGather(
        string callControlID,
        ActionStopGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/suppression_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopNoiseSuppression(ActionStopNoiseSuppressionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopNoiseSuppressionResponse>> StopNoiseSuppression(
        ActionStopNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopNoiseSuppression(ActionStopNoiseSuppressionParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopNoiseSuppressionResponse>> StopNoiseSuppression(
        string callControlID,
        ActionStopNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/playback_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopPlayback(ActionStopPlaybackParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopPlaybackResponse>> StopPlayback(
        ActionStopPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopPlayback(ActionStopPlaybackParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopPlaybackResponse>> StopPlayback(
        string callControlID,
        ActionStopPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/record_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopRecording(ActionStopRecordingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopRecordingResponse>> StopRecording(
        ActionStopRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopRecording(ActionStopRecordingParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopRecordingResponse>> StopRecording(
        string callControlID,
        ActionStopRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/siprec_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopSiprec(ActionStopSiprecParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopSiprecResponse>> StopSiprec(
        ActionStopSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopSiprec(ActionStopSiprecParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopSiprecResponse>> StopSiprec(
        string callControlID,
        ActionStopSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/streaming_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopStreaming(ActionStopStreamingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopStreamingResponse>> StopStreaming(
        ActionStopStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopStreaming(ActionStopStreamingParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopStreamingResponse>> StopStreaming(
        string callControlID,
        ActionStopStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/transcription_stop</c>, but is otherwise the
/// same as <see cref="IActionService.StopTranscription(ActionStopTranscriptionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopTranscriptionResponse>> StopTranscription(
        ActionStopTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopTranscription(ActionStopTranscriptionParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopTranscriptionResponse>> StopTranscription(
        string callControlID,
        ActionStopTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/switch_supervisor_role</c>, but is otherwise the
/// same as <see cref="IActionService.SwitchSupervisorRole(ActionSwitchSupervisorRoleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSwitchSupervisorRoleResponse>> SwitchSupervisorRole(
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SwitchSupervisorRole(ActionSwitchSupervisorRoleParams, CancellationToken)"/>
    Task<HttpResponse<ActionSwitchSupervisorRoleResponse>> SwitchSupervisorRole(
        string callControlID,
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls/{call_control_id}/actions/transfer</c>, but is otherwise the
/// same as <see cref="IActionService.Transfer(ActionTransferParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionTransferResponse>> Transfer(
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Transfer(ActionTransferParams, CancellationToken)"/>
    Task<HttpResponse<ActionTransferResponse>> Transfer(
        string callControlID,
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /calls/{call_control_id}/actions/client_state_update</c>, but is otherwise the
/// same as <see cref="IActionService.UpdateClientState(ActionUpdateClientStateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionUpdateClientStateResponse>> UpdateClientState(
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateClientState(ActionUpdateClientStateParams, CancellationToken)"/>
    Task<HttpResponse<ActionUpdateClientStateResponse>> UpdateClientState(
        string callControlID,
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}