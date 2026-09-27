using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;
using Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Services.AI.Assistants.Tests.TestSuites;

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
/// Retrieves paginated history of test runs for a specific test suite with
/// filtering options
/// </summary>
    Task<RunListPage> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<RunListPage> List(
        string suiteName,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Executes all tests within a specific test suite as a batch operation
/// </summary>
    Task<List<Runs::TestRunResponse>> Trigger(
        RunTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Trigger(RunTriggerParams, CancellationToken)"/>
    Task<List<Runs::TestRunResponse>> Trigger(
        string suiteName,
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
/// Returns a raw HTTP response for <c>get /ai/assistants/tests/test-suites/{suite_name}/runs</c>, but is otherwise the
/// same as <see cref="IRunService.List(RunListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RunListPage>> List(
        RunListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<HttpResponse<RunListPage>> List(
        string suiteName,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/tests/test-suites/{suite_name}/runs</c>, but is otherwise the
/// same as <see cref="IRunService.Trigger(RunTriggerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<Runs::TestRunResponse>>> Trigger(
        RunTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Trigger(RunTriggerParams, CancellationToken)"/>
    Task<HttpResponse<List<Runs::TestRunResponse>>> Trigger(
        string suiteName,
        RunTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}