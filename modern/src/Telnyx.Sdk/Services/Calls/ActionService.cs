using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Services.Calls;

/// <inheritdoc/>
public sealed class ActionService : IActionService
{
    readonly Lazy<IActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IActionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ActionService(this._client.WithOptions(modifier)); }

    public ActionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ActionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ActionAddAIAssistantMessagesResponse> AddAIAssistantMessages(
        ActionAddAIAssistantMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.AddAIAssistantMessages(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionAddAIAssistantMessagesResponse> AddAIAssistantMessages(
        string callControlID,
        ActionAddAIAssistantMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.AddAIAssistantMessages(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionAnswerResponse> Answer(
        ActionAnswerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Answer(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionAnswerResponse> Answer(
        string callControlID,
        ActionAnswerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Answer(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionBridgeResponse> Bridge(
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Bridge(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionBridgeResponse> Bridge(
        string callControlIDToBridge,
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Bridge(parameters with{
            CallControlIDToBridge = callControlIDToBridge
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionEnqueueResponse> Enqueue(
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Enqueue(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionEnqueueResponse> Enqueue(
        string callControlID,
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Enqueue(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionGatherResponse> Gather(
        ActionGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Gather(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionGatherResponse> Gather(
        string callControlID,
        ActionGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Gather(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionGatherUsingAIResponse> GatherUsingAI(
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GatherUsingAI(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionGatherUsingAIResponse> GatherUsingAI(
        string callControlID,
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GatherUsingAI(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionGatherUsingAudioResponse> GatherUsingAudio(
        ActionGatherUsingAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GatherUsingAudio(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionGatherUsingAudioResponse> GatherUsingAudio(
        string callControlID,
        ActionGatherUsingAudioParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GatherUsingAudio(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionGatherUsingSpeakResponse> GatherUsingSpeak(
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GatherUsingSpeak(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionGatherUsingSpeakResponse> GatherUsingSpeak(
        string callControlID,
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GatherUsingSpeak(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionHangupResponse> Hangup(
        ActionHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Hangup(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionHangupResponse> Hangup(
        string callControlID,
        ActionHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hangup(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionJoinAIAssistantResponse> JoinAIAssistant(
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.JoinAIAssistant(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionJoinAIAssistantResponse> JoinAIAssistant(
        string callControlID,
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.JoinAIAssistant(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionLeaveQueueResponse> LeaveQueue(
        ActionLeaveQueueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.LeaveQueue(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionLeaveQueueResponse> LeaveQueue(
        string callControlID,
        ActionLeaveQueueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.LeaveQueue(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionPauseRecordingResponse> PauseRecording(
        ActionPauseRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PauseRecording(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionPauseRecordingResponse> PauseRecording(
        string callControlID,
        ActionPauseRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PauseRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionPayResponse> Pay(
        ActionPayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Pay(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionPayResponse> Pay(
        string callControlID,
        ActionPayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pay(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionReferResponse> Refer(
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Refer(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionReferResponse> Refer(
        string callControlID,
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Refer(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionRejectResponse> Reject(
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Reject(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionRejectResponse> Reject(
        string callControlID,
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reject(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionResumeRecordingResponse> ResumeRecording(
        ActionResumeRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ResumeRecording(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionResumeRecordingResponse> ResumeRecording(
        string callControlID,
        ActionResumeRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ResumeRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionSendDtmfResponse> SendDtmf(
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendDtmf(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionSendDtmfResponse> SendDtmf(
        string callControlID,
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendDtmf(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionSendSipInfoResponse> SendSipInfo(
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendSipInfo(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionSendSipInfoResponse> SendSipInfo(
        string callControlID,
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendSipInfo(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionSpeakResponse> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Speak(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionSpeakResponse> Speak(
        string callControlID,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Speak(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartAIAssistantResponse> StartAIAssistant(
        ActionStartAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartAIAssistant(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartAIAssistantResponse> StartAIAssistant(
        string callControlID,
        ActionStartAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartAIAssistant(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartConversationRelayResponse> StartConversationRelay(
        ActionStartConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartConversationRelay(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartConversationRelayResponse> StartConversationRelay(
        string callControlID,
        ActionStartConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartConversationRelay(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartForkingResponse> StartForking(
        ActionStartForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartForking(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartForkingResponse> StartForking(
        string callControlID,
        ActionStartForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartForking(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartNoiseSuppressionResponse> StartNoiseSuppression(
        ActionStartNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartNoiseSuppression(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartNoiseSuppressionResponse> StartNoiseSuppression(
        string callControlID,
        ActionStartNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartNoiseSuppression(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartPlaybackResponse> StartPlayback(
        ActionStartPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartPlayback(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartPlaybackResponse> StartPlayback(
        string callControlID,
        ActionStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartPlayback(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartRecordingResponse> StartRecording(
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartRecording(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartRecordingResponse> StartRecording(
        string callControlID,
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StartRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartSiprecResponse> StartSiprec(
        ActionStartSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartSiprec(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartSiprecResponse> StartSiprec(
        string callControlID,
        ActionStartSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartSiprec(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartStreamingResponse> StartStreaming(
        ActionStartStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartStreaming(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartStreamingResponse> StartStreaming(
        string callControlID,
        ActionStartStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartStreaming(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStartTranscriptionResponse> StartTranscription(
        ActionStartTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StartTranscription(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStartTranscriptionResponse> StartTranscription(
        string callControlID,
        ActionStartTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartTranscription(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopAIAssistantResponse> StopAIAssistant(
        ActionStopAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopAIAssistant(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopAIAssistantResponse> StopAIAssistant(
        string callControlID,
        ActionStopAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopAIAssistant(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopConversationRelayResponse> StopConversationRelay(
        ActionStopConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopConversationRelay(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopConversationRelayResponse> StopConversationRelay(
        string callControlID,
        ActionStopConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopConversationRelay(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopForkingResponse> StopForking(
        ActionStopForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopForking(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopForkingResponse> StopForking(
        string callControlID,
        ActionStopForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopForking(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopGatherResponse> StopGather(
        ActionStopGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopGather(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopGatherResponse> StopGather(
        string callControlID,
        ActionStopGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopGather(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopNoiseSuppressionResponse> StopNoiseSuppression(
        ActionStopNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopNoiseSuppression(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopNoiseSuppressionResponse> StopNoiseSuppression(
        string callControlID,
        ActionStopNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopNoiseSuppression(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopPlaybackResponse> StopPlayback(
        ActionStopPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopPlayback(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopPlaybackResponse> StopPlayback(
        string callControlID,
        ActionStopPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopPlayback(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopRecordingResponse> StopRecording(
        ActionStopRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopRecording(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopRecordingResponse> StopRecording(
        string callControlID,
        ActionStopRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopSiprecResponse> StopSiprec(
        ActionStopSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopSiprec(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopSiprecResponse> StopSiprec(
        string callControlID,
        ActionStopSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopSiprec(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopStreamingResponse> StopStreaming(
        ActionStopStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopStreaming(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopStreamingResponse> StopStreaming(
        string callControlID,
        ActionStopStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopStreaming(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionStopTranscriptionResponse> StopTranscription(
        ActionStopTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopTranscription(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionStopTranscriptionResponse> StopTranscription(
        string callControlID,
        ActionStopTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopTranscription(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionSwitchSupervisorRoleResponse> SwitchSupervisorRole(
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SwitchSupervisorRole(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionSwitchSupervisorRoleResponse> SwitchSupervisorRole(
        string callControlID,
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SwitchSupervisorRole(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionTransferResponse> Transfer(
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Transfer(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionTransferResponse> Transfer(
        string callControlID,
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Transfer(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionUpdateClientStateResponse> UpdateClientState(
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateClientState(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionUpdateClientStateResponse> UpdateClientState(
        string callControlID,
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateClientState(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ActionServiceWithRawResponse : IActionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionAddAIAssistantMessagesResponse>> AddAIAssistantMessages(
        ActionAddAIAssistantMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionAddAIAssistantMessagesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionAddAIAssistantMessagesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionAddAIAssistantMessagesResponse>> AddAIAssistantMessages(
        string callControlID,
        ActionAddAIAssistantMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.AddAIAssistantMessages(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionAnswerResponse>> Answer(
        ActionAnswerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionAnswerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionAnswerResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionAnswerResponse>> Answer(
        string callControlID,
        ActionAnswerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Answer(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionBridgeResponse>> Bridge(
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlIDToBridge == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlIDToBridge' cannot be null"
            );
        }

        HttpRequest<ActionBridgeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionBridgeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionBridgeResponse>> Bridge(
        string callControlIDToBridge,
        ActionBridgeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Bridge(parameters with{
            CallControlIDToBridge = callControlIDToBridge
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionEnqueueResponse>> Enqueue(
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionEnqueueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionEnqueueResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionEnqueueResponse>> Enqueue(
        string callControlID,
        ActionEnqueueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Enqueue(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionGatherResponse>> Gather(
        ActionGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionGatherParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionGatherResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionGatherResponse>> Gather(
        string callControlID,
        ActionGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Gather(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionGatherUsingAIResponse>> GatherUsingAI(
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionGatherUsingAIParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionGatherUsingAIResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionGatherUsingAIResponse>> GatherUsingAI(
        string callControlID,
        ActionGatherUsingAIParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GatherUsingAI(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionGatherUsingAudioResponse>> GatherUsingAudio(
        ActionGatherUsingAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionGatherUsingAudioParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionGatherUsingAudioResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionGatherUsingAudioResponse>> GatherUsingAudio(
        string callControlID,
        ActionGatherUsingAudioParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GatherUsingAudio(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionGatherUsingSpeakResponse>> GatherUsingSpeak(
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionGatherUsingSpeakParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionGatherUsingSpeakResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionGatherUsingSpeakResponse>> GatherUsingSpeak(
        string callControlID,
        ActionGatherUsingSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GatherUsingSpeak(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionHangupResponse>> Hangup(
        ActionHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionHangupParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionHangupResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionHangupResponse>> Hangup(
        string callControlID,
        ActionHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hangup(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionJoinAIAssistantResponse>> JoinAIAssistant(
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionJoinAIAssistantParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionJoinAIAssistantResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionJoinAIAssistantResponse>> JoinAIAssistant(
        string callControlID,
        ActionJoinAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.JoinAIAssistant(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionLeaveQueueResponse>> LeaveQueue(
        ActionLeaveQueueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionLeaveQueueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionLeaveQueueResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionLeaveQueueResponse>> LeaveQueue(
        string callControlID,
        ActionLeaveQueueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.LeaveQueue(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionPauseRecordingResponse>> PauseRecording(
        ActionPauseRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionPauseRecordingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionPauseRecordingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionPauseRecordingResponse>> PauseRecording(
        string callControlID,
        ActionPauseRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PauseRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionPayResponse>> Pay(
        ActionPayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionPayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionPayResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionPayResponse>> Pay(
        string callControlID,
        ActionPayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pay(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionReferResponse>> Refer(
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionReferParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionReferResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionReferResponse>> Refer(
        string callControlID,
        ActionReferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Refer(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionRejectResponse>> Reject(
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionRejectParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionRejectResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionRejectResponse>> Reject(
        string callControlID,
        ActionRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reject(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionResumeRecordingResponse>> ResumeRecording(
        ActionResumeRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionResumeRecordingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionResumeRecordingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionResumeRecordingResponse>> ResumeRecording(
        string callControlID,
        ActionResumeRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ResumeRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionSendDtmfResponse>> SendDtmf(
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionSendDtmfParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionSendDtmfResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionSendDtmfResponse>> SendDtmf(
        string callControlID,
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendDtmf(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionSendSipInfoResponse>> SendSipInfo(
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionSendSipInfoParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionSendSipInfoResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionSendSipInfoResponse>> SendSipInfo(
        string callControlID,
        ActionSendSipInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendSipInfo(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionSpeakResponse>> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionSpeakParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionSpeakResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionSpeakResponse>> Speak(
        string callControlID,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Speak(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartAIAssistantResponse>> StartAIAssistant(
        ActionStartAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartAIAssistantParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartAIAssistantResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartAIAssistantResponse>> StartAIAssistant(
        string callControlID,
        ActionStartAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartAIAssistant(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartConversationRelayResponse>> StartConversationRelay(
        ActionStartConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartConversationRelayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartConversationRelayResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartConversationRelayResponse>> StartConversationRelay(
        string callControlID,
        ActionStartConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartConversationRelay(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartForkingResponse>> StartForking(
        ActionStartForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartForkingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartForkingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartForkingResponse>> StartForking(
        string callControlID,
        ActionStartForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartForking(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartNoiseSuppressionResponse>> StartNoiseSuppression(
        ActionStartNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartNoiseSuppressionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartNoiseSuppressionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartNoiseSuppressionResponse>> StartNoiseSuppression(
        string callControlID,
        ActionStartNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartNoiseSuppression(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartPlaybackResponse>> StartPlayback(
        ActionStartPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartPlaybackParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartPlaybackResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartPlaybackResponse>> StartPlayback(
        string callControlID,
        ActionStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartPlayback(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartRecordingResponse>> StartRecording(
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartRecordingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartRecordingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartRecordingResponse>> StartRecording(
        string callControlID,
        ActionStartRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StartRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartSiprecResponse>> StartSiprec(
        ActionStartSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartSiprecParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartSiprecResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartSiprecResponse>> StartSiprec(
        string callControlID,
        ActionStartSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartSiprec(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartStreamingResponse>> StartStreaming(
        ActionStartStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartStreamingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartStreamingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartStreamingResponse>> StartStreaming(
        string callControlID,
        ActionStartStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartStreaming(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStartTranscriptionResponse>> StartTranscription(
        ActionStartTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStartTranscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStartTranscriptionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStartTranscriptionResponse>> StartTranscription(
        string callControlID,
        ActionStartTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartTranscription(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopAIAssistantResponse>> StopAIAssistant(
        ActionStopAIAssistantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopAIAssistantParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopAIAssistantResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopAIAssistantResponse>> StopAIAssistant(
        string callControlID,
        ActionStopAIAssistantParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopAIAssistant(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopConversationRelayResponse>> StopConversationRelay(
        ActionStopConversationRelayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopConversationRelayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopConversationRelayResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopConversationRelayResponse>> StopConversationRelay(
        string callControlID,
        ActionStopConversationRelayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopConversationRelay(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopForkingResponse>> StopForking(
        ActionStopForkingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopForkingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopForkingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopForkingResponse>> StopForking(
        string callControlID,
        ActionStopForkingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopForking(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopGatherResponse>> StopGather(
        ActionStopGatherParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopGatherParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopGatherResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopGatherResponse>> StopGather(
        string callControlID,
        ActionStopGatherParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopGather(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopNoiseSuppressionResponse>> StopNoiseSuppression(
        ActionStopNoiseSuppressionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopNoiseSuppressionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopNoiseSuppressionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopNoiseSuppressionResponse>> StopNoiseSuppression(
        string callControlID,
        ActionStopNoiseSuppressionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopNoiseSuppression(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopPlaybackResponse>> StopPlayback(
        ActionStopPlaybackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopPlaybackParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopPlaybackResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopPlaybackResponse>> StopPlayback(
        string callControlID,
        ActionStopPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopPlayback(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopRecordingResponse>> StopRecording(
        ActionStopRecordingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopRecordingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopRecordingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopRecordingResponse>> StopRecording(
        string callControlID,
        ActionStopRecordingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopRecording(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopSiprecResponse>> StopSiprec(
        ActionStopSiprecParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopSiprecParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopSiprecResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopSiprecResponse>> StopSiprec(
        string callControlID,
        ActionStopSiprecParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopSiprec(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopStreamingResponse>> StopStreaming(
        ActionStopStreamingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopStreamingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopStreamingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopStreamingResponse>> StopStreaming(
        string callControlID,
        ActionStopStreamingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopStreaming(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionStopTranscriptionResponse>> StopTranscription(
        ActionStopTranscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionStopTranscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionStopTranscriptionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionStopTranscriptionResponse>> StopTranscription(
        string callControlID,
        ActionStopTranscriptionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopTranscription(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionSwitchSupervisorRoleResponse>> SwitchSupervisorRole(
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionSwitchSupervisorRoleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionSwitchSupervisorRoleResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionSwitchSupervisorRoleResponse>> SwitchSupervisorRole(
        string callControlID,
        ActionSwitchSupervisorRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SwitchSupervisorRole(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionTransferResponse>> Transfer(
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionTransferParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionTransferResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionTransferResponse>> Transfer(
        string callControlID,
        ActionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Transfer(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionUpdateClientStateResponse>> UpdateClientState(
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<ActionUpdateClientStateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionUpdateClientStateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionUpdateClientStateResponse>> UpdateClientState(
        string callControlID,
        ActionUpdateClientStateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateClientState(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }
}