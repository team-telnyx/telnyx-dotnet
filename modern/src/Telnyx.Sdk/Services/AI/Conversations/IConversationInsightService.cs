using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.ConversationInsights;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <summary>
/// Manage historical AI assistant conversations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConversationInsightService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConversationInsightServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationInsightService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Aggregate conversation insights by specified fields
/// </summary>
    Task<ConversationInsightRetrieveAggregatesResponse> RetrieveAggregates(
        ConversationInsightRetrieveAggregatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IConversationInsightService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConversationInsightServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationInsightServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/conversation-insights/aggregates</c>, but is otherwise the
/// same as <see cref="IConversationInsightService.RetrieveAggregates(ConversationInsightRetrieveAggregatesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationInsightRetrieveAggregatesResponse>> RetrieveAggregates(
        ConversationInsightRetrieveAggregatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}