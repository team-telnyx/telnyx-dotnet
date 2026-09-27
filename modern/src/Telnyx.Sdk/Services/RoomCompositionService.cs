using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.RoomCompositions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RoomCompositionService : IRoomCompositionService
{
    readonly Lazy<IRoomCompositionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoomCompositionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRoomCompositionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RoomCompositionService(this._client.WithOptions(modifier)); }

    public RoomCompositionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RoomCompositionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RoomCompositionCreateResponse> Create(
        RoomCompositionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RoomCompositionRetrieveResponse> Retrieve(
        RoomCompositionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RoomCompositionRetrieveResponse> Retrieve(
        string roomCompositionID,
        RoomCompositionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomCompositionID = roomCompositionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoomCompositionListPage> List(
        RoomCompositionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        RoomCompositionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string roomCompositionID,
        RoomCompositionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            RoomCompositionID = roomCompositionID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RoomCompositionServiceWithRawResponse : IRoomCompositionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoomCompositionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RoomCompositionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoomCompositionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomCompositionCreateResponse>> Create(
        RoomCompositionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomCompositionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var roomComposition = await response.Deserialize<RoomCompositionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                roomComposition.Validate();
            }
            return roomComposition;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomCompositionRetrieveResponse>> Retrieve(
        RoomCompositionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomCompositionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomCompositionID' cannot be null"
            );
        }

        HttpRequest<RoomCompositionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var roomComposition = await response.Deserialize<RoomCompositionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                roomComposition.Validate();
            }
            return roomComposition;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RoomCompositionRetrieveResponse>> Retrieve(
        string roomCompositionID,
        RoomCompositionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomCompositionID = roomCompositionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomCompositionListPage>> List(
        RoomCompositionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomCompositionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RoomCompositionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RoomCompositionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RoomCompositionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomCompositionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomCompositionID' cannot be null"
            );
        }

        HttpRequest<RoomCompositionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string roomCompositionID,
        RoomCompositionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RoomCompositionID = roomCompositionID
        }, cancellationToken);
    }
}