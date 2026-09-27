using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.Messages;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <summary>
/// Manage historical AI assistant conversations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve messages for a specific conversation, including tool calls made by the
/// assistant.
/// </summary>
    Task<MessageListPage> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(MessageListParams, CancellationToken)"/>
    Task<MessageListPage> List(
        string conversationID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/conversations/{conversation_id}/messages</c>, but is otherwise the
/// same as <see cref="IMessageService.List(MessageListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageListPage>> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(MessageListParams, CancellationToken)"/>
    Task<HttpResponse<MessageListPage>> List(
        string conversationID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}