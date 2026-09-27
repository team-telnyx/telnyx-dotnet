using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MessagingNumbersBulkUpdates;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingNumbersBulkUpdateService : IMessagingNumbersBulkUpdateService
{
    readonly Lazy<IMessagingNumbersBulkUpdateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingNumbersBulkUpdateServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingNumbersBulkUpdateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingNumbersBulkUpdateService(this._client.WithOptions(modifier));
    }

    public MessagingNumbersBulkUpdateService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingNumbersBulkUpdateServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingNumbersBulkUpdateCreateResponse> Create(
        MessagingNumbersBulkUpdateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingNumbersBulkUpdateRetrieveResponse> Retrieve(
        MessagingNumbersBulkUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingNumbersBulkUpdateRetrieveResponse> Retrieve(
        string orderID,
        MessagingNumbersBulkUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            OrderID = orderID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MessagingNumbersBulkUpdateServiceWithRawResponse : IMessagingNumbersBulkUpdateServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingNumbersBulkUpdateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingNumbersBulkUpdateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingNumbersBulkUpdateServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingNumbersBulkUpdateCreateResponse>> Create(
        MessagingNumbersBulkUpdateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessagingNumbersBulkUpdateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingNumbersBulkUpdate = await response.Deserialize<MessagingNumbersBulkUpdateCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingNumbersBulkUpdate.Validate();
            }
            return messagingNumbersBulkUpdate;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingNumbersBulkUpdateRetrieveResponse>> Retrieve(
        MessagingNumbersBulkUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.OrderID' cannot be null"
            );
        }

        HttpRequest<MessagingNumbersBulkUpdateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingNumbersBulkUpdate = await response.Deserialize<MessagingNumbersBulkUpdateRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingNumbersBulkUpdate.Validate();
            }
            return messagingNumbersBulkUpdate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingNumbersBulkUpdateRetrieveResponse>> Retrieve(
        string orderID,
        MessagingNumbersBulkUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            OrderID = orderID
        }, cancellationToken);
    }
}