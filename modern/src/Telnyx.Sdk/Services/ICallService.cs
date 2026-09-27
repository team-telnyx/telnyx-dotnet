using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Calls;
using Calls = Telnyx.Sdk.Services.Calls;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Calls::IActionService Actions { get; }

    /// <summary>
/// Dial a number or SIP URI from a given connection. A successful response will
/// include a `call_leg_id` which can be used to correlate the command with
/// subsequent webhooks.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `call.initiated` - `call.answered` or `call.hangup` - `call.hold` and
/// `call.unhold` if the call is held/unheld - `call.machine.detection.ended` if
/// `answering_machine_detection` was requested - `call.machine.greeting.ended` if
/// `answering_machine_detection` was requested to detect the end of machine
/// greeting - `call.machine.premium.detection.ended` if
/// `answering_machine_detection=premium` was requested -
/// `call.machine.premium.greeting.ended` if `answering_machine_detection=premium`
/// was requested and a beep was detected - `call.deepfake_detection.result` if
/// `deepfake_detection` was enabled - `call.deepfake_detection.error` if
/// `deepfake_detection` was enabled and an error occurred - `streaming.started`,
/// `streaming.stopped` or `streaming.failed` if `stream_url` was set</para>
/// 
/// <para>When the `record` parameter is set to `record-from-answer`, the response
/// will include a `recording_id` field. </para>
/// </summary>
    Task<CallDialResponse> Dial(
        CallDialParams parameters, CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the status of a call (data is available 10 minutes after call ended).
/// </summary>
    Task<CallRetrieveStatusResponse> RetrieveStatus(
        CallRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveStatus(CallRetrieveStatusParams, CancellationToken)"/>
    Task<CallRetrieveStatusResponse> RetrieveStatus(
        string callControlID,
        CallRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Calls::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /calls</c>, but is otherwise the
/// same as <see cref="ICallService.Dial(CallDialParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallDialResponse>> Dial(
        CallDialParams parameters, CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /calls/{call_control_id}</c>, but is otherwise the
/// same as <see cref="ICallService.RetrieveStatus(CallRetrieveStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallRetrieveStatusResponse>> RetrieveStatus(
        CallRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveStatus(CallRetrieveStatusParams, CancellationToken)"/>
    Task<HttpResponse<CallRetrieveStatusResponse>> RetrieveStatus(
        string callControlID,
        CallRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}