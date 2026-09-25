using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VerifiedNumbers;
using Telnyx.Sdk.Models.VerifiedNumbers.Actions;

namespace Telnyx.Sdk.Services.VerifiedNumbers;

/// <summary>
/// Verified Numbers operations
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
/// Submit the verification code received via the selected verification method to
/// verify a phone number.
/// </summary>
    Task<VerifiedNumberDataWrapper> SubmitVerificationCode(
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SubmitVerificationCode(ActionSubmitVerificationCodeParams, CancellationToken)"/>
    Task<VerifiedNumberDataWrapper> SubmitVerificationCode(
        string phoneNumber,
        ActionSubmitVerificationCodeParams parameters,
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
/// Returns a raw HTTP response for <c>post /verified_numbers/{phone_number}/actions/verify</c>, but is otherwise the
/// same as <see cref="IActionService.SubmitVerificationCode(ActionSubmitVerificationCodeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifiedNumberDataWrapper>> SubmitVerificationCode(
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SubmitVerificationCode(ActionSubmitVerificationCodeParams, CancellationToken)"/>
    Task<HttpResponse<VerifiedNumberDataWrapper>> SubmitVerificationCode(
        string phoneNumber,
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}