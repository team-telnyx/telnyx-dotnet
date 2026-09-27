using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MeetingSessions.Actions;

namespace Telnyx.Sdk.Services.MeetingSessions;

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
    public async Task<ActionAcceptedResponse> SendChat(
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendChat(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionAcceptedResponse> SendChat(
        string id,
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendChat(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionAcceptedResponse> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Speak(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionAcceptedResponse> Speak(
        string id,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Speak(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionAcceptedResponse> StopSpeaking(
        ActionStopSpeakingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StopSpeaking(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionAcceptedResponse> StopSpeaking(
        string id,
        ActionStopSpeakingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopSpeaking(parameters with{
            ID = id
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
    public async Task<HttpResponse<ActionAcceptedResponse>> SendChat(
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ActionSendChatParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var actionAcceptedResponse = await response.Deserialize<ActionAcceptedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                actionAcceptedResponse.Validate();
            }
            return actionAcceptedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionAcceptedResponse>> SendChat(
        string id,
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendChat(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionAcceptedResponse>> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ActionSpeakParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var actionAcceptedResponse = await response.Deserialize<ActionAcceptedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                actionAcceptedResponse.Validate();
            }
            return actionAcceptedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionAcceptedResponse>> Speak(
        string id,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Speak(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionAcceptedResponse>> StopSpeaking(
        ActionStopSpeakingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ActionStopSpeakingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var actionAcceptedResponse = await response.Deserialize<ActionAcceptedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                actionAcceptedResponse.Validate();
            }
            return actionAcceptedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionAcceptedResponse>> StopSpeaking(
        string id,
        ActionStopSpeakingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopSpeaking(parameters with{
            ID = id
        }, cancellationToken);
    }
}