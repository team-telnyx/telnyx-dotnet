using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberReservations.Actions;

namespace Telnyx.Sdk.Services.NumberReservations;

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
    public async Task<ActionExtendResponse> Extend(
        ActionExtendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Extend(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionExtendResponse> Extend(
        string numberReservationID,
        ActionExtendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Extend(parameters with{
            NumberReservationID = numberReservationID
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
    public async Task<HttpResponse<ActionExtendResponse>> Extend(
        ActionExtendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberReservationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberReservationID' cannot be null"
            );
        }

        HttpRequest<ActionExtendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionExtendResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionExtendResponse>> Extend(
        string numberReservationID,
        ActionExtendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Extend(parameters with{
            NumberReservationID = numberReservationID
        }, cancellationToken);
    }
}