using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;

namespace Telnyx.Sdk.Services.AI.Assistants.Tests;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    /// <summary>
/// Retrieves detailed information about a specific test run execution
/// </summary>
    Task<TestRunResponse> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<TestRunResponse> Retrieve(
        string runID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves paginated execution history for a specific assistant test with
/// filtering options
/// </summary>
    Task<RunListPage> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<RunListPage> List(
        string testID,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Initiates immediate execution of a specific assistant test
/// </summary>
    Task<TestRunResponse> Trigger(
        RunTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Trigger(RunTriggerParams, CancellationToken)"/>
    Task<TestRunResponse> Trigger(
        string testID,
        RunTriggerParams? parameters = null,
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

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/tests/{test_id}/runs/{run_id}</c>, but is otherwise the
/// same as <see cref="IRunService.Retrieve(RunRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TestRunResponse>> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TestRunResponse>> Retrieve(
        string runID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/tests/{test_id}/runs</c>, but is otherwise the
/// same as <see cref="IRunService.List(RunListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RunListPage>> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<HttpResponse<RunListPage>> List(
        string testID,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/tests/{test_id}/runs</c>, but is otherwise the
/// same as <see cref="IRunService.Trigger(RunTriggerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TestRunResponse>> Trigger(
        RunTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Trigger(RunTriggerParams, CancellationToken)"/>
    Task<HttpResponse<TestRunResponse>> Trigger(
        string testID,
        RunTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}