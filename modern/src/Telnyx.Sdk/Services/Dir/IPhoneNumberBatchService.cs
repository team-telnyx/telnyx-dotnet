using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

namespace Telnyx.Sdk.Services.Dir;

/// <summary>
/// Phone numbers are submitted to Telnyx for vetting in batches. Batches group all
/// numbers added in a single request under the same Letter of Authorization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberBatchService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Get a single phone-number batch by id. The enterprise is resolved server-side
/// from the DIR id.
/// </summary>
    Task<PhoneNumberBatchRetrieveResponse> Retrieve(
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberBatchRetrieveParams, CancellationToken)"/>
    Task<PhoneNumberBatchRetrieveResponse> Retrieve(
        string batchID,
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List the phone-number batches submitted under a DIR. The enterprise is resolved
/// server-side from the DIR id.
/// </summary>
    Task<PhoneNumberBatchListPage> List(
        PhoneNumberBatchListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberBatchListParams, CancellationToken)"/>
    Task<PhoneNumberBatchListPage> List(
        string dirID,
        PhoneNumberBatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberBatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/phone_number_batches/{batch_id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberBatchService.Retrieve(PhoneNumberBatchRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberBatchRetrieveResponse>> Retrieve(
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberBatchRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberBatchRetrieveResponse>> Retrieve(
        string batchID,
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/phone_number_batches</c>, but is otherwise the
/// same as <see cref="IPhoneNumberBatchService.List(PhoneNumberBatchListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberBatchListPage>> List(
        PhoneNumberBatchListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberBatchListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberBatchListPage>> List(
        string dirID,
        PhoneNumberBatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}