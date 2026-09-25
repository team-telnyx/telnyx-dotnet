using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.OtaUpdates;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class OtaUpdateService : IOtaUpdateService
{
    readonly Lazy<IOtaUpdateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOtaUpdateServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOtaUpdateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new OtaUpdateService(this._client.WithOptions(modifier)); }

    public OtaUpdateService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OtaUpdateServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<OtaUpdateRetrieveResponse> Retrieve(
        OtaUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OtaUpdateRetrieveResponse> Retrieve(
        string id,
        OtaUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OtaUpdateListPage> List(
        OtaUpdateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OtaUpdateServiceWithRawResponse : IOtaUpdateServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOtaUpdateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OtaUpdateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OtaUpdateServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<OtaUpdateRetrieveResponse>> Retrieve(
        OtaUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OtaUpdateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var otaUpdate = await response.Deserialize<OtaUpdateRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                otaUpdate.Validate();
            }
            return otaUpdate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OtaUpdateRetrieveResponse>> Retrieve(
        string id,
        OtaUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OtaUpdateListPage>> List(
        OtaUpdateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OtaUpdateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<OtaUpdateListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new OtaUpdateListPage(this, parameters, page);
        });
    }
}