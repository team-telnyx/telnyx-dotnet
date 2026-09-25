using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ShortCodes;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ShortCodeService : IShortCodeService
{
    readonly Lazy<IShortCodeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IShortCodeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IShortCodeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ShortCodeService(this._client.WithOptions(modifier)); }

    public ShortCodeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ShortCodeServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ShortCodeRetrieveResponse> Retrieve(
        ShortCodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ShortCodeRetrieveResponse> Retrieve(
        string id,
        ShortCodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ShortCodeUpdateResponse> Update(
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ShortCodeUpdateResponse> Update(
        string id,
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ShortCodeListPage> List(
        ShortCodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ShortCodeServiceWithRawResponse : IShortCodeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IShortCodeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ShortCodeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ShortCodeServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ShortCodeRetrieveResponse>> Retrieve(
        ShortCodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ShortCodeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var shortCode = await response.Deserialize<ShortCodeRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                shortCode.Validate();
            }
            return shortCode;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ShortCodeRetrieveResponse>> Retrieve(
        string id,
        ShortCodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ShortCodeUpdateResponse>> Update(
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ShortCodeUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var shortCode = await response.Deserialize<ShortCodeUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                shortCode.Validate();
            }
            return shortCode;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ShortCodeUpdateResponse>> Update(
        string id,
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ShortCodeListPage>> List(
        ShortCodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ShortCodeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ShortCodeListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ShortCodeListPage(this, parameters, page);
        });
    }
}