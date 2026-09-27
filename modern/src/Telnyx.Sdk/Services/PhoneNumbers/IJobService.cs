using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Jobs;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <summary>
/// Background jobs performed over a batch of phone numbers
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
/// Returns the status and details of the phone-number background job identified by
/// `id`.
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
/// Returns background jobs that operate on phone numbers. Filter by job type,
/// target phone numbers, or job status, and sort by creation time. Multiple
/// phone-number or status values use OR semantics within that filter; different
/// filter categories use AND semantics. Results include pagination metadata.
/// </summary>
    Task<JobListPage> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a new background job to delete a batch of numbers. At most one thousand
/// numbers can be updated per API call.
/// </summary>
    Task<JobDeleteBatchResponse> DeleteBatch(
        JobDeleteBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a new background job to update a batch of numbers. At most one thousand
/// numbers can be updated per API call. At least one of the updateable fields must
/// be submitted. IMPORTANT: You must either specify filters (using the filter
/// parameters) or specific phone numbers (using the phone_numbers parameter in the
/// request body). If you specify filters, ALL phone numbers that match the given
/// filters (up to 1000 at a time) will be updated. If you want to update only
/// specific numbers, you must use the phone_numbers parameter in the request body.
/// When using the phone_numbers parameter, ensure you follow the correct format as
/// shown in the example (either phone number IDs or phone numbers in E164 format).
/// </summary>
    Task<JobUpdateBatchResponse> UpdateBatch(
        JobUpdateBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a background job to update the emergency settings of a collection of
/// phone numbers. At most one thousand numbers can be updated per API call.
/// </summary>
    Task<JobUpdateEmergencySettingsBatchResponse> UpdateEmergencySettingsBatch(
        JobUpdateEmergencySettingsBatchParams parameters,
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
/// Returns a raw HTTP response for <c>get /phone_numbers/jobs/{id}</c>, but is otherwise the
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
/// Returns a raw HTTP response for <c>get /phone_numbers/jobs</c>, but is otherwise the
/// same as <see cref="IJobService.List(JobListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobListPage>> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/jobs/delete_phone_numbers</c>, but is otherwise the
/// same as <see cref="IJobService.DeleteBatch(JobDeleteBatchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobDeleteBatchResponse>> DeleteBatch(
        JobDeleteBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/jobs/update_phone_numbers</c>, but is otherwise the
/// same as <see cref="IJobService.UpdateBatch(JobUpdateBatchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobUpdateBatchResponse>> UpdateBatch(
        JobUpdateBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/jobs/update_emergency_settings</c>, but is otherwise the
/// same as <see cref="IJobService.UpdateEmergencySettingsBatch(JobUpdateEmergencySettingsBatchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobUpdateEmergencySettingsBatchResponse>> UpdateEmergencySettingsBatch(
        JobUpdateEmergencySettingsBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}