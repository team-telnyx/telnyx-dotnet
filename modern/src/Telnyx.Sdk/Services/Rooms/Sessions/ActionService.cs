using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rooms.Sessions.Actions;

namespace Telnyx.Sdk.Services.Rooms.Sessions;

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
    public async Task<ActionEndResponse> End(
        ActionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.End(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionEndResponse> End(
        string roomSessionID,
        ActionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.End(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionKickResponse> Kick(
        ActionKickParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Kick(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionKickResponse> Kick(
        string roomSessionID,
        ActionKickParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Kick(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionMuteResponse> Mute(
        ActionMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Mute(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionMuteResponse> Mute(
        string roomSessionID,
        ActionMuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Mute(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionUnmuteResponse> Unmute(
        ActionUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Unmute(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionUnmuteResponse> Unmute(
        string roomSessionID,
        ActionUnmuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unmute(parameters with{
            RoomSessionID = roomSessionID
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
    public async Task<HttpResponse<ActionEndResponse>> End(
        ActionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomSessionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomSessionID' cannot be null"
            );
        }

        HttpRequest<ActionEndParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionEndResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionEndResponse>> End(
        string roomSessionID,
        ActionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.End(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionKickResponse>> Kick(
        ActionKickParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomSessionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomSessionID' cannot be null"
            );
        }

        HttpRequest<ActionKickParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionKickResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionKickResponse>> Kick(
        string roomSessionID,
        ActionKickParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Kick(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionMuteResponse>> Mute(
        ActionMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomSessionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomSessionID' cannot be null"
            );
        }

        HttpRequest<ActionMuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionMuteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionMuteResponse>> Mute(
        string roomSessionID,
        ActionMuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Mute(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionUnmuteResponse>> Unmute(
        ActionUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomSessionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomSessionID' cannot be null"
            );
        }

        HttpRequest<ActionUnmuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionUnmuteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionUnmuteResponse>> Unmute(
        string roomSessionID,
        ActionUnmuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unmute(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }
}