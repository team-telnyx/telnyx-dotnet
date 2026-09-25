using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberReservations;
using NumberReservations = Telnyx.Sdk.Services.NumberReservations;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NumberReservationService : INumberReservationService
{
    readonly Lazy<INumberReservationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberReservationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberReservationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumberReservationService(this._client.WithOptions(modifier)); }

    public NumberReservationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberReservationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new NumberReservations::ActionService(client)) ;
    }

    readonly Lazy<NumberReservations::IActionService> _actions;
    public NumberReservations::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<NumberReservationCreateResponse> Create(
        NumberReservationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NumberReservationRetrieveResponse> Retrieve(
        NumberReservationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberReservationRetrieveResponse> Retrieve(
        string numberReservationID,
        NumberReservationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberReservationID = numberReservationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberReservationListPage> List(
        NumberReservationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NumberReservationServiceWithRawResponse : INumberReservationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberReservationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberReservationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberReservationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new NumberReservations::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<NumberReservations::IActionServiceWithRawResponse> _actions;
    public NumberReservations::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberReservationCreateResponse>> Create(
        NumberReservationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberReservationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberReservation = await response.Deserialize<NumberReservationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberReservation.Validate();
            }
            return numberReservation;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberReservationRetrieveResponse>> Retrieve(
        NumberReservationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberReservationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberReservationID' cannot be null"
            );
        }

        HttpRequest<NumberReservationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberReservation = await response.Deserialize<NumberReservationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberReservation.Validate();
            }
            return numberReservation;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberReservationRetrieveResponse>> Retrieve(
        string numberReservationID,
        NumberReservationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberReservationID = numberReservationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberReservationListPage>> List(
        NumberReservationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberReservationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NumberReservationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NumberReservationListPage(this, parameters, page);
        });
    }
}