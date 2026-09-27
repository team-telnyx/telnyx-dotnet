using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.InsightGroups.Insights;

namespace Telnyx.Sdk.Services.AI.Conversations.InsightGroups;

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
/// Assigns the specified insight template to the specified insight template group.
/// </summary>
    Task Assign(
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Assign(InsightAssignParams, CancellationToken)"/>
    Task Assign(
        string insightID,
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified insight template from the specified group. The insight
/// template itself is not deleted.
/// </summary>
    Task DeleteUnassign(
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteUnassign(InsightDeleteUnassignParams, CancellationToken)"/>
    Task DeleteUnassign(
        string insightID,
        InsightDeleteUnassignParams parameters,
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
/// Returns a raw HTTP response for <c>post /ai/conversations/insight-groups/{group_id}/insights/{insight_id}/assign</c>, but is otherwise the
/// same as <see cref="IInsightService.Assign(InsightAssignParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Assign(
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Assign(InsightAssignParams, CancellationToken)"/>
    Task<HttpResponse> Assign(
        string insightID,
        InsightAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/conversations/insight-groups/{group_id}/insights/{insight_id}/unassign</c>, but is otherwise the
/// same as <see cref="IInsightService.DeleteUnassign(InsightDeleteUnassignParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteUnassign(
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteUnassign(InsightDeleteUnassignParams, CancellationToken)"/>
    Task<HttpResponse> DeleteUnassign(
        string insightID,
        InsightDeleteUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}