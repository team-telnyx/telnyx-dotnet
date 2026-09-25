using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailValidations;
using Telnyx.Sdk.Services.EmailValidations;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Validate email addresses synchronously or in asynchronous batches.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailValidationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailValidationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailValidationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBatchService Batch { get; }

    /// <summary>
/// Validates a single email address and returns deliverability checks.
/// </summary>
    Task<EmailValidationCreateResponse> Create(
        EmailValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailValidationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailValidationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailValidationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBatchServiceWithRawResponse Batch { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_validations</c>, but is otherwise the
/// same as <see cref="IEmailValidationService.Create(EmailValidationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailValidationCreateResponse>> Create(
        EmailValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}