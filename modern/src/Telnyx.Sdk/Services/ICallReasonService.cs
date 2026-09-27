using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallReasons;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Static reference values the API accepts: call reasons, document types, rejection types.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallReasonService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallReasonServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallReasonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Telnyx maintains a library of pre-vetted call-reason phrases (e.g. "Appointment
/// reminders", "Billing inquiries") that carry through DIR vetting smoothly. You
/// can use any string that fits your use case in `DirCreateRequest.call_reasons`,
/// but matching one of these reduces the chance the vetting team flags the phrasing
/// for clarification.
/// </summary>
    Task<CallReasonListPage> List(
        CallReasonListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Check up to 10 candidate `call_reasons` strings against Telnyx's vetting
/// heuristics before sending them on a DIR create or update. The endpoint flags
/// strings that are likely to be rejected during vetting (too generic, banned
/// phrases, length issues, etc.) so you can fix them up front.
/// </summary>
    Task<CallReasonValidateResponse> Validate(
        CallReasonValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallReasonService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallReasonServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallReasonServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /call_reasons</c>, but is otherwise the
/// same as <see cref="ICallReasonService.List(CallReasonListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallReasonListPage>> List(
        CallReasonListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /call_reasons/validate</c>, but is otherwise the
/// same as <see cref="ICallReasonService.Validate(CallReasonValidateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallReasonValidateResponse>> Validate(
        CallReasonValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}