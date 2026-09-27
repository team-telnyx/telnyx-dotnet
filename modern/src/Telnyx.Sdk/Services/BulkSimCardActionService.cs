using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.BulkSimCardActions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BulkSimCardActionService : IBulkSimCardActionService
{
    readonly Lazy<IBulkSimCardActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBulkSimCardActionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBulkSimCardActionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BulkSimCardActionService(this._client.WithOptions(modifier)); }

    public BulkSimCardActionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BulkSimCardActionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BulkSimCardActionRetrieveResponse> Retrieve(
        BulkSimCardActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BulkSimCardActionRetrieveResponse> Retrieve(
        string id,
        BulkSimCardActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BulkSimCardActionListPage> List(
        BulkSimCardActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BulkSimCardActionServiceWithRawResponse : IBulkSimCardActionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBulkSimCardActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BulkSimCardActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BulkSimCardActionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BulkSimCardActionRetrieveResponse>> Retrieve(
        BulkSimCardActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<BulkSimCardActionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var bulkSimCardAction = await response.Deserialize<BulkSimCardActionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                bulkSimCardAction.Validate();
            }
            return bulkSimCardAction;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BulkSimCardActionRetrieveResponse>> Retrieve(
        string id,
        BulkSimCardActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BulkSimCardActionListPage>> List(
        BulkSimCardActionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BulkSimCardActionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<BulkSimCardActionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new BulkSimCardActionListPage(this, parameters, page);
        });
    }
}