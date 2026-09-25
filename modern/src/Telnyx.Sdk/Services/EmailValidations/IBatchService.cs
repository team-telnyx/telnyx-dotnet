using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailValidations.Batch;

namespace Telnyx.Sdk.Services.EmailValidations;

/// <summary>
/// Validate email addresses synchronously or in asynchronous batches.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates an asynchronous batch validation job for up to 1,000 email addresses.
/// </summary>
    Task<BatchCreateResponse> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the current status and, once completed, validation results for a batch
/// job.
/// </summary>
    Task<BatchRetrieveResponse> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BatchRetrieveParams, CancellationToken)"/>
    Task<BatchRetrieveResponse> Retrieve(
        string id,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_validations/batch</c>, but is otherwise the
/// same as <see cref="IBatchService.Create(BatchCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BatchCreateResponse>> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_validations/batch/{id}</c>, but is otherwise the
/// same as <see cref="IBatchService.Retrieve(BatchRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BatchRetrieveResponse>> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BatchRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BatchRetrieveResponse>> Retrieve(
        string id,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}