using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailInboxes.Messages.Actions;

namespace Telnyx.Sdk.Services.EmailInboxes.Messages;

/// <inheritdoc/>
public sealed class ActionService : IActionService
{
    readonly Lazy<IActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IActionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ActionService(this._client.WithOptions(modifier)); }

    public ActionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ActionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailMessageResponse> Forward(
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Forward(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageResponse> Forward(
        string messageID,
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Forward(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageResponse> Reply(
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Reply(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageResponse> Reply(
        string messageID,
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reply(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageResponse> ReplyAll(
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ReplyAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageResponse> ReplyAll(
        string messageID,
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ReplyAll(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ActionServiceWithRawResponse : IActionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageResponse>> Forward(
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessageID' cannot be null"
            );
        }

        HttpRequest<ActionForwardParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailMessageResponse = await response.Deserialize<EmailMessageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailMessageResponse.Validate();
            }
            return emailMessageResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageResponse>> Forward(
        string messageID,
        ActionForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Forward(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageResponse>> Reply(
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessageID' cannot be null"
            );
        }

        HttpRequest<ActionReplyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailMessageResponse = await response.Deserialize<EmailMessageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailMessageResponse.Validate();
            }
            return emailMessageResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageResponse>> Reply(
        string messageID,
        ActionReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reply(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageResponse>> ReplyAll(
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessageID' cannot be null"
            );
        }

        HttpRequest<ActionReplyAllParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailMessageResponse = await response.Deserialize<EmailMessageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailMessageResponse.Validate();
            }
            return emailMessageResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageResponse>> ReplyAll(
        string messageID,
        ActionReplyAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ReplyAll(parameters with{
            MessageID = messageID
        }, cancellationToken);
    }
}