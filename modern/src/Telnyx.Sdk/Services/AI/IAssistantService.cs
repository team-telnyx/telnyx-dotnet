using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants;
using Assistants = Telnyx.Sdk.Services.AI.Assistants;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAssistantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAssistantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssistantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Assistants::ITestService Tests { get; }

    Assistants::ICanaryDeployService CanaryDeploys { get; }

    Assistants::IScheduledEventService ScheduledEvents { get; }

    Assistants::IToolService Tools { get; }

    Assistants::IVersionService Versions { get; }

    Assistants::ITagService Tags { get; }

    Assistants::IInstructionService Instructions { get; }

    /// <summary>
/// Creates a new AI assistant from the provided configuration, including its model,
/// instructions, and attached tools, and returns the created assistant.
/// </summary>
    Task<InferenceEmbedding> Create(
        AssistantCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve an AI Assistant configuration by `assistant_id`.
/// </summary>
    Task<InferenceEmbedding> Retrieve(
        AssistantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AssistantRetrieveParams, CancellationToken)"/>
    Task<InferenceEmbedding> Retrieve(
        string assistantID,
        AssistantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified AI assistant's attributes and returns the updated
/// assistant. The request can also control how the change is promoted across
/// assistant versions.
/// </summary>
    Task<InferenceEmbedding> Update(
        AssistantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AssistantUpdateParams, CancellationToken)"/>
    Task<InferenceEmbedding> Update(
        string assistantID,
        AssistantUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of all AI Assistants configured by the user.
/// </summary>
    Task<AssistantsList> List(
        AssistantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete an AI Assistant by `assistant_id`.
/// </summary>
    Task<AssistantDeleteResponse> Delete(
        AssistantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AssistantDeleteParams, CancellationToken)"/>
    Task<AssistantDeleteResponse> Delete(
        string assistantID,
        AssistantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This endpoint allows a client to send a chat message to a specific AI Assistant.
/// The assistant processes the message and returns a relevant reply based on the
/// current conversation context. Refer to the Conversation API to [create a
/// conversation](https://developers.telnyx.com/api-reference/conversations/create-a-conversation),
/// [filter existing
/// conversations](https://developers.telnyx.com/api-reference/conversations/list-conversations),
/// [fetch messages for a
/// conversation](https://developers.telnyx.com/api-reference/conversations/get-conversation-messages),
/// and [manually add messages to a
/// conversation](https://developers.telnyx.com/api-reference/conversations/create-message).
/// </summary>
    Task<AssistantChatResponse> Chat(
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Chat(AssistantChatParams, CancellationToken)"/>
    Task<AssistantChatResponse> Chat(
        string assistantID,
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Clone an existing assistant, excluding telephony and messaging settings.
/// </summary>
    Task<InferenceEmbedding> Clone(
        AssistantCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Clone(AssistantCloneParams, CancellationToken)"/>
    Task<InferenceEmbedding> Clone(
        string assistantID,
        AssistantCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get an assistant texml by `assistant_id`.
/// </summary>
    Task<string> GetTexml(
        AssistantGetTexmlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetTexml(AssistantGetTexmlParams, CancellationToken)"/>
    Task<string> GetTexml(
        string assistantID,
        AssistantGetTexmlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Import assistants from external providers. Any assistant that has already been
/// imported will be overwritten with its latest version from the importing
/// provider.
/// </summary>
    Task<AssistantsList> Imports(
        AssistantImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Send an SMS message for an assistant. This endpoint:  1. Validates the assistant exists
/// and has messaging profile configured  2. If should_create_conversation is true,
/// creates a new conversation with metadata  3. Sends the SMS message (If `text` is set,
/// this will be sent. Otherwise, if this is the first message in the conversation and
/// the assistant has a `greeting` configured, this will be sent. Otherwise the assistant
/// will generate the text to send.)  4. Updates conversation metadata if provided  5.
/// Returns the conversation ID
/// </summary>
    Task<AssistantSendSmsResponse> SendSms(
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendSms(AssistantSendSmsParams, CancellationToken)"/>
    Task<AssistantSendSmsResponse> SendSms(
        string assistantID,
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAssistantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAssistantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssistantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Assistants::ITestServiceWithRawResponse Tests { get; }

    Assistants::ICanaryDeployServiceWithRawResponse CanaryDeploys { get; }

    Assistants::IScheduledEventServiceWithRawResponse ScheduledEvents { get; }

    Assistants::IToolServiceWithRawResponse Tools { get; }

    Assistants::IVersionServiceWithRawResponse Versions { get; }

    Assistants::ITagServiceWithRawResponse Tags { get; }

    Assistants::IInstructionServiceWithRawResponse Instructions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants</c>, but is otherwise the
/// same as <see cref="IAssistantService.Create(AssistantCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Create(
        AssistantCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}</c>, but is otherwise the
/// same as <see cref="IAssistantService.Retrieve(AssistantRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Retrieve(
        AssistantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AssistantRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InferenceEmbedding>> Retrieve(
        string assistantID,
        AssistantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}</c>, but is otherwise the
/// same as <see cref="IAssistantService.Update(AssistantUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Update(
        AssistantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AssistantUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InferenceEmbedding>> Update(
        string assistantID,
        AssistantUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants</c>, but is otherwise the
/// same as <see cref="IAssistantService.List(AssistantListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantsList>> List(
        AssistantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/{assistant_id}</c>, but is otherwise the
/// same as <see cref="IAssistantService.Delete(AssistantDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantDeleteResponse>> Delete(
        AssistantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AssistantDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AssistantDeleteResponse>> Delete(
        string assistantID,
        AssistantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/chat</c>, but is otherwise the
/// same as <see cref="IAssistantService.Chat(AssistantChatParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantChatResponse>> Chat(
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Chat(AssistantChatParams, CancellationToken)"/>
    Task<HttpResponse<AssistantChatResponse>> Chat(
        string assistantID,
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/clone</c>, but is otherwise the
/// same as <see cref="IAssistantService.Clone(AssistantCloneParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Clone(
        AssistantCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Clone(AssistantCloneParams, CancellationToken)"/>
    Task<HttpResponse<InferenceEmbedding>> Clone(
        string assistantID,
        AssistantCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}/texml</c>, but is otherwise the
/// same as <see cref="IAssistantService.GetTexml(AssistantGetTexmlParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> GetTexml(
        AssistantGetTexmlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetTexml(AssistantGetTexmlParams, CancellationToken)"/>
    Task<HttpResponse<string>> GetTexml(
        string assistantID,
        AssistantGetTexmlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/import</c>, but is otherwise the
/// same as <see cref="IAssistantService.Imports(AssistantImportsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantsList>> Imports(
        AssistantImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/chat/sms</c>, but is otherwise the
/// same as <see cref="IAssistantService.SendSms(AssistantSendSmsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantSendSmsResponse>> SendSms(
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendSms(AssistantSendSmsParams, CancellationToken)"/>
    Task<HttpResponse<AssistantSendSmsResponse>> SendSms(
        string assistantID,
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}