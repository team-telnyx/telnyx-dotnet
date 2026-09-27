using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tests;
using Telnyx.Sdk.Services.AI.Assistants.Tests;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ITestSuiteService TestSuites { get; }

    IRunService Runs { get; }

    /// <summary>
/// Creates a comprehensive test configuration for evaluating AI assistant
/// performance
/// </summary>
    Task<AssistantTest> Create(
        TestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves detailed information about a specific assistant test
/// </summary>
    Task<AssistantTest> Retrieve(
        TestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TestRetrieveParams, CancellationToken)"/>
    Task<AssistantTest> Retrieve(
        string testID,
        TestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates an existing assistant test configuration with new settings
/// </summary>
    Task<AssistantTest> Update(
        TestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TestUpdateParams, CancellationToken)"/>
    Task<AssistantTest> Update(
        string testID,
        TestUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a paginated list of assistant tests with optional filtering
/// capabilities
/// </summary>
    Task<TestListPage> List(
        TestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently removes an assistant test and all associated data
/// </summary>
    Task Delete(
        TestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TestDeleteParams, CancellationToken)"/>
    Task Delete(
        string testID,
        TestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ITestSuiteServiceWithRawResponse TestSuites { get; }

    IRunServiceWithRawResponse Runs { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/tests</c>, but is otherwise the
/// same as <see cref="ITestService.Create(TestCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantTest>> Create(
        TestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/tests/{test_id}</c>, but is otherwise the
/// same as <see cref="ITestService.Retrieve(TestRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantTest>> Retrieve(
        TestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TestRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AssistantTest>> Retrieve(
        string testID,
        TestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/assistants/tests/{test_id}</c>, but is otherwise the
/// same as <see cref="ITestService.Update(TestUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantTest>> Update(
        TestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TestUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AssistantTest>> Update(
        string testID,
        TestUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/tests</c>, but is otherwise the
/// same as <see cref="ITestService.List(TestListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TestListPage>> List(
        TestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/tests/{test_id}</c>, but is otherwise the
/// same as <see cref="ITestService.Delete(TestDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        TestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TestDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string testID,
        TestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}