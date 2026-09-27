using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.FineTuning.Jobs;

namespace Telnyx.Sdk.Services.AI.FineTuning;

/// <summary>
/// Customize LLMs for your unique needs
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
/// Creates a new fine-tuning job that trains a model on the provided dataset, and
/// returns the created job.
/// </summary>
    Task<FineTuningJob> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single fine-tuning job by its job_id, including its
/// current status.
/// </summary>
    Task<FineTuningJob> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(JobRetrieveParams, CancellationToken)"/>
    Task<FineTuningJob> Retrieve(
        string jobID,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of all fine tuning jobs created by the user.
/// </summary>
    Task<JobListResponse> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Cancels the specified in-progress fine-tuning job and returns the updated job.
/// </summary>
    Task<FineTuningJob> Cancel(
        JobCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Cancel(JobCancelParams, CancellationToken)"/>
    Task<FineTuningJob> Cancel(
        string jobID,
        JobCancelParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /ai/fine_tuning/jobs</c>, but is otherwise the
/// same as <see cref="IJobService.Create(JobCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FineTuningJob>> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/fine_tuning/jobs/{job_id}</c>, but is otherwise the
/// same as <see cref="IJobService.Retrieve(JobRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FineTuningJob>> Retrieve(
        JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(JobRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FineTuningJob>> Retrieve(
        string jobID,
        JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/fine_tuning/jobs</c>, but is otherwise the
/// same as <see cref="IJobService.List(JobListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JobListResponse>> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/fine_tuning/jobs/{job_id}/cancel</c>, but is otherwise the
/// same as <see cref="IJobService.Cancel(JobCancelParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FineTuningJob>> Cancel(
        JobCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Cancel(JobCancelParams, CancellationToken)"/>
    Task<HttpResponse<FineTuningJob>> Cancel(
        string jobID,
        JobCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}