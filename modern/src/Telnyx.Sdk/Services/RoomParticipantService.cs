using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.RoomParticipants;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RoomParticipantService : IRoomParticipantService
{
    readonly Lazy<IRoomParticipantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoomParticipantServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRoomParticipantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RoomParticipantService(this._client.WithOptions(modifier)); }

    public RoomParticipantService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RoomParticipantServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RoomParticipantRetrieveResponse> Retrieve(
        RoomParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RoomParticipantRetrieveResponse> Retrieve(
        string roomParticipantID,
        RoomParticipantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomParticipantID = roomParticipantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoomParticipantListPage> List(
        RoomParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RoomParticipantServiceWithRawResponse : IRoomParticipantServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoomParticipantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RoomParticipantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoomParticipantServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomParticipantRetrieveResponse>> Retrieve(
        RoomParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomParticipantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomParticipantID' cannot be null"
            );
        }

        HttpRequest<RoomParticipantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var roomParticipant = await response.Deserialize<RoomParticipantRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                roomParticipant.Validate();
            }
            return roomParticipant;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RoomParticipantRetrieveResponse>> Retrieve(
        string roomParticipantID,
        RoomParticipantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomParticipantID = roomParticipantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomParticipantListPage>> List(
        RoomParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomParticipantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RoomParticipantListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RoomParticipantListPage(this, parameters, page);
        });
    }
}