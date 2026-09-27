using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.VerificationCodes;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerificationCodeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerificationCodeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationCodeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a list of verification codes for a porting order.
/// </summary>
    Task<VerificationCodeListPage> List(
        VerificationCodeListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(VerificationCodeListParams, CancellationToken)"/>
    Task<VerificationCodeListPage> List(
        string id,
        VerificationCodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Send the verification code for all porting phone numbers.
/// </summary>
    Task Send(
        VerificationCodeSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Send(VerificationCodeSendParams, CancellationToken)"/>
    Task Send(
        string id,
        VerificationCodeSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Verifies the verification code for a list of phone numbers.
/// </summary>
    Task<VerificationCodeVerifyResponse> Verify(
        VerificationCodeVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(VerificationCodeVerifyParams, CancellationToken)"/>
    Task<VerificationCodeVerifyResponse> Verify(
        string id,
        VerificationCodeVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVerificationCodeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerificationCodeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationCodeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/verification_codes</c>, but is otherwise the
/// same as <see cref="IVerificationCodeService.List(VerificationCodeListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerificationCodeListPage>> List(
        VerificationCodeListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(VerificationCodeListParams, CancellationToken)"/>
    Task<HttpResponse<VerificationCodeListPage>> List(
        string id,
        VerificationCodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/verification_codes/send</c>, but is otherwise the
/// same as <see cref="IVerificationCodeService.Send(VerificationCodeSendParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Send(
        VerificationCodeSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Send(VerificationCodeSendParams, CancellationToken)"/>
    Task<HttpResponse> Send(
        string id,
        VerificationCodeSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/verification_codes/verify</c>, but is otherwise the
/// same as <see cref="IVerificationCodeService.Verify(VerificationCodeVerifyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerificationCodeVerifyResponse>> Verify(
        VerificationCodeVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(VerificationCodeVerifyParams, CancellationToken)"/>
    Task<HttpResponse<VerificationCodeVerifyResponse>> Verify(
        string id,
        VerificationCodeVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}