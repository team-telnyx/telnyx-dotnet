using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

namespace Telnyx.Sdk.Services.AI.Missions.Runs;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlanService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlanServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates the initial plan for the specified run from the provided steps and
/// returns the created plan steps. Progress is subsequently reported by updating
/// individual steps.
/// </summary>
    Task<PlanStepsCreatedResponse> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(PlanCreateParams, CancellationToken)"/>
    Task<PlanStepsCreatedResponse> Create(
        string runID,
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the plan for the specified run, including all plan steps and their
/// statuses, so you can see how the mission was decomposed and how far execution
/// has progressed.
/// </summary>
    Task<PlanRetrieveResponse> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PlanRetrieveParams, CancellationToken)"/>
    Task<PlanRetrieveResponse> Retrieve(
        string runID,
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Add one or more steps to an existing plan
/// </summary>
    Task<PlanStepsCreatedResponse> AddStepsToPlan(
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AddStepsToPlan(PlanAddStepsToPlanParams, CancellationToken)"/>
    Task<PlanStepsCreatedResponse> AddStepsToPlan(
        string runID,
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single plan step within a run's plan, including its
/// status.
/// </summary>
    Task<PlanStepResponse> GetStepDetails(
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetStepDetails(PlanGetStepDetailsParams, CancellationToken)"/>
    Task<PlanStepResponse> GetStepDetails(
        string stepID,
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the status of a single plan step and returns the updated step. Typically
/// called by the executing agent as it works through the plan.
/// </summary>
    Task<PlanStepResponse> UpdateStep(
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateStep(PlanUpdateStepParams, CancellationToken)"/>
    Task<PlanStepResponse> UpdateStep(
        string stepID,
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPlanService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPlanServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/plan</c>, but is otherwise the
/// same as <see cref="IPlanService.Create(PlanCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PlanStepsCreatedResponse>> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(PlanCreateParams, CancellationToken)"/>
    Task<HttpResponse<PlanStepsCreatedResponse>> Create(
        string runID,
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs/{run_id}/plan</c>, but is otherwise the
/// same as <see cref="IPlanService.Retrieve(PlanRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PlanRetrieveResponse>> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PlanRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PlanRetrieveResponse>> Retrieve(
        string runID,
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/runs/{run_id}/plan/steps</c>, but is otherwise the
/// same as <see cref="IPlanService.AddStepsToPlan(PlanAddStepsToPlanParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PlanStepsCreatedResponse>> AddStepsToPlan(
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AddStepsToPlan(PlanAddStepsToPlanParams, CancellationToken)"/>
    Task<HttpResponse<PlanStepsCreatedResponse>> AddStepsToPlan(
        string runID,
        PlanAddStepsToPlanParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/runs/{run_id}/plan/steps/{step_id}</c>, but is otherwise the
/// same as <see cref="IPlanService.GetStepDetails(PlanGetStepDetailsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PlanStepResponse>> GetStepDetails(
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetStepDetails(PlanGetStepDetailsParams, CancellationToken)"/>
    Task<HttpResponse<PlanStepResponse>> GetStepDetails(
        string stepID,
        PlanGetStepDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ai/missions/{mission_id}/runs/{run_id}/plan/steps/{step_id}</c>, but is otherwise the
/// same as <see cref="IPlanService.UpdateStep(PlanUpdateStepParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PlanStepResponse>> UpdateStep(
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateStep(PlanUpdateStepParams, CancellationToken)"/>
    Task<HttpResponse<PlanStepResponse>> UpdateStep(
        string stepID,
        PlanUpdateStepParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}