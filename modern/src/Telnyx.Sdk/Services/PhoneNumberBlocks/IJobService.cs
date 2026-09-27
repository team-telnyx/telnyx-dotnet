using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumberBlocks.Jobs;

namespace Telnyx.Sdk.Services.PhoneNumberBlocks;

/// <summary>
/// Background jobs performed over a phone-numbers block's phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the status and details of the phone-number-block background job
/// identified by `id`.
/// </summary>
    Task<JobRetrieveResponse> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(JobRetrieveParams, CancellationToken)"/>
    Task<JobRetrieveResponse> Retrieve(
        string id,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns background jobs that operate on phone-number blocks. Results can be
/// filtered by job type and status, sorted by creation time, and include pagination
/// metadata.
/// </summary>
    Task<JobListPage> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a new background job to delete all the phone numbers associated with the
/// given block. We will only consider the phone number block as deleted after all
/// phone numbers associated with it are removed, so multiple executions of this job
/// may be necessary in case some of the phone numbers present errors during the
/// deletion process.
/// </summary>
    Task<JobDeletePhoneNumberBlockResponse> DeletePhoneNumberBlock(
        JobDeletePhoneNumberBlockParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_number_blocks/jobs/{id}</c>, but is otherwise the
/// same as <see cref="IJobService.Retrieve(JobRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobRetrieveResponse>> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(JobRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<JobRetrieveResponse>> Retrieve(
        string id,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_number_blocks/jobs</c>, but is otherwise the
/// same as <see cref="IJobService.List(JobListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobListPage>> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_number_blocks/jobs/delete_phone_number_block</c>, but is otherwise the
/// same as <see cref="IJobService.DeletePhoneNumberBlock(JobDeletePhoneNumberBlockParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobDeletePhoneNumberBlockResponse>> DeletePhoneNumberBlock(
        JobDeletePhoneNumberBlockParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}