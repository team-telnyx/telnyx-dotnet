using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Verifications.ByPhoneNumber.Actions;

namespace Telnyx.Sdk.Services.Verifications.ByPhoneNumber;

/// <summary>
/// Two factor authentication API
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
/// Submits a verification code for the specified phone number and Verify profile.
/// The response indicates whether the code was accepted or rejected.
/// </summary>
    Task<VerifyVerificationCodeResponse> Verify(
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(ActionVerifyParams, CancellationToken)"/>
    Task<VerifyVerificationCodeResponse> Verify(
        string phoneNumber,
        ActionVerifyParams parameters,
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
/// Returns a raw HTTP response for <c>post /verifications/by_phone_number/{phone_number}/actions/verify</c>, but is otherwise the
/// same as <see cref="IActionService.Verify(ActionVerifyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyVerificationCodeResponse>> Verify(
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(ActionVerifyParams, CancellationToken)"/>
    Task<HttpResponse<VerifyVerificationCodeResponse>> Verify(
        string phoneNumber,
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}