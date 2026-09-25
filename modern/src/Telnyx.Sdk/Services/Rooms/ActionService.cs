using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rooms.Actions;

namespace Telnyx.Sdk.Services.Rooms;

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
    public async Task<ActionGenerateJoinClientTokenResponse> GenerateJoinClientToken(
        ActionGenerateJoinClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GenerateJoinClientToken(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionGenerateJoinClientTokenResponse> GenerateJoinClientToken(
        string roomID,
        ActionGenerateJoinClientTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GenerateJoinClientToken(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionRefreshClientTokenResponse> RefreshClientToken(
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RefreshClientToken(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionRefreshClientTokenResponse> RefreshClientToken(
        string roomID,
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RefreshClientToken(parameters with{
            RoomID = roomID
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
    public async Task<HttpResponse<ActionGenerateJoinClientTokenResponse>> GenerateJoinClientToken(
        ActionGenerateJoinClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomID' cannot be null"
            );
        }

        HttpRequest<ActionGenerateJoinClientTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionGenerateJoinClientTokenResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionGenerateJoinClientTokenResponse>> GenerateJoinClientToken(
        string roomID,
        ActionGenerateJoinClientTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GenerateJoinClientToken(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionRefreshClientTokenResponse>> RefreshClientToken(
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomID' cannot be null"
            );
        }

        HttpRequest<ActionRefreshClientTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionRefreshClientTokenResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionRefreshClientTokenResponse>> RefreshClientToken(
        string roomID,
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RefreshClientToken(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }
}