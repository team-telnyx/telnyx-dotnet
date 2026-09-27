using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailInboxes.Messages;
using Messages = Telnyx.Sdk.Services.EmailInboxes.Messages;

namespace Telnyx.Sdk.Services.EmailInboxes;

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
        _actions =new(() => new Messages::ActionService(client)) ;
        _labels =new(() => new Messages::LabelService(client)) ;
    }

    readonly Lazy<Messages::IActionService> _actions;
    public Messages::IActionService Actions { get { return _actions.Value; } }

    readonly Lazy<Messages::ILabelService> _labels;
    public Messages::ILabelService Labels { get { return _labels.Value; } }

    /// <inheritdoc/>
    public async Task<MessageUpdateResponse> Update(
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageUpdateResponse> Update(
        string messageID,
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageListPage> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageListPage> List(
        string inboxID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDraftResponse> Drafts(
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Drafts(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDraftResponse> Drafts(
        string messageID,
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Drafts(parameters with{
            MessageID = messageID
        }, cancellationToken);
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

        _actions =new(
            () => new Messages::ActionServiceWithRawResponse(client)
        ) ;
        _labels =new(() => new Messages::LabelServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Messages::IActionServiceWithRawResponse> _actions;
    public Messages::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<Messages::ILabelServiceWithRawResponse> _labels;
    public Messages::ILabelServiceWithRawResponse Labels {
        get { return _labels.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageUpdateResponse>> Update(
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessageID' cannot be null"
            );
        }

        HttpRequest<MessageUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var message = await response.Deserialize<MessageUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                message.Validate();
            }
            return message;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageUpdateResponse>> Update(
        string messageID,
        MessageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageListPage>> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<MessageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessageListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessageListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageListPage>> List(
        string inboxID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDraftResponse>> Drafts(
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessageID' cannot be null"
            );
        }

        HttpRequest<MessageDraftsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDraftResponse = await response.Deserialize<EmailDraftResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDraftResponse.Validate();
            }
            return emailDraftResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDraftResponse>> Drafts(
        string messageID,
        MessageDraftsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Drafts(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }
}