using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Conferences.Actions;

namespace Telnyx.Sdk.Services.Conferences;

/// <summary>
/// Conference command operations
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
/// Update conference participant supervisor_role
/// </summary>
    Task<ActionUpdateResponse> Update(
        ActionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ActionUpdateParams, CancellationToken)"/>
    Task<ActionUpdateResponse> Update(
        string id,
        ActionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// End a conference and terminate all active participants.
/// </summary>
    Task<ActionEndConferenceResponse> EndConference(
        ActionEndConferenceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="EndConference(ActionEndConferenceParams, CancellationToken)"/>
    Task<ActionEndConferenceResponse> EndConference(
        string id,
        ActionEndConferenceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Play an audio file to a specific conference participant and gather DTMF input.
/// </summary>
    Task<ActionGatherDtmfAudioResponse> GatherDtmfAudio(
        ActionGatherDtmfAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherDtmfAudio(ActionGatherDtmfAudioParams, CancellationToken)"/>
    Task<ActionGatherDtmfAudioResponse> GatherDtmfAudio(
        string id,
        ActionGatherDtmfAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Hold a list of participants in a conference call
/// </summary>
    Task<ActionHoldResponse> Hold(
        ActionHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Hold(ActionHoldParams, CancellationToken)"/>
    Task<ActionHoldResponse> Hold(
        string id,
        ActionHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Join an existing call leg to a conference. Issue the Join Conference command
/// with the conference ID in the path and the `call_control_id` of the leg you wish
/// to join to the conference as an attribute. The conference can have up to a
/// certain amount of active participants, as set by the `max_participants`
/// parameter in conference creation request.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `conference.participant.joined` - `conference.participant.left` </para>
/// </summary>
    Task<ActionJoinResponse> Join(
        ActionJoinParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Join(ActionJoinParams, CancellationToken)"/>
    Task<ActionJoinResponse> Join(
        string id,
        ActionJoinParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes a call leg from a conference and moves it back to parked state.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `conference.participant.left` </para>
/// </summary>
    Task<ActionLeaveResponse> Leave(
        ActionLeaveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Leave(ActionLeaveParams, CancellationToken)"/>
    Task<ActionLeaveResponse> Leave(
        string id,
        ActionLeaveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Mute a list of participants in a conference call
/// </summary>
    Task<ActionMuteResponse> Mute(
        ActionMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Mute(ActionMuteParams, CancellationToken)"/>
    Task<ActionMuteResponse> Mute(
        string id,
        ActionMuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Play audio to all or some participants on a conference call.
/// </summary>
    Task<ActionPlayResponse> Play(
        ActionPlayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Play(ActionPlayParams, CancellationToken)"/>
    Task<ActionPlayResponse> Play(
        string id,
        ActionPlayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Pauses the active recording of the specified conference. Resume it later with
/// the record_resume action.
/// </summary>
    Task<ActionRecordPauseResponse> RecordPause(
        ActionRecordPauseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordPause(ActionRecordPauseParams, CancellationToken)"/>
    Task<ActionRecordPauseResponse> RecordPause(
        string id,
        ActionRecordPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Resumes a previously paused recording of the specified conference, continuing
/// capture from the point it was paused.
/// </summary>
    Task<ActionRecordResumeResponse> RecordResume(
        ActionRecordResumeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordResume(ActionRecordResumeParams, CancellationToken)"/>
    Task<ActionRecordResumeResponse> RecordResume(
        string id,
        ActionRecordResumeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Start recording the conference. Recording will stop on conference end, or via
/// the Stop Recording command.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `conference.recording.saved`</para>
/// </summary>
    Task<ActionRecordStartResponse> RecordStart(
        ActionRecordStartParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordStart(ActionRecordStartParams, CancellationToken)"/>
    Task<ActionRecordStartResponse> RecordStart(
        string id,
        ActionRecordStartParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop recording the conference.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `conference.recording.saved` </para>
/// </summary>
    Task<ActionRecordStopResponse> RecordStop(
        ActionRecordStopParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordStop(ActionRecordStopParams, CancellationToken)"/>
    Task<ActionRecordStopResponse> RecordStop(
        string id,
        ActionRecordStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Send DTMF tones to one or more conference participants.
/// </summary>
    Task<ActionSendDtmfResponse> SendDtmf(
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendDtmf(ActionSendDtmfParams, CancellationToken)"/>
    Task<ActionSendDtmfResponse> SendDtmf(
        string id,
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Convert text to speech and play it to all or some participants.
/// </summary>
    Task<ActionSpeakResponse> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Speak(ActionSpeakParams, CancellationToken)"/>
    Task<ActionSpeakResponse> Speak(
        string id,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop audio being played to all or some participants on a conference call.
/// </summary>
    Task<ActionStopResponse> Stop(
        ActionStopParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Stop(ActionStopParams, CancellationToken)"/>
    Task<ActionStopResponse> Stop(
        string id,
        ActionStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Unhold a list of participants in a conference call
/// </summary>
    Task<ActionUnholdResponse> Unhold(
        ActionUnholdParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unhold(ActionUnholdParams, CancellationToken)"/>
    Task<ActionUnholdResponse> Unhold(
        string id,
        ActionUnholdParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Unmute a list of participants in a conference call
/// </summary>
    Task<ActionUnmuteResponse> Unmute(
        ActionUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unmute(ActionUnmuteParams, CancellationToken)"/>
    Task<ActionUnmuteResponse> Unmute(
        string id,
        ActionUnmuteParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/update</c>, but is otherwise the
/// same as <see cref="IActionService.Update(ActionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionUpdateResponse>> Update(
        ActionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ActionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ActionUpdateResponse>> Update(
        string id,
        ActionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/end</c>, but is otherwise the
/// same as <see cref="IActionService.EndConference(ActionEndConferenceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEndConferenceResponse>> EndConference(
        ActionEndConferenceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="EndConference(ActionEndConferenceParams, CancellationToken)"/>
    Task<HttpResponse<ActionEndConferenceResponse>> EndConference(
        string id,
        ActionEndConferenceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/gather_using_audio</c>, but is otherwise the
/// same as <see cref="IActionService.GatherDtmfAudio(ActionGatherDtmfAudioParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionGatherDtmfAudioResponse>> GatherDtmfAudio(
        ActionGatherDtmfAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GatherDtmfAudio(ActionGatherDtmfAudioParams, CancellationToken)"/>
    Task<HttpResponse<ActionGatherDtmfAudioResponse>> GatherDtmfAudio(
        string id,
        ActionGatherDtmfAudioParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/hold</c>, but is otherwise the
/// same as <see cref="IActionService.Hold(ActionHoldParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionHoldResponse>> Hold(
        ActionHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Hold(ActionHoldParams, CancellationToken)"/>
    Task<HttpResponse<ActionHoldResponse>> Hold(
        string id,
        ActionHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/join</c>, but is otherwise the
/// same as <see cref="IActionService.Join(ActionJoinParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionJoinResponse>> Join(
        ActionJoinParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Join(ActionJoinParams, CancellationToken)"/>
    Task<HttpResponse<ActionJoinResponse>> Join(
        string id,
        ActionJoinParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/leave</c>, but is otherwise the
/// same as <see cref="IActionService.Leave(ActionLeaveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionLeaveResponse>> Leave(
        ActionLeaveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Leave(ActionLeaveParams, CancellationToken)"/>
    Task<HttpResponse<ActionLeaveResponse>> Leave(
        string id,
        ActionLeaveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/mute</c>, but is otherwise the
/// same as <see cref="IActionService.Mute(ActionMuteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionMuteResponse>> Mute(
        ActionMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Mute(ActionMuteParams, CancellationToken)"/>
    Task<HttpResponse<ActionMuteResponse>> Mute(
        string id,
        ActionMuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/play</c>, but is otherwise the
/// same as <see cref="IActionService.Play(ActionPlayParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionPlayResponse>> Play(
        ActionPlayParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Play(ActionPlayParams, CancellationToken)"/>
    Task<HttpResponse<ActionPlayResponse>> Play(
        string id,
        ActionPlayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/record_pause</c>, but is otherwise the
/// same as <see cref="IActionService.RecordPause(ActionRecordPauseParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRecordPauseResponse>> RecordPause(
        ActionRecordPauseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordPause(ActionRecordPauseParams, CancellationToken)"/>
    Task<HttpResponse<ActionRecordPauseResponse>> RecordPause(
        string id,
        ActionRecordPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/record_resume</c>, but is otherwise the
/// same as <see cref="IActionService.RecordResume(ActionRecordResumeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRecordResumeResponse>> RecordResume(
        ActionRecordResumeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordResume(ActionRecordResumeParams, CancellationToken)"/>
    Task<HttpResponse<ActionRecordResumeResponse>> RecordResume(
        string id,
        ActionRecordResumeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/record_start</c>, but is otherwise the
/// same as <see cref="IActionService.RecordStart(ActionRecordStartParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRecordStartResponse>> RecordStart(
        ActionRecordStartParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordStart(ActionRecordStartParams, CancellationToken)"/>
    Task<HttpResponse<ActionRecordStartResponse>> RecordStart(
        string id,
        ActionRecordStartParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/record_stop</c>, but is otherwise the
/// same as <see cref="IActionService.RecordStop(ActionRecordStopParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRecordStopResponse>> RecordStop(
        ActionRecordStopParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RecordStop(ActionRecordStopParams, CancellationToken)"/>
    Task<HttpResponse<ActionRecordStopResponse>> RecordStop(
        string id,
        ActionRecordStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/send_dtmf</c>, but is otherwise the
/// same as <see cref="IActionService.SendDtmf(ActionSendDtmfParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSendDtmfResponse>> SendDtmf(
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendDtmf(ActionSendDtmfParams, CancellationToken)"/>
    Task<HttpResponse<ActionSendDtmfResponse>> SendDtmf(
        string id,
        ActionSendDtmfParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/speak</c>, but is otherwise the
/// same as <see cref="IActionService.Speak(ActionSpeakParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionSpeakResponse>> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Speak(ActionSpeakParams, CancellationToken)"/>
    Task<HttpResponse<ActionSpeakResponse>> Speak(
        string id,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/stop</c>, but is otherwise the
/// same as <see cref="IActionService.Stop(ActionStopParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionStopResponse>> Stop(
        ActionStopParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Stop(ActionStopParams, CancellationToken)"/>
    Task<HttpResponse<ActionStopResponse>> Stop(
        string id,
        ActionStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/unhold</c>, but is otherwise the
/// same as <see cref="IActionService.Unhold(ActionUnholdParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionUnholdResponse>> Unhold(
        ActionUnholdParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unhold(ActionUnholdParams, CancellationToken)"/>
    Task<HttpResponse<ActionUnholdResponse>> Unhold(
        string id,
        ActionUnholdParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences/{id}/actions/unmute</c>, but is otherwise the
/// same as <see cref="IActionService.Unmute(ActionUnmuteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionUnmuteResponse>> Unmute(
        ActionUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unmute(ActionUnmuteParams, CancellationToken)"/>
    Task<HttpResponse<ActionUnmuteResponse>> Unmute(
        string id,
        ActionUnmuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}