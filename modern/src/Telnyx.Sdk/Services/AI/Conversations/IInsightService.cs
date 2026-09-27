using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.Insights;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <summary>
/// Manage historical AI assistant conversations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInsightService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInsightServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInsightService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new insight template defining an analysis to run over conversations,
/// and returns the created template.
/// </summary>
    Task<InsightTemplateDetail> Create(
        InsightCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single insight template by its ID, including its
/// configuration.
/// </summary>
    Task<InsightTemplateDetail> Retrieve(
        InsightRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InsightRetrieveParams, CancellationToken)"/>
    Task<InsightTemplateDetail> Retrieve(
        string insightID,
        InsightRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified insight template and returns the updated template.
/// </summary>
    Task<InsightTemplateDetail> Update(
        InsightUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(InsightUpdateParams, CancellationToken)"/>
    Task<InsightTemplateDetail> Update(
        string insightID,
        InsightUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your insight templates. Insight templates define
/// analyses that run over AI conversations to extract structured findings.
/// </summary>
    Task<InsightListPage> List(
        InsightListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified insight template by its ID.
/// </summary>
    Task Delete(
        InsightDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(InsightDeleteParams, CancellationToken)"/>
    Task Delete(
        string insightID,
        InsightDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInsightService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInsightServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInsightServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/conversations/insights</c>, but is otherwise the
/// same as <see cref="IInsightService.Create(InsightCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightTemplateDetail>> Create(
        InsightCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/insights/{insight_id}</c>, but is otherwise the
/// same as <see cref="IInsightService.Retrieve(InsightRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightTemplateDetail>> Retrieve(
        InsightRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InsightRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InsightTemplateDetail>> Retrieve(
        string insightID,
        InsightRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/conversations/insights/{insight_id}</c>, but is otherwise the
/// same as <see cref="IInsightService.Update(InsightUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightTemplateDetail>> Update(
        InsightUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(InsightUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InsightTemplateDetail>> Update(
        string insightID,
        InsightUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/insights</c>, but is otherwise the
/// same as <see cref="IInsightService.List(InsightListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightListPage>> List(
        InsightListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/conversations/insights/{insight_id}</c>, but is otherwise the
/// same as <see cref="IInsightService.Delete(InsightDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        InsightDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(InsightDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string insightID,
        InsightDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}