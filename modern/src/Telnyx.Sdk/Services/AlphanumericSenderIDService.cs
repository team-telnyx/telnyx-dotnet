using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AlphanumericSenderIDService : IAlphanumericSenderIDService
{
    readonly Lazy<IAlphanumericSenderIDServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAlphanumericSenderIDServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAlphanumericSenderIDService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AlphanumericSenderIDService(this._client.WithOptions(modifier));
    }

    public AlphanumericSenderIDService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AlphanumericSenderIDServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AlphanumericSenderIDCreateResponse> Create(
        AlphanumericSenderIDCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AlphanumericSenderIDRetrieveResponse> Retrieve(
        AlphanumericSenderIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AlphanumericSenderIDRetrieveResponse> Retrieve(
        string id,
        AlphanumericSenderIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AlphanumericSenderIDListPage> List(
        AlphanumericSenderIDListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AlphanumericSenderIDDeleteResponse> Delete(
        AlphanumericSenderIDDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AlphanumericSenderIDDeleteResponse> Delete(
        string id,
        AlphanumericSenderIDDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AlphanumericSenderIDServiceWithRawResponse : IAlphanumericSenderIDServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAlphanumericSenderIDServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AlphanumericSenderIDServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AlphanumericSenderIDServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AlphanumericSenderIDCreateResponse>> Create(
        AlphanumericSenderIDCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AlphanumericSenderIDCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var alphanumericSenderID = await response.Deserialize<AlphanumericSenderIDCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                alphanumericSenderID.Validate();
            }
            return alphanumericSenderID;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AlphanumericSenderIDRetrieveResponse>> Retrieve(
        AlphanumericSenderIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AlphanumericSenderIDRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var alphanumericSenderID = await response.Deserialize<AlphanumericSenderIDRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                alphanumericSenderID.Validate();
            }
            return alphanumericSenderID;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AlphanumericSenderIDRetrieveResponse>> Retrieve(
        string id,
        AlphanumericSenderIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AlphanumericSenderIDListPage>> List(
        AlphanumericSenderIDListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AlphanumericSenderIDListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AlphanumericSenderIDListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AlphanumericSenderIDListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AlphanumericSenderIDDeleteResponse>> Delete(
        AlphanumericSenderIDDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AlphanumericSenderIDDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var alphanumericSenderID = await response.Deserialize<AlphanumericSenderIDDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                alphanumericSenderID.Validate();
            }
            return alphanumericSenderID;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AlphanumericSenderIDDeleteResponse>> Delete(
        string id,
        AlphanumericSenderIDDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}