using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.VerifyEmail;

namespace Telnyx.Sdk.Services.Dir;

/// <summary>
/// Verify ownership of a DIR's authorizer email. A short code is emailed and confirmed;
/// the email must be verified before references can be submitted.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerifyEmailService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerifyEmailServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifyEmailService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Email a 6-digit code to the DIR's authorizer email to confirm ownership of that
/// address.
/// 
/// <para>The code expires in 15 minutes. Requesting a new code invalidates any
/// previous one. Resends are rate limited (a short cooldown plus a daily cap).
/// Submit the code to `POST /dir/{dir_id}/verify_email/confirm`.</para>
/// </summary>
    Task<EmailVerificationStatusWrapped> Create(
        VerifyEmailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(VerifyEmailCreateParams, CancellationToken)"/>
    Task<EmailVerificationStatusWrapped> Create(
        string dirID,
        VerifyEmailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Whether the DIR's current authorizer email has been verified.
/// </summary>
    Task<EmailVerificationStatusWrapped> List(
        VerifyEmailListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(VerifyEmailListParams, CancellationToken)"/>
    Task<EmailVerificationStatusWrapped> List(
        string dirID,
        VerifyEmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submit the 6-digit code that was emailed to the DIR's authorizer email. On
/// success the authorizer email is marked verified.
/// 
/// <para>For security, any failure (wrong, expired, already-used, or too many
/// attempts) returns the same generic message.</para>
/// </summary>
    Task<EmailVerificationStatusWrapped> Confirm(
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Confirm(VerifyEmailConfirmParams, CancellationToken)"/>
    Task<EmailVerificationStatusWrapped> Confirm(
        string dirID,
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVerifyEmailService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerifyEmailServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifyEmailServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/verify_email</c>, but is otherwise the
/// same as <see cref="IVerifyEmailService.Create(VerifyEmailCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailVerificationStatusWrapped>> Create(
        VerifyEmailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(VerifyEmailCreateParams, CancellationToken)"/>
    Task<HttpResponse<EmailVerificationStatusWrapped>> Create(
        string dirID,
        VerifyEmailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/verify_email</c>, but is otherwise the
/// same as <see cref="IVerifyEmailService.List(VerifyEmailListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailVerificationStatusWrapped>> List(
        VerifyEmailListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(VerifyEmailListParams, CancellationToken)"/>
    Task<HttpResponse<EmailVerificationStatusWrapped>> List(
        string dirID,
        VerifyEmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/verify_email/confirm</c>, but is otherwise the
/// same as <see cref="IVerifyEmailService.Confirm(VerifyEmailConfirmParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailVerificationStatusWrapped>> Confirm(
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Confirm(VerifyEmailConfirmParams, CancellationToken)"/>
    Task<HttpResponse<EmailVerificationStatusWrapped>> Confirm(
        string dirID,
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}