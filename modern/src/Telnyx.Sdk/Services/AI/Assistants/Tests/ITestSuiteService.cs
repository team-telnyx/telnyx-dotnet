using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites;
using TestSuites = Telnyx.Sdk.Services.AI.Assistants.Tests.TestSuites;

namespace Telnyx.Sdk.Services.AI.Assistants.Tests;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITestSuiteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITestSuiteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITestSuiteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    TestSuites::IRunService Runs { get; }

    /// <summary>
/// Retrieves a list of all distinct test suite names available to the current user
/// </summary>
    Task<TestSuiteListResponse> List(
        TestSuiteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITestSuiteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITestSuiteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITestSuiteServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    TestSuites::IRunServiceWithRawResponse Runs { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/tests/test-suites</c>, but is otherwise the
/// same as <see cref="ITestSuiteService.List(TestSuiteListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TestSuiteListResponse>> List(
        TestSuiteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}