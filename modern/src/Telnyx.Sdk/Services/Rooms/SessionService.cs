using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rooms.Sessions;
using Sessions = Telnyx.Sdk.Services.Rooms.Sessions;

namespace Telnyx.Sdk.Services.Rooms;

/// <inheritdoc/>
public sealed class SessionService : ISessionService
{
    readonly Lazy<ISessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISessionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISessionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SessionService(this._client.WithOptions(modifier)); }

    public SessionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SessionServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Sessions::ActionService(client)) ;
    }

    readonly Lazy<Sessions::IActionService> _actions;
    public Sessions::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<SessionRetrieveResponse> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SessionRetrieveResponse> Retrieve(
        string roomSessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionList0Page> List0(
        SessionList0Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List0(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SessionList1Page> List1(
        SessionList1Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List1(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SessionList1Page> List1(
        string roomID,
        SessionList1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List1(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionRetrieveParticipantsPage> RetrieveParticipants(
        SessionRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveParticipants(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SessionRetrieveParticipantsPage> RetrieveParticipants(
        string roomSessionID,
        SessionRetrieveParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveParticipants(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SessionServiceWithRawResponse : ISessionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SessionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(
            () => new Sessions::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Sessions::IActionServiceWithRawResponse> _actions;
    public Sessions::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionRetrieveResponse>> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomSessionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomSessionID' cannot be null"
            );
        }

        HttpRequest<SessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var session = await response.Deserialize<SessionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                session.Validate();
            }
            return session;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SessionRetrieveResponse>> Retrieve(
        string roomSessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionList0Page>> List0(
        SessionList0Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SessionList0Params> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SessionList0PageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SessionList0Page(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionList1Page>> List1(
        SessionList1Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomID' cannot be null"
            );
        }

        HttpRequest<SessionList1Params> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SessionList1PageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SessionList1Page(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SessionList1Page>> List1(
        string roomID,
        SessionList1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List1(parameters with{
            RoomID = roomID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionRetrieveParticipantsPage>> RetrieveParticipants(
        SessionRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomSessionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomSessionID' cannot be null"
            );
        }

        HttpRequest<SessionRetrieveParticipantsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SessionRetrieveParticipantsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SessionRetrieveParticipantsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SessionRetrieveParticipantsPage>> RetrieveParticipants(
        string roomSessionID,
        SessionRetrieveParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveParticipants(parameters with{
            RoomSessionID = roomSessionID
        }, cancellationToken);
    }
}