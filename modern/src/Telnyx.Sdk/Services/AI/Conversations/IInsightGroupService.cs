using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.InsightGroups;
using InsightGroups = Telnyx.Sdk.Services.AI.Conversations.InsightGroups;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <summary>
/// Manage historical AI assistant conversations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInsightGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInsightGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInsightGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    InsightGroups::IInsightService Insights { get; }

    /// <summary>
/// Returns the details of a single insight template group, including the insight
/// templates assigned to it.
/// </summary>
    Task<InsightTemplateGroupDetail> Retrieve(
        InsightGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InsightGroupRetrieveParams, CancellationToken)"/>
    Task<InsightTemplateGroupDetail> Retrieve(
        string groupID,
        InsightGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified insight template group and returns the updated group.
/// </summary>
    Task<InsightTemplateGroupDetail> Update(
        InsightGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(InsightGroupUpdateParams, CancellationToken)"/>
    Task<InsightTemplateGroupDetail> Update(
        string groupID,
        InsightGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified insight template group by its ID.
/// </summary>
    Task Delete(
        InsightGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(InsightGroupDeleteParams, CancellationToken)"/>
    Task Delete(
        string groupID,
        InsightGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a new insight template group for organizing related insight templates,
/// and returns the created group.
/// </summary>
    Task<InsightTemplateGroupDetail> InsightGroups(
        InsightGroupInsightGroupsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your insight template groups. Groups organize
/// related insight templates that are applied together when analyzing
/// conversations.
/// </summary>
    Task<InsightGroupRetrieveInsightGroupsPage> RetrieveInsightGroups(
        InsightGroupRetrieveInsightGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInsightGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInsightGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInsightGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    InsightGroups::IInsightServiceWithRawResponse Insights { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/insight-groups/{group_id}</c>, but is otherwise the
/// same as <see cref="IInsightGroupService.Retrieve(InsightGroupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightTemplateGroupDetail>> Retrieve(
        InsightGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InsightGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InsightTemplateGroupDetail>> Retrieve(
        string groupID,
        InsightGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/conversations/insight-groups/{group_id}</c>, but is otherwise the
/// same as <see cref="IInsightGroupService.Update(InsightGroupUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightTemplateGroupDetail>> Update(
        InsightGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(InsightGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InsightTemplateGroupDetail>> Update(
        string groupID,
        InsightGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/conversations/insight-groups/{group_id}</c>, but is otherwise the
/// same as <see cref="IInsightGroupService.Delete(InsightGroupDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        InsightGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(InsightGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string groupID,
        InsightGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/conversations/insight-groups</c>, but is otherwise the
/// same as <see cref="IInsightGroupService.InsightGroups(InsightGroupInsightGroupsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightTemplateGroupDetail>> InsightGroups(
        InsightGroupInsightGroupsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/insight-groups</c>, but is otherwise the
/// same as <see cref="IInsightGroupService.RetrieveInsightGroups(InsightGroupRetrieveInsightGroupsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InsightGroupRetrieveInsightGroupsPage>> RetrieveInsightGroups(
        InsightGroupRetrieveInsightGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}