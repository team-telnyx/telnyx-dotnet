using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations;
using Conversations = Telnyx.Sdk.Services.AI.Conversations;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// Manage historical AI assistant conversations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConversationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Conversations::IInsightGroupService InsightGroups { get; }

    Conversations::IInsightService Insights { get; }

    Conversations::IMessageService Messages { get; }

    Conversations::IConversationInsightService ConversationInsights { get; }

    /// <summary>
/// Creates a new AI conversation, the container for messages exchanged with an
/// assistant, and returns the created conversation.
/// </summary>
    Task<Conversation> Create(
        ConversationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a specific AI conversation by its ID.
/// </summary>
    Task<ConversationRetrieveResponse> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConversationRetrieveParams, CancellationToken)"/>
    Task<ConversationRetrieveResponse> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update metadata for a specific conversation.
/// </summary>
    Task<ConversationUpdateResponse> Update(
        ConversationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ConversationUpdateParams, CancellationToken)"/>
    Task<ConversationUpdateResponse> Update(
        string conversationID,
        ConversationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of all AI conversations configured by the user. Supports
/// [PostgREST-style query
/// parameters](https://postgrest.org/en/stable/api.html#horizontal-filtering-rows)
/// for filtering. Examples are included for the standard metadata fields, but you
/// can filter on any field in the metadata JSON object. For example, to filter by a
/// custom field `metadata-&gt;custom_field`, use
/// `metadata-&gt;custom_field=eq.value`.
/// </summary>
    Task<ConversationListResponse> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a specific conversation by its ID.
/// </summary>
    Task Delete(
        ConversationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ConversationDeleteParams, CancellationToken)"/>
    Task Delete(
        string conversationID,
        ConversationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Add a new message to the conversation. Used to insert a new messages to a
/// conversation manually ( without using chat endpoint )
/// </summary>
    Task AddMessage(
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AddMessage(ConversationAddMessageParams, CancellationToken)"/>
    Task AddMessage(
        string conversationID,
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve insights for a specific conversation
/// </summary>
    Task<ConversationRetrieveConversationsInsightsResponse> RetrieveConversationsInsights(
        ConversationRetrieveConversationsInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConversationsInsights(ConversationRetrieveConversationsInsightsParams, CancellationToken)"/>
    Task<ConversationRetrieveConversationsInsightsResponse> RetrieveConversationsInsights(
        string conversationID,
        ConversationRetrieveConversationsInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IConversationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConversationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Conversations::IInsightGroupServiceWithRawResponse InsightGroups { get; }

    Conversations::IInsightServiceWithRawResponse Insights { get; }

    Conversations::IMessageServiceWithRawResponse Messages { get; }

    Conversations::IConversationInsightServiceWithRawResponse ConversationInsights {
        get;
    }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/conversations</c>, but is otherwise the
/// same as <see cref="IConversationService.Create(ConversationCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Conversation>> Create(
        ConversationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/{conversation_id}</c>, but is otherwise the
/// same as <see cref="IConversationService.Retrieve(ConversationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConversationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/conversations/{conversation_id}</c>, but is otherwise the
/// same as <see cref="IConversationService.Update(ConversationUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationUpdateResponse>> Update(
        ConversationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ConversationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ConversationUpdateResponse>> Update(
        string conversationID,
        ConversationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations</c>, but is otherwise the
/// same as <see cref="IConversationService.List(ConversationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationListResponse>> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/conversations/{conversation_id}</c>, but is otherwise the
/// same as <see cref="IConversationService.Delete(ConversationDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        ConversationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ConversationDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string conversationID,
        ConversationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/conversations/{conversation_id}/message</c>, but is otherwise the
/// same as <see cref="IConversationService.AddMessage(ConversationAddMessageParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> AddMessage(
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AddMessage(ConversationAddMessageParams, CancellationToken)"/>
    Task<HttpResponse> AddMessage(
        string conversationID,
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/{conversation_id}/conversations-insights</c>, but is otherwise the
/// same as <see cref="IConversationService.RetrieveConversationsInsights(ConversationRetrieveConversationsInsightsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationRetrieveConversationsInsightsResponse>> RetrieveConversationsInsights(
        ConversationRetrieveConversationsInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConversationsInsights(ConversationRetrieveConversationsInsightsParams, CancellationToken)"/>
    Task<HttpResponse<ConversationRetrieveConversationsInsightsResponse>> RetrieveConversationsInsights(
        string conversationID,
        ConversationRetrieveConversationsInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}