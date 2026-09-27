using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.Runs;
using Telnyx.Sdk.Services.AI.Missions.Runs;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRunService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRunServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IEventService Events { get; }

    IPlanService Plan { get; }

    ITelnyxAgentService TelnyxAgents { get; }

    /// <summary>
/// Starts a new run of the specified mission and returns the created run object.
/// Track its progress through the run detail, plan, and events endpoints.
/// </summary>
    Task<MissionRunResponse> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(RunCreateParams, CancellationToken)"/>
    Task<MissionRunResponse> Create(
        string missionID,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the full details of a single run, including its current status. Use this
/// to poll an in-flight run or inspect the outcome of a completed one.
/// </summary>
    Task<MissionRunResponse> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<MissionRunResponse> Retrieve(
        string runID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates a run's status and/or result and returns the updated run object.
/// Typically used by executing agents to report progress or record the final
/// outcome.
/// </summary>
    Task<MissionRunResponse> Update(
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RunUpdateParams, CancellationToken)"/>
    Task<MissionRunResponse> Update(
        string runID,
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of runs for the specified mission, optionally filtered
/// by run status, so you can track the mission's execution history over time.
/// </summary>
    Task<RunListPage> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<RunListPage> List(
        string missionID,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Cancels a running or paused run and returns the updated run object. A cancelled
/// run stops executing; start a new run to execute the mission again.
/// </summary>
    Task<MissionRunResponse> CancelRun(
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CancelRun(RunCancelRunParams, CancellationToken)"/>
    Task<MissionRunResponse> CancelRun(
        string runID,
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of recent runs across every mission in your
/// organization, optionally filtered by run status. Useful for monitoring overall
/// mission activity without querying each mission individually.
/// </summary>
    Task<RunListRunsPage> ListRuns(
        RunListRunsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Pauses a currently running run and returns the updated run object. Execution
/// halts until the run is resumed.
/// </summary>
    Task<MissionRunResponse> PauseRun(
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PauseRun(RunPauseRunParams, CancellationToken)"/>
    Task<MissionRunResponse> PauseRun(
        string runID,
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Resumes a previously paused run and returns the updated run object, letting
/// execution continue from where it was paused.
/// </summary>
    Task<MissionRunResponse> ResumeRun(
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ResumeRun(RunResumeRunParams, CancellationToken)"/>
    Task<MissionRunResponse> ResumeRun(
        string runID,
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRunService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRunServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IEventServiceWithRawResponse Events { get; }

    IPlanServiceWithRawResponse Plan { get; }

    ITelnyxAgentServiceWithRawResponse TelnyxAgents { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs</c>, but is otherwise the
/// same as <see cref="IRunService.Create(RunCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionRunResponse>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(RunCreateParams, CancellationToken)"/>
    Task<HttpResponse<MissionRunResponse>> Create(
        string missionID,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs/{run_id}</c>, but is otherwise the
/// same as <see cref="IRunService.Retrieve(RunRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionRunResponse>> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MissionRunResponse>> Retrieve(
        string runID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ai/missions/{mission_id}/runs/{run_id}</c>, but is otherwise the
/// same as <see cref="IRunService.Update(RunUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionRunResponse>> Update(
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RunUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MissionRunResponse>> Update(
        string runID,
        RunUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs</c>, but is otherwise the
/// same as <see cref="IRunService.List(RunListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RunListPage>> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<HttpResponse<RunListPage>> List(
        string missionID,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/cancel</c>, but is otherwise the
/// same as <see cref="IRunService.CancelRun(RunCancelRunParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionRunResponse>> CancelRun(
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CancelRun(RunCancelRunParams, CancellationToken)"/>
    Task<HttpResponse<MissionRunResponse>> CancelRun(
        string runID,
        RunCancelRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/runs</c>, but is otherwise the
/// same as <see cref="IRunService.ListRuns(RunListRunsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RunListRunsPage>> ListRuns(
        RunListRunsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/pause</c>, but is otherwise the
/// same as <see cref="IRunService.PauseRun(RunPauseRunParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionRunResponse>> PauseRun(
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PauseRun(RunPauseRunParams, CancellationToken)"/>
    Task<HttpResponse<MissionRunResponse>> PauseRun(
        string runID,
        RunPauseRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/resume</c>, but is otherwise the
/// same as <see cref="IRunService.ResumeRun(RunResumeRunParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionRunResponse>> ResumeRun(
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ResumeRun(RunResumeRunParams, CancellationToken)"/>
    Task<HttpResponse<MissionRunResponse>> ResumeRun(
        string runID,
        RunResumeRunParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}