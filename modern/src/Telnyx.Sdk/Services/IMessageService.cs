using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messages;
using Messages = Telnyx.Sdk.Services.Messages;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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

    Messages::IRcService Rcs { get; }

    /// <summary>
/// Note: This API endpoint can only retrieve messages that are no older than 10
/// days since their creation. If you require messages older than this, please
/// generate an [MDR
/// report.](https://developers.telnyx.com/api-reference/mdr-usage-reports/create-mdr-usage-report)
/// </summary>
    Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<MessageRetrieveResponse> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Cancel a scheduled message that has not yet been sent. Only messages with
/// `status=scheduled` and `send_at` more than a minute from now can be cancelled.
/// </summary>
    Task<MessageCancelScheduledResponse> CancelScheduled(
        MessageCancelScheduledParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CancelScheduled(MessageCancelScheduledParams, CancellationToken)"/>
    Task<MessageCancelScheduledResponse> CancelScheduled(
        string id,
        MessageCancelScheduledParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve all messages in a group MMS conversation by the group message ID.
/// </summary>
    Task<MessageRetrieveGroupMessagesResponse> RetrieveGroupMessages(
        MessageRetrieveGroupMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveGroupMessages(MessageRetrieveGroupMessagesParams, CancellationToken)"/>
    Task<MessageRetrieveGroupMessagesResponse> RetrieveGroupMessages(
        string messageID,
        MessageRetrieveGroupMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Schedule a message with a Phone Number, Alphanumeric Sender ID, Short Code or
/// Number Pool.
/// 
/// <para>This endpoint allows you to schedule a message with any messaging
/// resource. Current messaging resources include: long-code, short-code,
/// number-pool, and alphanumeric-sender-id. </para>
/// </summary>
    Task<MessageScheduleResponse> Schedule(
        MessageScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Send a message with a Phone Number, Alphanumeric Sender ID, Short Code or Number
/// Pool.
/// 
/// <para>This endpoint allows you to send a message with any messaging resource.
/// Current messaging resources include: long-code, short-code, number-pool, and
/// alphanumeric-sender-id. </para>
/// </summary>
    Task<MessageSendResponse> Send(
        MessageSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Queues an MMS addressed to multiple recipients as a group conversation. Delivery
/// events are reported asynchronously through messaging webhooks.
/// </summary>
    Task<MessageSendGroupMmsResponse> SendGroupMms(
        MessageSendGroupMmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Queues an outbound SMS or MMS using a long-code sender. Delivery progress and
/// final disposition are reported asynchronously through messaging webhooks.
/// </summary>
    Task<MessageSendLongCodeResponse> SendLongCode(
        MessageSendLongCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Queues an outbound message using a number pool. Telnyx selects an eligible
/// sender from the pool according to its messaging profile configuration.
/// </summary>
    Task<MessageSendNumberPoolResponse> SendNumberPool(
        MessageSendNumberPoolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Queues an outbound SMS or MMS using a short-code sender. Delivery progress and
/// final disposition are reported asynchronously through messaging webhooks.
/// </summary>
    Task<MessageSendShortCodeResponse> SendShortCode(
        MessageSendShortCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Send an SMS message using an alphanumeric sender ID. This is SMS only.
/// </summary>
    Task<MessageSendWithAlphanumericSenderResponse> SendWithAlphanumericSender(
        MessageSendWithAlphanumericSenderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends a WhatsApp message using a Telnyx WhatsApp-enabled number. The message
/// body, interactive elements, media, location, and reaction content are specified
/// in the `whatsapp_message` field. Delivery progress and final disposition are
/// reported asynchronously through messaging webhooks.
/// </summary>
    Task<MessageWhatsappResponse> Whatsapp(
        MessageWhatsappParams parameters,
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

    Messages::IRcServiceWithRawResponse Rcs { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /messages/{id}</c>, but is otherwise the
/// same as <see cref="IMessageService.Retrieve(MessageRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /messages/{id}</c>, but is otherwise the
/// same as <see cref="IMessageService.CancelScheduled(MessageCancelScheduledParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageCancelScheduledResponse>> CancelScheduled(
        MessageCancelScheduledParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CancelScheduled(MessageCancelScheduledParams, CancellationToken)"/>
    Task<HttpResponse<MessageCancelScheduledResponse>> CancelScheduled(
        string id,
        MessageCancelScheduledParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messages/group/{message_id}</c>, but is otherwise the
/// same as <see cref="IMessageService.RetrieveGroupMessages(MessageRetrieveGroupMessagesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageRetrieveGroupMessagesResponse>> RetrieveGroupMessages(
        MessageRetrieveGroupMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveGroupMessages(MessageRetrieveGroupMessagesParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveGroupMessagesResponse>> RetrieveGroupMessages(
        string messageID,
        MessageRetrieveGroupMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/schedule</c>, but is otherwise the
/// same as <see cref="IMessageService.Schedule(MessageScheduleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageScheduleResponse>> Schedule(
        MessageScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages</c>, but is otherwise the
/// same as <see cref="IMessageService.Send(MessageSendParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageSendResponse>> Send(
        MessageSendParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/group_mms</c>, but is otherwise the
/// same as <see cref="IMessageService.SendGroupMms(MessageSendGroupMmsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageSendGroupMmsResponse>> SendGroupMms(
        MessageSendGroupMmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/long_code</c>, but is otherwise the
/// same as <see cref="IMessageService.SendLongCode(MessageSendLongCodeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageSendLongCodeResponse>> SendLongCode(
        MessageSendLongCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/number_pool</c>, but is otherwise the
/// same as <see cref="IMessageService.SendNumberPool(MessageSendNumberPoolParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageSendNumberPoolResponse>> SendNumberPool(
        MessageSendNumberPoolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/short_code</c>, but is otherwise the
/// same as <see cref="IMessageService.SendShortCode(MessageSendShortCodeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageSendShortCodeResponse>> SendShortCode(
        MessageSendShortCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/alphanumeric_sender_id</c>, but is otherwise the
/// same as <see cref="IMessageService.SendWithAlphanumericSender(MessageSendWithAlphanumericSenderParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageSendWithAlphanumericSenderResponse>> SendWithAlphanumericSender(
        MessageSendWithAlphanumericSenderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messages/whatsapp</c>, but is otherwise the
/// same as <see cref="IMessageService.Whatsapp(MessageWhatsappParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageWhatsappResponse>> Whatsapp(
        MessageWhatsappParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}