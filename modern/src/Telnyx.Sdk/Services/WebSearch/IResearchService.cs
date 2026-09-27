using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WebSearch.Research;

namespace Telnyx.Sdk.Services.WebSearch;

/// <summary>
/// Deep research with citations and async task polling.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IResearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IResearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Starts a deep research task that runs multiple searches, reads sources, and
/// synthesizes an answer with citations.
/// 
/// <para>## Synchronous mode (default)</para>
/// 
/// <para>When `background` is `false` or omitted, the request blocks until the
/// research completes and returns the answer with citations. This can take up to
/// 120 seconds depending on `research_effort`.</para>
/// 
/// <para>## Asynchronous mode</para>
/// 
/// <para>When `background` is `true`, the request returns immediately with a
/// `task_id` and `status: pending`. Poll `GET /web_search/research/{task_id}` to
/// check when the research completes and retrieve the answer.</para>
/// </summary>
    Task<ResearchCreateResponse> Create(
        ResearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Polls the status of a previously started asynchronous research task. When the
/// status is `completed`, the response includes the answer and citations. When the
/// status is `failed`, the response includes an error message.
/// </summary>
    Task<ResearchRetrieveResponse> Retrieve(
        ResearchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ResearchRetrieveParams, CancellationToken)"/>
    Task<ResearchRetrieveResponse> Retrieve(
        string taskID,
        ResearchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IResearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IResearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /web_search/research</c>, but is otherwise the
/// same as <see cref="IResearchService.Create(ResearchCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ResearchCreateResponse>> Create(
        ResearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /web_search/research/{task_id}</c>, but is otherwise the
/// same as <see cref="IResearchService.Retrieve(ResearchRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ResearchRetrieveResponse>> Retrieve(
        ResearchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ResearchRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ResearchRetrieveResponse>> Retrieve(
        string taskID,
        ResearchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}