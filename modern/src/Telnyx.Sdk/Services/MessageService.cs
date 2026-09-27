using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messages;
using Messages = Telnyx.Sdk.Services.Messages;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessageService : IMessageService
{
    readonly Lazy<IMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessageService(this._client.WithOptions(modifier)); }

    public MessageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessageServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _rcs =new(() => new Messages::RcService(client)) ;
    }

    readonly Lazy<Messages::IRcService> _rcs;
    public Messages::IRcService Rcs { get { return _rcs.Value; } }

    /// <inheritdoc/>
    public async Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageRetrieveResponse> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageCancelScheduledResponse> CancelScheduled(
        MessageCancelScheduledParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CancelScheduled(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageCancelScheduledResponse> CancelScheduled(
        string id,
        MessageCancelScheduledParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelScheduled(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageRetrieveGroupMessagesResponse> RetrieveGroupMessages(
        MessageRetrieveGroupMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveGroupMessages(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageRetrieveGroupMessagesResponse> RetrieveGroupMessages(
        string messageID,
        MessageRetrieveGroupMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveGroupMessages(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageScheduleResponse> Schedule(
        MessageScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Schedule(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageSendResponse> Send(
        MessageSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Send(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageSendGroupMmsResponse> SendGroupMms(
        MessageSendGroupMmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendGroupMms(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageSendLongCodeResponse> SendLongCode(
        MessageSendLongCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendLongCode(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageSendNumberPoolResponse> SendNumberPool(
        MessageSendNumberPoolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendNumberPool(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageSendShortCodeResponse> SendShortCode(
        MessageSendShortCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendShortCode(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageSendWithAlphanumericSenderResponse> SendWithAlphanumericSender(
        MessageSendWithAlphanumericSenderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendWithAlphanumericSender(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageWhatsappResponse> Whatsapp(
        MessageWhatsappParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Whatsapp(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessageServiceWithRawResponse : IMessageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessageServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _rcs =new(() => new Messages::RcServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Messages::IRcServiceWithRawResponse> _rcs;
    public Messages::IRcServiceWithRawResponse Rcs {
        get { return _rcs.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var message = await response.Deserialize<MessageRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                message.Validate();
            }
            return message;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageCancelScheduledResponse>> CancelScheduled(
        MessageCancelScheduledParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessageCancelScheduledParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageCancelScheduledResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageCancelScheduledResponse>> CancelScheduled(
        string id,
        MessageCancelScheduledParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelScheduled(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageRetrieveGroupMessagesResponse>> RetrieveGroupMessages(
        MessageRetrieveGroupMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessageID' cannot be null"
            );
        }

        HttpRequest<MessageRetrieveGroupMessagesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageRetrieveGroupMessagesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageRetrieveGroupMessagesResponse>> RetrieveGroupMessages(
        string messageID,
        MessageRetrieveGroupMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveGroupMessages(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageScheduleResponse>> Schedule(
        MessageScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageScheduleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageScheduleResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendResponse>> Send(
        MessageSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageSendResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendGroupMmsResponse>> SendGroupMms(
        MessageSendGroupMmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendGroupMmsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageSendGroupMmsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendLongCodeResponse>> SendLongCode(
        MessageSendLongCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendLongCodeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageSendLongCodeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendNumberPoolResponse>> SendNumberPool(
        MessageSendNumberPoolParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendNumberPoolParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageSendNumberPoolResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendShortCodeResponse>> SendShortCode(
        MessageSendShortCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendShortCodeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageSendShortCodeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendWithAlphanumericSenderResponse>> SendWithAlphanumericSender(
        MessageSendWithAlphanumericSenderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendWithAlphanumericSenderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageSendWithAlphanumericSenderResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageWhatsappResponse>> Whatsapp(
        MessageWhatsappParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageWhatsappParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessageWhatsappResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}