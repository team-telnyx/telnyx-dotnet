using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rooms;
using Rooms = Telnyx.Sdk.Services.Rooms;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RoomService : IRoomService
{
    readonly Lazy<IRoomServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoomServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRoomService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new RoomService(this._client.WithOptions(modifier)); }

    public RoomService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RoomServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Rooms::ActionService(client)) ;
        _sessions =new(() => new Rooms::SessionService(client)) ;
    }

    readonly Lazy<Rooms::IActionService> _actions;
    public Rooms::IActionService Actions { get { return _actions.Value; } }

    readonly Lazy<Rooms::ISessionService> _sessions;
    public Rooms::ISessionService Sessions { get { return _sessions.Value; } }

    /// <inheritdoc/>
    public async Task<RoomCreateResponse> Create(
        RoomCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RoomRetrieveResponse> Retrieve(
        RoomRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RoomRetrieveResponse> Retrieve(
        string roomID,
        RoomRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoomUpdateResponse> Update(
        RoomUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RoomUpdateResponse> Update(
        string roomID,
        RoomUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoomListPage> List(
        RoomListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        RoomDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string roomID,
        RoomDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            RoomID = roomID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RoomServiceWithRawResponse : IRoomServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoomServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RoomServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoomServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(() => new Rooms::ActionServiceWithRawResponse(client)) ;
        _sessions =new(() => new Rooms::SessionServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Rooms::IActionServiceWithRawResponse> _actions;
    public Rooms::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<Rooms::ISessionServiceWithRawResponse> _sessions;
    public Rooms::ISessionServiceWithRawResponse Sessions {
        get { return _sessions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomCreateResponse>> Create(
        RoomCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var room = await response.Deserialize<RoomCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                room.Validate();
            }
            return room;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomRetrieveResponse>> Retrieve(
        RoomRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomID' cannot be null"
            );
        }

        HttpRequest<RoomRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var room = await response.Deserialize<RoomRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                room.Validate();
            }
            return room;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RoomRetrieveResponse>> Retrieve(
        string roomID,
        RoomRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomUpdateResponse>> Update(
        RoomUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomID' cannot be null"
            );
        }

        HttpRequest<RoomUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var room = await response.Deserialize<RoomUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                room.Validate();
            }
            return room;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RoomUpdateResponse>> Update(
        string roomID,
        RoomUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomListPage>> List(
        RoomListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RoomListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RoomListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RoomDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomID' cannot be null"
            );
        }

        HttpRequest<RoomDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string roomID,
        RoomDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }
}